import { Component } from '@angular/core';
import { CustomerService } from '../customer.service';  // Import the service
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { MatDialog, MatDialogModule } from '@angular/material/dialog'; // For dialog (if using modal)
import { CustomerEditDialog } from '../edit/customerEditDialog.component';

@Component({
  selector: 'app-customer-list',
  templateUrl: './customerList.component.html',
  styleUrls: ['./customerList.component.css'],
  standalone: true,  // Marking this as a standalone component
  imports: [ReactiveFormsModule, CommonModule, MatDialogModule], // Import ReactiveFormsModule and CommonModule directly here
})
export class CustomerListComponent {
  customerForm = new FormGroup({
    name: new FormControl('', [Validators.required]),
    email: new FormControl('', [Validators.required, Validators.email]),
    phoneNumber: new FormControl('', [Validators.required, Validators.pattern('^[0-9]+$')]),
  });

  customers: any[] = [];
  pageSize: number = 5;
  currentPage: number = 1;
  totalPages: number = 1; 
  hideId: boolean = true;

  constructor(private customerService: CustomerService, private dialog: MatDialog) {}

ngOnInit() {
  this.customerService.getAll().subscribe(
    response => {
      console.log('API Response:', response); 
      this.customers = response.data.customers;
      this.totalPages = Math.ceil(this.customers.length / this.pageSize);
      console.log( this.customers);
    },
    error => {
      console.error('Error fetching customers:', error);
      this.customers = []; 
      this.totalPages = 1; 
    }
  );
}


  getPagedCustomers() {
    const startIndex = (this.currentPage - 1) * this.pageSize;
    const endIndex = startIndex + this.pageSize;
    return this.customers.slice(startIndex, endIndex);
  }

  goToPage(page: number) {
    if (page >= 1 && page <= this.totalPages) {
      this.currentPage = page;
    }
  }

  
  removeCustomer(customer: any) {
    if (confirm('Are you sure you want to remove this customer?')) {
      this.customerService.removeCustomer(customer).subscribe(
        response => {
          if(response.isDeleted === true)
            window.location.reload();
        },
        error => {
          console.error('Error fetching customers:', error);
        }
      );
    }
  }

  editCustomer(customer: any) {
    console.log('Edit customer:', customer);
    const dialogRef = this.dialog.open(CustomerEditDialog, {
      data: customer,
    });
    dialogRef.afterClosed().subscribe(result => {
    
    });
  }

  isFirstPage() {
    return this.currentPage === 1;
  }

  isLastPage() {
    return this.currentPage === this.totalPages;
  }
}
