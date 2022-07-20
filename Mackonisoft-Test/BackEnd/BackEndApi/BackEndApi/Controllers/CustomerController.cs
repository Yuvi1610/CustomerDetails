using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEndApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: api/Customer
        [HttpGet("GetCustomerList")]
        public ResponseModel<List<CustomerModel>> GetCustomerList()
        {
            ResponseModel<List<CustomerModel>> response = new ResponseModel<List<CustomerModel>>();
            try
            {
                response.Data = _customerService.GetCustomerList();
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.ExceptionMessage = ex.Message;
            }
            return response;
            
        }

        // POST: api/Customer
        [HttpPost("AddCustomer")]
        public ResponseModel<List<CustomerModel>> AddCustomer(CustomerModel customerModel)
        {
            ResponseModel<List<CustomerModel>> response = new ResponseModel<List<CustomerModel>>();
            try
            {
                response.Status = _customerService.AddCustomer(customerModel);
                response.Data = _customerService.GetCustomerList();
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.ExceptionMessage = ex.Message;
            }
            return response;
        }
    }
}
