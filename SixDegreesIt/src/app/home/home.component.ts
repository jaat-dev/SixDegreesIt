import { Component, OnInit } from '@angular/core';
import { Respuesta } from '../Models/Response';
import { Usuario } from '../Models/Usuario';
import { UsuarioService } from '../services/usuario.service';
import { ToastrService } from 'ngx-toastr';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  listUsuarios: Usuario[] = [];
  estado: boolean = false;
  form: FormGroup;
  id: number | undefined;

  constructor(
    private _usuarioService: UsuarioService, 
    private toastr: ToastrService,
    private modal:NgbModal,
    private formBuilder: FormBuilder) {
      this.form = this.formBuilder.group({
        nombre: ['', Validators.required, Validators.maxLength(100)],
        apellido: ['', Validators.required, Validators.maxLength(100)]
      });
    }

  ngOnInit(): void {
    this.estado = false;
  }

  mostrar() {
    this.estado = !this.estado;
    this.obtenerUsuarios();
  }

  obtenerUsuarios() {
    this._usuarioService.getUsuarios().subscribe(
      (data:Respuesta) => {
        var {result} = data     
        this.listUsuarios = result
        console.log(this.listUsuarios)   
      }, 
      error => {
        console.log(error);
      }
    );
  }

  eliminarUsuario(id: number) {
    this._usuarioService.deleteUsuario(id).subscribe(
      () => {
        this.toastr.error('Usuario eliminado con exito!', 'Tarjeta Eliminada!');
        this.obtenerUsuarios();
      }, 
      error => {
        console.log(error);
      }
    );
  }

  showForm(contenido: any) {
    this.modal.open(contenido, {
      centered:true,
      size: 'sm',
      backdrop: 'static',
      keyboard: false
    });
  }

  guardarUsuario() {
    const usuario:Usuario = {
      usuId: this.id === undefined ? 0 : this.id,
      nombre: this.form.get('nombre')?.value,
      apellido: this.form.get('apellido')?.value,
    }

    if (this.id === undefined) {      
      this._usuarioService.saveUsuario(usuario)
      .subscribe(
        () => {
          this.toastr.success('La tarjeta fue registrada con exito!', 'Error');
          this.obtenerUsuarios();
          this.form.reset();
        }, 
        error => {
          this.toastr.error('Opss... Ocurrio un error', 'Tarjeta Eliminada!');
          console.log(error);
        }
      );
    }
    else 
    {
      this._usuarioService.updateUsuario(this.id, usuario)
        .subscribe(
          () => {
            this.form.reset();
            this.id = undefined;
            this.toastr.info('La tarjeta fue actualizada con exito!', 'Tarjeta Actualizada');
            this.obtenerUsuarios();
          }, 
          error => {
            console.log(error);
          }
        )
    }
  }
}
