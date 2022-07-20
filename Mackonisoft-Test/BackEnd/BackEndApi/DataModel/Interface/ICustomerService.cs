using System.Collections.Generic;
using DataModel;

namespace DataModel
{
    public interface ICustomerService
    {
        bool AddCustomer(CustomerModel customer);
        List<CustomerModel> GetCustomerList();
    }
}
