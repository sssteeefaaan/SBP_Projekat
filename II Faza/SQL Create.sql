----------------------------------------------------------------TABELE----------------------------------------------------------------

CREATE TABLE ZATVORSKA_JEDINICA(
SIFRA VARCHAR(5) PRIMARY KEY,
NAZIV VARCHAR(60) NOT NULL,
ADRESA VARCHAR(60) NOT NULL,
JMBG_UPRAVNIKA VARCHAR(13),
KAPACITET INTEGER NOT NULL CHECK (KAPACITET > 0),
FREZIM_O VARCHAR(5) NOT NULL CHECK (FREZIM_O IN ('TRUE', 'FALSE')) ,
FREZIM_S VARCHAR(5) NOT NULL CHECK (FREZIM_S IN ('TRUE', 'FALSE')),
FREZIM_PO VARCHAR(5) NOT NULL CHECK (FREZIM_PO IN ('TRUE', 'FALSE'))
);

CREATE TABLE ZAPOSLENI(
-- OSOBA
JMBG VARCHAR(13) PRIMARY KEY,
IME VARCHAR(25) NOT NULL,
PREZIME VARCHAR(25) NOT NULL,
POL VARCHAR(2) CHECK(POL IN ('M', 'Ž')) NOT NULL,
-- ZAPOSLENI
RADNO_MESTO VARCHAR(100) NOT NULL,
DATUM_OBUKE_PPZ DATE NOT NULL,
RADI_U_ZJ VARCHAR(5) NOT NULL,
DATUM_POCETKA_RADA DATE NOT NULL,
TIP VARCHAR(20) CHECK(TIP IN('ADMINISTRACIJA', 'PSIHOLOG', 'RADNIK OBEZBEĐENJA')) NOT NULL,
-- ADMINISTRACIJA
ZANIMANJE VARCHAR(30),
POZICIJA VARCHAR(30),
STRUCNA_SPREMA VARCHAR(7) CHECK(STRUCNA_SPREMA IN ('SREDNJA', 'VIŠA', 'VISOKA')),
UPRAVNIK_ZJ VARCHAR(5),
-- IMAJU_KONTAKT
LP_LEKAR VARCHAR(30),
LP_DATUM DATE,
LP_NAZIV_USTANOVE VARCHAR(60),
LP_ADRESA_USTANOVE VARCHAR(60),
-- PSIHOLOG
S_SPECIJALIZACIJA VARCHAR(30),
S_NAZIV_USTANOVE VARCHAR(60),
-- RADNIK_OBEZBEDJENJA
DORVO_SIFRA VARCHAR(10),
DORVO_POLICIJSKA_UPRAVA VARCHAR(60),
DORVO_DATUM_IZDAVANJA DATE
);

ALTER TABLE ZAPOSLENI
ADD CONSTRAINT RADI_U_FK FOREIGN KEY (RADI_U_ZJ) REFERENCES ZATVORSKA_JEDINICA(SIFRA);

ALTER TABLE ZAPOSLENI
ADD CONSTRAINT UPRAVNIK_ZJ_FK FOREIGN KEY (UPRAVNIK_ZJ) REFERENCES ZATVORSKA_JEDINICA(SIFRA);

ALTER TABLE ZATVORSKA_JEDINICA
ADD CONSTRAINT JMBG_UPRAVNIKA_FK FOREIGN KEY (JMBG_UPRAVNIKA) REFERENCES ZAPOSLENI(JMBG);

CREATE TABLE ZATVORENIK(
JMBG VARCHAR(13) PRIMARY KEY,
IME VARCHAR(25) NOT NULL,
PREZIME VARCHAR(25) NOT NULL,
POL VARCHAR(2) CHECK(POL IN ('M','Ž')) NOT NULL,
ADRESA VARCHAR(60),
BROJ VARCHAR(5) NOT NULL UNIQUE,
DATUM_INKARCERACIJE DATE NOT NULL,
STATUS_USLOVNOG_OTPUSTA VARCHAR(11) CHECK( STATUS_USLOVNOG_OTPUSTA IN('PRIHVAĆEN', 'ODBIJEN', 'RAZMATRA SE')),
DATUM_SLEDECEG_SASLUSANJA DATE,
SIFRA_ZJ VARCHAR(5) REFERENCES ZATVORSKA_JEDINICA(SIFRA)
);

