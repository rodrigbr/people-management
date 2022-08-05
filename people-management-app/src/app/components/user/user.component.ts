import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { SubscriptionCancel } from 'src/app/subsctiption-cancel';
import Swal from 'sweetalert2';
import { UserRead } from './models/user-read.model';
import { UserWrite } from './models/user-write.model';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.scss']
})

export class UserComponent extends SubscriptionCancel implements OnInit {

  public displayedColumns: string[] = ['id', 'firstName', 'lastName', 'email', 'birthDate', 'adress', 'city', 'uf', 'number', 'country', 'zipCode', 'schoolingTypeName', 'schoolRecordFormat', 'schoolRecordName', 'edit', 'remove'];

  @ViewChild('userModal', { static: true }) userModal: any;
  @Input() users: UserRead[];

  public showUserModal: boolean = false;
  public showSchollingModal: boolean = false;
  public showSchoolRecordModal: boolean = false;
  public userModalData: UserRead;

  constructor(
    private modalService: NgbModal,
  ) {
    super();
  }

  ngOnInit() {

  }

  toggle(){
    this.showUserModal = false;
    this.showSchollingModal = false;
    this.showSchoolRecordModal = false;
    this.userModalData = null;
  }

  showAddUser(user?: UserRead){
    this.userModalData = user;
    this.showUserModal = !this.showUserModal;
  }

  removeUser(){
    Swal.fire({
      title: 'Exclusão de usuário !',
      text: "Tem certeza que deseja excluir este usuário ?",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#FF0000',
      cancelButtonColor: '#6c757d',
      confirmButtonText: 'Excluir',
      cancelButtonText: 'Cancelar',
      customClass: {
        confirmButton: "swal2-confirm"
      }
    }).then((result) => {
      if (result.isConfirmed) {

      }
    });
  }

  showAddSchooling(user?: UserRead){
    this.userModalData = user;
    this.showSchollingModal = !this.showSchollingModal;
  }

  removeSchooling(){
    Swal.fire({
      title: 'Remoção da escolaridade !',
      text: "Tem certeza que deseja remover a escolaridade deste usuário ?",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#ff4c06',
      cancelButtonColor: '#6c757d',
      confirmButtonText: 'Remover',
      cancelButtonText: 'Cancelar',
      customClass: {
        confirmButton: "swal2-confirm"
      }
    }).then((result) => {
      if (result.isConfirmed) {

      }
    });
  }

  showAddSchoolRecord(user?: UserRead){
    this.userModalData = user;
    this.showSchoolRecordModal = !this.showSchoolRecordModal;
  }

  removeSchoolRecord(){
    Swal.fire({
      title: 'Remoção do histórico !',
      text: "Tem certeza que deseja remover o historico deste usuário ?",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#ff4c06',
      cancelButtonColor: '#6c757d',
      confirmButtonText: 'Remover',
      cancelButtonText: 'Cancelar',
      customClass: {
        confirmButton: "swal2-confirm"
      }
    }).then((result) => {
      if (result.isConfirmed) {

      }
    });
  }
}
