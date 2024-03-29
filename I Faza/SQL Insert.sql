--------------------------------------------------------------------------------ZATVORSKA JEDINICA---------------------------------------------------------------------------------
INSERT INTO ZATVORSKA_JEDINICA VALUES ('AAA21', 'Kazneno-popravni zavod "Padinska Skela"', 'Zrenjaninski put bb, 11200 Padinska Skela', null, 160, 'TRUE', 'FALSE', 'FALSE');
INSERT INTO ZATVORSKA_JEDINICA VALUES ('AAB21', 'Kazneno-popravni zavod "Zabeli"', 'Zabela bb, 12102 Požarevac', null, 1300, 'TRUE', 'FALSE', 'TRUE');
INSERT INTO ZATVORSKA_JEDINICA VALUES ('AAC21', 'Okružni zatvor Novi Sad', 'Proleterska 16a, 21000 Novi Sad', null, 304, 'FALSE', 'TRUE', 'FALSE');
INSERT INTO ZATVORSKA_JEDINICA VALUES ('AAD21', 'Okružni zatvor Čačak', 'Cara Dušana bb, 32000 Čačak', null, 110, 'FALSE', 'FALSE', 'TRUE');


-------------------------------------------------------------------------------------ZAPOSLENI-------------------------------------------------------------------------------------
--ADMIN --UPRAVA
INSERT INTO ZAPOSLENI VALUES ('2809965327690', 'Valentina', 'Aleksić', 'Ž', 'Administracija', '12-APR-21');
INSERT INTO ZAPOSLENI VALUES ('2802987679065', 'Milutin', 'Milanković', 'M', 'Administracija', '15-APR-21');
INSERT INTO ZAPOSLENI VALUES ('3001978775698', 'Goran', 'Jovanović', 'M', 'Administracija', '12-JAN-21');
INSERT INTO ZAPOSLENI VALUES ('2209999759711', 'Miljana', 'Simić', 'Ž', 'Administracija', '19-SEP-20');
--ADMIN --KNJIGOVODSTVO
INSERT INTO ZAPOSLENI VALUES ('1212976313145', 'Nenad', 'Nenković', 'M', 'Administracija', '13-MAY-21');
INSERT INTO ZAPOSLENI VALUES ('2208995759711', 'Marijana', 'Stojić', 'Ž', 'Administracija', '03-DEC-20');
INSERT INTO ZAPOSLENI VALUES ('0904999756138', 'Uroš', 'Pešić', 'M', 'Administracija', '03-DEC-20');
INSERT INTO ZAPOSLENI VALUES ('1609988728807', 'Lav', 'Srećković', 'M', 'Administracija', '04-APRIL-21');
--ADMIN --PRAVNA SLUŽBA
INSERT INTO ZAPOSLENI VALUES ('1505985675322', 'Pavle', 'Mijatović', 'M', 'Administracija', '13-MAY-21');
INSERT INTO ZAPOSLENI VALUES ('1302988765432', 'Katarina', 'Kostić', 'Ž', 'Administracija', '03-DEC-20');
INSERT INTO ZAPOSLENI VALUES ('0101997764321', 'Uroš', 'Kostadinović', 'M', 'Administracija', '03-DEC-20');
INSERT INTO ZAPOSLENI VALUES ('1209977237898', 'Stojadin', 'Srećković', 'M', 'Administracija', '04-APRIL-21');
--PSIHOLOZI
INSERT INTO ZAPOSLENI VALUES ('0509997654312', 'Jelica', 'Janić', 'Ž', 'Psiholog', '03-MAR-21');
INSERT INTO ZAPOSLENI VALUES ('0708983834772', 'Svetozar', 'Vučković', 'M', 'Psiholog', '29-SEP-20');
INSERT INTO ZAPOSLENI VALUES ('1509874334210', 'Danica', 'Đorđević', 'Ž', 'Psiholog', '10-AUG-21');
INSERT INTO ZAPOSLENI VALUES ('0107985432341', 'Eleonora', 'Pantić', 'Ž', 'Psiholog', '27-FEB-21');
--OBEZBEĐENJE
INSERT INTO ZAPOSLENI VALUES ('0609974432621', 'Nikola', 'Anđelić', 'M', 'Obezbeđenje', '19-JUL-21');
INSERT INTO ZAPOSLENI VALUES ('2607982273190', 'Branko', 'Ranković', 'M', 'Obezbeđenje', '13-JAN-21');
INSERT INTO ZAPOSLENI VALUES ('2807978458721', 'Dušica', 'Aleksić', 'Ž', 'Obezbeđenje', '28-OCT-20');
INSERT INTO ZAPOSLENI VALUES ('2906974739042', 'Njegoš', 'Harambaša', 'M', 'Obezbeđenje', '09-OCT-20');
INSERT INTO ZAPOSLENI VALUES ('1312989432832', 'Pavle', 'Stojkovič', 'M', 'Obezbeđenje', '28-OCT-20');
INSERT INTO ZAPOSLENI VALUES ('1310967623160', 'Kristijan', 'Nedeljković', 'M', 'Obezbeđenje', '13-SEP-20');
INSERT INTO ZAPOSLENI VALUES ('2712991342432', 'Pavle', 'Stojkovič', 'M', 'Obezbeđenje', '12-AUG-20');
INSERT INTO ZAPOSLENI VALUES ('0808978432562', 'Robert', 'Stojković', 'M', 'Obezbeđenje', '01-FEB-21');


