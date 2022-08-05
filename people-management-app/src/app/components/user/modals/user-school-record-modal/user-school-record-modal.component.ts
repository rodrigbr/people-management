import { Component, OnInit, Output, ViewChild, EventEmitter, Input } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { takeUntil } from 'rxjs/operators';
import { SubscriptionCancel } from 'src/app/subsctiption-cancel';
import { UserService } from '../../services/user.service';
import { UserRead } from '../../models/user-read.model';
import { ValidationsFormService } from '../../services/validations-form.service';

@Component({
  selector: 'app-user-school-record-modal',
  templateUrl: './user-school-record-modal.component.html',
  styleUrls: ['./user-school-record-modal.component.scss']
})
export class UserSchoolRecordModalComponent extends SubscriptionCancel implements OnInit {

  @Input() user: UserRead;
  @Output() userSaved = new EventEmitter();

  public formSchoolRecord: FormGroup;
  public errorMessage: string;

  constructor(private service: UserService,
    private formBuilder: FormBuilder,
    public validationsFormService: ValidationsFormService
  ) { super() }

  ngOnInit(): void {
    this.enableForm();
  }

  private enableForm() {
    this.formSchoolRecord = this.formBuilder.group({
      id: [this.user != null ? this.user.schoolRecordId : null],
      userId: [this.user != null ? this.user.id : null, { validators: [Validators.required] }],
      format: [this.user != null ? this.user.schoolRecordFormat : '', { validators: [Validators.required, Validators.maxLength(100)] }],
      name: [this.user != null ? this.user.schoolRecordName : '', { validators: [Validators.required, Validators.maxLength(100)] }]
    });
  }

  save() {
    if (this.formSchoolRecord.valid) {
      if (!this.formSchoolRecord.controls['id'].value) {
        this.formSchoolRecord.controls['id'].setValue(undefined);
      }

      this.service.addSchoolRecordUser(this.formSchoolRecord.value).pipe(takeUntil(this.destroy$)).subscribe((data) => {
        if (data) {
          this.userSaved.emit();
        }
      }, (error) => {
        this.errorMessage = error.message;
      });
    }
  }
}
