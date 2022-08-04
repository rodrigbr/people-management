import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { SubscriptionCancel } from 'src/app/subsctiption-cancel';
import { UserRead } from './models/user-read.model';

export interface PeriodicElement {
  name: string;
  position: number;
  weight: number;
  symbol: string;
}

const ELEMENT_DATA: PeriodicElement[] = [
  { position: 1, name: 'Hydrogen', weight: 1.0079, symbol: 'H' },
  { position: 2, name: 'Helium', weight: 4.0026, symbol: 'He' },
  { position: 3, name: 'Lithium', weight: 6.941, symbol: 'Li' },
  { position: 4, name: 'Beryllium', weight: 9.0122, symbol: 'Be' },
  { position: 5, name: 'Boron', weight: 10.811, symbol: 'B' },
  { position: 6, name: 'Carbon', weight: 12.0107, symbol: 'C' },
  { position: 7, name: 'Nitrogen', weight: 14.0067, symbol: 'N' },
  { position: 8, name: 'Oxygen', weight: 15.9994, symbol: 'O' },
  { position: 9, name: 'Fluorine', weight: 18.9984, symbol: 'F' },
  { position: 10, name: 'Neon', weight: 20.1797, symbol: 'Ne' },
];

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.scss']
})

export class UserComponent extends SubscriptionCancel implements OnInit {

  public displayedColumns: string[] = ['id', 'firstName', 'lastName', 'email', 'birthDate', 'adress', 'city', 'uf', 'number', 'country', 'zipCode', 'schoolingTypeName', 'schoolRecordFormat', 'schoolRecordName', 'edit', 'remove'];

  @Input() users: UserRead[];

  constructor(
    private activatedRoute: ActivatedRoute,
  ) {
    super();
  }

  ngOnInit() {

  }

  addUser(){
    console.log("addUser");
  }

  editUser(){
    console.log("editUser");
  }

  removeUser(){
    console.log("removeUser");
  }

  addSchooling(){
    console.log("addSchooling");
  }

  removeSchooling(){
    console.log("removeSchooling");
  }

  addSchoolRecord(){
    console.log("addSchoolRecord");
  }

  removeSchoolRecord(){
    console.log("removeSchoolRecord");
  }
}
