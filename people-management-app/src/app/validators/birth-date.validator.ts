import { FormControl } from '@angular/forms';
import { Injectable } from '@angular/core';

@Injectable()
export class BirthDateValidator {

  public static strength(): (control: FormControl) => object | null {
    return (control: FormControl): object | null => {
      const valid = this.hasDateIsGreaterToday(control.value);
      if (!valid) {
        return { dateValidated: true };
      }
      return null;
    };
  }

  public static hasDateIsGreaterToday(value: Date) : Boolean {
    if(value > new Date()){
      return true;
    }else{
      return false;
    }
  }
}
