import { Component, Input, OnInit } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';
import { takeUntil } from 'rxjs';
import { SubscriptionCancel } from 'src/app/subsctiption-cancel';
import Swal from 'sweetalert2';
import { UserQuery } from './models/user-query.model';
import { UserRead } from './models/user-read.model';
import { UserService } from './services/user.service';
import jspdf from 'jspdf';
import html2canvas from 'html2canvas';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.scss']
})

export class UserComponent extends SubscriptionCancel implements OnInit {

  public displayedColumns: string[] = ['id', 'refId', 'firstName', 'lastName', 'email', 'birthDate', 'adress', 'city', 'uf', 'number', 'country', 'zipCode', 'schoolingTypeName', 'schoolRecordFormat', 'schoolRecordName', 'edit', 'remove'];

  @Input() users: UserRead[];

  public showUserModal: boolean = false;
  public showSchollingModal: boolean = false;
  public showSchoolRecordModal: boolean = false;
  public userModalData: UserRead;
  public userQuery = new UserQuery();
  public errorMessage: string;

  // MatPaginator Inputs
  length = 100;
  pageSize = 10;
  pageSizeOptions: number[] = [5, 10, 25, 100];

  // MatPaginator Output
  pageEvent: PageEvent;

  constructor(
    private service: UserService
  ) {
    super();
  }

  ngOnInit() {
    this.resetPagination();
  }

  resetPagination() {
    this.userQuery.pageIndex = 1;
    this.userQuery.pageSize = 10;
  }

  handlePageEvent(event: PageEvent) {
    this.length = event.length;
    this.userQuery.pageSize = event.pageSize;
    this.userQuery.pageIndex = event.pageIndex;
    this.getList();
  }

  getRenewList() {
    this.toggle();
    this.resetPagination();
    this.getList();
  }

  getList() {
    this.service.getList(this.userQuery).pipe(takeUntil(this.destroy$)).subscribe((data) => {
      if (data) {
        this.users = data;
      }
    }, (error) => {
      this.errorMessage = error.message;
    });
  }

  toggle() {
    this.showUserModal = false;
    this.showSchollingModal = false;
    this.showSchoolRecordModal = false;
    this.userModalData = null;
  }

  showAddUser(user?: UserRead) {
    this.userModalData = user;
    this.showUserModal = !this.showUserModal;
  }

  removeUser(user: UserRead) {
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
        this.service.deleteUser(user.id).pipe(takeUntil(this.destroy$)).subscribe((data) => {
          if (data) {
            this.getRenewList();
          }
        }, (error) => {
          this.errorMessage = error.message;
        });
      }
    });
  }

  showAddSchooling(user?: UserRead) {
    this.userModalData = user;
    this.showSchollingModal = !this.showSchollingModal;
  }

  removeSchooling(user: UserRead) {
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
        this.service.removeSchoolingUser(user.id).pipe(takeUntil(this.destroy$)).subscribe((data) => {
          if (data) {
            this.getRenewList();
          }
        }, (error) => {
          this.errorMessage = error.message;
        });
      }
    });
  }

  showAddSchoolRecord(user?: UserRead) {
    this.userModalData = user;
    this.showSchoolRecordModal = !this.showSchoolRecordModal;
  }

  removeSchoolRecord(user: UserRead) {
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
        this.service.removeSchoolRecordUser(user.id).pipe(takeUntil(this.destroy$)).subscribe((data) => {
          if (data) {
            this.getRenewList();
          }
        }, (error) => {
          this.errorMessage = error.message;
        });
      }
    });
  }

  public captureScreen() {
    const contentPage1 = document.getElementById('contentPage1');

    let pdf = new jspdf('l', 'mm', 'a4');
    const position = 0;
    const scale = 2;
    const quality = 3.0;
    const margin = 0;
    const imgWidth = 320;
    const imgHeight = 200
    ;

    html2canvas(contentPage1, { allowTaint: true, scale: scale }).then(canvas => {
      const contentDataURLPage1 = canvas.toDataURL('image/jpeg', quality);
      pdf.addImage(contentDataURLPage1, 'JPG', margin, position, imgWidth, imgHeight);
      pdf.save("a4.pdf");
    });

  }
}
