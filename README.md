# opr-ocenjevanje
opr-ocenjevanje
Aplikacija za upravljanje inventarja prostorov v stanovanju. Omogoča dodajanje, odstranjevanje in premikanje predmetov med različnimi prostori (Kuhinja, Dnevna soba, Spalnica, Kopalnica, Garaža, Klet) ob upoštevanju pravil, kateri predmeti sodijo v katere prostore.

Sistemske zahteve

Windows 10 ali novejši
.NET Framework 4.7.2
Visual Studio 2019 ali novejši (za prevajanje)


Namestitev in zagon

Klonirajte repozitorij:

   git clone https://github.com/<uporabnisko-ime>/opr-ocenjevanje.git

Odprite datoteko opr-ocenjevanje.sln v Visual Studiu.
Prevedite rešitev z Build > Build Solution (Ctrl+Shift+B).
Zaženite aplikacijo s tipko F5.


Uporaba

V levem spustnem meniju izberite prostor.
V srednjem spustnem meniju izberite predmet (prikazani so le predmeti, ki sodijo v izbrani prostor).
Kliknite Dodaj za dodajanje predmeta v prostor.
Označite predmet na seznamu in kliknite Odstrani za odstranitev.
Izberite ciljni prostor v desnem spustnem meniju in kliknite Premakni za premik označenega predmeta.


Struktura projekta
opr-ocenjevanje/
├── opr-ocenjevanje/       # Windows Forms projekt (UI)
│   ├── Form1.cs
│   ├── Form1.Designer.cs
│   └── Program.cs
├── classLibrary/          # Knjižnica razredov
│   ├── Prostor.cs
│   ├── Stvar.cs
│   ├── ItemPravila.cs
│   ├── DnevnaSoba.cs
│   ├── Spalnica.cs
│   ├── Kuhinja.cs
│   ├── Kopalnica.cs
│   ├── Garaza.cs
│   └── Klet.cs
└── opr-ocenjevanje.sln