-----------------------------------------------------------------------------------ADMINISTRACIJA----------------------------------------------------------------------------------
INSERT INTO ADMINISTRACIJA VALUES ('2809965327690', 'Uprava', 'Upravnik', 'VISOKA');
INSERT INTO ADMINISTRACIJA VALUES ('2802987679065', 'Uprava', 'Upravnik', 'VISOKA');
INSERT INTO ADMINISTRACIJA VALUES ('3001978775698', 'Uprava', 'Upravnik', 'SREDNJA');
INSERT INTO ADMINISTRACIJA VALUES ('2209999759711', 'Uprava', 'Upravnik', 'VISOKA');

INSERT INTO ADMINISTRACIJA VALUES ('1212976313145', 'Knjigovodstvo', 'Knjigovođa', 'VIŠA');
INSERT INTO ADMINISTRACIJA VALUES ('2208995759711', 'Knjigovodstvo', 'Knjigovođa', 'SREDNJA');
INSERT INTO ADMINISTRACIJA VALUES ('0904999756138', 'Knjigovodstvo', 'Knjigovođa', 'SREDNJA');
INSERT INTO ADMINISTRACIJA VALUES ('1609988728807', 'Knjigovodstvo', 'Knjigovođa', 'VIŠA');

INSERT INTO ADMINISTRACIJA VALUES ('1505985675322', 'Pravna služba', 'Pravnik', 'VISOKA');
INSERT INTO ADMINISTRACIJA VALUES ('1302988765432', 'Pravna služba', 'Pravnik', 'VISOKA');
INSERT INTO ADMINISTRACIJA VALUES ('0101997764321', 'Pravna služba', 'Pravnik', 'VISOKA');
INSERT INTO ADMINISTRACIJA VALUES ('1209977237898', 'Pravna služba', 'Pravnik', 'VIŠA');

UPDATE ZATVORSKA_JEDINICA SET JMBG_UPRAVNIK='2809965327690' WHERE SIFRA='AAA21';
UPDATE ZATVORSKA_JEDINICA SET JMBG_UPRAVNIK='2802987679065' WHERE SIFRA='AAB21';
UPDATE ZATVORSKA_JEDINICA SET JMBG_UPRAVNIK='3001978775698' WHERE SIFRA='AAC21';
UPDATE ZATVORSKA_JEDINICA SET JMBG_UPRAVNIK='2209999759711' WHERE SIFRA='AAD21';

-----------------------------------------------------------------------------------IMAJU_KONTAKT-----------------------------------------------------------------------------------
--PSIHOLOZI
INSERT INTO IMAJU_KONTAKT VALUES ('0509997654312', 'Marijana Novaković', '12-FEB-21', 'Vojnomedicinska akademija', 'Crnotravska 17, 11000 Beograd');
INSERT INTO IMAJU_KONTAKT VALUES ('0708983834772', 'Filip Sretenović', '15-MAR-21', 'Dom zdravlja "Dr. Mladen Stojanović"', 'Kralja Petra I 26/a, 21400 Bačka Palanka');
INSERT INTO IMAJU_KONTAKT VALUES ('1509874334210', 'Kristina Prvulović', '22-APR-21', 'Zavod za javno zdravlje', 'Dr Emila Gavrila 15, 23101 Zrenjanin');
INSERT INTO IMAJU_KONTAKT VALUES ('0107985432341', 'Miodrag Petrović', '25-JAN-21', 'Poliklinika DCM', 'Radanska bb, 16000 Leskovac');
--OBEZBEĐENJE
INSERT INTO IMAJU_KONTAKT VALUES ('0609974432621', 'Marijana Novaković', '12-FEB-21', 'Vojnomedicinska akademija', 'Crnotravska 17, 11000 Beograd');
INSERT INTO IMAJU_KONTAKT VALUES ('2607982273190', 'Marijana Novaković', '12-FEB-21', 'Vojnomedicinska akademija', 'Crnotravska 17, 11000 Beograd');
INSERT INTO IMAJU_KONTAKT VALUES ('2807978458721', 'Filip Sretenović', '15-MAR-21', 'Dom zdravlja "Dr. Mladen Stojanović"', 'Kralja Petra I 26/a, 21400 Bačka Palanka');
INSERT INTO IMAJU_KONTAKT VALUES ('2906974739042', 'Filip Sretenović', '15-MAR-21', 'Dom zdravlja "Dr. Mladen Stojanović"', 'Kralja Petra I 26/a, 21400 Bačka Palanka');
INSERT INTO IMAJU_KONTAKT VALUES ('1312989432832', 'Kristina Prvulović', '22-APR-21', 'Zavod za javno zdravlje', 'Dr Emila Gavrila 15, 23101 Zrenjanin');
INSERT INTO IMAJU_KONTAKT VALUES ('1310967623160', 'Kristina Prvulović', '22-APR-21', 'Zavod za javno zdravlje', 'Dr Emila Gavrila 15, 23101 Zrenjanin');
INSERT INTO IMAJU_KONTAKT VALUES ('2712991342432', 'Miodrag Petrović', '25-JAN-21', 'Poliklinika DCM', 'Radanska bb, 16000 Leskovac');
INSERT INTO IMAJU_KONTAKT VALUES ('0808978432562', 'Miodrag Petrović', '25-JAN-21', 'Poliklinika DCM', 'Radanska bb, 16000 Leskovac');
--PSIHOLOG
INSERT INTO PSIHOLOG VALUES ('0509997654312', 'Adolescentna psihijatrija', 'Univerzitet u Beogradu Medicinski fakultet');
INSERT INTO PSIHOLOG VALUES ('0708983834772', 'Forenzička psihijatrija', 'Medicinski fakultet Univerzitet u Nišu');
INSERT INTO PSIHOLOG VALUES ('1509874334210', 'Medicinska psihijatrija', 'Univerzitet u Beogradu Medicinski fakultet');
INSERT INTO PSIHOLOG VALUES ('0107985432341', 'Psihijatrija u gerijatriji', 'Medicinski fakultet Univerzitet u Nišu');
--OBEZBEĐENJE
INSERT INTO RADNIK_OBEZBEDJENJA VALUES ('0609974432621', '34HGB789JJ', 'Policijska Stanica Savski Venac', '19-JUL-21');
INSERT INTO RADNIK_OBEZBEDJENJA VALUES ('2607982273190', '54SDF231GD', 'Policijska uprava Niš', '13-JAN-21');
INSERT INTO RADNIK_OBEZBEDJENJA VALUES ('2807978458721', '637FV37383', 'Policijska uprava Novi Sad', '28-OCT-20');
INSERT INTO RADNIK_OBEZBEDJENJA VALUES ('2906974739042', '27F37F3GV2', 'Policijska stanica Bor', '09-OCT-20');
INSERT INTO RADNIK_OBEZBEDJENJA VALUES ('1312989432832', '762FDG73D2', 'Policijska stanica Bor', '28-OCT-20');
INSERT INTO RADNIK_OBEZBEDJENJA VALUES ('1310967623160', '9H82D2F23F', 'Policijska uprava Niš', '13-SEP-20');
INSERT INTO RADNIK_OBEZBEDJENJA VALUES ('2712991342432', '27TFZ723GF', 'Policijska Stanica Savski Venac', '12-AUG-20');
INSERT INTO RADNIK_OBEZBEDJENJA VALUES ('0808978432562', '8912UD82H1', 'Policijska uprava Novi Sad', '01-FEB-21');


