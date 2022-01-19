import { Liga } from "./Liga.js";
import { Igrac } from "./Igrac.js";

export class Tim {
    constructor(id, ime, ligaId, liga, igraci) {
        this.id = id;
        this.ime = ime;
        this.ligaId = ligaId;
        this.Liga = liga;
        this.igraci = igraci;
    }
    crtaj(host, hostForButtonCrtaj) {

        var tr = document.createElement("tr");
        host.appendChild(tr);

        var el = document.createElement("td");
        el.innerHTML = this.ime;
        tr.appendChild(el);

        var el = document.createElement("td");
        el.innerHTML = this.Liga.naziv;
        tr.appendChild(el);

        var el = document.createElement("td");
        var btn = document.createElement("button");
        btn.onclick = (ev) => this.prikaziIgrace(hostForButtonCrtaj);
        el.appendChild(btn);
        tr.appendChild(el);
        //pored 2 buttona za prikaz igraca i utakmica
    }

    prikaziIgrace(host) {
        //ime, prezime, godiste, visina
        var spec = ["Ime", "Prezime", "Godiste", "Visina"];

        var igraciTabela = document.createElement("table");
        igraciTabela.className = "TabelaKlubovi";
        host.append(igraciTabela);

        var igraciHead = document.createElement("thead");
        igraciTabela.appendChild(igraciHead);

        var tr = document.createElement("tr");
        igraciHead.appendChild(tr);
        let th;
        spec.forEach(el => {
            th = document.createElement("th");
            th.innerHTML = el;
            tr.appendChild(th);
        })

        igraciTabela.appendChild(th);

        debugger;
        this.igraci.forEach(igrac => {
            var tr = document.createElement("tr");
            host.appendChild(tr);

            var el = document.createElement("td");
            el.innerHTML = igrac.ime;
            tr.appendChild(el);

            var el = document.createElement("td");
            el.innerHTML = igrac.prezime;
            tr.appendChild(el);

            var el = document.createElement("td");
            el.innerHTML = igrac.godiste;
            tr.appendChild(el);

            var el = document.createElement("td");
            el.innerHTML = igrac.godiste;
            tr.appendChild(el);

            console.log(tr);

            th.appendChild(tr);

        });

        console.log("Prikazi igrace kluba " + this.ime);
    }
}