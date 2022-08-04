import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UserResolver } from './components/user/guards/user.resolver';
import { HomeComponent } from './pages/home/home.component';
import { PageUserComponent } from './pages/user/page-user.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'users', component: PageUserComponent, resolve: { userList: UserResolver }}
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
