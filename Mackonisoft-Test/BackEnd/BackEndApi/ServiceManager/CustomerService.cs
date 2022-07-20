using System;
using System.Collections.Generic;
using System.Text;
using DataModel;
using FileHandler;
using Newtonsoft.Json;

namespace ServiceManager
{
    public class CustomerService : ICustomerService
    {
        private readonly IFileOperation _fileHelper;
        public CustomerService(IFileOperation helper)
        {
            _fileHelper = helper;
        }

        public bool AddCustomer(CustomerModel customer)
        {
            var customers = CreateObject();
            customers.Add(customer);
            return _fileHelper.WriteFile(JsonConvert.SerializeObject(customers));
        }

        public List<CustomerModel> GetCustomerList()
        {
            return _fileHelper.ReadFile<CustomerModel>();
        }

        private List<CustomerModel> CreateObject()
        {
            var customers = GetCustomerList();
            if (customers == null)
                customers = new List<CustomerModel>();
            return customers;
        }
    }
}
