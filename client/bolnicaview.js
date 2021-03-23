import {Bolnica} from "./bolnica.js"
import { Pacijent } from "./pacijent.js";

export class BolnicaView {
    
    constructor(bolnica){
        this.hospital = bolnica;
    }
    crtajBolnicu(host){
        let brisanje = Array.prototype.slice.call(document.getElementsByClassName("zabrisanje"));
        for(let i; i<brisanje.length; i++)
        brisanje[i].remove();
        brisanje.map(function(el){
           return el.remove();
        });
        brisanje = Array.prototype.slice.call(document.getElementsByClassName("zabrisanje1"));
        for(let i; i<brisanje.length; i++)
        brisanje[i].remove();
        brisanje.map(function(el){
           return el.remove();
        });
        brisanje = Array.prototype.slice.call(document.getElementsByClassName("dijagramSobe"));
        brisanje.map(function(el){
           return el.remove();
        });
        brisanje = Array.prototype.slice.call(document.getElementsByClassName("dijagramPacijenta"));
        brisanje.map(function(el){
           return el.remove();
        });
        
        // MATRICA SOBA //
        const legenda = document.createElement("div");
        legenda.innerHTML = "Зелена-постоји слободно место, Црвена-нема слободног места";
        legenda.classList.add("zabrisanje");
        host.appendChild(legenda);

        const legenda2 = document.createElement("div");
        legenda2.classList.add("zabrisanje");
        legenda2.innerHTML = "Број слободних места:" + this.hospital.brojSlobodnihMesta() + "  Број заузетих места:" + this.hospital.brojZauzetihMesta();
        legenda2.style.fontWeight = "bold";
        host.appendChild(legenda2);

        const matricaSoba = document.createElement("div");
        matricaSoba.className = "DivZaMatricuSoba";
        const div1 = document.createElement("div");
        const divSpratovi = document.createElement("div");
        divSpratovi.className = "divSpratovi";
        divSpratovi.classList.add("zabrisanje");
      
        for(let i=0; i<this.hospital.spratovi.length; i++)
        {
            const sprat = document.createElement("div");
            sprat.innerHTML = i+1 + ". спрат";
            sprat.style.fontWeight = "bold";
            divSpratovi.appendChild(sprat);
        }
       
        div1.className = "matricasoba";
        div1.classList.add("zabrisanje");
        let BrojSpratova = 0;
        this.hospital.spratovi.forEach(p => {
            const sprat = document.createElement("div");
            sprat.className = "sprat";
            let BrojSobe = 0;
                p.sobe.forEach(l => {
                    let dugmeSoba = document.createElement("button");
                    dugmeSoba.className = "sobadugme";

                    let pom=BrojSobe+1;
                    let pom2=BrojSpratova;
                
                    dugmeSoba.innerHTML = "соба " + pom;
                    dugmeSoba.style.fontWeight = "bold";

                    if(l.daLiImaSlobodnihMesta())
                        dugmeSoba.style.backgroundColor = "lime";
                    else 
                        dugmeSoba.style.backgroundColor = "darkred";
                    dugmeSoba.onclick=(ev)=>{ this.crtajDijagramSobe(host, l, div1.style.width, pom2, pom); }
                    sprat.appendChild(dugmeSoba);

                    BrojSobe++;
            })
            BrojSpratova++;
            div1.appendChild(sprat);
            
        })
    

        matricaSoba.appendChild(divSpratovi);
        matricaSoba.appendChild(div1);
        host.appendChild(matricaSoba);

        let razmak = document.createElement("div");
        razmak.style.height = "15px";
        razmak.classList.add("zabrisanje");
        host.appendChild(razmak);
    }
    crtajDijagramSobe(host, soba, width, brSprata, brSobe){
    
        let brisanje = document.getElementsByClassName("dijagramSobe");
        //let brisanje = document.getElementById(1);

        if(brisanje.length !== 0)
        //if(brisanje !== null)
        brisanje[0].remove();

        brisanje = document.getElementsByClassName("dijagramPacijenta");
        if(brisanje.length !== 0)
            brisanje[0].remove();

        const glavniProzor = document.createElement("div");
        glavniProzor.className = "dijagramSobe";
        
        glavniProzor.innerHTML = "спрат:"+ (brSprata+1) + "  соба:" + (brSobe);
        glavniProzor.style.width = width;
        glavniProzor.style.fontWeight = "bold";

        for(let i=0; i < soba.vratiBrojKreveta(); i++){
            const dugmeKreveta = document.createElement("button");
            dugmeKreveta.className = "krevetDugme";
            dugmeKreveta.style.fontWeight = "bold";
            dugmeKreveta.onclick=(ev)=>{
                if(soba.kreveti[i].slobodan())
                this.crtajDijagramNovogPacijenta(host, soba.kreveti[i]);
                else this.crtajDijagramPacijenta(host, soba.kreveti[i]);
            }
            if(!soba.kreveti[i].slobodan()){
                dugmeKreveta.innerHTML = "Кревет " + (i+1) + ": " + soba.kreveti[i].pacijent.Ime + " " + soba.kreveti[i].pacijent.Prezime + "<br />" + "Дијета:" + soba.kreveti[i].pacijent.Dijeta + "<br />" + "Дијагноза:" + soba.kreveti[i].pacijent.Dijagnoza;
            }else dugmeKreveta.innerHTML ="Слободнo";
            glavniProzor.appendChild(dugmeKreveta);
        }
        host.appendChild(glavniProzor);
    }
    crtajDijagramPacijenta(host, pacijent){

        let brisanje = document.getElementsByClassName("dijagramPacijenta");
        if(brisanje.length !== 0)
            brisanje[0].remove();

        brisanje = document.getElementsByClassName("zabrisanje1");
        if(brisanje.length !== 0)
            brisanje[0].remove();

        let razmak = document.createElement("div");
        razmak.classList.add("zabrisanje1");
        razmak.style.height = "15px";
        host.appendChild(razmak);

        const glavniProzor = document.createElement("div");
        glavniProzor.classList.add("dijagramPacijenta");

        const imeProzor = document.createElement("div");
        imeProzor.className = "divIme";

        const imePacijenta = document.createElement("div");
        imePacijenta.innerHTML = "Име:";

        const unosImenaPacijenta = document.createElement("input");
        unosImenaPacijenta.type = "text";
        unosImenaPacijenta.value = pacijent.pacijent.Ime;

        imeProzor.appendChild(imePacijenta);
        imeProzor.appendChild(unosImenaPacijenta);
        glavniProzor.appendChild(imeProzor);

        const prezimeProzor = document.createElement("div");
        prezimeProzor.className = "divPrezime";

        const prezimePacijenta = document.createElement("div");
        prezimePacijenta.innerHTML = "Презиме:";

        const unosPrezimenaPacijenta = document.createElement("input");
        unosPrezimenaPacijenta.type = "text";
        unosPrezimenaPacijenta.value = pacijent.pacijent.Prezime;
        
        prezimeProzor.appendChild(prezimePacijenta);
        prezimeProzor.appendChild(unosPrezimenaPacijenta);
        glavniProzor.appendChild(prezimeProzor);

        const dijetaProzor = document.createElement("div");
        dijetaProzor.className = "divDijeta";

        const dijetaPacijenta = document.createElement("div");
        dijetaPacijenta.innerHTML = "Дијета:";

        const unosDijetePacijenta = document.createElement("input");
        unosDijetePacijenta.type = "text";
        unosDijetePacijenta.value = pacijent.pacijent.Dijeta;
        
        dijetaProzor.appendChild(dijetaPacijenta);
        dijetaProzor.appendChild(unosDijetePacijenta);
        glavniProzor.appendChild(dijetaProzor);

        const dijagnozaProzor = document.createElement("div");
        dijagnozaProzor.className = "divDijagnoza";

        const dijagnozaPacijenta = document.createElement("div");
        dijagnozaPacijenta.innerHTML = "Дијагноза:";

        const unosDijagnozePacijenta = document.createElement("input");
        unosDijagnozePacijenta.type = "text";
        unosDijagnozePacijenta.value = pacijent.pacijent.Dijagnoza;
        
        dijagnozaProzor.appendChild(dijagnozaPacijenta);
        dijagnozaProzor.appendChild(unosDijagnozePacijenta);
        glavniProzor.appendChild(dijagnozaProzor);

        const dugmePotvrdi = document.createElement("button");
        dugmePotvrdi.innerHTML = "Потврди";
        dugmePotvrdi.style.backgroundColor = "lightgreen";
        dugmePotvrdi.onclick=(ev)=>{
            if(!allLetter(unosImenaPacijenta.value))
            {
                alert("Име није валидно!");
                return false;
            }

            pacijent.pacijent.Ime = unosImenaPacijenta.value;

            if(!allLetter(unosPrezimenaPacijenta.value))
            {
                alert("Презиме није валидно!");
                return false;
            }
            pacijent.pacijent.Prezime = unosPrezimenaPacijenta.value;
            pacijent.pacijent.Dijeta = unosDijetePacijenta.value;
            pacijent.pacijent.Dijagnoza = unosDijagnozePacijenta.value;

            
            fetch("https://localhost:5001/Bolnica/IzmeniPacijenta2/"+pacijent.pacijent.id,{
            method:"PUT",
            headers:{
            "Content-Type":"application/json"
            },
            body: JSON.stringify({
            
            ime:pacijent.pacijent.Ime,
            prezime:pacijent.pacijent.Prezime,
            dijeta:pacijent.pacijent.Dijeta,
            dijagnoza:pacijent.pacijent.Dijagnoza

            })
    });
            this.crtajBolnicu(host);
        }
        glavniProzor.appendChild(dugmePotvrdi);

        const dugmeOslobodi = document.createElement("button");
        dugmeOslobodi.innerHTML = "Ослободи";
        dugmeOslobodi.style.backgroundColor = "red";
        dugmeOslobodi.onclick=(ev)=>{
            console.log(pacijent.pacijent);
            
            fetch("https://localhost:5001/Bolnica/IzbrisiPacijenta/"+ pacijent.pacijent.id,{
            method:"DELETE",headers:{
                "Content-Type":"application/json"
                }});
            pacijent.oslobodiKrevet();
            this.crtajBolnicu(host);
        }
        glavniProzor.appendChild(dugmeOslobodi);
        host.appendChild(glavniProzor);
    }

