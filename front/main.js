import { Liga } from "./Liga.js";
import { SkSavez } from "./SkSavez.js";
import { Tim } from "./Tim.js";
import { Igrac } from "./Igrac.js"
var listaIgraca = [];
var listaTimova = [];
fetch("https://localhost:5001/controller/PreuzmiTimove")
    .then(p => {

        p.json().then(timovi => {
            timovi.forEach(tim => {
                var liga = new Liga(tim.liga.ligaId, tim.liga.naziv);
                var t = new Tim(tim.id, tim.ime, tim.ligaId, liga, tim.igraci);
                listaTimova.push(t);
            })
        })
    })

var listaLiga = [];
fetch("https://localhost:5001/Liga/Lige")
    .then(p => {
        p.json().then(lige => {
            lige.forEach(liga => {
                var l = new Liga(liga.id, liga.naziv);
                listaLiga.push(l);
            })
        })
    });

fetch("https://localhost:5001/Igrac/Preuzmi")
    .then(p => {

        p.json().then(igraci => {
            igraci.forEach(igrac => {
                var t = igrac.tim;
                var l = new Igrac(igrac.id, igrac.ime, igrac.prezime, igrac.godiste, igrac.visina, t);
                listaIgraca.push(l);
                console.log(l);
            })
            var savez = new SkSavez(listaIgraca, listaTimova, listaLiga);
            savez.crtajNaslovnuStranu(document.body);
        })
    });

//var savez = new SkSavez(listaIgraca, listaTimova, listaUtakmica, listaLiga);
//savez.crtaj(document.body);