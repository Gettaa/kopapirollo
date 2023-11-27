CREATE DATABASE kopapirollo;
USE kopapirollo;

CREATE TABLE jatekosok (
	ID INT NOT NULL AUTO_INCREMENT,
	nev VARCHAR(255) NOT NULL,
	nyertJatek INT DEFAULT 0,
	vesztettJatek INT DEFAULT 0,
	dontetlenJatek INT DEFAULT 0,
	PRIMARY KEY (ID)
);

INSERT INTO jatekosok (nev) VALUES ("Gép");