import {BolnicaView} from "./bolnicaview.js"
import {Bolnica} from "./bolnica.js"
import {Pacijent} from "./pacijent.js"

let razmak = document.createElement("div");
razmak.style.height = "15px";
document.body.appendChild(razmak);

let pacijent1 = new Pacijent("Nemanja", "Kostic", "A", "Slepo crevo");
let pacijent2 = new Pacijent("Emilija", "Vlajic", "Sve sto moze da pojede", "nepoznato");

let bolnica = new Bolnica(5, 10, 2);

console.log(bolnica.dodajPacijenta(pacijent1));
console.log(bolnica.dodajPacijenta(pacijent2));
console.log(bolnica.dodajPacijenta(pacijent2));
console.log(bolnica.dodajPacijenta(pacijent2));
console.log(bolnica.dodajPacijenta(pacijent2));
console.log(bolnica.dodajPacijenta(pacijent2));

bolnica.Spratovi[0][0].Kreveti[0].Pacijent = pacijent1;

let prikaz = new BolnicaView(bolnica);

prikaz.crtajBolnicu(document.body);
//prikaz.crtajBolnicu(document.body);
//prikaz.crtajBolnicu(document.body);

