using CaseStudy.Business.Result;
using CaseStudy.Dto.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Business.Abstract
{
    public interface IProductManager
    {
        Task<IResult> SetProductQuantity(List<int> cardProducts);
        Task<IDataResult<List<GetProductDto>>> GetProductsByIds(List<int> ids);
    }
}
