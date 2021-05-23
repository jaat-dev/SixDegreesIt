import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Respuesta } from '../Models/Response';
import { Usuario } from '../Models/Usuario';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {
  private myAppUrl = environment.AppUrl;
  private myApiUrl = 'api/Usuarios/'

  constructor(private http: HttpClient) { }

  getUsuarios(): Observable<Respuesta> {
    return this.http.get<Respuesta>(this.myAppUrl + this.myApiUrl);
  }

  deleteUsuario(id:number): Observable<Usuario> {
    return this.http.delete<Usuario>(this.myAppUrl + this.myApiUrl + id);
  }

  saveUsuario(usuario: Usuario): Observable<Usuario> {
    return this.http.post<Usuario>(this.myAppUrl + this.myApiUrl, usuario);
  }

  updateUsuario(id: number, usuario: Usuario): Observable<any> {
    return this.http.put(this.myAppUrl + this.myApiUrl + id, usuario);
  }
}