    crtajDijagramNovogPacijenta(host, krevet) {
        let brisanje = document.getElementsByClassName("dijagramPacijenta");
        if(brisanje.length !== 0)
            brisanje[0].remove();

        brisanje = document.getElementsByClassName("zabrisanje1");
        if(brisanje.length !== 0)
            brisanje[0].remove();
        let razmak = document.createElement("div");
        razmak.classList.add("zabrisanje1");
        razmak.style.height = "15px";
        host.appendChild(razmak);

        const glavniProzor = document.createElement("div");
        glavniProzor.classList.add("dijagramPacijenta");

        const imeProzor = document.createElement("div");
        imeProzor.className = "divIme";

        const imePacijenta = document.createElement("div");
        imePacijenta.innerHTML = "Име:";

        const unosImenaPacijenta = document.createElement("input");
        unosImenaPacijenta.type = "text";
        unosImenaPacijenta.value = "";

        imeProzor.appendChild(imePacijenta);
        imeProzor.appendChild(unosImenaPacijenta);
        glavniProzor.appendChild(imeProzor);

        const prezimeProzor = document.createElement("div");
        prezimeProzor.className = "divPrezime";

        const prezimePacijenta = document.createElement("div");
        prezimePacijenta.innerHTML = "Презиме:";

        const unosPrezimenaPacijenta = document.createElement("input");
        unosPrezimenaPacijenta.type = "text";
        unosPrezimenaPacijenta.value = "";
        
        prezimeProzor.appendChild(prezimePacijenta);
        prezimeProzor.appendChild(unosPrezimenaPacijenta);
        glavniProzor.appendChild(prezimeProzor);

        const dijetaProzor = document.createElement("div");
        dijetaProzor.className = "divDijeta";

        const dijetaPacijenta = document.createElement("div");
        dijetaPacijenta.innerHTML = "Дијета:";

        const unosDijetePacijenta = document.createElement("input");
        unosDijetePacijenta.type = "text";
        unosDijetePacijenta.value = "";
        
        dijetaProzor.appendChild(dijetaPacijenta);
        dijetaProzor.appendChild(unosDijetePacijenta);
        glavniProzor.appendChild(dijetaProzor);

        const dijagnozaProzor = document.createElement("div");
        dijagnozaProzor.className = "divDijagnoza";

        const dijagnozaPacijenta = document.createElement("div");
        dijagnozaPacijenta.innerHTML = "Дијагноза:";

        const unosDijagnozePacijenta = document.createElement("input");
        unosDijagnozePacijenta.type = "text";
        unosDijagnozePacijenta.value = "";
        
        dijagnozaProzor.appendChild(dijagnozaPacijenta);
        dijagnozaProzor.appendChild(unosDijagnozePacijenta);
        glavniProzor.appendChild(dijagnozaProzor);

        const dugmePotvrdi = document.createElement("button");
        dugmePotvrdi.innerHTML = "Потврди";
        dugmePotvrdi.style.backgroundColor = "lightgreen";
        dugmePotvrdi.onclick=(ev)=>{
            let pacijent = new Pacijent;

            if(!allLetter(unosImenaPacijenta.value))
            {
                alert("Име није валидно!");
                return false;
            }

            pacijent.Ime = unosImenaPacijenta.value;

            if(!allLetter(unosPrezimenaPacijenta.value))
            {
                alert("Презиме није валидно!");
                return false;
            }

            pacijent.Prezime = unosPrezimenaPacijenta.value;
            pacijent.Dijeta = unosDijetePacijenta.value;
            pacijent.Dijagnoza = unosDijagnozePacijenta.value;

            fetch("https://localhost:5001/Bolnica/UpisiPacijenta/"+krevet.id,{
            method:"POST",
            headers:{
            "Content-Type":"application/json"
            },
            body: JSON.stringify({
            
            ime:pacijent.Ime,
            prezime:pacijent.Prezime,
            dijeta:pacijent.Dijeta,
            dijagnoza:pacijent.Dijagnoza

            })
    });

            krevet.smestiUKrevet(pacijent);

            this.crtajBolnicu(host);
        }
        glavniProzor.appendChild(dugmePotvrdi);

        host.appendChild(glavniProzor);
    }


}
function allLetter(inputtxt)
  {
   var letters = /^[A-Za-z]+$/;
   if(letters.test(inputtxt))
     {
      return true;
     }
   else
     {
     return false;
     }
  }