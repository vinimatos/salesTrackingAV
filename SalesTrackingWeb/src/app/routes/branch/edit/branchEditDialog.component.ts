import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { FormGroup, FormControl, Validators, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { BranchService } from '../branch.service';

@Component({
  selector: 'app-branch-edit-dialog',
  templateUrl: './branchEditDialog.component.html',
  styleUrls: ['./branchEditDialog.component.css'],
  standalone: true,  // Marking this as a standalone component
  imports: [ReactiveFormsModule, CommonModule]
})
export class BranchEditDialog {
  editForm: FormGroup;

  constructor(
    public dialogRef: MatDialogRef<BranchEditDialog>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private branchService: BranchService // Inject the service here
  ) {
    // Initialize the form with branch data
    this.editForm = new FormGroup({
      id: new FormControl(data.id),
      name: new FormControl(data.name, [Validators.required]),
      location: new FormControl(data.location, [Validators.required])
    });
  }

  save() {
    if (this.editForm.valid) {
      const branchData = this.editForm.value;
      console.log(branchData);
      this.branchService.editBranch(branchData).subscribe(response => {
        // Handle response from the service (e.g., show success message or close dialog)
        console.log('Prodct updated successfully:', branchData);
        this.dialogRef.close(branchData);
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
