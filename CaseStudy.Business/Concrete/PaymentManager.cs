using AutoMapper;
using CaseStudy.Business.Abstract;
using CaseStudy.Business.AbstractUnitOfWork;
using CaseStudy.Business.Result;
using CaseStudy.Data.Abstract;
using CaseStudy.Data.Concrete;
using CaseStudy.Dto.Cart;
using CaseStudy.Dto.Payment;
using CaseStudy.Dto.Product;
using CaseStudy.Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Business.Concrete
{
    public class PaymentManager : IPaymentManager
    {
        private readonly IProductManager _productManager;
        private readonly ICartManager _cartManager;
        private readonly IOrderManager _orderManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IRepository<Product> _productGenericManager;
        private readonly IMapper _mapper;
        public virtual IUnitOfWorkFactory UnitOfWorkFactory { get; }
        public PaymentManager(IUnitOfWorkFactory unitOfWorkFactory,
            IProductManager productManager,
            ICartManager cartManager,
            IOrderManager orderManager,
            UserManager<AppUser> userManager,
            IRepository<Product> productGenericManager,
            IMapper mapper)
        {
            UnitOfWorkFactory = unitOfWorkFactory;
            _productManager = productManager;
            _cartManager = cartManager;
            _orderManager = orderManager;
            _userManager = userManager;
            _productGenericManager = productGenericManager;
            _mapper = mapper;
        }

        public async Task<IResult> Payment(PaymentDto payment)
        {
            //Banka entegresyon metodu ile ilgili banka api'sine requestte bulunulur, dönen sonuca göre işlemlere devam edilir.
            return new SuccessResult();
        }

        public async Task<IResult> PaymentProcess(PaymentDto payment, int userID)
        {
            using var uow = await UnitOfWorkFactory.NewAsync();
            var cardProducts = await _cartManager.GetCartByUserID(userID);
            if (cardProducts.Data.Count <= 0)
            {
                return new ErrorResult(new List<string> { "Sepette ürün bulunamadı" }, "ProductDoesNotExist");
            }
            try
            {
                //satın alınan ürünlerin stok sayısı güncellemesi yapılır.
                var result = await _productManager.SetProductQuantity(cardProducts.Data);
                if (result.Success)
                {
                    var paymentResult = await Payment(payment);
                    if (paymentResult.Success)
                    {
                        //sepet temizlenir.
                        await _cartManager.RemoveCartByUserID(userID);

                        //kullanıcının siparişleri olarak eklenir.
                        await _orderManager.CreateOrderList(cardProducts.Data, userID);
                    }
                    await uow.CommitAsync();
                }
                else
                {
                    await uow.RollbackAsync();
                    return new ErrorResult(result.Message, result.Code);
                }
            }
            catch (Exception ex)
            {
                await uow.RollbackAsync();
                return new ErrorResult(new List<string> { "" }, "");
            }
            finally
            {
                uow.Dispose();
            }

            await NotifyUserViaEmail(cardProducts.Data, userID);
            return new SuccessResult();
        }

        private async Task<IResult> NotifyUserViaEmail(List<CartListDto> cardProducts, int userID)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userID.ToString());
                if (user == null)
                {
                    return new ErrorResult(new List<string> { "Aranılan user bulunamadı" }, "UserDoesNotExist");
                }
                string recipientEmail = user.Email!;
                string subject = "Siparişiniz oluşturuldu. Sipariş Detayları;";
                string body = $"<html>";

                foreach (var product in cardProducts)
                {
                    var productResult = await _productGenericManager.GetFirstByFilter(n => n.ProductID == product.ProductID);
                    body = body + $"<b>Ürün adı: </b>{productResult.Name} <br/><b>Adet: </b>{product.Quantity} <br/><b>Birim Fiyatı: </b>{productResult.Price} <br/><br/>";
                }
                body += "</html>";
                var rabbitMqSender = new RabbitMqSender("localhost", 5672, "guest", "guest", "email_queue");
                rabbitMqSender.SendEmailMessage(recipientEmail, subject, body);
                return new SuccessResult();
            }
            catch (Exception ex)
            {
                return new ErrorResult(new List<string> { "Beklenmeyen bir hata oluştu" }, "Failed");
            }
        }
    }
}
