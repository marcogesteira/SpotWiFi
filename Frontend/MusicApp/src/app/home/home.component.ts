import { Component, OnInit } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { BandaService } from '../services/banda.service';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { FlexLayoutModule } from '@angular/flex-layout';
import { Router } from '@angular/router';
import { Banda } from '../model/banda';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [
    MatCardModule,
    MatButtonModule,
    HttpClientModule,
    CommonModule,
    FlexLayoutModule,
  ],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css',
})
export class HomeComponent implements OnInit {
  bandas = null;

  constructor(private bandaService: BandaService, private router: Router) {}
  ngOnInit(): void {
    this.bandaService.getBanda().subscribe((response) => {
      console.log(response);
      this.bandas = response as any;
    });
  }
  public goToDetail(item: Banda) {
    this.router.navigate(['detail', item.id]);
  }
  public goToBuscar() {
    this.router.navigate(['buscar-musica']);
  }
}
