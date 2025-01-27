import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { FormGroup, FormControl, Validators, ReactiveFormsModule } from '@angular/forms';
import { OrderService } from '../order.service';
import { BranchService } from '../../branch/branch.service';
import { CustomerService } from '../../customer/customer.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-order-edit-dialog',
  templateUrl: './orderEditDialog.component.html',
  styleUrls: ['./orderEditDialog.component.css'],
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule]
})
export class OrderEditDialog implements OnInit {
  editForm: FormGroup;
  branchs: any[] = [];
  customers: any[] = [];
  saleNumber: any;

  constructor(
    public dialogRef: MatDialogRef<OrderEditDialog>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private orderService: OrderService,
    private branchService: BranchService,
    private customerService: CustomerService
  ) {

    this.editForm = new FormGroup({
      id: new FormControl(data.id),
      saleNumber: new FormControl(data.id.slice(0, 2)),
      IsCancelled: new FormControl(data.isCancelled),
    });
  }

  ngOnInit() {
    this.saleNumber = this.data.id;
  }

  save() {
    if (this.editForm.valid) {
      const orderData = this.editForm.value;
      console.log('Order data to be saved:', orderData);
      this.orderService.edit(orderData).subscribe(
        (response) => {
          alert('Order updated successfully:');
          this.dialogRef.close(orderData);
          window.location.reload();
        },
        (error) => {
          console.error('Error updating order:', error);
        }
      );
    }
  }

  close() {
    this.dialogRef.close();
  }
}
