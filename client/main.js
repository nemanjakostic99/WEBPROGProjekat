import { BolnicaView } from "./bolnicaview.js"
import { Bolnica } from "./bolnica.js"
import { Pacijent } from "./pacijent.js"
import { Sprat } from "./sprat.js";
import { Soba } from "./soba.js";
import { Krevet } from "./krevet.js";

let razmak = document.createElement("div");
razmak.style.height = "15px";
document.body.appendChild(razmak);


// let bolnica = new Bolnica(1);
// let sprat = new Sprat(1);
// let soba = new Soba(1);
// let krevet = new Krevet(1);
// let krevet1 = new Krevet(2);
// let pacijent = new Pacijent(1,"Nemanja", "Kostic", "A", "B");

// //console.log(pacijent);

// krevet.smestiUKrevet(pacijent);

// soba.dodajKrevet(krevet);
// soba.dodajKrevet(krevet1);

// sprat.dodajSobu(soba);
// sprat.dodajSobu(soba);
// sprat.dodajSobu(soba);

// bolnica.dodajSprat(sprat);
// bolnica.dodajSprat(sprat);

// let prikaz = new BolnicaView(bolnica);
// prikaz.crtajBolnicu(document.body);


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
            const bolnica1 = new Bolnica(bolnice.id);
            

            bolnice.spratovi.forEach(s => {
                const sprat = new Sprat(s.id);
                bolnica1.dodajSprat(sprat);
                s.sobe.forEach(a => {
                    const soba = new Soba(a.id);
                    sprat.dodajSobu(soba);
                    a.kreveti.forEach(l => {
                        const krevet = new Krevet(l.id);
                        if(l.pacijent != null)
                            krevet.smestiUKrevet(new Pacijent(l.pacijent.id, l.pacijent.ime, l.pacijent.prezime, l.pacijent.dijeta, l.pacijent.dijagnoza));
                        soba.dodajKrevet(krevet);
                    })
                })
            });
            const bolnicaPrikaz = new BolnicaView(bolnica1);

            const divBolnice = document.createElement("div");
            divBolnice.classList.add("divBolnica");

            bolnicaPrikaz.crtajBolnicu(divBolnice);

            document.body.appendChild(divBolnice);
            
        });
 
        });

    });

        




// function PosaljiBolnicu(bolnica){
//     fetch("https://localhost:5001/Bolnica/IzmeniBolnicu",{
//                 method:"PUT",
//                 headers:{
//                     "Content-Type":"application/json"
//                 },
//                 body:JSON.stringify({
//                     id:this.sobe[brSobe-1].id,
//                     brojSobe:brSobe,
//                     odelenje:odelenje,
//                     pacijenti:this.sobe[brSobe-1].pacijenti+","+imeprezime,
//                     maxPrimljeni:this.kapacitetSobe,
//                     hitno:hitno,
//                 })
//             }).then(p=>{
//                 this.sobe[brSobe-1].azurirajSobu(imeprezime,odelenje,hitno);
//             });
//             }
// }


