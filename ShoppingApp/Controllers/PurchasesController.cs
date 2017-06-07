using ShoppingApp.Models;
using System.Runtime.Serialization;

namespace ShoppingApp.Controllers
{
    [DataContract(IsReference = true)]
    public class PurchasesController : GenericController<Purchase>
    {
    }
}
