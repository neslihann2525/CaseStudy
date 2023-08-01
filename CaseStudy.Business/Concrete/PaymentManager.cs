using CaseStudy.Business.Abstract;
using CaseStudy.Business.AbstractUnitOfWork;
using CaseStudy.Business.Result;
using CaseStudy.Data.Abstract;
using CaseStudy.Data.Concrete;
using CaseStudy.Dto.Payment;
using CaseStudy.Dto.Product;
using CaseStudy.Entities.Models;
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
        private readonly IRepository<Product> _productGenericManager;
        public virtual IUnitOfWorkFactory UnitOfWorkFactory { get; }
        public PaymentManager(IUnitOfWorkFactory unitOfWorkFactory,
            IProductManager productManager,
            ICartManager cartManager,
            IOrderManager orderManager,
            IRepository<Product> productGenericManager)
        {
            UnitOfWorkFactory = unitOfWorkFactory;
            _productManager = productManager;
            _cartManager = cartManager;
            _orderManager = orderManager;
            _productGenericManager = productGenericManager;
        }

        public async Task<IResult> Payment(PaymentDto payment)
        {
            //Banka entegresyon metodu ile ilgili banka api'sine requestte bulunulur, dönen sonuca göre işlemlere devam edilir.
            return new SuccessResult();
        }

        public async Task<IResult> PaymentProcess(List<ProductAddDto> cardProducts, PaymentDto payment, int userID)
        {
            using var uow = await UnitOfWorkFactory.NewAsync();
            try
            {
                //satın alınan ürünlerin stok sayısı güncellemesi yapılır.
                await _productManager.SetProductQuantity(cardProducts.Select(n => n.ProductID).ToList
                    ());

                var paymentResult = await Payment(payment);
                if (paymentResult.Success)
                {
                    //sepet temizlenir.
                    await _cartManager.RemoveCartByUserID(userID);

                    //kullanıcının siparişleri olarak eklenir.
                    await _orderManager.CreateOrderList(cardProducts, userID);
                }

                await uow.CommitAsync();
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

            await NotifyUserViaEmail(cardProducts);
            return new SuccessResult();
        }

        private async Task NotifyUserViaEmail(List<ProductAddDto> cardProducts)
        {
            string recipientEmail = "info@kafein.com.tr";
            string subject = "Siparişiniz oluşturuldu. Sipariş Detayları;";
            string body = $"";

            foreach (var product in cardProducts)
            {
                var productResult = await _productGenericManager.GetFirstByFilter(n => n.ProductID == product.ProductID);
                body = body + $"Ürün adı: {productResult.Name} Adet: {product.Quantity} Birim Fiyatı: {productResult.Price} \n";
            }

            var rabbitMqSender = new RabbitMqSender("localhost", 5672, "guest", "guest", "email_queue");
            rabbitMqSender.SendEmailMessage(recipientEmail, subject, body);
        }
    }
}
