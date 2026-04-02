# OPR – Ocenjevanje prostorov

Aplikacija omogoča upravljanje predmetov po prostorih v hiši.
Uporabnik lahko predmete dodaja, briše in premika med prostori, sistem pa pri tem upošteva logična pravila (npr. avto ne more biti v kuhinji).

## Glavne funkcionalnosti

- izbor prostora (Kuhinja, Dnevna soba, Spalnica, Kopalnica, Garaža, Klet),
- dodajanje predmetov iz predlaganega seznama za izbrani prostor,
- brisanje izbranega predmeta iz prostora,
- premikanje predmeta v drug prostor,
- preverjanje pravil, ali je predmet dovoljen v ciljnem prostoru,
- preprečevanje podvojenih predmetov v istem prostoru,
- omejitev števila predmetov glede na kapaciteto prostora.

## Kako uporabljati aplikacijo

1. V zgornjem levem seznamu izberi prostor.
2. V seznamu predmetov izberi predmet, ki ga želiš dodati.
3. Klikni **Dodaj**.
4. Za brisanje označi predmet v listi in klikni **Izbriši**.
5. Za premik predmeta:
   - označi predmet v listi,
   - izberi ciljni prostor,
   - klikni **Premakni izbrano v prostor**.

Če premik ni dovoljen, aplikacija prikaže obvestilo in predmet ostane v izvorni sobi.

## Pravila predmetov

Pravila so centralno definirana v `classLibrary/ItemPravila.cs`.
To pomeni, da isti vir pravil uporablja:
- prikaz predlaganih predmetov v uporabniškem vmesniku,
- validacija pri dodajanju,
- validacija pri premikanju.