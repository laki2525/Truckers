**TRUCKERS** je desktop aplikacija koja prati kretanje kamiona i paketa izmedju gradova. Aplikacija omogucava dodavanje novih gradova i autoputeva, dodavanje kamiona, kreiranje paketa, ubacivanje paketa u kamion i podesavanje destinacije paketa. Pored toga moguce je pracenje pomocu NeoDash i azuriranje lokacije kamiona koji dostavlja paket, pretraga paketa i kamiona kao i njhovo brisanje.

## Uputstvo za pokretanje
1. Potrebno je instalirati **APOC** plugin za neo4j bazu.

## Kratko uputstvo za koriscenje
### Dodavanje / Brisanje
U ovoj formi je moguce dodavanje ovih gradova uu bazi, autoputeva izmedju dva grada, dodavanje kamiona i kreiranje paketa.
U boxu "Ubacivanje posiljke u kamion" izlistavaju se slobodne posiljke, na osnovu toga se bira slobodan kamion iz istog grada koji moze da preveze tu posiljku i na kraju destinacija posiljke.

### Upravljanje kamionima
Klikom na dugme "Upravljanje" na pocetnoj formi otvara se forma za pracenje i azuriranje lokacije kamiona koji nose pakete.

 ![new dashboard](img/Manage_LoadData.png?raw=true)
 Pri prvom pokretanju aplikacije potrebno je kreirati novi dashboard sa podacima koji su izlistani u formi.

 ![load](img/Manage_NewDashboard.png?raw=true)
 Nakon povezivanja potrebno je kopirati dashboard konfiguraciju klikom na dugme koje se nalazi na formi. Konfiguraciju nalepiti u Load opciji koja se nalazi sa leve strane.

 Nakon toga dashboard je uspesno konfigurisan i vidimo prikaz mape.
 Sa padajuceg menija biramo kamion koji dostavlja posiljku. Klikom na "Azuriraj kamion" njegova lokacija se pomera na sledeci grad, sve dok ne stigne do odredista.
 Mapa se azurira svakih 10 sekundi (moze se podesiti drugacije).