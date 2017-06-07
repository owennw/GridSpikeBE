using ShoppingApp.DTOs;
using ShoppingApp.Models;
using ShoppingApp.Repositories;

namespace ShoppingApp.Controllers
{
    public class PurchaseItemsController : GenericController<PurchaseItem, PurchaseItemDTO>
    {
        public PurchaseItemsController(IUnitOfWork unitOfWork) : base(unitOfWork, pi => new PurchaseItemDTO(pi))
        {
        }
    }
}