CREATE TABLE FIRMA(
PIB VARCHAR(9) PRIMARY KEY,
NAZIV VARCHAR(60) NOT NULL,
ADRESA VARCHAR(60) NOT NULL,
KONTAKT_TELEFON VARCHAR(15) NOT NULL
);

CREATE TABLE ADVOKAT( 
JMBG VARCHAR(13) PRIMARY KEY,
IME VARCHAR(25) NOT NULL,
PREZIME VARCHAR(25) NOT NULL,
POL VARCHAR(2) CHECK(POL IN ('M', 'Ž')) NOT NULL
);

CREATE TABLE PRESTUP(
ID INTEGER NOT NULL,
JMBG_ZAT VARCHAR(13) NOT NULL,
PUN_NAZIV VARCHAR(100) NOT NULL,
DATUM_PRESTUPA DATE NOT NULL,
MESTO_PRESTUPA VARCHAR(60) NOT NULL,
KATEGORIJA VARCHAR(128) NOT NULL,
OPIS VARCHAR(2048),
MIN_KAZNA_DANI INTEGER NOT NULL CHECK (MIN_KAZNA_DANI >= 0),
MAKS_KAZNA_DANI INTEGER NOT NULL CHECK (MAKS_KAZNA_DANI > 0),
CONSTRAINT PRESTUP_GRANICE CHECK (MIN_KAZNA_DANI <= MAKS_KAZNA_DANI),
CONSTRAINT PRESTUP_PK PRIMARY KEY (ID),
CONSTRAINT PRESTUP_UNQIUE UNIQUE (JMBG_ZAT, PUN_NAZIV, DATUM_PRESTUPA),
CONSTRAINT PRESTUP_ZAT_FK FOREIGN KEY (JMBG_ZAT) REFERENCES ZATVORENIK(JMBG)
ON DELETE CASCADE
);

CREATE TABLE ZASTUPA(
ID INTEGER NOT NULL,
JMBG_ZAT VARCHAR(13) NOT NULL,
JMBG_ADV VARCHAR(13) NOT NULL,
DATUM_POCETKA_SARADNJE DATE NOT NULL,
DATUM_POSLEDNJEG_KONTAKTA DATE,
CONSTRAINT ZASTUPA_PK PRIMARY KEY (ID),
CONSTRAINT ZASTUPA_UNIQUE UNIQUE (JMBG_ZAT, JMBG_ADV),
CONSTRAINT ZASTUPA_ZAT_FK FOREIGN KEY (JMBG_ZAT) REFERENCES ZATVORENIK(JMBG)
ON DELETE CASCADE,
CONSTRAINT ZASTUPA_ADV_FK FOREIGN KEY (JMBG_ADV) REFERENCES ADVOKAT(JMBG)
ON DELETE CASCADE
);

CREATE TABLE POSECUJE(
ID INTEGER NOT NULL,
JMBG_ZAT VARCHAR(13) NOT NULL,
JMBG_ADV VARCHAR(13) NOT NULL,
DT_POCETKA DATE NOT NULL,
DT_KRAJA DATE NOT NULL,
CONSTRAINT POSECUJE_PK PRIMARY KEY (ID),
CONSTRAINT POSECUJE_DATUM CHECK (DT_POCETKA <= DT_KRAJA),
CONSTRAINT POSECUJE_UNIQUE UNIQUE (JMBG_ZAT, JMBG_ADV),
CONSTRAINT POS_ZATV_FK FOREIGN KEY (JMBG_ZAT) REFERENCES ZATVORENIK(JMBG)
ON DELETE CASCADE,
CONSTRAINT POS_ADV_FK FOREIGN KEY (JMBG_ADV) REFERENCES ADVOKAT(JMBG)
);

