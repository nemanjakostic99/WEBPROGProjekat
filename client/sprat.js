import {Soba} from "./soba.js"
export class Sprat {
    constructor(id){
        this.id = id
        this.sobe = [];
    }

    dodajSobu(soba)
    {
        this.sobe.push(soba);
    }

    vratiBrojSoba()
    {
        return this.sobe.length;
    }

    vratiBrojKreveta()
    {
        let sum = 0;
        this.sobe.forEach(p => {
            sum+=p.vratiBrojKreveta;
        })
        return sum;
    }
    
}