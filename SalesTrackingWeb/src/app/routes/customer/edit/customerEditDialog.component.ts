import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { FormGroup, FormControl, Validators, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { CustomerService } from '../customer.service';

@Component({
  selector: 'app-costumer-edit-dialog',
  templateUrl: './customerEditDialog.component.html',
  styleUrls: ['./customerEditDialog.component.css'],
  standalone: true,  // Marking this as a standalone component
  imports: [ReactiveFormsModule, CommonModule]
})
export class CustomerEditDialog {
  editForm: FormGroup;

  constructor(
    public dialogRef: MatDialogRef<CustomerEditDialog>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private customerService: CustomerService // Inject the service here
  ) {
    // Initialize the form with customer data
    this.editForm = new FormGroup({
      id: new FormControl(data.id),
      name: new FormControl(data.name, [Validators.required]),
      email: new FormControl(data.email, [Validators.required, Validators.email]),
      phoneNumber: new FormControl(data.phoneNumber, [Validators.required, Validators.pattern('^[0-9]+$')]),
    });
  }

  save() {
    if (this.editForm.valid) {
      const customerData = this.editForm.value;
      this.customerService.editCustomer(customerData).subscribe(response => {
        // Handle response from the service (e.g., show success message or close dialog)
        console.log('Customer updated successfully:', customerData);
        this.dialogRef.close(customerData);
      }, error => {
        // Handle error (e.g., show error message)
        console.error('Error updating customer:', error);
      });
    }
  }

  close() {
    this.dialogRef.close();
  }
}
