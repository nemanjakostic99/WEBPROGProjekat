import {Soba} from "./soba.js"

export class Bolnica{

    constructor(id, ime){

        this.ime = ime;
        this.id = id;
        this.spratovi = [];

    }
    dodajSprat(sprat)
    {
       this.spratovi.push(sprat); 
    }

    vratiBrojSpratova()
    {
        return this.spratovi.length;
    }

    vratiBrojSoba()
    {
        let sum = 0;
        this.spratovi.forEach(p => {
            sum += p.vratiBrojSoba
        })
    }

    brojSlobodnihMesta() 
    {
         let sum = 0;
        // for(let i=0; i<this.spratovi.length; i++)
        //     for(let j=0; j<this.spratovi[i].sobe.length; j++)
        //         for(let k=0; k<this.spratovi[i].sobe[j].kreveti.length; k++)
        //             {
        //                 if(this.spratovi[i].sobe[j].kreveti[k].slobodan())
        //                 sum++;
        //             }
        this.spratovi.forEach(p => {
            p.sobe.forEach(t => {
                t.kreveti.forEach(l => {
                    if(l.slobodan())
                        sum++;
                })
            })
        })
        return sum;
    }

    brojZauzetihMesta() 
    {
        let sum = 0;
        this.spratovi.forEach(p => {
            p.sobe.forEach(t => {
                t.kreveti.forEach(l => {
                    if(!l.slobodan())
                        sum++;
                })
            })
        })
        return sum;
    }

    
    

    
}