CREATE TABLE MOZE_DA_ANGAZUJE(
PIB_FIRME VARCHAR(9) NOT NULL, 
SIFRA_ZJ VARCHAR(5) NOT NULL,
CONSTRAINT MDA_PK PRIMARY KEY (PIB_FIRME, SIFRA_ZJ),
CONSTRAINT MDA_FIRMA_FK FOREIGN KEY (PIB_FIRME) REFERENCES FIRMA(PIB)
ON DELETE CASCADE,
CONSTRAINT MDA_ZJ_FK FOREIGN KEY (SIFRA_ZJ) REFERENCES ZATVORSKA_JEDINICA(SIFRA)
ON DELETE CASCADE
);

CREATE TABLE TERMIN_SETNJE(
ID INTEGER NOT NULL,
SIFRA_ZJ VARCHAR(5) NOT NULL,
TERMIN VARCHAR(15) NOT NULL,
CONSTRAINT TERMIN_SETNJE_PK PRIMARY KEY (ID),
CONSTRAINT TERMIN_SETNJE_UNIQUE UNIQUE (SIFRA_ZJ, TERMIN),
CONSTRAINT TS_ZJ_FK FOREIGN KEY (SIFRA_ZJ) REFERENCES ZATVORSKA_JEDINICA(SIFRA)
ON DELETE CASCADE 
);

CREATE TABLE TERMIN_POSETE(
ID INTEGER NOT NULL,
SIFRA_ZJ VARCHAR(5) NOT NULL,
DAN VARCHAR(10) CHECK (DAN IN ('PONEDELJAK', 'UTORAK','SREDA','ČETVRTAK','PETAK','SUBOTA','NEDELJA')) NOT NULL,
PERIOD VARCHAR(15) NOT NULL,
CONSTRAINT TERMIN_POSETE_PK PRIMARY KEY (ID),
CONSTRAINT TERMIN_POSETE_UNIQUE UNIQUE (SIFRA_ZJ, DAN, PERIOD),
CONSTRAINT TERMIN_POSETE_ZJ_FK FOREIGN KEY (SIFRA_ZJ) REFERENCES ZATVORSKA_JEDINICA(SIFRA)
ON DELETE CASCADE
);

CREATE TABLE CELIJSKI_PERIOD(
ID INTEGER NOT NULL,
SIFRA_ZJ VARCHAR(5) NOT NULL,
PERIOD VARCHAR(15) NOT NULL,
CONSTRAINT CELIJSKI_PERIOD_PK PRIMARY KEY (ID),
CONSTRAINT CELIJSKI_PERIOD_UNIQUE UNIQUE (SIFRA_ZJ, PERIOD),
CONSTRAINT CELIJSKI_PERIOD_ZJ_FK FOREIGN KEY (SIFRA_ZJ) REFERENCES ZATVORSKA_JEDINICA(SIFRA)
ON DELETE CASCADE
);

CREATE TABLE ODGOVORNO_LICE (
ID INTEGER NOT NULL,
PIB_FIRME VARCHAR(9) NOT NULL,
JMBG VARCHAR(13) NOT NULL,
IME VARCHAR(25) NOT NULL,
PREZIME VARCHAR(25) NOT NULL,
CONSTRAINT ODG_LICE_PK PRIMARY KEY (ID),
CONSTRAINT ODG_LICE_UNIQUE UNIQUE (PIB_FIRME, JMBG),
CONSTRAINT ODG_LICE_FIRMA_FK FOREIGN KEY (PIB_FIRME) REFERENCES FIRMA(PIB)
);


----------------------------------------------------------------TRIGERI----------------------------------------------------------------


CREATE SEQUENCE PRESTUP_ID_SEQ MINVALUE 1 MAXVALUE 999999 INCREMENT BY 1 START WITH 1 CACHE 20 ORDER NOCYCLE;

