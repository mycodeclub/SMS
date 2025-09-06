import { Routes } from '@angular/router';
import { HomeComponent } from './pages/home-component/home-component';
import { AboutComponent } from './pages/about-component/about-component';
import { ExpenseCategoriesComponent } from './pages/expense-categories-component/expense-categories-component';
import { ExpensePlanComponent } from './pages/expense-plan-component/expense-plan-component';
import { ExpensesComponent } from './pages/expenses-component/expenses-component';
import { LoginComponent } from './pages/login-component/login-component';
import { MonthlyIncomeComponent } from './pages/monthly-income-component/monthly-income-component';
import { NotFoundComponent } from './pages/not-found-component/not-found-component';
import { RegisterComponent } from './pages/register-component/register-component';
import { WishListComponent } from './pages/wish-list-component/wish-list-component';
import { DashboardComponentComponent } from './pages/dashboard-component/dashboard-component.component';

export const routes: Routes = [
    { path: '', component: HomeComponent },
    { path: 'about', component: AboutComponent },
    { path: 'register', component: RegisterComponent },
    { path: 'login', component: LoginComponent },
    { path: 'dashboard', component: DashboardComponentComponent },
    { path: 'monthly-income', component: MonthlyIncomeComponent },
    { path: 'expense-categories', component: ExpenseCategoriesComponent },
    { path: 'expense-plan', component: ExpensePlanComponent },
    { path: 'expenses', component: ExpensesComponent },
    { path: 'wish-list', component: WishListComponent },
    { path: '**', component: NotFoundComponent }

];
