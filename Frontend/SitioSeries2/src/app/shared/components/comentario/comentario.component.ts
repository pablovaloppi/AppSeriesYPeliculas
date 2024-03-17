import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-comentario',
  templateUrl: './comentario.component.html',
  styleUrls: ['./comentario.component.css']
})
export class ComentarioComponent {
  @Input() imagenUser:string = "";
  @Input() nombreUsuario:string = "Usuario";
  @Input() fecha!:string | null;
  @Input() comentario:string = "Comentario";
}
