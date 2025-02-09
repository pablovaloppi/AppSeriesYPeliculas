import { Component, Input } from '@angular/core';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-input-text',
  templateUrl: './input-text.component.html',
  styleUrls: ['./input-text.component.css']
})
export class InputTextComponent {
  @Input() control!:FormControl;
  @Input() iconLeft:string = "../../../../../assets/images/icon-send.svg";
  @Input() iconRight:string = '';
  @Input() placeHolder:string = '';
  @Input() type:string = "text"
  @Input() value?:string | number = '';
}
