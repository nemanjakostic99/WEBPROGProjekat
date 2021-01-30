import {Pacijent} from "./pacijent.js"

export class Krevet{
    constructor(){
        this.Zauzet = false;
        this.Pacijent = null;
    }
    oslobodiKrevet() {
        this.Pacijent = null;
        this.Zauzet = false;
    }
    smestiUKrevet(pacijent){
        this.Pacijent = pacijent;
        this.Zauzet = true;
    }
    slobodan(){
        return !this.Zauzet;
    }
    
}