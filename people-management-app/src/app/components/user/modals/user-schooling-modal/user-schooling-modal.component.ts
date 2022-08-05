import { Component, OnInit, Output, ViewChild, EventEmitter, Input } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { takeUntil } from 'rxjs/operators';
import { NgbModal } from "@ng-bootstrap/ng-bootstrap";
import { SubscriptionCancel } from 'src/app/subsctiption-cancel';
import { UserService } from '../../services/user.service';
import { UserRead } from '../../models/user-read.model';

@Component({
  selector: 'app-user-schooling-modal',
  templateUrl: './user-schooling-modal.component.html',
  styleUrls: ['./user-schooling-modal.component.scss']
})
export class UserSchoolingModalComponent extends SubscriptionCancel implements OnInit {

  @Input() user: UserRead;

  public form: FormGroup;
  public errorMessage: string;

constructor(private service: UserService,
    private formBuilder: FormBuilder,
    private modalService: NgbModal,
    // public validationsFormService: ValidationsFormService
    ) { super() }

  ngOnInit(): void {
  }

  // private enableForm() {
  //   this.form = this.formBuilder.group({
  //     id:[this.journalist != null ? this.journalist.id : null],
  //     name:[this.journalist != null ? this.journalist.name : '', { validators: [Validators.required, Validators.maxLength(64)] }],
  //     email: [this.journalist != null ? this.journalist.email : '', { validators: [Validators.required, Validators.maxLength(128)] }],
  //     vehicle: [this.journalist != null ? this.journalist.vehicle : '', { validators: [Validators.required, Validators.maxLength(128)] }],
  //     authorized: [this.journalist != null ? this.journalist.authorized : false, { validators: [Validators.required] }],
  //     blocked: [this.journalist != null ? this.journalist.blocked : false, { validators: [Validators.required] }],
  //     imported: [this.journalist != null ? this.journalist.imported : false, { validators: [Validators.required] }],
  //     typeVehicleId: [this.journalist != null ? this.journalist.typeVehicleId : null],
  //     regionId: [this.journalist != null ? this.journalist.regionId : null]
  //   });
  // }

  save() {
    if (this.form.valid) {
      if (this.form.controls['id'].value) {
        // this.service.updateUser(this.form.value).pipe(takeUntil(this.destroy$)).subscribe((data) => {
        //   if (data) {
        //     this.journalistSaved.emit();
        //     this.close();
        //   }
        // }, (error) => {
        //   this.errorMessage = error.message;
        // });
      } else {
        this.form.controls['id'].setValue(undefined);
        // this.service.saveUser(this.form.value).pipe(takeUntil(this.destroy$)).subscribe((data) => {
        //   if (data) {
        //     this.journalistSaved.emit();
        //     this.close();
        //   }
        // }, (error) => {
        //   this.errorMessage = error.message;
        // });
      }
    }
  }
}
