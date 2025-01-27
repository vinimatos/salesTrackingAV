import { Component } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { BranchService } from './branch.service';
@Component({
  selector: 'app-branch',
  standalone: true,
  templateUrl: './branch.component.html',
  styleUrls: ['./branch.component.css'],
  imports: [ReactiveFormsModule],
})
export class BranchComponent {
  registerForm: any;
  constructor(private branchService: BranchService) { }
  showDashboard = false;

  branchForm = new FormGroup({
    name: new FormControl('', [Validators.required]),
    location: new FormControl('', [Validators.required]),
  });

  addBranch() {
    const branchData = this.branchForm.value;
    this.branchService.addBranch(branchData).subscribe(
      response => {
        alert('Branch added successfully!');
        // You can handle the response or reset the form here
        this.branchForm.reset();
      },
      error => {
        console.error('Error adding branch:', error);
        // Handle error (show a message, etc.)
      }
    );
  }
}
