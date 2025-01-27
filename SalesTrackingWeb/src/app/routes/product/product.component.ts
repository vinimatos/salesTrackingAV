import { Component } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ProductService } from './product.service';

@Component({
  selector: 'app-product',
  standalone: true,
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css'],
  imports: [ReactiveFormsModule],
})
export class ProductComponent {
  productForm: FormGroup;
  result: any;
  constructor(private productService: ProductService) {
    this.productForm = new FormGroup({
      title: new FormControl('', [Validators.required]),
      price: new FormControl('', [Validators.required, Validators.min(0)]),
      description: new FormControl('', [Validators.required]),
      rate: new FormControl('', [Validators.required, Validators.min(0), Validators.max(5)]),
      image: new FormControl(''),
      count: new FormControl('', [Validators.required]),
    });
  }

  addProduct() {
    const productData = {
      title: this.productForm.value.title,
      price: this.productForm.value.price,
      description: this.productForm.value.description,
      category: this.productForm.value.category || 'Uncategorized',
      image: this.productForm.value.image,
      ratings: {
        rate: this.productForm.value.rate,
        count: this.productForm.value.count
      }
    };

    console.log('Product Data:', productData);


    this.result = this.productService.addProduct(productData);

    console.log(this.result);
    this.productService.addProduct(productData).subscribe(
      response => {
        alert('Product added successfully!');
        this.productForm.reset({
          title: '',
          price: '',
          description: '',
          category: '',
          image: '',
          rate: '',
          count: ''
        });
      },
      error => {
        console.error('Error adding product:', error);
        alert('An error occurred while adding the product. Please try again.');
      }
    );
  }
}
