import { Krevet } from "./krevet.js";

export class Soba{


    constructor(id, brojKreveta) {
        this.id = id
        this.kreveti = [];
    }

    dodajKrevet(krevet)
    {
        this.kreveti.push(krevet);
    }

    vratiBrojKreveta()
    {
        return this.kreveti.length;
    }

    daLiImaSlobodnihMesta()
    {
        for(let i=0; i<this.kreveti.length; i++)
            if(this.kreveti[i].slobodan())
                return true;
        return false;
    }

}