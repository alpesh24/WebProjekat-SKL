export class Liga {
    constructor(id, naziv) {
        this.id = id;
        this.ime = naziv;
    }

    crtaj(host) {

        var tr = document.createElement("tr");
        host.appendChild(tr);

        var el = document.createElement("td");
        el.innerHTML = this.ime;
        tr.appendChild(el);

        //pored buton za klik za prikaz timova
    }
}