-------------------------------------------------------------------------------------ZATVORENIK------------------------------------------------------------------------------------
--AAA21
INSERT INTO ZATVORENIK VALUES ('0203995750023', 'Stojan', 'Džehverović', 'M', 'Skadarska 40c1, 11000 Beograd', '16989', '12-MAY-20', 'RAZMATRA SE', '06-JUN-21', 'AAA21');
INSERT INTO ZATVORENIK VALUES ('1407988752119', 'Sloba', 'Radanović', 'M', 'Ulica Narodne omladine, Zrenjanin, 11000 Beograd', '15989', '15-DEC-19', 'RAZMATRA SE', '12-FEB-22', 'AAA21');
INSERT INTO ZATVORENIK VALUES ('1302000750023', 'Vuk', 'Bibić', 'M', 'Nikole Pašića 13, 18000 Niš', '17015', '12-APR-19', 'RAZMATRA SE', '06-JUN-21', 'AAA21');
INSERT INTO ZATVORENIK VALUES ('1107999759131', 'Strahinja', 'Stamenković', 'M', 'Gavrila Principa 31, 16210 Vlasotince', '17413', '15-MAR-21', 'PRIHVAĆEN', '16-JUN-21', 'AAA21');
--AAB21
INSERT INTO ZATVORENIK VALUES ('2011956748912', 'Aneta', 'Simić', 'Ž', 'Besna kobila bb, 17500 Vranje', 'UZ789', '02-JUL-19', 'RAZMATRA SE', '15-DEC-25', 'AAB21');
INSERT INTO ZATVORENIK VALUES ('1208999759118', 'Kristina', 'Stanojević', 'Ž', 'Džervinska 36, 19350 Knjaževac', 'A37HZ', '05-MAY-17', 'RAZMATRA SE', '12-AUG-21', 'AAB21');
INSERT INTO ZATVORENIK VALUES ('1305993741118', 'Petra', 'Marković', 'Ž', 'Vizantijski bulevar 5, 18000 Niš', 'JT9Z2', '04-DEC-15', 'ODBIJEN', '13-MAR-23', 'AAB21');
INSERT INTO ZATVORENIK VALUES ('0209997591541', 'Sofija', 'Stojanović', 'Ž', 'Karađorđeva 109, 17510 Vladičin Han',  'I38MZ', '12-JUN-12','RAZMATRA SE', '10-OCT-21', 'AAB21');
INSERT INTO ZATVORENIK VALUES ('1708978732323', 'Jelena', 'Karleuša', 'Ž', 'Oračka - Zemun, 11000 Beograd',  'JK8JK', '13-SEP-13','ODBIJEN', '17-DEC-24', 'AAB21');
--AAC21
INSERT INTO ZATVORENIK VALUES ('1607997742023', 'Darko', 'Stošić', 'M', 'Rasadnik 2/5, 18000 Niš', 'T1NA3', '05-MAY-20', 'PRIHVAĆEN', '23-JAN-21', 'AAC21');
INSERT INTO ZATVORENIK VALUES ('2302983773221', 'Milan', 'Ranković', 'M', 'Miroslava Antića, 24000 Subotica', 'K01H2', '02-APR-21', 'RAZMATRA SE', '18-SEP-22', 'AAC21');
INSERT INTO ZATVORENIK VALUES ('1809987654126', 'Dušan', 'Nikolić', 'M', 'Anke Frank - Palilula, 11000 Beograd',  'TH98L', '03-OCT-20', 'PRIHVAĆEN', '01-JUN-23', 'AAC21');
INSERT INTO ZATVORENIK VALUES ('0101967554919', 'Osman', 'Agić', 'M', NULL,  'OA20G', '15-MAY-20', 'ODBIJEN', NULL, 'AAC21');
INSERT INTO ZATVORENIK VALUES ('0903966759113', 'Jovan', 'Popović', 'M', 'Nikole Tesle 9, 26000 Pančevo', 'TP27L', '12-JUN-20','RAZMATRA SE', '09-AUG-23', 'AAC21');
--AAD21
INSERT INTO ZATVORENIK VALUES ('0203000768799', 'Stefan', 'Aleksić', 'M', 'Gornje Zuniče bb, 19350 Knjaževac', '16995', '06-SEP-20', 'PRIHVAĆEN', '02-MAR-22', 'AAD21');
INSERT INTO ZATVORENIK VALUES ('2406999755433', 'Kosta', 'Rakić', 'M', '9. Avgust 12, 19350 Knjaževac', '18666', '12-MAR-21', 'ODBIJEN', '24-JUN-21', 'AAD21'); 
INSERT INTO ZATVORENIK VALUES ('0606999728012', 'Luka', 'Obradović', 'M', 'Romanijska 23, 18000 Niš', '95669', '06-SEP-20', 'ODBIJEN', '06-JUN-21', 'AAD21'); 
INSERT INTO ZATVORENIK VALUES ('0505945748024', 'Dobrivoje', 'Pasulj', 'M', 'Kromanjonska 14, 11000 Beograd', '76432', '13-NOV-20','RAZMATRA SE', '22-OCT-21', 'AAD21'); 
INSERT INTO ZATVORENIK VALUES ('1909999738712', 'Nikola', 'Petrović', 'M', 'Grdelica bb, 16220 Leskovac', '17344', '15-AUG-20', 'PRIHVAĆEN', '05-SEP-21', 'AAD21');


