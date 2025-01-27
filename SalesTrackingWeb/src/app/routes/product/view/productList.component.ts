import { Component } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { CustomerService } from '../../customer/customer.service';
import { ProductService } from '../product.service';
import { ProductEditDialog } from '../edit/productEditDialog.component';

@Component({
  selector: 'app-product-list',
  templateUrl: './productList.component.html',
  styleUrls: ['./productList.component.css'],
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule, MatDialogModule],
})
export class ProductListComponent {
  productForm = new FormGroup({
    name: new FormControl('', [Validators.required]),
    email: new FormControl('', [Validators.required, Validators.email]),
    phoneNumber: new FormControl('', [Validators.required, Validators.pattern('^[0-9]+$')]),
  });

  products: any[] = [];
  pageSize: number = 5; 
  currentPage: number = 1; 
  totalPages: number = 1; 
  hideId: boolean = true;

  constructor(private productService: ProductService, private dialog: MatDialog) { }

  ngOnInit() {
    this.productService.getAll().subscribe(
      response => {
        this.products = response.data.products;
        this.totalPages = Math.ceil(this.products.length / this.pageSize);
      },
      error => {
        console.error('Error fetching customers:', error);
      }
    );
  }


  getPagedProducts() {
    const startIndex = (this.currentPage - 1) * this.pageSize;
    const endIndex = startIndex + this.pageSize;
    return this.products.slice(startIndex, endIndex);
  }

  goToPage(page: number) {
    if (page >= 1 && page <= this.totalPages) {
      this.currentPage = page;
    }
  }

  editProduct(product: any) {
    const dialogRef = this.dialog.open(ProductEditDialog, {
      data: product,
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        console.log('Edited product data:', result);
      }
    });
  }

  removeProduct(product: any) {
    if (confirm('Are you sure you want to remove this product?')) {
      this.productService.removeProduct(product).subscribe(
        response => {
          if (response.isDeleted === true)
            window.location.reload();
        },
        error => {
          console.error('Error fetching customers:', error);
        }
      );
    }
  }
}
