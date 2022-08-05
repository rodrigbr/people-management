import { Component, OnInit, Output, ViewChild, EventEmitter, Input } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { takeUntil } from 'rxjs/operators';
import { SubscriptionCancel } from 'src/app/subsctiption-cancel';
import { UserService } from '../../services/user.service';
import { UserRead } from '../../models/user-read.model';
import { ValidationsFormService } from '../../services/validations-form.service';
import { primeNgConst } from 'src/app/constants/primeng-format-calendar';
import { BirthDateValidator } from 'src/app/validators/birth-date.validator';

@Component({
  selector: 'app-user-modal',
  templateUrl: './user-modal.component.html',
  styleUrls: ['./user-modal.component.scss']
})
export class UserModalComponent extends SubscriptionCancel implements OnInit {

  @ViewChild('contentUserModal', { static: true }) contentUserModal: any;
  @Input() user: UserRead;
  @Output() userSaved = new EventEmitter();

  public formUser: FormGroup;
  public errorMessage: string;
  public yesterday = new Date();
  public ptBr: object;
  public errors: string [];

constructor(private service: UserService,
    private formBuilder: FormBuilder,
    public validationsFormService: ValidationsFormService
    ) { super() }

  ngOnInit(): void {
    this.ptBr = primeNgConst;
    this.enableForm();
  }

  private enableForm() {
    const birthDateValidators = [Validators.required, BirthDateValidator.strength()];
    this.formUser = this.formBuilder.group({
      id:[this.user != null ? this.user.id : null],
      firstName:[this.user != null ? this.user.firstName : '', { validators: [Validators.required, Validators.maxLength(100)] }],
      email: [this.user != null ? this.user.email : '', { validators: [Validators.required, Validators.email, Validators.maxLength(100)] }],
      lastName: [this.user != null ? this.user.lastName : '', { validators: [Validators.required, Validators.maxLength(100)] }],
      birthDate: [this.user != null ? this.user.birthDate : null, { validators: birthDateValidators }],
      adress: [this.user != null ? this.user.adress : '', { validators: [Validators.required, Validators.maxLength(100)] }],
      city: [this.user != null ? this.user.city : '', { validators: [Validators.required, Validators.maxLength(100)] }],
      uf: [this.user != null ? this.user.uf : '', { validators: [Validators.required, Validators.maxLength(2)] }],
      zipCode: [this.user != null ? this.user.zipCode : '', { validators: [Validators.required, Validators.maxLength(9)] }],
      country: [this.user != null ? this.user.country : '', { validators: [Validators.required, Validators.maxLength(100)] }],
      number: [this.user != null ? this.user.number : null, { validators: [Validators.required] }]
    });
  }

  save() {
    if (this.formUser.valid) {
      if (this.formUser.controls['id'].value) {
        this.service.updateUser(this.formUser.value).pipe(takeUntil(this.destroy$)).subscribe((data) => {
          if (data) {
            this.userSaved.emit();
          }
        }, (error) => {
          this.errorMessage = error.message;
        });
      } else {
        this.formUser.controls['id'].setValue(undefined);
        this.service.createUser(this.formUser.value).pipe(takeUntil(this.destroy$)).subscribe((data) => {
          if (data) {            
            this.userSaved.emit();
          }
        }, (error) => {
          this.errorMessage = error.message;
          this.errors = error.error.errors.Messages;
        });
      }
    }
  }
}
