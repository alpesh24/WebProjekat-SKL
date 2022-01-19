import { Liga } from "./Liga.js";
import { Tim } from "./Tim.js";

export class SkSavez {
    constructor(listaIgraca, listaTimova, listaLiga) {

        this.listaIgraca = listaIgraca;
        this.listaTimova = listaTimova;
        this.listaUtakmica = [];
        this.listaLiga = listaLiga;
        this.kont = null;
    }

    crtajNaslovnuStranu(host) {
        //mainContainer - kont
        this.mainContainer = document.createElement("div");
        this.mainContainer.className = "GlavniKontejner";
        host.appendChild(this.mainContainer);

        //header - zaglavlje
        let header = document.createElement("div");
        header.className = "Zaglavlje";
        this.mainContainer.appendChild(header);

        //titleForm-naslovForma
        let titleForm = document.createElement("div");
        titleForm.className = "NaslovForm";
        header.appendChild(titleForm);
        // this.CrtajNaslov(titleForm);

        //dugmici-buttons meni-menu
        let buttons = ["Timovi", "Lige"];
        var btns = [];
        let menu = document.createElement("div");
        menu.className = "Meni";
        this.mainContainer.appendChild(menu);

        buttons.forEach(D => {
            var btn = document.createElement("button");
            btn.innerHTML = D;
            btn.className = "DugmiciMeni";
            btns.push(btn);
            menu.appendChild(btn);
        });

        //glavniForma - mainForm 
        let mainForm = document.createElement("div");
        mainForm.className = "GlavnaForma";
        this.mainContainer.appendChild(mainForm);

        btns[0].onclick = (ev) => this.prikaziTimove(mainForm);
        btns[1].onclick = (ev) => this.prikaziLige(mainForm);
    }


    CrtajNaslov(host) {

        let img = document.createElement("img");
        img.src = "Sah_Grb-removebg-preview.png";
        img.onclick = (ev) => this.CrtajNaslovnu_Stranu(document.body);
        host.appendChild(img);

        let l = document.createElement("label");
        l.className = "NaslovLabel";
        l.innerHTML = this.naziv;
        host.appendChild(l);
    }

    DodajHeader(host, tekst) {
        var H1 = document.createElement("h1");
        H1.className = "Header";
        H1.innerHTML = tekst;
        host.appendChild(H1);
    }

    removeAllChildNodes(parent) {
        while (parent.firstChild) {
            parent.removeChild(parent.firstChild);
        }
    }


    prikaziLige(host) {
        this.removeAllChildNodes(host);

        var FormaPrikaz = document.createElement("div");
        FormaPrikaz.className = "FormaPrikaz";
        host.appendChild(FormaPrikaz);

        var FormaKontrole = document.createElement("div");
        FormaKontrole.className = "FormaKontrole";
        host.appendChild(FormaKontrole);

        this.DodajHeader(FormaPrikaz, "Lista liga");

        var LigeTabela = document.createElement("table");
        LigeTabela.className = "TabelaKlubovi";
        FormaPrikaz.append(LigeTabela);

        var LigeHead = document.createElement("thead");
        LigeTabela.appendChild(LigeHead);

        var tr = document.createElement("tr");
        LigeHead.appendChild(tr);

        let th;
        var Head = ["Naziv lige"];
        Head.forEach(el => {
            th = document.createElement("th");
            th.innerHTML = el;
            tr.appendChild(th);
        })

        var LigeBody = document.createElement("tbody");
        LigeBody.className = "KluboviPodaci";
        LigeTabela.appendChild(LigeBody);

        this.listaLiga.forEach(K => {
            K.crtaj(LigeTabela);
        })

        // Kraj za deo koji prikazuje klubove

        // Deo koji prikazuje kontrole

        this.DodajHeader(FormaKontrole, "Podaci o Ligi");

        // this.IscrtajKontroleKlub(FormaKontrole);

    }

    prikaziTimove(host) {
        this.removeAllChildNodes(host);

        var FormaPrikaz = document.createElement("div");
        FormaPrikaz.className = "FormaPrikaz";
        host.appendChild(FormaPrikaz);

        var FormaKontrole = document.createElement("div");
        FormaKontrole.className = "FormaKontrole";
        host.appendChild(FormaKontrole);

        this.DodajHeader(FormaPrikaz, "Lista timova");

        var KluboviTabela = document.createElement("table");
        KluboviTabela.className = "TabelaKlubovi";
        FormaPrikaz.append(KluboviTabela);

        var KluboviHead = document.createElement("thead");
        KluboviTabela.appendChild(KluboviHead);

        var tr = document.createElement("tr");
        KluboviHead.appendChild(tr);

        let th;
        var Head = ["Ime", "Naziv lige", "Buttons"];
        Head.forEach(el => {
            th = document.createElement("th");
            th.innerHTML = el;
            tr.appendChild(th);
        })


        var KluboviBody = document.createElement("tbody");
        KluboviBody.className = "KluboviPodaci";
        KluboviTabela.appendChild(KluboviBody);

        this.listaTimova.forEach(K => {
            K.crtaj(KluboviTabela, FormaKontrole);
        })

        // Kraj za deo koji prikazuje klubove

        // Deo koji prikazuje kontrole

        this.DodajHeader(FormaKontrole, "Podaci o klubu");

        this.IscrtajKontroleKlub(FormaKontrole);
    };

    IscrtajKontroleKlub(host) {
        this.removeAllChildNodes(host);

        this.DodajHeader(host, "Klub:");

        var Kontrole = ["Dodaj klub", "Igraci kluba", "Obrisi klub"];
        var btnsKontrole = [];

        Kontrole.forEach(K => {
            var btn = document.createElement("button");
            btn.innerHTML = K;
            btn.className = "DugmiciKontrole";
            btnsKontrole.push(btn);
            host.appendChild(btn);
        })

        btnsKontrole[0].onclick = (ev) => this.IscrtajKontroleKlub_Dodaj(host);
        btnsKontrole[1].onclick = (ev) => this.IscrtajKontroleKlub_IgraciKluba(host);
        btnsKontrole[2].onclick = (ev) => this.IscrtajKontroleKlub_Brisanje(host);
    }
}