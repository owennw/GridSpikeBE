using ShoppingApp.Models;

namespace ShoppingApp.Repositories
{
    public class CustomerRepository : Repository<Customer>
    {
        public CustomerRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public override void Add(Customer customer)
        {
            this.PreserveIntegrity(customer);

            base.Add(customer);
        }

        private void PreserveIntegrity(Customer customer)
        {
            if (customer.Purchases == null)
            {
                return;
            }

            foreach (var purchase in customer.Purchases)
            {
                purchase.Customer = customer;

                foreach (var purchaseItem in purchase.PurchaseItems)
                {
                    purchaseItem.Purchase = purchase;
                }
            }
        }
    }
}