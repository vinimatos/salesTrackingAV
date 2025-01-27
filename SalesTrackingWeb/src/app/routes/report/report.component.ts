import { Component } from '@angular/core';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { ReportService } from './report.service';

@Component({
  selector: 'app-report',
  templateUrl: './report.component.html',
  styleUrls: ['./report.component.css'],
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule, MatDialogModule, FormsModule],
})
export class ReportComponent {
  // Initialize the form with empty fields
  reportForm = new FormGroup({
    customerName: new FormControl(''),
    dateSale: new FormControl(''),
  });

  reports: Array<any> = [];
  show: boolean = false;
  total: number = 0;

  constructor(private reportService: ReportService, private dialog: MatDialog) { }

  getReport() {
    const reportForm = this.reportForm.value;
    if (reportForm.dateSale == "") {
      reportForm.dateSale = null;
    }
    this.reportService.getReport(reportForm).subscribe(
      (response: any) => {
        if (response?.data?.items && Array.isArray(response.data.items)) {
          this.reports = response.data.items;
          this.show = this.reports.length > 0;
          this.total = 0;

          this.total = this.reports.reduce((sum: number, item: any) => {
            return sum + (item.product?.price || 0);
          }, 0);

          console.log('Total Price:', this.total);
        } else {
          console.error('Unexpected response structure:', response);
          this.reports = [];
          this.show = false;
          this.total = 0;
        }

        this.reportForm.reset();
      },
      (error) => {
        console.error('Error fetching report:', error);
        this.reports = [];
        this.show = false;
        this.total = 0;
      }
    );
  }
}