---------------------------------------------------------------------------------------FIRME---------------------------------------------------------------------------------------
INSERT INTO FIRMA VALUES ('100234131', 'Krojačka radionica "PECA"', 'Dunavska 31, 11000 Beograd', '0638225611');
INSERT INTO FIRMA VALUES ('102131525', 'Vulkanizer "GAGI"', 'Nikole Pašića, 18000 Niš', '0611765413');
INSERT INTO FIRMA VALUES ('109865782', 'Bravar "ZOKI"', 'Osamnaesti jul 12, 32000 Čačak', '0633765721');


-------------------------------------------------------------------------------------ADVOKATI--------------------------------------------------------------------------------------
INSERT INTO ADVOKAT VALUES ('2109978665119', 'Aleksandar', 'Gavrilović', 'M');
INSERT INTO ADVOKAT VALUES ('1204964525465', 'Milena', 'Kostić', 'Ž');
INSERT INTO ADVOKAT VALUES ('3104988756441', 'Slaviša', 'Stepić', 'M');
INSERT INTO ADVOKAT VALUES ('0303989323255', 'Katarina', 'Stefanović', 'Ž');
INSERT INTO ADVOKAT VALUES ('2103131432452', 'Istok', 'Nikić', 'M');
INSERT INTO ADVOKAT VALUES ('1209972431232', 'Kristijan', 'Antonijević', 'M');
INSERT INTO ADVOKAT VALUES ('0906967212124', 'Ognjenka', 'Lilić', 'Ž');
INSERT INTO ADVOKAT VALUES ('1911988765213', 'Dragutin', 'Simov', 'M');
-------------------------------------------------------------------------------------PRESTUP--------------------------------------------------------------------------------------
INSERT INTO PRESTUP VALUES (NULL, '0203995750023', 'Nehatno lišenje života', '10-May-20', 'Nikole Vujačića 15, 214422 Lazarevac', 'Krivična dela protiv života i tela', 'Ko drugog liši života iz nehata', 182, 1825);
INSERT INTO PRESTUP VALUES (NULL, '1407988752119', 'Odavanje poslovne tajne iz nehata', '30-Jun-18', 'Bulevar Oslobođenja 10a, 400112 Novi Sad', 'Krivično delo protiv privrede', 'Ko neovlašćeno drugom saopšti, preda ili na drugi način učini dostupnim podatke koji predstavljaju poslovnu tajnu ili ko pribavlja takve podatke u nameri da ih preda nepozvanom licu', 182, 1825);
INSERT INTO PRESTUP VALUES (NULL, '1302000750023', 'Izazivanje opasnosti neobezbedjenjem mera zaštite na radu', '21-Apr-18', 'Moše Pijade 12, 19210 Bor', 'Krivična dela protiv opšte sigurnosti čjudi i imovine', 'Ko u rudnicima, fabrikama, radionicama, na gradilištima ili na drugom mestu rada ošteti ili ukloni zaštitne uređaje i time izazove opasnost za život ili telo ljudi ili za imovinu većeg obima', 182, 1095);
INSERT INTO PRESTUP VALUES (NULL, '1107999759131', 'Nesavesno pružanje lekarske pomoći', '30-Mar-19', 'Kneza Mihaila 22c, 104102 Beograd', 'Krivično delo protiv zdravlja ljudi', 'Lekar koji pri pružanju lekarske pomoći primeni očigledno nepodobno sredstvo ili očigledno nepodoban način lečenja ili ne primeni odgovarajuće higijenske mere ili uopšte očigledno nesavesno postupa i time prouzrokuje pogoršanje zdravstvenog stanja nekog lica', 91, 1095);

