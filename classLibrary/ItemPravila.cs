using System;
using System.Collections.Generic;

namespace classLibrary
{
    // Enostaven model pravila: predmet + prostori, kjer je dovoljen.
    public class PraviloPredmeta
    {
        public string ImePredmeta { get; }
        public List<string> DovoljeniProstori { get; }

        // params da ni treba delat posebi list-a
        // 
        public PraviloPredmeta(string imePredmeta, params string[] dovoljeniProstori)
        {
            // Shrani ime predmeta.
            ImePredmeta = imePredmeta;
            // Ustvari novo listo iz podanih prostorov.
            DovoljeniProstori = new List<string>(dovoljeniProstori);
        }
    }

    // Centralna pravila: kateri predmet je dovoljen v katerih prostorih.
    public static class ItemPravila
    {
        // Tukaj ustvarimo GLAVNO listo pravil.
        // Vsaka vrstica je: predmet + prostori, kjer je dovoljen.
        private static readonly List<PraviloPredmeta> Pravila = new List<PraviloPredmeta>
        {
            new PraviloPredmeta("zobna ščetka", "Kopalnica", "Spalnica", "Garaža", "Klet"),
            new PraviloPredmeta("zobna pasta", "Kopalnica", "Spalnica", "Garaža", "Klet"),
            new PraviloPredmeta("milo", "Kopalnica", "Kuhinja", "Klet"),
            new PraviloPredmeta("brisača", "Kopalnica", "Spalnica", "Klet"),
            new PraviloPredmeta("sušilec za lase", "Kopalnica", "Spalnica"),
            new PraviloPredmeta("pralni prašek", "Kopalnica", "Klet"),
            new PraviloPredmeta("koš za perilo", "Kopalnica", "Spalnica", "Klet"),

            new PraviloPredmeta("avto", "Garaža"),
            new PraviloPredmeta("motor", "Garaža"),
            new PraviloPredmeta("kolo", "Garaža", "Klet"),
            new PraviloPredmeta("orodje", "Garaža", "Klet"),
            new PraviloPredmeta("kompresor", "Garaža", "Klet"),
            new PraviloPredmeta("akumulator", "Garaža", "Klet"),
            new PraviloPredmeta("kanister", "Garaža", "Klet"),

            new PraviloPredmeta("hladilnik", "Kuhinja", "Garaža"),
            new PraviloPredmeta("zamrzovalnik", "Kuhinja", "Klet", "Garaža"),
            new PraviloPredmeta("štedilnik", "Kuhinja"),
            new PraviloPredmeta("mikrovalovka", "Kuhinja"),
            new PraviloPredmeta("pečica", "Kuhinja"),
            new PraviloPredmeta("krožnik", "Kuhinja", "Dnevna soba"),
            new PraviloPredmeta("kozarec", "Kuhinja", "Dnevna soba"),
            new PraviloPredmeta("jedilna miza", "Kuhinja", "Dnevna soba"),

            new PraviloPredmeta("postelja", "Spalnica"),
            new PraviloPredmeta("omara", "Spalnica"),
            new PraviloPredmeta("nočna luč", "Spalnica", "Dnevna soba"),
            new PraviloPredmeta("odeja", "Spalnica", "Dnevna soba"),
            new PraviloPredmeta("blazina", "Spalnica", "Dnevna soba"),
            new PraviloPredmeta("pisalna miza", "Spalnica", "Dnevna soba"),
            new PraviloPredmeta("stol", "Spalnica", "Kuhinja", "Dnevna soba", "Klet"),

            new PraviloPredmeta("kavč", "Dnevna soba"),
            new PraviloPredmeta("TV", "Dnevna soba", "Spalnica"),
            new PraviloPredmeta("mizica", "Dnevna soba"),
            new PraviloPredmeta("daljinec", "Dnevna soba", "Spalnica"),
            new PraviloPredmeta("zvočnik", "Dnevna soba", "Spalnica"),
            new PraviloPredmeta("knjižna polica", "Dnevna soba", "Spalnica", "Klet"),

            new PraviloPredmeta("škatla", "Klet", "Garaža"),
            new PraviloPredmeta("konzerva", "Klet", "Kuhinja"),
            new PraviloPredmeta("polica", "Klet", "Garaža"),
            new PraviloPredmeta("orodna omara", "Klet", "Garaža"),
            new PraviloPredmeta("barva", "Klet", "Garaža"),
            new PraviloPredmeta("sesalec", "Klet", "Garaža", "Spalnica"),
        };


        // Če ni v pravilih -> ne spustimo, da ne bo čudnih kombinacij.
        public static bool LahkoVProstoru(string imePredmeta, string imeProstora)
        {

            if (string.IsNullOrWhiteSpace(imePredmeta) || string.IsNullOrWhiteSpace(imeProstora))
                return false;

            string predmet = imePredmeta.Trim();
            string prostor = imeProstora.Trim();

            // Najprej najdemo pravilo za točno ta predmet.
            foreach (var pravilo in Pravila)
            {
                if (!string.Equals(pravilo.ImePredmeta, predmet, StringComparison.OrdinalIgnoreCase))
                    continue;

                // Ko najdemo predmet, preverimo še njegove dovoljene prostore.
                foreach (var dovoljenProstor in pravilo.DovoljeniProstori)
                {
                    if (string.Equals(dovoljenProstor, prostor, StringComparison.OrdinalIgnoreCase))
                        return true;
                    //predmet obstaja in prostor je med dovoljenimi
                }

                // Predmet obstaja, ampak prostor ni med dovoljenimi
                return false;
            }

            // Predmeta sploh ni v pravilih -> prepovedano.
            return false;
        }

        // vrne seznam stvari za combobox glede na izbran prostor.
        public static IReadOnlyList<string> PredlaganeZaProstor(string imeProstora)
        {
            // Rezultat bo seznam imen predmetov za combobox.
            var rezultat = new List<string>();

            if (string.IsNullOrWhiteSpace(imeProstora))
                return rezultat;

            string prostor = imeProstora.Trim();

            // Gremo čez vsa pravila in pobrskamo, katera dovolijo trenutni prostor.
            foreach (var pravilo in Pravila)
            {
                foreach (var dovoljenProstor in pravilo.DovoljeniProstori)
                {
                    if (string.Equals(dovoljenProstor, prostor, StringComparison.OrdinalIgnoreCase))
                    {
                        // Če paše, dodamo ime predmeta v rezultat.
                        rezultat.Add(pravilo.ImePredmeta);
                        // break: ni treba več gledat drugih prostorov istega pravila.
                        break;
                    }
                }
            }

            rezultat.Sort(StringComparer.OrdinalIgnoreCase);
            return rezultat;
        }
    }
}
