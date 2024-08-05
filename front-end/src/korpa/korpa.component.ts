import {Component, OnInit} from '@angular/core';
import {CommonModule} from "@angular/common";
import {FormsModule} from "@angular/forms";
import {Mojconfig} from "../app/moj-config";
import {KorpaResponse} from "./KorpaResponse";
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
declare function porukaError(m:string):any;
declare function porukaSuccess(m:string):any;
@Component({
  selector: 'app-korpa',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './korpa.component.html',
  styleUrl: './korpa.component.css'
})
export class KorpaComponent  implements OnInit{
  trenutnaStranica = 1 ;
  nacinDostave:string ="";
  nacinPlacanja:string ="";
  regularnaIsporukaChecked: boolean = false;
  clickNCollectChecked: boolean = false;
  karticnoPlacanjeChecked: boolean = false;
  placanjePreuzimanjeChecked: boolean = false;
  korpa: KorpaResponse ={
    korpaID: 0,
    proizvodi: [],
    vrijednost: 0
  }
  korisnikId:number=0;

  constructor(private httpClient:HttpClient, private router:Router) {
  }

  ngOnInit(): void {
    this.provjeriJelLogovan();
    this.ucitajProizvode();
  }

  prebaciNaStranicu4() {
    this.trenutnaStranica = 4;
  }

  handleCheckbox(selected: string) {
    switch (selected) {
      case  'regularna':
        this.regularnaIsporukaChecked = !this.regularnaIsporukaChecked;
        if(this.clickNCollectChecked){
          this.clickNCollectChecked = false;
        }
        this.nacinDostave=selected;
        console.log(this.nacinDostave);
        break;
      case  'clickNCollect':
        this.clickNCollectChecked = !this.clickNCollectChecked;
        if(this.regularnaIsporukaChecked){
          this.regularnaIsporukaChecked = false;
        }
        this.nacinDostave=selected;
        console.log(this.nacinDostave);
        break;
        case  'karticno':
          this.karticnoPlacanjeChecked = !this.karticnoPlacanjeChecked;
          if(this.placanjePreuzimanjeChecked){
            this.placanjePreuzimanjeChecked = false;
          }
          this.nacinPlacanja=selected;
          console.log(this.nacinPlacanja);
          break;
        case  'preuzimanje':
          this.placanjePreuzimanjeChecked = !this.placanjePreuzimanjeChecked;
          if(this.karticnoPlacanjeChecked){
            this.karticnoPlacanjeChecked = false;
          }
          this.nacinPlacanja=selected;
          console.log(this.nacinPlacanja);
          break;
    }
  }

  sljedecikorak() {
    this.trenutnaStranica++;
  }

  prethodnikorak() {
    this.trenutnaStranica--;
  }

  provjeriJelLogovan() {
    let korisnikString = window.localStorage.getItem("korisnik")??"";
    if(korisnikString == "") {
      porukaError("Morate biti prijavljeni da biste mogli pregledati korpu");
      this.router.navigate(['/prijavi-se']);
      return;
    }
    const korisnikObject = JSON.parse(korisnikString);
    this.korisnikId = korisnikObject.autentifikacijaToken.korisnickiNalogId;
  }

  ucitajProizvode() {
    let url = Mojconfig.adresa_servera + `/api/Korpa/GetKorpaByKorisnikID/${this.korisnikId}`;
    this.httpClient.get(url).subscribe(x=>{
      this.korpa = x as KorpaResponse;
    })
  }
}