INSERT INTO PRESTUP VALUES (NULL, '2011956748912', 'Odavanje državne tajne', '12-Dec-18', 'Nemanjina 15, 32000 Čačak', 'Krivična dela protiv ustavnog uređenja i beybednosti republike srbije', ' Ko neovlašćeno nepozvanom licu saopšti, preda ili učini dostupnim podatke ili dokumente koji su mu povereni ili do kojih je na drugi način došao, a koji predstavljaju državnu tajnu', 365, 3650);
INSERT INTO PRESTUP VALUES (NULL, '1208999759118', 'Napad naslužbeno lice u vršenju službene dužnosti', '25-Jun-16', 'Zmaj Jove Jovanovića 5, 19350 Knjaževac', 'Krivična dela protiv državnih organa', 'Ko napadne ili preti da će napasti službeno lice u vršenju službene dužnosti, prilikom izvršenja dela učinilac je  službenom licu nano tešku telesnu povredu', 1095, 4380);
INSERT INTO PRESTUP VALUES (NULL, '1305993741118', 'Nedozvoljen prelaz državne granice i krijumčarenje ljudi', '10-Sep-14', 'Vovjode Stepe 13, 32000 Čačak', 'Krivična dela protiv javnog reda i mira', ' Ko u nameri da sebi ili drugom pribavi kakvu korist, omogućava drugom nedozvoljeni prelaz granice Srbije ili nedozvoljeni boravak ili tranzit kroz Srbiju', 365, 2920);
INSERT INTO PRESTUP VALUES (NULL, '0209997591541', 'Teške telesne povrede', '02-Mar-11', 'Knežopoljska 13, 101801 Palilula', 'Krivična dela protiv života i tela', 'Ko drugog teško telesno povredi ili mu zdravlje naruši tako teško da je usled toga doveden u opasnost život povređenog ili je uništen ili trajno i u znatnoj meri oštećen ili oslabljen neki važan deo njegovog tela ili važan organ ili je prouzrokovana trajna nesposobnost za rad povređenog ili trajno i teško narušenje njegovog zdravlja ili unakaženost, usled dela je nastupila smrt povređenog lica', 730, 4380);
INSERT INTO PRESTUP VALUES (NULL, '1708978732323', 'Prinuda', '10-Sep-19', 'Neznanog Junaka 22, 11040 Beograd', 'Krivična dela protiv slobode i prava čoveka', 'Ko drugog silom ili pretnjom prinudi da nešto učini ili ne učini ili trpi, delo je iyvrseno odo strane kriminalne grupe', 1825, 5475);

INSERT INTO PRESTUP VALUES (NULL, '1607997742023', 'Zlostavljanje i mučenje', '03-May-17', 'Sterijina 15, 26000 Pančevo', 'Krivična dela protiv sloboda i prava čoveka i građanina', 'Ko zlostavlja drugog ili prema njemu postupa na način kojim se vređa ljudsko dostojanstvo', 0, 365);
INSERT INTO PRESTUP VALUES (NULL, '2302983773221', 'Krivična dela protiv izbornih prava', '01-Apr-20', 'Vojska Jugoslavije 13, 290802 Požarevac', 'Davanje i primanje mita u vezi sa glasanjem', 'Ko drugome nudi, daje, obeća nagradu, poklon ili kakvu drugu korist da na izborima ili referendumu glasa ili ne glasa ili da glasa u korist ili protiv određenog lica odnosno predloga', 30, 1095);
INSERT INTO PRESTUP VALUES (NULL, '1809987654126', 'Neovlašćeno otkrivanje tajne', '01-Oct-14', 'Cara Lazara 4, 31210 Požega', 'Krivična dela protiv sloboda i prava čoveka i građanina', 'Advokat, lekar ili drugo lice koje neovlašćeno otkrije tajnu koju je saznalo u vršenju svog poziva', 0, 365);
INSERT INTO PRESTUP VALUES (NULL, '0101967554919', 'Povreda prava pri zapošljavanju i za vreme nezaposlenosti', '10-Mar-15', '7. Septembar, 19000 Zaječar', 'Krivična dela protiv prava po osnovu rada', ' Ko svesnim kršenjem propisa ili na drugi protivpravan način uskrati ili ograniči pravo građana na slobodno zapošljavanje na teritoriji Srbije pod jednakim uslovima', 30, 356);
INSERT INTO PRESTUP VALUES (NULL, '0903966759113', 'Povreda ugleda strane države ili međunarodne organizacije', '09-Jun-16', 'Fadil Franca 15, 40000 Kosovska Mitrovica', 'KRIVIČNA DELA PROTIV ČASTI I UGLEDA', ' Ko javno izloži poruzi stranu državu, njenu zastavu, grb ili himnu', 0, 365);

INSERT INTO PRESTUP VALUES (NULL, '0203000768799', 'Falsifikovanje novca', '04-Sep-20', 'Jug Bogdanova 1, 19350 Knjaževac', 'KRIVIČNA DELA PROTIV PRIVREDE', 'Ko napravi lažan novac u nameri da ga stavi u opticaj kao pravi ili ko u istoj nameri preinači pravi novac', 365, 4380);
INSERT INTO PRESTUP VALUES (NULL, '2406999755433', 'Posredovanje u vršenju prostitucije', '10-Mar-17', 'Četvrtog Jula 2, 19350 Knjaževac', 'KRIVIČNA DELA PROTIV POLNE SLOBODE', 'Ko navodi ili podstiče drugog na prostituciju ili učestvuje u predaji nekog lica drugome radi vršenja prostitucije ili ko putem sredstava javnog informisanja i drugih sličnih sredstava propagira ili reklamira prostituciju', 182, 1825);
INSERT INTO PRESTUP VALUES (NULL, '0606999728012', 'Zlostavljanje i mučenje', '04-Sep-20', 'KretenVille 15, 66666 Satanarevo', 'Krivična dela protiv sloboda i prava čoveka i građanina', 'Ko zlostavlja drugog ili prema njemu postupa na način kojim se vređa ljudsko dostojanstvo', 0, 365);
INSERT INTO PRESTUP VALUES (NULL, '0505945748024', 'Neovlašćeni pristup zaštićenom računaru, računarskoj mreži i elektronskoj obradi podataka', '10-Nov-30', 'Sedmog Jula 15, 18000 Niš', 'KRIVIČNA DELA PROTIV BEZBEDNOSTI RAČUNARSKIH PODATAKA', 'Ko se, kršeći mere zaštite, neovlašćeno uključi u računar ili računarsku mrežu, ili neovlašćeno pristupi elektronskoj obradi podataka', 0, 182);
INSERT INTO PRESTUP VALUES (NULL, '1909999738712', 'Povreda slobode kretanja i nastanjivanja', '19-Aug-18', 'Đure Daničića 13, 16000 Leskovac', 'Krivična dela protiv sloboda i prava čoveka i građanina', 'Ko protivpravno uskrati ili ograniči građaninu Srbije slobodu kretanja ili nastanjivanja na teritoriji Srbije', 0, 365);



