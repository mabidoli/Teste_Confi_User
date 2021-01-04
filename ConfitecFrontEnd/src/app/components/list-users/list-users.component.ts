import { UserModel } from '../../shared/user.model';
import { UserService } from '../../shared/user.service';
import { Component, ViewChild, OnInit } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-list-users',
  templateUrl: './list-users.component.html',
  styleUrls: ['./list-users.component.css']
})

export class ListUsersComponent implements OnInit {
  users: any = [];
  dataSource: MatTableDataSource<UserModel>;
  @ViewChild(MatPaginator, { static: false }) paginator: MatPaginator;
  displayedColumns: string[] = ['id', 'firstName', 'lastName', 'emailAddress', 'birthDate' , 'action'];

  constructor(private userService: UserService) {
    this.userService.GetUsers().subscribe(data => {
      console.log(`data: ${data}`);
      this.users = data;
      this.dataSource = new MatTableDataSource<UserModel>(this.users);
      setTimeout(() => {
        this.dataSource.paginator = this.paginator;
      }, 0);
    })    
  }

  ngOnInit() { }

  deleteUser(index: number, e){
    if(window.confirm(`Tem certeza que deseja deletar o Usuário? \n${e.firstName} ${e.lastName}`)) {
      const data = this.dataSource.data;
      data.splice((this.paginator.pageIndex * this.paginator.pageSize) + index, 1);
      this.dataSource.data = data;
      this.userService.DeleteUser(e.id).subscribe()
    }
  }
}
