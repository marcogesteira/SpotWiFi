import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Playlist, Usuario } from '../model/usuario';

@Injectable({
  providedIn: 'root',
})
export class UsuarioService {
  private url = 'https://localhost:7280/connect/token';

  constructor(private http: HttpClient) {}

  public autenticar(email: string, senha: string): Observable<any> {
    let body = new URLSearchParams();
    body.set('username', email);
    body.set('password', senha);
    body.set('client_id', 'client-angular-spotiWiFi');
    body.set('client_secret', 'SpotiWiFiSecret');
    body.set('grant_type', 'password');
    body.set('scope', 'SpotiWiFiScope');

    let options = {
      headers: new HttpHeaders().set(
        'Content-Type',
        'application/x-www-form-urlencoded'
      ),
    };

    return this.http.post(`${this.url}`, body.toString(), options);
  }

  public adicionarMusicaPlaylist(
    idPlaylist: String,
    nomeMusica: String
  ): Observable<Playlist> {
    return this.http.post<Playlist>(
      `${this.url}/playlist?idPlaylist=${idPlaylist}`,
      {
        nomeMusica: nomeMusica,
      },
      this.setAuthenticationHeader()
    );
  }

  private setAuthenticationHeader() {
    let access_token = sessionStorage.getItem('access_token');

    let options = {
      headers: new HttpHeaders().set('Authorization', `Bearer ${access_token}`),
    };
    return options;
  }
}
