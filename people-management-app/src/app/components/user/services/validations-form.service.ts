import { Injectable } from "@angular/core";
import { FormGroup, FormArray } from "@angular/forms";

@Injectable()
export class ValidationsFormService {
    public verifyInputValidTouched(form: FormGroup, field: string) {
        return !form.get(field).valid && form.get(field).touched;
    }

    public applyCssErro(form: FormGroup, field: string) {
        return this.verifyInputValidTouched(form, field) ? 'is-invalid' : '';
    }

    public verifyValidForm(form: FormGroup) {
        Object.keys(form.controls).forEach(field => {
            let control = form.get(field);
            control.markAsTouched();
            if (control instanceof FormGroup)
                this.verifyValidForm(control);
            else if (control instanceof FormArray) {
                for (let controlOfArray of control.controls) {
                    this.verifyValidForm(<FormGroup>controlOfArray);
                }
            }
        });
    }  
}