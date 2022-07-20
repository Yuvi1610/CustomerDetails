import { Component, OnInit } from '@angular/core';
import { CustomerService } from '../_service/customer.service';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css']
})
export class CustomerComponent implements OnInit {
  form: any = {
    firstname: '',
    lastname: ''
  }

  customerList: any ;

  constructor(private customerservice: CustomerService) {
  }

  ngOnInit(): void {
    this.customerservice.getCustomerList().subscribe(
      res => {
        if (res.status == true) {
          this.customerList = res.data;
        }
        else{
          alert(res.exceptionMessage)
        }
      });
  }

  onSubmit(form:any) {
    this.customerservice.addCustomer(this.form).subscribe(
      res => {
        if (res.status == true) {
          this.customerList = res.data;
          form.resetForm();
        }
        else{
          alert(res.exceptionMessage)
        }
      });
  }
}
