import {Pacijent} from "./pacijent.js"

export class Krevet{

    constructor(id)
    {
        this.id = id;
        this.zauzet = false;
        this.pacijent = null;
    }

    oslobodiKrevet() 
    {
        this.pacijent = null;
        this.zauzet = false;
    }

    smestiUKrevet(pacijent)
    {
        this.pacijent = pacijent;
        this.zauzet = true;
    }

    slobodan(){
        return !this.zauzet;
    }
    
}