using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using ShoppingApp.Models;

namespace ShoppingApp.Hubs
{
    [HubName("customerHub")]
    public class CustomerHub : Hub
    {
        public void Add(Customer customer)
        {
            Clients.All.addCustomer(customer);
        }

        public void Delete(Customer customer)
        {
            Clients.All.deleteCustomer(customer);
        }
    }
}