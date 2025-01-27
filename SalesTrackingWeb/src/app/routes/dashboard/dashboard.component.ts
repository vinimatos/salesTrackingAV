import { Component } from '@angular/core';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { DashboardService } from './dashboard.service';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { CommonModule } from '@angular/common';
import { MatSidenavModule } from '@angular/material/sidenav';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css'],
  standalone: true,
  imports: [ReactiveFormsModule,
    MatCardModule,
    MatButtonModule,
    CommonModule,
    FormsModule,
    MatSidenavModule,
    RouterModule],
})
export class DashboardComponent {
  constructor(private dashBoardService: DashboardService) { }
  dashboard: any;
  customers: number = 0;
  orders: number = 0;
  products: number = 0;
  showDashboard = false;

  ngOnInit() {
    console.log("teste");
    this.dashBoardService.getAll().subscribe(
      response => {
        this.dashboard = response.data;
        this.customers = this.dashboard.customers;
        this.orders = this.dashboard.orders;
        this.products = this.dashboard.products;
      },
      error => {
        console.error('Error adding customer:', error);
      }
    );
  }
}