CREATE OR REPLACE TRIGGER "PRESTUP_PK"
    BEFORE INSERT
    ON PRESTUP
    REFERENCING NEW AS NEW_VAR
    FOR EACH ROW
BEGIN
    SELECT PRESTUP_ID_SEQ.NEXTVAL INTO :NEW_VAR.ID FROM DUAL;
END;
/

CREATE SEQUENCE ZASTUPA_ID_SEQ MINVALUE 1 MAXVALUE 999999 INCREMENT BY 1 START WITH 1 CACHE 20 ORDER NOCYCLE;

CREATE OR REPLACE TRIGGER "ZASTUPA_PK"
    BEFORE INSERT
    ON ZASTUPA
    REFERENCING NEW AS NEW_VAR
    FOR EACH ROW
BEGIN
    SELECT ZASTUPA_ID_SEQ.NEXTVAL INTO :NEW_VAR.ID FROM DUAL;
END;
/

CREATE SEQUENCE POSECUJE_ID_SEQ MINVALUE 1 MAXVALUE 999999 INCREMENT BY 1 START WITH 1 CACHE 20 ORDER NOCYCLE;

CREATE OR REPLACE TRIGGER "POSECUJE_PK"
    BEFORE INSERT
    ON POSECUJE
    REFERENCING NEW AS NEW_VAR
    FOR EACH ROW
BEGIN
    SELECT POSECUJE_ID_SEQ.NEXTVAL INTO :NEW_VAR.ID FROM DUAL;
END;
/

CREATE SEQUENCE TERMIN_SETNJE_ID_SEQ MINVALUE 1 MAXVALUE 999999 INCREMENT BY 1 START WITH 1 CACHE 20 ORDER NOCYCLE;

CREATE OR REPLACE TRIGGER "TERMIN_SETNJE_PK"
    BEFORE INSERT
    ON TERMIN_SETNJE
    REFERENCING NEW AS NEW_VAR
    FOR EACH ROW
BEGIN
    SELECT TERMIN_SETNJE_ID_SEQ.NEXTVAL INTO :NEW_VAR.ID FROM DUAL;
END;
/

CREATE SEQUENCE TERMIN_POSETE_ID_SEQ MINVALUE 1 MAXVALUE 999999 INCREMENT BY 1 START WITH 1 CACHE 20 ORDER NOCYCLE;

CREATE OR REPLACE TRIGGER "TERMIN_POSETE_PK"
    BEFORE INSERT
    ON TERMIN_POSETE
    REFERENCING NEW AS NEW_VAR
    FOR EACH ROW
BEGIN
    SELECT TERMIN_POSETE_ID_SEQ.NEXTVAL INTO :NEW_VAR.ID FROM DUAL;
END;
/

CREATE SEQUENCE CELIJSKI_PERIOD_ID_SEQ MINVALUE 1 MAXVALUE 999999 INCREMENT BY 1 START WITH 1 CACHE 20 ORDER NOCYCLE;

CREATE OR REPLACE TRIGGER "CELIJSKI_PERIOD_PK"
    BEFORE INSERT
    ON CELIJSKI_PERIOD
    REFERENCING NEW AS NEW_VAR
    FOR EACH ROW
BEGIN
    SELECT CELIJSKI_PERIOD_ID_SEQ.NEXTVAL INTO :NEW_VAR.ID FROM DUAL;
END;
/

CREATE SEQUENCE ODG_LICE_ID_SEQ MINVALUE 1 MAXVALUE 999999 INCREMENT BY 1 START WITH 1 CACHE 20 ORDER NOCYCLE;

CREATE OR REPLACE TRIGGER "ODG_LICE_PK"
    BEFORE INSERT
    ON ODGOVORNO_LICE
    REFERENCING NEW AS NEW_VAR
    FOR EACH ROW
BEGIN
    SELECT ODG_LICE_ID_SEQ.NEXTVAL INTO :NEW_VAR.ID FROM DUAL;
END;
/