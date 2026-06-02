-- =====================================================
-- SCRIPT COMPLET BASE DE DONNÉES MEDIATEK
-- =====================================================

DROP DATABASE IF EXISTS mediatek;
CREATE DATABASE mediatek;
USE mediatek;

DROP USER IF EXISTS  @'localhost';
CREATE USER 'mediatek'@'localhost' IDENTIFIED BY 'mediatek86!';
GRANT ALL PRIVILEGES ON mediatek.* TO 'mediatek'@'localhost';
FLUSH PRIVILEGES;

CREATE TABLE service (
    idservice INT AUTO_INCREMENT PRIMARY KEY,
    nom VARCHAR(50) NOT NULL
);

CREATE TABLE motif (
    idmotif INT AUTO_INCREMENT PRIMARY KEY,
    libelle VARCHAR(128) NOT NULL
);

CREATE TABLE personnel (
    idpersonnel INT AUTO_INCREMENT PRIMARY KEY,
    nom VARCHAR(50) NOT NULL,
    prenom VARCHAR(50) NOT NULL,
    tel VARCHAR(15),
    mail VARCHAR(128),
    idservice INT NOT NULL,
    FOREIGN KEY (idservice) REFERENCES service(idservice)
);

CREATE TABLE absence (
    idpersonnel INT NOT NULL,
    datedebut DATETIME NOT NULL,
    datefin DATETIME NOT NULL,
    idmotif INT NOT NULL,
    PRIMARY KEY (idpersonnel, datedebut),
    FOREIGN KEY (idpersonnel) REFERENCES personnel(idpersonnel),
    FOREIGN KEY (idmotif) REFERENCES motif(idmotif)
);

CREATE TABLE responsable (
    login VARCHAR(64) NOT NULL PRIMARY KEY,
    pwd VARCHAR(64) NOT NULL
);

INSERT INTO service (nom) VALUES 
('Administratif'),
('Médiation culturelle'),
('Prêt');

INSERT INTO motif (libelle) VALUES 
('vacances'),
('maladie'),
('motif familial'),
('congé parental');

INSERT INTO responsable (login, pwd) VALUES 
('responsable', SHA2('admin123', 256));

INSERT INTO personnel (nom, prenom, tel, mail, idservice) VALUES 
('Dupont', 'Jean', '0612345601', 'jean.dupont@mediatek.com', 1),
('Martin', 'Sophie', '0612345602', 'sophie.martin@mediatek.com', 2),
('Bernard', 'Lucas', '0612345603', 'lucas.bernard@mediatek.com', 3),
('Petit', 'Julie', '0612345604', 'julie.petit@mediatek.com', 1),
('Robert', 'Nicolas', '0612345605', 'nicolas.robert@mediatek.com', 2),
('Richard', 'Amélie', '0612345606', 'amelie.richard@mediatek.com', 3);

INSERT INTO absence (idpersonnel, datedebut, datefin, idmotif) VALUES 
(1, '2026-01-05', '2026-01-12', 1),
(1, '2026-07-10', '2026-07-24', 1),
(2, '2026-02-10', '2026-02-17', 1),
(2, '2026-08-01', '2026-08-15', 1),
(3, '2026-03-15', '2026-03-22', 1),
(1, '2026-03-10', '2026-03-12', 2),
(2, '2026-04-15', '2026-04-17', 2),
(3, '2026-05-20', '2026-05-22', 2);