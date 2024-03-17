import { group } from "@angular/animations";
import { AbstractControl, ValidationErrors, ValidatorFn } from "@angular/forms";

export class MyValidators {

    static isInRange(a: number, b: number): ValidatorFn {
        return (control: AbstractControl): ValidationErrors | null => {
            let nro = parseInt(control.value);

            if (nro >= a && nro <= b) {
                return null;
            }
            return { isInRange: true };
        }
    }

    static isSamePassword(password:string, repeatPassword:string):ValidatorFn{
        return (control:AbstractControl):ValidationErrors | null =>{
            console.log(control.value);
            return (control.get(password)?.value === control.get(repeatPassword)?.value) ? null :{isSamePassword: true};
        }
    }
} 