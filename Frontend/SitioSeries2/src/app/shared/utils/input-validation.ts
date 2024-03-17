import { FormGroup } from "@angular/forms";

export class InputValidation {

    
    form!: FormGroup;
    constructor(){
        
    }

    setFormGroup(form:FormGroup){
        this.form = form;
    }
    isRequired(key: string): boolean {
        if(!this.form){
            console.log("El formgroup es null");
        }
        
        return this.form.get(key)?.errors?.['required'];
    }

    isCorrectLength(key:string):boolean{
        if(!this.form){
            console.log("El formgroup es null");
        }
        console.log( `Errores: ${this.form.get(key)?.errors?.['minlength']}` );
        return this.form.get(key)?.errors?.['minlength'];
      }
      isCorrectEmail(key:string):boolean{
        if(!this.form){
            console.log("El formgroup es null");
        }
        return this.form.get(key)?.errors?.['email'];
      }
    
      isCheck(key:string):boolean{
        if(!this.form){
            console.log("El formgroup es null");
        }
        return this.isRequired(key);
      }
}