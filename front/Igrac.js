import { Liga } from "./Liga.js";
import { Tim } from "./Tim.js";
export class Igrac {
    constructor(id, ime, prezime, godiste, visina, tim) {
        this.id = id;
        this.ime = ime;
        this.prezime = prezime;
        this.godiste = godiste;
        this.visina = visina;
        this.tim = tim;
    }

    crtaj(host) {

        var tr = document.createElement("tr");
        host.appendChild(tr);

        var el = document.createElement("td");
        el.innerHTML = this.ime;
        tr.appendChild(el);

        var el = document.createElement("td");
        el.innerHTML = this.prezime;
        tr.appendChild(el);

        var el = document.createElement("td");
        el.innerHTML = this.godiste;
        tr.appendChild(el);

        var el = document.createElement("td");
        el.innerHTML = this.visina;
        tr.appendChild(el);

    }

}