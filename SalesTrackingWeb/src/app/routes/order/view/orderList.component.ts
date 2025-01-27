import { Component } from '@angular/core';
import { OrderService } from '../order.service';  // Import the service
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { MatDialog, MatDialogModule } from '@angular/material/dialog'; // For dialog (if using modal)
import { OrderEditDialog } from '../edit/orderEditDialog.component';

@Component({
  selector: 'app-order-list',
  templateUrl: './orderList.component.html',
  styleUrls: ['./orderList.component.css'],
  standalone: true,  // Marking this as a standalone component
  imports: [ReactiveFormsModule, CommonModule, MatDialogModule], // Import ReactiveFormsModule and CommonModule directly here
})
export class OrderListComponent {
  orderForm = new FormGroup({
    name: new FormControl('', [Validators.required]),
    email: new FormControl('', [Validators.required, Validators.email]),
    phoneNumber: new FormControl('', [Validators.required, Validators.pattern('^[0-9]+$')]),
  });

  orders: any[] = [];
  pageSize: number = 5; // Items per page
  currentPage: number = 1; // Current page
  totalPages: number = 1; // Total pages
  hideId: boolean = true;
  saleNumber: any;
  constructor(private orderService: OrderService, private dialog: MatDialog) { }

  ngOnInit() {
    this.orderService.getOrders().subscribe(
      response => {
        this.orders = response.data.items;
        this.totalPages = Math.ceil(this.orders.length / this.pageSize); // Recalculate total pages
      },
      error => {
        console.error('Error fetching orders:', error);
      }
    );
  }

  getPagedOrders() {
    const startIndex = (this.currentPage - 1) * this.pageSize;
    const endIndex = startIndex + this.pageSize;
    return this.orders.slice(startIndex, endIndex);
  }

  goToPage(page: number) {
    if (page >= 1 && page <= this.totalPages) {
      this.currentPage = page;
    }
  }

  editOrder(order: any) {
    const dialogRef = this.dialog.open(OrderEditDialog, {
      data: order,
    });
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        console.log('Edited order data:', result);
      }
    });
  }

  isFirstPage() {
    return this.currentPage === 1;
  }

  isLastPage() {
    return this.currentPage === this.totalPages;
  }
}
