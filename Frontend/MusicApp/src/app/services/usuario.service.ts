import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Usuario } from '../model/usuario';

@Injectable({
  providedIn: 'root',
})
export class UsuarioService {
  private url = 'https://localhost:7080/api/Usuario';

  constructor(private http: HttpClient) {}

  public autenticar(email: String, senha: String): Observable<Usuario> {
    return this.http.post<Usuario>(`${this.url}/Login`, {
      email: email,
      senha: senha,
    });
  }
}
