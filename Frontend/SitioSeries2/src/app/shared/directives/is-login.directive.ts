import { Directive, Input, OnChanges, OnInit, SimpleChanges, TemplateRef, ViewContainerRef } from '@angular/core';
import { AuthService } from 'src/app/core/services/auth.service';

@Directive({
  selector: '[isLogin]'
})
export class IsLoginDirective implements OnInit, OnChanges {

  @Input() isLogin!: boolean;

  // @Input()
  // set appIsLogin(state: boolean){
  //   this.isLogin = state;
  //   console.log(`Estado de login: ${state}`)
  //   // Templateref hace referencia al componenete html donde esta puesto
  //   this.viewContainer.createEmbeddedView(this.templateRef)
  //   this.updateView();
  // }
  constructor(private templateRef: TemplateRef<any>,
    private viewContainerRef: ViewContainerRef, private authService:AuthService) { 
    }
  ngOnChanges(changes: SimpleChanges): void {
    console.log(`Change: ${changes['isLogin'].currentValue}`);
  }
 
    ngOnInit(): void {
    //console.log(this.isLogin);
    if(this.isLogin){
      this.updateView();  
    }
  }
  
    // ngOnChanges(changes: SimpleChanges): void {
    //   if(changes['isLogin'] && changes['isLogin'].previousValue != undefined){
    //     console.log(this.isLogin);
    //     this.updateView();
    //   }
  // }


  updateView() {
    this.viewContainerRef.clear();
    this.viewContainerRef.createEmbeddedView(this.templateRef);
  }


}
