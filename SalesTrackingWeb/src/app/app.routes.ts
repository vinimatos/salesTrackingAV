import { RedirectCommand, Router, Routes } from '@angular/router';
import { ProductComponent } from './routes/product/product.component';
import { HomeComponent } from './routes/home/home.component';
import { CustomerComponent } from './routes/customer/customer.component';
import { inject } from '@angular/core';
import { CustomerListComponent } from './routes/customer/view/customerList.component';
import { ProductListComponent } from './routes/product/view/productList.component';
import { OrderComponent } from './routes/order/order.component';
import { OrderListComponent } from './routes/order/view/orderList.component';
import { BranchComponent } from './routes/branch/branch.component';
import { BranchListComponent } from './routes/branch/view/branchList.component';
import { ReportComponent } from './routes/report/report.component';
import { DashboardComponent } from './routes/dashboard/dashboard.component';

export const routes: Routes = [
  { path: 'customer', component: CustomerComponent },
  { path: 'product', component: ProductComponent },
  { path: 'customer-list', component: CustomerListComponent },
  { path: 'product-list', component: ProductListComponent },
  { path: 'order', component: OrderComponent },
  { path: 'order-list', component: OrderListComponent },
  { path: 'branch', component: BranchComponent },
  { path: 'branch-list', component: BranchListComponent },
  { path: 'report', component: ReportComponent },
  { path: 'dashboard', component: DashboardComponent },

  {
    path: 'redirect',
    component: HomeComponent,
    canActivate: [
      () => {
        return new RedirectCommand(inject(Router).parseUrl('/error'), {
          skipLocationChange: false,
        });
      },
    ],
  },
];
