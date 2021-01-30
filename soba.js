import { Krevet } from "./krevet.js";

export class Soba{
    constructor(brojKreveta) {
        this.BrojKreveta = brojKreveta;
        this.Kreveti = new Array(brojKreveta);
        this.Dugme = null;

        for(let i=0; i<this.BrojKreveta; i++){
            this.Kreveti[i] = new Krevet();
        }
    }

    dodajKrevet(kolicina = 1){
        this.BrojKreveta += this.BrojKreveta + kolicina;
        for(let i=0; i < kolicina; i++)
        this.Kreveti.push(new Krevet());

    }
    dodajPacijenta(pacijent, krevet){
        if(krevet.slobodan()){
        this.Kreveti.smestiUKrevet(pacijent);
        } else console.log("Krevet je zauzet!");
    }
    DaLiImaSlobodnoMesto() {
        for(let i=0; i < this.Kreveti.length; i++){
            if(this.Kreveti[i].slobodan())
            return true;
        }
        return false;
    }
}