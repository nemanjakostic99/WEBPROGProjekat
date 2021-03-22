import { BolnicaView } from "./bolnicaview.js"
import { Bolnica } from "./bolnica.js"
import { Pacijent } from "./pacijent.js"

let razmak = document.createElement("div");
razmak.style.height = "15px";
document.body.appendChild(razmak);

//let pacijent1 = new Pacijent("Nemanja", "Kostic", "A", "Slepo crevo");
//let pacijent2 = new Pacijent("Emilija", "Vlajic", "Sve sto moze da pojede", "nepoznato");

//let bolnica = new Bolnica(5, 10, 2);

//console.log(bolnica.dodajPacijenta(pacijent1));
//console.log(bolnica.dodajPacijenta(pacijent2));
//console.log(bolnica.dodajPacijenta(pacijent2));
//console.log(bolnica.dodajPacijenta(pacijent2));
//console.log(bolnica.dodajPacijenta(pacijent2));
//console.log(bolnica.dodajPacijenta(pacijent2));

//bolnica.Spratovi[0][0].Kreveti[0].Pacijent = pacijent1;

//let prikaz = new BolnicaView(bolnica);

//prikaz.crtajBolnicu(document.body);
//prikaz.crtajBolnicu(document.body);
//prikaz.crtajBolnicu(document.body);

// SERVER //

fetch("https://localhost:5001/Bolnica/PreuzmiBolnice").then(p => {
    p.json().then(data => {
        data.forEach(bolnice => {
            const bolnica1 = new Bolnica(bolnice.brojSpratova, bolnice.brojSoba, bolnice.brojKrevetaPoSobi);
            bolnice.spratovi.forEach(sprat => {
                sprat.kreveti.forEach(krevet => {
                    if(krevet.pacijent != null){
                        let pacijent1 = new Pacijent(krevet.pacijent.ime, krevet.pacijent.prezime,
                             krevet.pacijent.dijeta, krevet.pacijent.dijagnoza)
                             bolnica1.Spratovi[krevet.pacijent.brojSprata][krevet.pacijent.brojSobe]
                             .Kreveti[krevet.pacijent.brojKreveta].smestiUKrevet(pacijent1);
                        //bolnica1.dodajPacijenta(pacijent1);
                       // bolnica1.Spratovi[][]
                    }

                })

            });

            // for(let i=0; i<bolnice.brojSpratova; i++)
            // for(let j=0; j<bolnice.brojSoba; j++)
            // for(let k=0; k<bolnice.brojKrevetaPoSobi; k++){
            // if(bolnice.Spratovi != null && bolnice.Spratovi[i*bolnice.brojSoba + j] != null){
            // bolnica1.Spratovi[i,j].Kreveti[k].smestiUKrevet(pacijent => {
            //     pacijent = new Pacijent(bolnice.Spratovi[i*bolnice.brojSoba + j].Kreveti[k].Pacijent.Ime,
            //                          bolnice.Spratovi[i*bolnice.brojSoba + j].Kreveti[k].Pacijent.Prezime,
            //                          bolnice.Spratovi[i*bolnice.brojSoba + j].Kreveti[k].Pacijent.Dijeta,
            //                          bolnice.Spratovi[i*bolnice.brojSoba + j].Kreveti[k].Pacijent.Dijagnoza);
            //                                                             });
            //}

            let prikaz = new BolnicaView(bolnica1);
            prikaz.crtajBolnicu(document.body);
        });
    })
});

function PosaljiBolnicu(bolnica){
    fetch("https://localhost:5001/Bolnica/IzmeniBolnicu",{
                method:"PUT",
                headers:{
                    "Content-Type":"application/json"
                },
                body:JSON.stringify({
                    id:this.sobe[brSobe-1].id,
                    brojSobe:brSobe,
                    odelenje:odelenje,
                    pacijenti:this.sobe[brSobe-1].pacijenti+","+imeprezime,
                    maxPrimljeni:this.kapacitetSobe,
                    hitno:hitno,
                })
            }).then(p=>{
                this.sobe[brSobe-1].azurirajSobu(imeprezime,odelenje,hitno);
            });
            }
}