---------------------------------------------------------------------------------------RADI_U--------------------------------------------------------------------------------------
--ADMIN--UPRAVA
INSERT INTO RADI_U (JMBG_ZAP, SIFRA_ZJ, DATUM_POCETKA_RADA) VALUES ('2809965327690', 'AAA21', '12-APR-20');
INSERT INTO RADI_U (JMBG_ZAP, SIFRA_ZJ, DATUM_POCETKA_RADA) VALUES ('2802987679065', 'AAB21', '15-APR-18');
INSERT INTO RADI_U (JMBG_ZAP, SIFRA_ZJ, DATUM_POCETKA_RADA) VALUES ('3001978775698', 'AAC21', '12-JAN-15');
INSERT INTO RADI_U (JMBG_ZAP, SIFRA_ZJ, DATUM_POCETKA_RADA) VALUES ('2209999759711', 'AAD21', '19-SEP-18');
INSERT INTO RADI_U (JMBG_ZAP, SIFRA_ZJ, DATUM_POCETKA_RADA) VALUES ('2209999759711', 'AAA21', '19-SEP-18');
--ADMIN --KNJIGOVODSTVO
INSERT INTO RADI_U (JMBG_ZAP, SIFRA_ZJ, DATUM_POCETKA_RADA) VALUES ('1212976313145', 'AAA21', '13-MAY-00');
INSERT INTO RADI_U (JMBG_ZAP, SIFRA_ZJ, DATUM_POCETKA_RADA) VALUES ('2208995759711', 'AAB21', '03-DEC-12');
INSERT INTO RADI_U (JMBG_ZAP, SIFRA_ZJ, DATUM_POCETKA_RADA) VALUES ('0904999756138', 'AAC21', '03-DEC-15');
INSERT INTO RADI_U (JMBG_ZAP, SIFRA_ZJ, DATUM_POCETKA_RADA) VALUES ('1609988728807', 'AAD21', '04-APRIL-20');
--ADMIN --PRAVNA SLUŽBA
INSERT INTO RADI_U (JMBG_ZAP, SIFRA_ZJ, DATUM_POCETKA_RADA) VALUES ('1505985675322', 'AAA21', '13-MAY-13');
INSERT INTO RADI_U (JMBG_ZAP, SIFRA_ZJ, DATUM_POCETKA_RADA) VALUES ('1302988765432', 'AAB21', '03-DEC-12');
INSERT INTO RADI_U (JMBG_ZAP, SIFRA_ZJ, DATUM_POCETKA_RADA) VALUES ('0101997764321', 'AAC21', '03-DEC-13');
INSERT INTO RADI_U (JMBG_ZAP, SIFRA_ZJ, DATUM_POCETKA_RADA) VALUES ('1209977237898', 'AAD21', '04-APRIL-05');
--PSIHOLOZI
INSERT INTO RADI_U (JMBG_ZAP, SIFRA_ZJ, DATUM_POCETKA_RADA) VALUES ('0509997654312', 'AAA21', '03-MAR-04');
INSERT INTO RADI_U (JMBG_ZAP, SIFRA_ZJ, DATUM_POCETKA_RADA) VALUES ('0708983834772', 'AAB21', '29-SEP-12');
INSERT INTO RADI_U (JMBG_ZAP, SIFRA_ZJ, DATUM_POCETKA_RADA) VALUES ('1509874334210', 'AAC21', '10-AUG-18');
INSERT INTO RADI_U (JMBG_ZAP, SIFRA_ZJ, DATUM_POCETKA_RADA) VALUES ('0107985432341', 'AAD21', '27-FEB-08');
--OBEZBEĐENJE
INSERT INTO RADI_U (JMBG_ZAP, SIFRA_ZJ, DATUM_POCETKA_RADA) VALUES ('0609974432621', 'AAA21', '19-JUL-12');
INSERT INTO RADI_U (JMBG_ZAP, SIFRA_ZJ, DATUM_POCETKA_RADA) VALUES ('2607982273190', 'AAA21', '13-JAN-13');
INSERT INTO RADI_U (JMBG_ZAP, SIFRA_ZJ, DATUM_POCETKA_RADA) VALUES ('2807978458721', 'AAB21', '28-OCT-14');
INSERT INTO RADI_U (JMBG_ZAP, SIFRA_ZJ, DATUM_POCETKA_RADA) VALUES ('2906974739042', 'AAB21', '09-OCT-15');
INSERT INTO RADI_U (JMBG_ZAP, SIFRA_ZJ, DATUM_POCETKA_RADA) VALUES ('1312989432832', 'AAC21', '28-OCT-12');
INSERT INTO RADI_U (JMBG_ZAP, SIFRA_ZJ, DATUM_POCETKA_RADA) VALUES ('1310967623160', 'AAC21', '13-SEP-13');
INSERT INTO RADI_U (JMBG_ZAP, SIFRA_ZJ, DATUM_POCETKA_RADA) VALUES ('2712991342432', 'AAD21', '12-AUG-15');
INSERT INTO RADI_U (JMBG_ZAP, SIFRA_ZJ, DATUM_POCETKA_RADA) VALUES ('0808978432562', 'AAD21', '01-FEB-17');


