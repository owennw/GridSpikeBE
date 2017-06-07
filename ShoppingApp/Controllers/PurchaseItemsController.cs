using ShoppingApp.Models;
using ShoppingApp.Repositories;

namespace ShoppingApp.Controllers
{
    public class PurchaseItemsController : GenericController<PurchaseItem>
    {
        public PurchaseItemsController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
