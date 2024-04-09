import { Component, OnInit } from '@angular/core';
import {
  FormControl,
  Validators,
  FormsModule,
  ReactiveFormsModule,
} from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { BandaService } from '../services/banda.service';
import { Musica } from '../model/album';
import { MatListModule } from '@angular/material/list';
import { UsuarioService } from '../services/usuario.service';

@Component({
  selector: 'app-buscar-musica',
  standalone: true,
  imports: [
    MatFormFieldModule,
    MatInputModule,
    FormsModule,
    ReactiveFormsModule,
    MatListModule,
  ],
  templateUrl: './buscar-musica.component.html',
  styleUrl: './buscar-musica.component.css',
})

export class BuscarMusicaComponent {
  nomeMusica = new FormControl('', [Validators.required]);
  errorMessage = '';
  musicas!: Musica[];

  constructor(private bandaService: BandaService, private usuarioService: UsuarioService) {}

  public buscar() {
    if (this.nomeMusica.invalid) {
      return;
    }

    let nomeValue = this.nomeMusica.getRawValue() as string;

    this.bandaService.getMusicasPorNome(nomeValue).subscribe({
      next: (response) => {
        this.musicas = response;
        console.log();
      },
      error: (e) => {
        if (e.error) {
          this.errorMessage = e.error.error;
        }
      },
    });
  }

  // public favoritarMusica() {

  // }
}
