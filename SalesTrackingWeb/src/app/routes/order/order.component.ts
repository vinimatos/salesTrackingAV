import { Component } from '@angular/core';
import { FormArray, FormControl, FormGroup, Validators } from '@angular/forms';
import { OrderService } from './order.service';
import { ProductService } from '../product/product.service';
import { CommonModule } from '@angular/common';
import { CustomerService } from '../customer/customer.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-order',
  standalone: true,
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css'],
  imports: [CommonModule, FormsModule, ReactiveFormsModule],
})
export class OrderComponent {
  orderForm: FormGroup;
  branchs: any[] = [];
  products: any[] = [];
  customers: any[] = [];

  constructor(
    private orderService: OrderService,
    private productService: ProductService,
    private customerService: CustomerService
  ) {
    this.orderForm = new FormGroup({
      customerId: new FormControl('', [Validators.required]),
      products: new FormArray([]), 
    });
  }

  ngOnInit() {
    this.productService.getAll().subscribe(
      (response) => {
        this.products = response.data.products;
        console.log(this.products);
      },
      (error) => {
        console.error('Error fetching products:', error);
      }
    );

    this.customerService.getAll().subscribe(
      (response) => {
        this.customers = response.data.customers;
      },
      (error) => {
        console.error('Error fetching products:', error);
      }
    );
  }

  get productsFormArray(): FormArray {
    return this.orderForm.get('products') as FormArray;
  }

  onCheckboxChange(event: Event, product: any) {
    const checkbox = event.target as HTMLInputElement;
    const productId = product.id;
  
    if (checkbox.checked) {
      const productGroup = new FormGroup({
        productId: new FormControl(productId),
        quantity: new FormControl(1, [Validators.required, Validators.min(1)]), 
      });
      this.productsFormArray.push(productGroup);
    } else {
      const index = this.productsFormArray.controls.findIndex(
        (control) => control.get('productId')?.value === productId
      );
      if (index !== -1) {
        this.productsFormArray.removeAt(index);
      }
    }
  }
  
  getProductQuantityControl(productId: number): FormControl {
    const productGroup = this.productsFormArray.controls.find(
      (control) => control.get('productId')?.value === productId
    ) as FormGroup;
    return productGroup ? (productGroup.get('quantity') as FormControl) : new FormControl(1);
  }
  
  isProductSelected(productId: number): boolean {
    return this.productsFormArray.controls.some(
      (control) => control.get('productId')?.value === productId
    );
  }

  addOrder() {
    const formValue = this.orderForm.value;
    const orderData = {
      customerId: formValue.customerId,
      orderItems: this.productsFormArray.value.map((product: any) => {
        console.log(product);
        return {
          productId: product.productId,
          quantity: product.quantity,
        };
      }),
    };

    console.log('Transformed Order Data:', orderData);

    this.orderService.add(orderData).subscribe(
      (response) => {
       alert('Order added successfully!');
        this.orderForm.reset();
        this.productsFormArray.clear();
      },
      (error) => {
        console.error('Error adding order:', error);
      }
    );
  }
}
