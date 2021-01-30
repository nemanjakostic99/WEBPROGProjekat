import {Soba} from "./soba.js"

export class Bolnica{

    constructor(brojSpratova, brojSoba, brojKrevetaPoSobi){

        this.BrojSpratova = brojSpratova;     // broj spratova koriscenih za boravak pacijenata u bolnici.
        this.BrojSoba = brojSoba;         // broj soba po spratu.
        this.BrojKrevetaPoSobi = brojKrevetaPoSobi;

         // Matrica koja predstavlja jedan sprat kao vrstu i njegove sobe kao kolone.
        this.Spratovi = new Array(brojSpratova);
        for(let i=0; i<this.BrojSpratova; i++)
        {
            this.Spratovi[i] = new Array(brojSoba);
            for(let j=0; j<this.BrojSoba; j++)
            {
                this.Spratovi[i][j] = new Soba(this.BrojKrevetaPoSobi);
            }
        }

    }

    dodajPacijenta(pacijent) 
    {
        for(let i=0; i<this.BrojSpratova; i++)
        {
            for(let j=0; j<this.BrojSoba; j++)
            {
                for(let k=0; k<2; k++)
                {
                    if(this.Spratovi[i][j].Kreveti[k].slobodan())
                    {
                        this.Spratovi[i][j].Kreveti[k].smestiUKrevet(pacijent);
                        return true;
                    }
                }
            }
        }
        return false;
    }

    brojSlobodnihMesta() {
        let sum = 0;
        for(let i=0; i<this.BrojSpratova; i++)
        {
            for(let j=0; j<this.BrojSoba; j++)
            {
                for(let k=0; k<2; k++)
                {
                    if(this.Spratovi[i][j].Kreveti[k].slobodan())
                    {
                        sum++;
                    }
                }
            }
        }
        return sum;
    }

    brojZauzetihMesta() {
        let sum = 0;
        for(let i=0; i<this.BrojSpratova; i++)
        {
            for(let j=0; j<this.BrojSoba; j++)
            {
                for(let k=0; k<2; k++)
                {
                    if(!this.Spratovi[i][j].Kreveti[k].slobodan())
                    {
                        sum++;
                    }
                }
            }
        }
        return sum;
    }

    
    

    
}