import { Component } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { MatDialog, MatDialogModule } from '@angular/material/dialog'; // For dialog (if using modal)
import { BranchEditDialog } from '../edit/branchEditDialog.component';
import { BranchService } from '../branch.service';

@Component({
  selector: 'app-branch-list',
  templateUrl: './branchList.component.html',
  styleUrls: ['./branchList.component.css'],
  standalone: true,  // Marking this as a standalone component
  imports: [ReactiveFormsModule, CommonModule, MatDialogModule], // Import ReactiveFormsModule and CommonModule directly here
})
export class BranchListComponent {
  customerForm = new FormGroup({
    name: new FormControl('', [Validators.required]),
    location: new FormControl('', [Validators.required]),
  });

  branchs: any[] = [];
  pageSize: number = 5; // Items per page
  currentPage: number = 1; // Current page
  totalPages: number = 1; // Total pages
  hideId: boolean = true;
  success: any = false;
  constructor(private branchService: BranchService, private dialog: MatDialog) { }

  ngOnInit() {
    this.branchService.getAll().subscribe(
      response => {
        this.branchs = response.branchs;
        this.totalPages = Math.ceil(this.branchs.length / this.pageSize); // Recalculate total pages
      },
      error => {
        console.error('Error fetching branchs:', error);
      }
    );
  }

  // Get the branchs for the current page
  getPagedBranchs() {
    const startIndex = (this.currentPage - 1) * this.pageSize;
    const endIndex = startIndex + this.pageSize;
    return this.branchs.slice(startIndex, endIndex);
  }

  // Navigate to the next page
  goToPage(page: number) {
    if (page >= 1 && page <= this.totalPages) {
      this.currentPage = page;
    }
  }

  removeBranch(branch: any) {
    if (confirm('Are you sure you want to remove this branch?')) {
      this.branchService.removeBranch(branch).subscribe(
        response => {
          if(response.isDeleted === true)
            window.location.reload();
        },
        error => {
          console.error('Error fetching branches:', error);
        }
      );
    }
  }
  
  // Edit customer function
  editBranch(customer: any) {
    console.log('Edit customer:', customer);
    // You can implement inline editing, open a modal dialog, or navigate to an edit page
    // Example of opening an edit dialog using Angular Material Dialog (optional)
    const dialogRef = this.dialog.open(BranchEditDialog, {
      data: customer,
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        // Update customer data if necessary after editing
        console.log('Edited customer data:', result);
      }
    });
  }

  // Check if the current page is the first page
  isFirstPage() {
    return this.currentPage === 1;
  }

  // Check if the current page is the last page
  isLastPage() {
    return this.currentPage === this.totalPages;
  }
}
