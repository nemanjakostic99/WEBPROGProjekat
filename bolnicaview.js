import {Bolnica} from "./bolnica.js"

export class BolnicaView {
    
    constructor(bolnica){
        this.hospital = bolnica;
    }
    crtajBolnicu(host){
        let brisanje = Array.prototype.slice.call(document.getElementsByClassName("zabrisanje"));
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
        for(let i=0; i<this.hospital.BrojSpratova; i++)
        {
            const sprat = document.createElement("div");
            sprat.innerHTML = i+1 + ". спрат";
            sprat.style.fontWeight = "bold";
            divSpratovi.appendChild(sprat);
        }
       
        div1.className = "matricasoba";
        div1.classList.add("zabrisanje");
        div1.style.height = ((this.hospital.BrojSpratova-1)*(50)+50)+"px";
        div1.style.width = ((this.hospital.BrojSoba-1)*60+60)+"px";
        for(let i=0; i<this.hospital.BrojSpratova; i++)
            for(let j=0; j<this.hospital.BrojSoba; j++){
                let dugmeSoba = document.createElement("button");
                dugmeSoba.className = "sobadugme";
                let pom=j+1
                dugmeSoba.innerHTML = "соба " + pom;
                dugmeSoba.style.fontWeight = "bold";
                if(this.hospital.Spratovi[i][j].DaLiImaSlobodnoMesto())
                dugmeSoba.style.backgroundColor = "lime";
                else dugmeSoba.style.backgroundColor = "darkred";
                dugmeSoba.onclick=(ev)=>{
                    this.crtajDijagramSobe(host, this.hospital.Spratovi[i][j], div1.style.width, i, j)
                }
                this.hospital.Spratovi[i][j].Dugme = dugmeSoba; //referenca na dugme
                div1.appendChild(dugmeSoba);
        }
        matricaSoba.appendChild(divSpratovi);
        matricaSoba.appendChild(div1);
        host.appendChild(matricaSoba);

        let razmak = document.createElement("div");
        razmak.style.height = "15px";
        host.appendChild(razmak);
    }
    crtajDijagramSobe(host, soba, width, brSprata, brSobe){
    
        let brisanje = document.getElementsByClassName("dijagramSobe");
        //let brisanje = document.getElementById(1);

        if(brisanje.length !== 0)
        //if(brisanje !== null)
        brisanje[0].remove();

        const glavniProzor = document.createElement("div");
        glavniProzor.className = "dijagramSobe";
        
        glavniProzor.innerHTML = "спрат:"+ (brSprata+1) + "  соба:" + (brSobe+1);
        glavniProzor.style.width = width;
        glavniProzor.style.fontWeight = "bold";

        for(let i=0; i < soba.BrojKreveta; i++){
            const dugmeKreveta = document.createElement("button");
            dugmeKreveta.className = "krevetDugme";
            dugmeKreveta.style.fontWeight = "bold";
            dugmeKreveta.onclick=(ev)=>{
                this.crtajDijagramPacijenta(host, soba.Kreveti[i].Pacijent);
            }
            if(!soba.Kreveti[i].slobodan()){
                dugmeKreveta.innerHTML = "Кревет " + (i+1) + ": " + soba.Kreveti[i].Pacijent.Ime + " " + soba.Kreveti[i].Pacijent.Prezime + "<br />" + "Дијета:" + soba.Kreveti[i].Pacijent.Dijeta + "<br />" + "Дијагноза:" + soba.Kreveti[i].Pacijent.Dijagnoza;
            }else dugmeKreveta.innerHTML ="Слободнo";
            glavniProzor.appendChild(dugmeKreveta);
        }
        host.appendChild(glavniProzor);
    }
    crtajDijagramPacijenta(host, pacijent){
        let brisanje = document.getElementsByClassName("dijagramPacijenta");
        if(brisanje.length !== 0)
            brisanje[0].remove();

        let razmak = document.createElement("div");
        
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
        unosImenaPacijenta.value = pacijent.Ime;

        imeProzor.appendChild(imePacijenta);
        imeProzor.appendChild(unosImenaPacijenta);
        glavniProzor.appendChild(imeProzor);

        const prezimeProzor = document.createElement("div");
        prezimeProzor.className = "divPrezime";

        const prezimePacijenta = document.createElement("div");
        prezimePacijenta.innerHTML = "Презиме:";

        const unosPrezimenaPacijenta = document.createElement("input");
        unosPrezimenaPacijenta.type = "text";
        unosPrezimenaPacijenta.value = pacijent.Prezime;
        
        prezimeProzor.appendChild(prezimePacijenta);
        prezimeProzor.appendChild(unosPrezimenaPacijenta);
        glavniProzor.appendChild(prezimeProzor);

        const dijetaProzor = document.createElement("div");
        dijetaProzor.className = "divDijeta";

        const dijetaPacijenta = document.createElement("div");
        dijetaPacijenta.innerHTML = "Дијета:";

        const unosDijetePacijenta = document.createElement("input");
        unosDijetePacijenta.type = "text";
        unosDijetePacijenta.value = pacijent.Dijeta;
        
        dijetaProzor.appendChild(dijetaPacijenta);
        dijetaProzor.appendChild(unosDijetePacijenta);
        glavniProzor.appendChild(dijetaProzor);

        const dijagnozaProzor = document.createElement("div");
        dijagnozaProzor.className = "divDijagnoza";

        const dijagnozaPacijenta = document.createElement("div");
        dijagnozaPacijenta.innerHTML = "Дијагноза:";

        const unosDijagnozePacijenta = document.createElement("input");
        unosDijagnozePacijenta.type = "text";
        unosDijagnozePacijenta.value = pacijent.Dijagnoza;
        
        dijagnozaProzor.appendChild(dijagnozaPacijenta);
        dijagnozaProzor.appendChild(unosDijagnozePacijenta);
        glavniProzor.appendChild(dijagnozaProzor);

        const dugmePotvrdi = document.createElement("button");
        dugmePotvrdi.innerHTML = "Потврди";
        dugmePotvrdi.style.backgroundColor = "lightgreen";
        dugmePotvrdi.onclick=(ev)=>{
            pacijent.Ime = unosImenaPacijenta.value;
            pacijent.Prezime = unosPrezimenaPacijenta.value;
            pacijent.Dijeta = unosDijetePacijenta.value;
            pacijent.Dijagnoza = unosDijagnozePacijenta.value;;
            this.crtajBolnicu(host);
        }
        glavniProzor.appendChild(dugmePotvrdi);

        host.appendChild(glavniProzor);
    }


}