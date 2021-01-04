import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CreateUserComponent } from './components/create-user/create-user.component';
import { EditUserComponent } from './components/edit-user/edit-user.component';
import { ListUsersComponent } from './components/list-users/list-users.component';

const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: 'list-users' },
  { path: 'create-user', component: CreateUserComponent },
  { path: 'edit-user/:id', component: EditUserComponent },
  { path: 'list-users', component: ListUsersComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }