using ShoppingApp.Models;
using ShoppingApp.Repositories;
using System.Runtime.Serialization;

namespace ShoppingApp.Controllers
{
    [DataContract(IsReference = true)]
    public class PurchasesController : GenericController<Purchase>
    {
        public PurchasesController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