--------------------------------------------------------------------------------------ZASTUPA--------------------------------------------------------------------------------------
--AAA21
INSERT INTO ZASTUPA VALUES (NULL, '0203995750023', '2109978665119', '12-MAY-18', '12-JAN-21');
INSERT INTO ZASTUPA VALUES (NULL, '1407988752119', '2109978665119', '15-DEC-15', '15-MAR-21');
INSERT INTO ZASTUPA VALUES (NULL, '1302000750023', '1204964525465', '12-APR-10', '25-APR-21');
INSERT INTO ZASTUPA VALUES (NULL, '1107999759131', '1204964525465', '15-MAR-19', '13-APR-21');
--AAB21
INSERT INTO ZASTUPA VALUES (NULL, '2011956748912', '3104988756441', '02-JUL-19', '14-JUN-20');
INSERT INTO ZASTUPA VALUES (NULL, '1208999759118', '3104988756441', '05-MAY-17', '02-MAY-21');
INSERT INTO ZASTUPA VALUES (NULL, '1305993741118', '0303989323255', '04-DEC-15', '15-APR-21');
INSERT INTO ZASTUPA VALUES (NULL, '0209997591541', '0303989323255', '12-JUN-12', '15-FEB-21');
INSERT INTO ZASTUPA VALUES (NULL, '1708978732323', '0303989323255', '13-SEP-13', '16-FEB-21');
--AAC21
INSERT INTO ZASTUPA VALUES (NULL, '1607997742023', '2103131432452', '05-MAY-17', '15-NOV-20');
INSERT INTO ZASTUPA VALUES (NULL, '2302983773221', '2103131432452', '02-APR-20', '06-DEC-20');
INSERT INTO ZASTUPA VALUES (NULL, '1809987654126', '2103131432452', '03-OCT-14', '22-JAN-21');
INSERT INTO ZASTUPA VALUES (NULL, '0101967554919', '1209972431232', '15-MAY-15', '26-APR-21');
INSERT INTO ZASTUPA VALUES (NULL, '0903966759113', '1209972431232', '12-JUN-16', '13-JAN-21');
--AAD21
INSERT INTO ZASTUPA VALUES (NULL, '0203000768799', '0906967212124', '06-SEP-20', '10-FEB-21');
INSERT INTO ZASTUPA VALUES (NULL, '2406999755433', '1911988765213', '12-MAR-17', '13-MAR-21');
INSERT INTO ZASTUPA VALUES (NULL, '0606999728012', '0906967212124', '06-SEP-20', '14-MAR-21');
INSERT INTO ZASTUPA VALUES (NULL, '0505945748024', '1911988765213', '13-NOV-13', '26-FEB-21');
INSERT INTO ZASTUPA VALUES (NULL, '1909999738712', '0906967212124', '15-AUG-18', '16-APR-21');


--------------------------------------------------------------------------------------POSECUJE-------------------------------------------------------------------------------------
--AAA21
INSERT INTO POSECUJE VALUES (NULL, '0203995750023', '2109978665119', TO_DATE('12-JAN-21 15:00', 'dd-mon-yy hh24:mi'),TO_DATE('12-JAN-21 15:45', 'dd-mon-yy hh24:mi'));
INSERT INTO POSECUJE VALUES (NULL, '1407988752119', '2109978665119', TO_DATE('15-MAR-21 17:10', 'dd-mon-yy hh24:mi'), TO_DATE('15-MAR-21 20:20', 'dd-mon-yy hh24:mi'));
INSERT INTO POSECUJE VALUES (NULL, '1302000750023', '1204964525465', TO_DATE('25-APR-21 18:45', 'dd-mon-yy hh24:mi'), TO_DATE('25-APR-21 19:10', 'dd-mon-yy hh24:mi'));
INSERT INTO POSECUJE VALUES (NULL, '1107999759131', '1204964525465', TO_DATE('13-APR-21 13:10', 'dd-mon-yy hh24:mi'), TO_DATE('13-APR-21 14:20', 'dd-mon-yy hh24:mi'));
--AAB21
INSERT INTO POSECUJE VALUES (NULL, '2011956748912', '3104988756441', TO_DATE('14-JUN-20 11:35', 'dd-mon-yy hh24:mi'), TO_DATE('14-JUN-20 12:00', 'dd-mon-yy hh24:mi'));
INSERT INTO POSECUJE VALUES (NULL, '1208999759118', '3104988756441', TO_DATE('02-MAY-21 18:23', 'dd-mon-yy hh24:mi'), TO_DATE('02-MAY-21 20:22', 'dd-mon-yy hh24:mi'));
INSERT INTO POSECUJE VALUES (NULL, '1305993741118', '0303989323255', TO_DATE('15-APR-21 14:18', 'dd-mon-yy hh24:mi'), TO_DATE('15-APR-21 14:50', 'dd-mon-yy hh24:mi'));
INSERT INTO POSECUJE VALUES (NULL, '0209997591541', '0303989323255', TO_DATE('15-FEB-21 09:10', 'dd-mon-yy hh24:mi'), TO_DATE('15-FEB-21 11:00', 'dd-mon-yy hh24:mi'));
INSERT INTO POSECUJE VALUES (NULL, '1708978732323', '0303989323255', TO_DATE('16-FEB-21 08:00', 'dd-mon-yy hh24:mi'), TO_DATE('16-FEB-21 09:33', 'dd-mon-yy hh24:mi'));
--AAC21
INSERT INTO POSECUJE VALUES (NULL, '1607997742023', '2103131432452', TO_DATE('15-NOV-20 17:50', 'dd-mon-yy hh24:mi'), TO_DATE('15-NOV-20 18:30', 'dd-mon-yy hh24:mi'));
INSERT INTO POSECUJE VALUES (NULL, '2302983773221', '2103131432452', TO_DATE('06-DEC-20 13:20', 'dd-mon-yy hh24:mi'), TO_DATE('06-DEC-20 14:10', 'dd-mon-yy hh24:mi'));
INSERT INTO POSECUJE VALUES (NULL, '1809987654126', '2103131432452', TO_DATE('22-JAN-21 14:45', 'dd-mon-yy hh24:mi'), TO_DATE('22-JAN-21 16:20', 'dd-mon-yy hh24:mi'));
INSERT INTO POSECUJE VALUES (NULL, '0101967554919', '1209972431232', TO_DATE('26-APR-21 12:11', 'dd-mon-yy hh24:mi'), TO_DATE('26-APR-21 13:50', 'dd-mon-yy hh24:mi'));
INSERT INTO POSECUJE VALUES (NULL, '0903966759113', '1209972431232', TO_DATE('13-JAN-21 12:18', 'dd-mon-yy hh24:mi'), TO_DATE('13-JAN-21 14:11', 'dd-mon-yy hh24:mi'));
--AAD21
INSERT INTO POSECUJE VALUES (NULL, '0203000768799', '0906967212124', TO_DATE('10-FEB-21 14:20', 'dd-mon-yy hh24:mi'), TO_DATE('10-FEB-21 15:50', 'dd-mon-yy hh24:mi'));
INSERT INTO POSECUJE VALUES (NULL, '2406999755433', '1911988765213', TO_DATE('13-MAR-21 11:45', 'dd-mon-yy hh24:mi'), TO_DATE('13-MAR-21 12:55', 'dd-mon-yy hh24:mi'));
INSERT INTO POSECUJE VALUES (NULL, '0606999728012', '0906967212124', TO_DATE('14-MAR-21 12:34', 'dd-mon-yy hh24:mi'), TO_DATE('14-MAR-21 14:10', 'dd-mon-yy hh24:mi'));
INSERT INTO POSECUJE VALUES (NULL, '0505945748024', '1911988765213', TO_DATE('26-FEB-21 15:40', 'dd-mon-yy hh24:mi'), TO_DATE('26-FEB-21 16:50', 'dd-mon-yy hh24:mi'));
INSERT INTO POSECUJE VALUES (NULL, '1909999738712', '0906967212124', TO_DATE('16-APR-21 11:11', 'dd-mon-yy hh24:mi'), TO_DATE('16-APR-21 12:43', 'dd-mon-yy hh24:mi'));



