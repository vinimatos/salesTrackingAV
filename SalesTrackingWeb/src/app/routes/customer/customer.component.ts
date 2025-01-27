import { Component } from '@angular/core';
import { CustomerService } from './customer.service';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css'],
  standalone: true,
  imports: [ReactiveFormsModule],
})
export class CustomerComponent {
  customerForm = new FormGroup({
    name: new FormControl('', [Validators.required]),
    email: new FormControl('', [Validators.required, Validators.email]),
    phone: new FormControl('', [Validators.required, Validators.pattern('^[0-9]+$')]),
    street: new FormControl('', [Validators.required]),
    phoneNumber: new FormControl('', [Validators.required]),
    number: new FormControl('', [Validators.required]),
    city: new FormControl('', [Validators.required]),
    zipCode: new FormControl('', [Validators.required])
  });

  customers: any[] = [];
  constructor(private customerService: CustomerService) { }

  addCustomer() {
    const customerData = {
      name: this.customerForm.value.name,
      email: this.customerForm.value.email,
      phoneNumber: this.customerForm.value.phoneNumber,
      address: {
        street: this.customerForm.value.street,
        number: this.customerForm.value.number,
        city: this.customerForm.value.city,
        zipCode: this.customerForm.value.zipCode,
      }
    };

    this.customerService.addCustomer(customerData).subscribe(
      response => {
       alert('Customer added successfully!');
        this.customerForm.reset();
      },
      error => {
        console.error('Error adding customer:', error);
      }
    );
  }

  ngOnInit() {

    this.customerService.getAll().subscribe(
      response => {
        console.log(response);
        this.customers = response;
      },
      error => {
        console.error('Error adding customer:', error);
      }
    );
  }

}