import { Component, OnInit, Output, ViewChild, EventEmitter, Input } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { takeUntil } from 'rxjs/operators';
import { SubscriptionCancel } from 'src/app/subsctiption-cancel';
import { UserService } from '../../services/user.service';
import { UserRead } from '../../models/user-read.model';
import { ValidationsFormService } from '../../services/validations-form.service';
import { SchoolingTypeStatic } from '../../models/statics/scholling-type.static';

@Component({
  selector: 'app-user-schooling-modal',
  templateUrl: './user-schooling-modal.component.html',
  styleUrls: ['./user-schooling-modal.component.scss']
})
export class UserSchoolingModalComponent extends SubscriptionCancel implements OnInit {

  @Input() user: UserRead;
  @Output() userSaved = new EventEmitter();

  public formSchooling: FormGroup;
  public errorMessage: string;
  public schoolingTypeStatic = SchoolingTypeStatic;

  constructor(private service: UserService,
    private formBuilder: FormBuilder,
    public validationsFormService: ValidationsFormService
  ) { super() }

  ngOnInit(): void {
    this.enableForm();
  }

  private enableForm() {
    this.formSchooling = this.formBuilder.group({
      id: [this.user != null ? this.user.schoolingId : null],
      userId: [this.user != null ? this.user.id : null, { validators: [Validators.required] }],
      schoolingTypeId: [this.user != null ? this.user.schoolingTypeId : null, { validators: [Validators.required] }]
    });
  }

  save() {
    if (this.formSchooling.valid) {
      if (this.formSchooling.valid) {
        if (!this.formSchooling.controls['id'].value) {
          this.formSchooling.controls['id'].setValue(undefined);
        }

        this.service.addSchoolingUser(this.formSchooling.value).pipe(takeUntil(this.destroy$)).subscribe((data) => {
          if (data) {
            this.userSaved.emit();
          }
        }, (error) => {
          this.errorMessage = error.message;
        });
      }
    }
  }
}
