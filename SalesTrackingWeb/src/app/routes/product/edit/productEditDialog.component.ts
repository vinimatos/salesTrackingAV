import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { FormGroup, FormControl, Validators, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ProductService } from '../product.service';

@Component({
  selector: 'app-product-edit-dialog',
  templateUrl: './productEditDialog.component.html',
  styleUrls: ['./productEditDialog.component.css'],
  standalone: true,  
  imports: [ReactiveFormsModule, CommonModule]
})
export class ProductEditDialog {
  editForm: FormGroup;

  constructor(
    public dialogRef: MatDialogRef<ProductEditDialog>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private productService: ProductService
  ) {
    console.log(data);
    this.editForm = new FormGroup({
      id: new FormControl(data.id),
      title: new FormControl(data.title, [Validators.required]),
      description: new FormControl(data.description, [Validators.required]),
      price: new FormControl(data.price, [Validators.required]),
      rate: new FormControl(data.rating.rate, [Validators.required]),
      count: new FormControl(data.rating.count, [Validators.required]),
    });
  }

  save() {
    const productData = {
      id: this.editForm.value.id,
      title: this.editForm.value.title,
      price: this.editForm.value.price,
      description: this.editForm.value.description,
      category: this.editForm.value.category || 'Uncategorized',
      image: this.editForm.value.image,
      ratings: {
        rate: this.editForm.value.rate,
        count: this.editForm.value.count
      }
    };
    if (this.editForm.valid) {
      console.log(productData);
      this.productService.editProduct(productData).subscribe(response => {
        
        alert('Product updated successfully:');
        this.dialogRef.close(productData);
      }, error => {
        console.error('Error updating customer:', error);
      });
    }
  }

  close() {
    this.dialogRef.close();
  }


  
}
