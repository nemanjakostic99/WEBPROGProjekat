
export class Pacijent{

    constructor(ime, prezime, dijeta, dijagnoza){
        this.Ime = ime;
        this.Prezime = prezime;
        this.Dijeta = dijeta;
        this.Dijagnoza = dijagnoza;
    }

    dodajDijetu(dijeta){
        this.Dijeta = dijeta;
    }

    dodajDijagnozu(dijagnoza){
        this.Dijagnoza = dijagnoza;
    }

} 