import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-main-button',
  templateUrl: './main-button.component.html',
  styleUrls: ['./main-button.component.css']
})
export class MainButtonComponent {
  @Input() type:string = "button";
  @Input() value:string = ""
  @Input() backgroundColor = "var(--secondary-accent)"
  @Input() textColor = "var(--primary-white)"
  @Input() icon:string | undefined = undefined;
}