----------------------------------------------------------------------------------MOZE_DA_ANGAZUJE---------------------------------------------------------------------------------
INSERT INTO MOZE_DA_ANGAZUJE VALUES ('100234131', 'AAA21');
INSERT INTO MOZE_DA_ANGAZUJE VALUES ('100234131', 'AAB21');
INSERT INTO MOZE_DA_ANGAZUJE VALUES ('102131525', 'AAA21');
INSERT INTO MOZE_DA_ANGAZUJE VALUES ('102131525', 'AAB21');
INSERT INTO MOZE_DA_ANGAZUJE VALUES ('109865782', 'AAB21');


-----------------------------------------------------------------------------------TERMIN_SETNJE-----------------------------------------------------------------------------------
INSERT INTO TERMIN_SETNJE VALUES (NULL, 'AAC21', '07:00 - 08:00h');
INSERT INTO TERMIN_SETNJE VALUES (NULL, 'AAC21', '14:00 - 16:00h');
INSERT INTO TERMIN_SETNJE VALUES (NULL, 'AAC21', '18:30 - 20:30h');


-----------------------------------------------------------------------------------TERMIN_POSETE-----------------------------------------------------------------------------------
INSERT INTO TERMIN_POSETE VALUES (NULL, 'AAC21', 'PONEDELJAK', '13:00 - 15:00h');
INSERT INTO TERMIN_POSETE VALUES (NULL, 'AAC21', 'SREDA', '15:00 - 18:00h');
INSERT INTO TERMIN_POSETE VALUES (NULL, 'AAC21', 'PETAK', '14:30 - 15:45h');
INSERT INTO TERMIN_POSETE VALUES (NULL, 'AAC21', 'NEDELJA', '12:00 - 13:00h');


----------------------------------------------------------------------------------CELIJSKI_PERIOD----------------------------------------------------------------------------------
INSERT INTO CELIJSKI_PERIOD VALUES (NULL, 'AAA21', '21:00 - 06:00h');
INSERT INTO CELIJSKI_PERIOD VALUES (NULL, 'AAA21', '12:00 - 14:00h');
INSERT INTO CELIJSKI_PERIOD VALUES (NULL, 'AAB21', '22:00 - 06:00h');
INSERT INTO CELIJSKI_PERIOD VALUES (NULL, 'AAB21', '12:30 - 13:30h');
INSERT INTO CELIJSKI_PERIOD VALUES (NULL, 'AAD21', '21:30 - 05:30h');


-----------------------------------------------------------------------------------ODGOVORNO_LICE----------------------------------------------------------------------------------
INSERT INTO ODGOVORNO_LICE VALUES (NULL, '100234131', '0712986764321', 'Petar', 'Petrović');
INSERT INTO ODGOVORNO_LICE VALUES (NULL, '100234131', '0911978654321', 'Žizela', 'Ostojević');
INSERT INTO ODGOVORNO_LICE VALUES (NULL, '102131525', '1212982672190', 'Dragan', 'Belogrlić');
INSERT INTO ODGOVORNO_LICE VALUES (NULL, '109865782', '0111988675211', 'Zoran', 'Krstić');