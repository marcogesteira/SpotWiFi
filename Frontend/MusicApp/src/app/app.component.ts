import { Component, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatToolbarModule } from '@angular/material/toolbar';
import { Usuario } from './model/usuario';
import { UsuarioService } from './services/usuario.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, MatToolbarModule, MatButtonModule, MatIconModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent implements OnInit {
  userName = '';

  constructor(private usuarioService: UsuarioService) {}

  ngOnInit(): void {
    if (sessionStorage.getItem("user_session")) {
      let token = JSON.parse(sessionStorage.getItem('user_session') as string);
      this.userName = token.name;
    }
  }
}
