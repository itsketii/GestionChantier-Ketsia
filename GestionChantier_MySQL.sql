-- ============================================================================
--  GestionChantier - Base de données MySQL (équivalent de dbGestionChantierKetsia SQL Server)
--  Compatible MySQL 8.x / phpMyAdmin (onglet SQL : le script gère lui-même le DELIMITER)
--  Comptes de démonstration : admin / Admin@2026 - gestion / Gestion@2026 - consult / Consult@2026
-- ============================================================================
DROP DATABASE IF EXISTS dbGestionChantierKetsia;
CREATE DATABASE dbGestionChantierKetsia CHARACTER SET utf8mb4;
USE dbGestionChantierKetsia;

-- ----------------------------------------------------------------------------
-- TABLES
-- ----------------------------------------------------------------------------
CREATE TABLE client (
    client_id INT NOT NULL AUTO_INCREMENT,
    client_nom VARCHAR(100) NOT NULL,
    client_telephone VARCHAR(100) NOT NULL,
    client_email VARCHAR(100) NOT NULL,
    CONSTRAINT pk_client PRIMARY KEY (client_id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE chantier (
    chantier_id INT NOT NULL AUTO_INCREMENT,
    chantier_nom VARCHAR(100) NOT NULL,
    chantier_adresse VARCHAR(100) NOT NULL,
    chantier_statut VARCHAR(100) NOT NULL,
    chantier_date_debut DATE NOT NULL,
    chantier_date_fin DATE NOT NULL,
    chantier_budget DECIMAL(12,2) NOT NULL,
    client_id INT NOT NULL,
    CONSTRAINT pk_chantier PRIMARY KEY (chantier_id),
    CONSTRAINT fk_chantier_client_id FOREIGN KEY (client_id) REFERENCES client (client_id),
    CONSTRAINT ck_chantier_1 CHECK (chantier_budget >= 0),
    CONSTRAINT ck_chantier_2 CHECK (chantier_date_fin >= chantier_date_debut)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE phase (
    phase_id INT NOT NULL AUTO_INCREMENT,
    phase_libelle VARCHAR(100) NOT NULL,
    phase_ordre INT NOT NULL,
    chantier_id INT NOT NULL,
    CONSTRAINT pk_phase PRIMARY KEY (phase_id),
    CONSTRAINT fk_phase_chantier_id FOREIGN KEY (chantier_id) REFERENCES chantier (chantier_id),
    CONSTRAINT ck_phase_1 CHECK (phase_ordre > 0)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE intervenant (
    intervenant_id INT NOT NULL AUTO_INCREMENT,
    intervenant_nom VARCHAR(255) NOT NULL,
    intervenant_specialite VARCHAR(100) NOT NULL,
    intervenant_taux_horaire DECIMAL(10,2) NOT NULL,
    CONSTRAINT pk_intervenant PRIMARY KEY (intervenant_id),
    CONSTRAINT ck_intervenant_1 CHECK (intervenant_taux_horaire >= 0)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE service_travail (
    ser_trav_id INT NOT NULL AUTO_INCREMENT,
    ser_trav_nom VARCHAR(100) NOT NULL,
    `type` VARCHAR(10) NOT NULL,
    phase_id INT NOT NULL,
    intervenant_id INT NOT NULL,
    CONSTRAINT pk_service_travail PRIMARY KEY (ser_trav_id),
    CONSTRAINT fk_service_travail_phase_id FOREIGN KEY (phase_id) REFERENCES phase (phase_id),
    CONSTRAINT fk_service_travail_intervenant_id FOREIGN KEY (intervenant_id) REFERENCES intervenant (intervenant_id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE fournisseur (
    fournisseur_id INT NOT NULL AUTO_INCREMENT,
    fournisseur_nom VARCHAR(100) NOT NULL,
    fournisseur_adresse VARCHAR(100) NOT NULL,
    fournisseur_telephone VARCHAR(100) NOT NULL,
    fournisseur_mail VARCHAR(100) NOT NULL,
    CONSTRAINT pk_fournisseur PRIMARY KEY (fournisseur_id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE article (
    article_id INT NOT NULL AUTO_INCREMENT,
    article_nom VARCHAR(100) NOT NULL,
    article_unite VARCHAR(50) NOT NULL,
    article_prix_unitaire DECIMAL(12,2) NOT NULL,
    CONSTRAINT pk_article PRIMARY KEY (article_id),
    CONSTRAINT ck_article_1 CHECK (article_prix_unitaire >= 0)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE facture_achat (
    facture_id INT NOT NULL AUTO_INCREMENT,
    facture_total_ttc DECIMAL(12,2) NOT NULL,
    facture_date DATE NOT NULL,
    fournisseur_id INT NOT NULL,
    CONSTRAINT pk_facture_achat PRIMARY KEY (facture_id),
    CONSTRAINT fk_facture_achat_fournisseur_id FOREIGN KEY (fournisseur_id) REFERENCES fournisseur (fournisseur_id),
    CONSTRAINT ck_facture_achat_1 CHECK (facture_total_ttc >= 0)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE achat (
    achat_id INT NOT NULL AUTO_INCREMENT,
    achat_date DATE NOT NULL,
    achat_description VARCHAR(255) NOT NULL,
    chantier_id INT NOT NULL,
    facture_id INT NOT NULL,
    CONSTRAINT pk_achat PRIMARY KEY (achat_id),
    CONSTRAINT fk_achat_chantier_id FOREIGN KEY (chantier_id) REFERENCES chantier (chantier_id),
    CONSTRAINT fk_achat_facture_id FOREIGN KEY (facture_id) REFERENCES facture_achat (facture_id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE porte_sur (
    achat_id INT NOT NULL,
    article_id INT NOT NULL,
    quantite INT NOT NULL,
    prix_achat DECIMAL(12,2) NOT NULL,
    CONSTRAINT pk_porte_sur PRIMARY KEY (achat_id, article_id),
    CONSTRAINT fk_porte_sur_achat_id FOREIGN KEY (achat_id) REFERENCES achat (achat_id) ON DELETE CASCADE,
    CONSTRAINT fk_porte_sur_article_id FOREIGN KEY (article_id) REFERENCES article (article_id),
    CONSTRAINT ck_porte_sur_1 CHECK (quantite > 0),
    CONSTRAINT ck_porte_sur_2 CHECK (prix_achat >= 0)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE reglement (
    reglement_id INT NOT NULL AUTO_INCREMENT,
    reglement_date DATE NOT NULL,
    reglement_montant DECIMAL(12,2) NOT NULL,
    achat_id INT NULL,
    ser_trav_id INT NULL,
    CONSTRAINT pk_reglement PRIMARY KEY (reglement_id),
    CONSTRAINT fk_reglement_achat_id FOREIGN KEY (achat_id) REFERENCES achat (achat_id),
    CONSTRAINT fk_reglement_ser_trav_id FOREIGN KEY (ser_trav_id) REFERENCES service_travail (ser_trav_id),
    CONSTRAINT ck_reglement_1 CHECK (reglement_montant > 0),
    CONSTRAINT ck_reglement_2 CHECK ((achat_id IS NULL) <> (ser_trav_id IS NULL))
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE controle_qualite (
    controle_id INT NOT NULL AUTO_INCREMENT,
    controle_date DATE NOT NULL,
    ser_trav_id INT NOT NULL,
    CONSTRAINT pk_controle_qualite PRIMARY KEY (controle_id),
    CONSTRAINT fk_controle_qualite_ser_trav_id FOREIGN KEY (ser_trav_id) REFERENCES service_travail (ser_trav_id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE rapport_controle (
    rapport_id INT NOT NULL AUTO_INCREMENT,
    rapport_date DATE NOT NULL,
    rapport_recommandation TEXT NOT NULL,
    controle_id INT NOT NULL,
    CONSTRAINT pk_rapport_controle PRIMARY KEY (rapport_id),
    CONSTRAINT fk_rapport_controle_controle_id FOREIGN KEY (controle_id) REFERENCES controle_qualite (controle_id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE utilisateur (
    utilisateur_id                INT          NOT NULL AUTO_INCREMENT,
    utilisateur_login             VARCHAR(50)  NOT NULL,
    utilisateur_nom_complet       VARCHAR(100) NOT NULL,
    utilisateur_mot_de_passe_hash CHAR(64)     NOT NULL,
    utilisateur_sel               CHAR(36)     NOT NULL,
    utilisateur_role              VARCHAR(20)  NOT NULL,
    utilisateur_actif             TINYINT(1)   NOT NULL DEFAULT 1,
    CONSTRAINT pk_utilisateur PRIMARY KEY (utilisateur_id),
    CONSTRAINT uq_utilisateur_login UNIQUE (utilisateur_login),
    CONSTRAINT ck_utilisateur_role CHECK (utilisateur_role IN ('Admin','Gestionnaire','Consultant'))
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- ----------------------------------------------------------------------------
-- PROCÉDURES STOCKÉES
-- ----------------------------------------------------------------------------
DELIMITER $$

CREATE PROCEDURE sp_client_create(
    IN p_client_nom VARCHAR(100),
    IN p_client_telephone VARCHAR(100),
    IN p_client_email VARCHAR(100),
    OUT p_id INT)
BEGIN
    INSERT INTO client (client_nom, client_telephone, client_email)
    VALUES (p_client_nom, p_client_telephone, p_client_email);
    SET p_id = LAST_INSERT_ID();
END$$

CREATE PROCEDURE sp_client_get(IN p_id INT)
BEGIN
    SELECT t.*
    FROM client t 
    WHERE t.client_id = p_id;
END$$

CREATE PROCEDURE sp_client_update(
    IN p_id INT,
    IN p_client_nom VARCHAR(100),
    IN p_client_telephone VARCHAR(100),
    IN p_client_email VARCHAR(100))
BEGIN
    UPDATE client SET
        client_nom = p_client_nom,
        client_telephone = p_client_telephone,
        client_email = p_client_email
    WHERE client_id = p_id;
END$$

CREATE PROCEDURE sp_client_delete(IN p_id INT)
BEGIN
    DELETE FROM client WHERE client_id = p_id;
END$$

CREATE PROCEDURE sp_client_list()
BEGIN
    SELECT t.*
    FROM client t 
    ORDER BY t.client_nom;
END$$

CREATE PROCEDURE sp_chantier_create(
    IN p_chantier_nom VARCHAR(100),
    IN p_chantier_adresse VARCHAR(100),
    IN p_chantier_statut VARCHAR(100),
    IN p_chantier_date_debut DATE,
    IN p_chantier_date_fin DATE,
    IN p_chantier_budget DECIMAL(12,2),
    IN p_client_id INT,
    OUT p_id INT)
BEGIN
    INSERT INTO chantier (chantier_nom, chantier_adresse, chantier_statut, chantier_date_debut, chantier_date_fin, chantier_budget, client_id)
    VALUES (p_chantier_nom, p_chantier_adresse, p_chantier_statut, p_chantier_date_debut, p_chantier_date_fin, p_chantier_budget, p_client_id);
    SET p_id = LAST_INSERT_ID();
END$$

CREATE PROCEDURE sp_chantier_get(IN p_id INT)
BEGIN
    SELECT t.*, j1.client_nom AS client_nom, (SELECT COALESCE(SUM(ps.quantite * ps.prix_achat),0) FROM achat a INNER JOIN porte_sur ps ON ps.achat_id = a.achat_id WHERE a.chantier_id = t.chantier_id) AS depense_ht
    FROM chantier t INNER JOIN client j1 ON j1.client_id = t.client_id
    WHERE t.chantier_id = p_id;
END$$

CREATE PROCEDURE sp_chantier_update(
    IN p_id INT,
    IN p_chantier_nom VARCHAR(100),
    IN p_chantier_adresse VARCHAR(100),
    IN p_chantier_statut VARCHAR(100),
    IN p_chantier_date_debut DATE,
    IN p_chantier_date_fin DATE,
    IN p_chantier_budget DECIMAL(12,2),
    IN p_client_id INT)
BEGIN
    UPDATE chantier SET
        chantier_nom = p_chantier_nom,
        chantier_adresse = p_chantier_adresse,
        chantier_statut = p_chantier_statut,
        chantier_date_debut = p_chantier_date_debut,
        chantier_date_fin = p_chantier_date_fin,
        chantier_budget = p_chantier_budget,
        client_id = p_client_id
    WHERE chantier_id = p_id;
END$$

CREATE PROCEDURE sp_chantier_delete(IN p_id INT)
BEGIN
    DELETE FROM chantier WHERE chantier_id = p_id;
END$$

CREATE PROCEDURE sp_chantier_list()
BEGIN
    SELECT t.*, j1.client_nom AS client_nom, (SELECT COALESCE(SUM(ps.quantite * ps.prix_achat),0) FROM achat a INNER JOIN porte_sur ps ON ps.achat_id = a.achat_id WHERE a.chantier_id = t.chantier_id) AS depense_ht
    FROM chantier t INNER JOIN client j1 ON j1.client_id = t.client_id
    ORDER BY t.chantier_id;
END$$

CREATE PROCEDURE sp_phase_create(
    IN p_phase_libelle VARCHAR(100),
    IN p_phase_ordre INT,
    IN p_chantier_id INT,
    OUT p_id INT)
BEGIN
    INSERT INTO phase (phase_libelle, phase_ordre, chantier_id)
    VALUES (p_phase_libelle, p_phase_ordre, p_chantier_id);
    SET p_id = LAST_INSERT_ID();
END$$

CREATE PROCEDURE sp_phase_get(IN p_id INT)
BEGIN
    SELECT t.*, j1.chantier_nom AS chantier_nom
    FROM phase t INNER JOIN chantier j1 ON j1.chantier_id = t.chantier_id
    WHERE t.phase_id = p_id;
END$$

CREATE PROCEDURE sp_phase_update(
    IN p_id INT,
    IN p_phase_libelle VARCHAR(100),
    IN p_phase_ordre INT,
    IN p_chantier_id INT)
BEGIN
    UPDATE phase SET
        phase_libelle = p_phase_libelle,
        phase_ordre = p_phase_ordre,
        chantier_id = p_chantier_id
    WHERE phase_id = p_id;
END$$

CREATE PROCEDURE sp_phase_delete(IN p_id INT)
BEGIN
    DELETE FROM phase WHERE phase_id = p_id;
END$$

CREATE PROCEDURE sp_phase_list()
BEGIN
    SELECT t.*, j1.chantier_nom AS chantier_nom
    FROM phase t INNER JOIN chantier j1 ON j1.chantier_id = t.chantier_id
    ORDER BY t.chantier_id, t.phase_ordre;
END$$

CREATE PROCEDURE sp_intervenant_create(
    IN p_intervenant_nom VARCHAR(255),
    IN p_intervenant_specialite VARCHAR(100),
    IN p_intervenant_taux_horaire DECIMAL(10,2),
    OUT p_id INT)
BEGIN
    INSERT INTO intervenant (intervenant_nom, intervenant_specialite, intervenant_taux_horaire)
    VALUES (p_intervenant_nom, p_intervenant_specialite, p_intervenant_taux_horaire);
    SET p_id = LAST_INSERT_ID();
END$$

CREATE PROCEDURE sp_intervenant_get(IN p_id INT)
BEGIN
    SELECT t.*
    FROM intervenant t 
    WHERE t.intervenant_id = p_id;
END$$

CREATE PROCEDURE sp_intervenant_update(
    IN p_id INT,
    IN p_intervenant_nom VARCHAR(255),
    IN p_intervenant_specialite VARCHAR(100),
    IN p_intervenant_taux_horaire DECIMAL(10,2))
BEGIN
    UPDATE intervenant SET
        intervenant_nom = p_intervenant_nom,
        intervenant_specialite = p_intervenant_specialite,
        intervenant_taux_horaire = p_intervenant_taux_horaire
    WHERE intervenant_id = p_id;
END$$

CREATE PROCEDURE sp_intervenant_delete(IN p_id INT)
BEGIN
    DELETE FROM intervenant WHERE intervenant_id = p_id;
END$$

CREATE PROCEDURE sp_intervenant_list()
BEGIN
    SELECT t.*
    FROM intervenant t 
    ORDER BY t.intervenant_nom;
END$$

CREATE PROCEDURE sp_service_travail_create(
    IN p_ser_trav_nom VARCHAR(100),
    IN p_type VARCHAR(10),
    IN p_phase_id INT,
    IN p_intervenant_id INT,
    OUT p_id INT)
BEGIN
    INSERT INTO service_travail (ser_trav_nom, `type`, phase_id, intervenant_id)
    VALUES (p_ser_trav_nom, p_type, p_phase_id, p_intervenant_id);
    SET p_id = LAST_INSERT_ID();
END$$

CREATE PROCEDURE sp_service_travail_get(IN p_id INT)
BEGIN
    SELECT t.*, j2.chantier_nom AS chantier_nom, j1.phase_libelle AS phase_libelle, j3.intervenant_nom AS intervenant_nom
    FROM service_travail t INNER JOIN phase j1 ON j1.phase_id = t.phase_id INNER JOIN chantier j2 ON j2.chantier_id = j1.chantier_id INNER JOIN intervenant j3 ON j3.intervenant_id = t.intervenant_id
    WHERE t.ser_trav_id = p_id;
END$$

CREATE PROCEDURE sp_service_travail_update(
    IN p_id INT,
    IN p_ser_trav_nom VARCHAR(100),
    IN p_type VARCHAR(10),
    IN p_phase_id INT,
    IN p_intervenant_id INT)
BEGIN
    UPDATE service_travail SET
        ser_trav_nom = p_ser_trav_nom,
        `type` = p_type,
        phase_id = p_phase_id,
        intervenant_id = p_intervenant_id
    WHERE ser_trav_id = p_id;
END$$

CREATE PROCEDURE sp_service_travail_delete(IN p_id INT)
BEGIN
    DELETE FROM service_travail WHERE ser_trav_id = p_id;
END$$

CREATE PROCEDURE sp_service_travail_list()
BEGIN
    SELECT t.*, j2.chantier_nom AS chantier_nom, j1.phase_libelle AS phase_libelle, j3.intervenant_nom AS intervenant_nom
    FROM service_travail t INNER JOIN phase j1 ON j1.phase_id = t.phase_id INNER JOIN chantier j2 ON j2.chantier_id = j1.chantier_id INNER JOIN intervenant j3 ON j3.intervenant_id = t.intervenant_id
    ORDER BY t.ser_trav_id;
END$$

CREATE PROCEDURE sp_fournisseur_create(
    IN p_fournisseur_nom VARCHAR(100),
    IN p_fournisseur_adresse VARCHAR(100),
    IN p_fournisseur_telephone VARCHAR(100),
    IN p_fournisseur_mail VARCHAR(100),
    OUT p_id INT)
BEGIN
    INSERT INTO fournisseur (fournisseur_nom, fournisseur_adresse, fournisseur_telephone, fournisseur_mail)
    VALUES (p_fournisseur_nom, p_fournisseur_adresse, p_fournisseur_telephone, p_fournisseur_mail);
    SET p_id = LAST_INSERT_ID();
END$$

CREATE PROCEDURE sp_fournisseur_get(IN p_id INT)
BEGIN
    SELECT t.*
    FROM fournisseur t 
    WHERE t.fournisseur_id = p_id;
END$$

CREATE PROCEDURE sp_fournisseur_update(
    IN p_id INT,
    IN p_fournisseur_nom VARCHAR(100),
    IN p_fournisseur_adresse VARCHAR(100),
    IN p_fournisseur_telephone VARCHAR(100),
    IN p_fournisseur_mail VARCHAR(100))
BEGIN
    UPDATE fournisseur SET
        fournisseur_nom = p_fournisseur_nom,
        fournisseur_adresse = p_fournisseur_adresse,
        fournisseur_telephone = p_fournisseur_telephone,
        fournisseur_mail = p_fournisseur_mail
    WHERE fournisseur_id = p_id;
END$$

CREATE PROCEDURE sp_fournisseur_delete(IN p_id INT)
BEGIN
    DELETE FROM fournisseur WHERE fournisseur_id = p_id;
END$$

CREATE PROCEDURE sp_fournisseur_list()
BEGIN
    SELECT t.*
    FROM fournisseur t 
    ORDER BY t.fournisseur_nom;
END$$

CREATE PROCEDURE sp_article_create(
    IN p_article_nom VARCHAR(100),
    IN p_article_unite VARCHAR(50),
    IN p_article_prix_unitaire DECIMAL(12,2),
    OUT p_id INT)
BEGIN
    INSERT INTO article (article_nom, article_unite, article_prix_unitaire)
    VALUES (p_article_nom, p_article_unite, p_article_prix_unitaire);
    SET p_id = LAST_INSERT_ID();
END$$

CREATE PROCEDURE sp_article_get(IN p_id INT)
BEGIN
    SELECT t.*
    FROM article t 
    WHERE t.article_id = p_id;
END$$

CREATE PROCEDURE sp_article_update(
    IN p_id INT,
    IN p_article_nom VARCHAR(100),
    IN p_article_unite VARCHAR(50),
    IN p_article_prix_unitaire DECIMAL(12,2))
BEGIN
    UPDATE article SET
        article_nom = p_article_nom,
        article_unite = p_article_unite,
        article_prix_unitaire = p_article_prix_unitaire
    WHERE article_id = p_id;
END$$

CREATE PROCEDURE sp_article_delete(IN p_id INT)
BEGIN
    DELETE FROM article WHERE article_id = p_id;
END$$

CREATE PROCEDURE sp_article_list()
BEGIN
    SELECT t.*
    FROM article t 
    ORDER BY t.article_nom;
END$$

CREATE PROCEDURE sp_facture_achat_create(
    IN p_facture_total_ttc DECIMAL(12,2),
    IN p_facture_date DATE,
    IN p_fournisseur_id INT,
    OUT p_id INT)
BEGIN
    INSERT INTO facture_achat (facture_total_ttc, facture_date, fournisseur_id)
    VALUES (p_facture_total_ttc, p_facture_date, p_fournisseur_id);
    SET p_id = LAST_INSERT_ID();
END$$

CREATE PROCEDURE sp_facture_achat_get(IN p_id INT)
BEGIN
    SELECT t.*, j1.fournisseur_nom AS fournisseur_nom
    FROM facture_achat t INNER JOIN fournisseur j1 ON j1.fournisseur_id = t.fournisseur_id
    WHERE t.facture_id = p_id;
END$$

CREATE PROCEDURE sp_facture_achat_update(
    IN p_id INT,
    IN p_facture_total_ttc DECIMAL(12,2),
    IN p_facture_date DATE,
    IN p_fournisseur_id INT)
BEGIN
    UPDATE facture_achat SET
        facture_total_ttc = p_facture_total_ttc,
        facture_date = p_facture_date,
        fournisseur_id = p_fournisseur_id
    WHERE facture_id = p_id;
END$$

CREATE PROCEDURE sp_facture_achat_delete(IN p_id INT)
BEGIN
    DELETE FROM facture_achat WHERE facture_id = p_id;
END$$

CREATE PROCEDURE sp_facture_achat_list()
BEGIN
    SELECT t.*, j1.fournisseur_nom AS fournisseur_nom
    FROM facture_achat t INNER JOIN fournisseur j1 ON j1.fournisseur_id = t.fournisseur_id
    ORDER BY t.facture_date DESC;
END$$

CREATE PROCEDURE sp_achat_create(
    IN p_achat_date DATE,
    IN p_achat_description VARCHAR(255),
    IN p_chantier_id INT,
    IN p_facture_id INT,
    OUT p_id INT)
BEGIN
    INSERT INTO achat (achat_date, achat_description, chantier_id, facture_id)
    VALUES (p_achat_date, p_achat_description, p_chantier_id, p_facture_id);
    SET p_id = LAST_INSERT_ID();
END$$

CREATE PROCEDURE sp_achat_get(IN p_id INT)
BEGIN
    SELECT t.*, j1.chantier_nom AS chantier_nom, CONCAT('FA-', LPAD(j2.facture_id, 4, '0')) AS facture_ref, (SELECT COALESCE(SUM(ps.quantite * ps.prix_achat),0) FROM porte_sur ps WHERE ps.achat_id = t.achat_id) AS total_ht
    FROM achat t INNER JOIN chantier j1 ON j1.chantier_id = t.chantier_id INNER JOIN facture_achat j2 ON j2.facture_id = t.facture_id
    WHERE t.achat_id = p_id;
END$$

CREATE PROCEDURE sp_achat_update(
    IN p_id INT,
    IN p_achat_date DATE,
    IN p_achat_description VARCHAR(255),
    IN p_chantier_id INT,
    IN p_facture_id INT)
BEGIN
    UPDATE achat SET
        achat_date = p_achat_date,
        achat_description = p_achat_description,
        chantier_id = p_chantier_id,
        facture_id = p_facture_id
    WHERE achat_id = p_id;
END$$

CREATE PROCEDURE sp_achat_delete(IN p_id INT)
BEGIN
    DELETE FROM achat WHERE achat_id = p_id;
END$$

CREATE PROCEDURE sp_achat_list()
BEGIN
    SELECT t.*, j1.chantier_nom AS chantier_nom, CONCAT('FA-', LPAD(j2.facture_id, 4, '0')) AS facture_ref, (SELECT COALESCE(SUM(ps.quantite * ps.prix_achat),0) FROM porte_sur ps WHERE ps.achat_id = t.achat_id) AS total_ht
    FROM achat t INNER JOIN chantier j1 ON j1.chantier_id = t.chantier_id INNER JOIN facture_achat j2 ON j2.facture_id = t.facture_id
    ORDER BY t.achat_date DESC;
END$$

CREATE PROCEDURE sp_porte_sur_create(
    IN p_achat_id INT,
    IN p_article_id INT,
    IN p_quantite INT,
    IN p_prix_achat DECIMAL(12,2))
BEGIN
    INSERT INTO porte_sur (achat_id, article_id, quantite, prix_achat)
    VALUES (p_achat_id, p_article_id, p_quantite, p_prix_achat);
END$$

CREATE PROCEDURE sp_porte_sur_get(
    IN p_achat_id INT,
    IN p_article_id INT)
BEGIN
    SELECT t.*, CONCAT('ACH-', LPAD(j1.achat_id, 4, '0'), ' – ', j1.achat_description) AS achat_libelle, j2.article_nom AS article_nom, j2.article_unite AS article_unite, t.quantite * t.prix_achat AS sous_total
    FROM porte_sur t INNER JOIN achat j1 ON j1.achat_id = t.achat_id INNER JOIN article j2 ON j2.article_id = t.article_id
    WHERE t.achat_id = p_achat_id AND t.article_id = p_article_id;
END$$

CREATE PROCEDURE sp_porte_sur_update(
    IN p_achat_id INT,
    IN p_article_id INT,
    IN p_quantite INT,
    IN p_prix_achat DECIMAL(12,2))
BEGIN
    UPDATE porte_sur SET
        quantite = p_quantite,
        prix_achat = p_prix_achat
    WHERE achat_id = p_achat_id AND article_id = p_article_id;
END$$

CREATE PROCEDURE sp_porte_sur_delete(
    IN p_achat_id INT,
    IN p_article_id INT)
BEGIN
    DELETE FROM porte_sur WHERE achat_id = p_achat_id AND article_id = p_article_id;
END$$

CREATE PROCEDURE sp_porte_sur_list()
BEGIN
    SELECT t.*, CONCAT('ACH-', LPAD(j1.achat_id, 4, '0'), ' – ', j1.achat_description) AS achat_libelle, j2.article_nom AS article_nom, j2.article_unite AS article_unite, t.quantite * t.prix_achat AS sous_total
    FROM porte_sur t INNER JOIN achat j1 ON j1.achat_id = t.achat_id INNER JOIN article j2 ON j2.article_id = t.article_id
    ORDER BY t.achat_id, t.article_id;
END$$

CREATE PROCEDURE sp_porte_sur_list_by_achat(IN p_achat_id INT)
BEGIN
    SELECT t.*, CONCAT('ACH-', LPAD(j1.achat_id, 4, '0'), ' – ', j1.achat_description) AS achat_libelle, j2.article_nom AS article_nom, j2.article_unite AS article_unite, t.quantite * t.prix_achat AS sous_total
    FROM porte_sur t INNER JOIN achat j1 ON j1.achat_id = t.achat_id INNER JOIN article j2 ON j2.article_id = t.article_id
    WHERE t.achat_id = p_achat_id
    ORDER BY t.article_id;
END$$

CREATE PROCEDURE sp_reglement_create(
    IN p_reglement_date DATE,
    IN p_reglement_montant DECIMAL(12,2),
    IN p_achat_id INT,
    IN p_ser_trav_id INT,
    OUT p_id INT)
BEGIN
    INSERT INTO reglement (reglement_date, reglement_montant, achat_id, ser_trav_id)
    VALUES (p_reglement_date, p_reglement_montant, p_achat_id, p_ser_trav_id);
    SET p_id = LAST_INSERT_ID();
END$$

CREATE PROCEDURE sp_reglement_get(IN p_id INT)
BEGIN
    SELECT t.*, CASE WHEN j1.achat_id IS NULL THEN '' ELSE CONCAT('ACH-', LPAD(j1.achat_id, 4, '0'), ' – ', j1.achat_description) END AS achat_libelle, COALESCE(j2.ser_trav_nom, '') AS ser_trav_nom
    FROM reglement t LEFT JOIN achat j1 ON j1.achat_id = t.achat_id LEFT JOIN service_travail j2 ON j2.ser_trav_id = t.ser_trav_id
    WHERE t.reglement_id = p_id;
END$$

CREATE PROCEDURE sp_reglement_update(
    IN p_id INT,
    IN p_reglement_date DATE,
    IN p_reglement_montant DECIMAL(12,2),
    IN p_achat_id INT,
    IN p_ser_trav_id INT)
BEGIN
    UPDATE reglement SET
        reglement_date = p_reglement_date,
        reglement_montant = p_reglement_montant,
        achat_id = p_achat_id,
        ser_trav_id = p_ser_trav_id
    WHERE reglement_id = p_id;
END$$

CREATE PROCEDURE sp_reglement_delete(IN p_id INT)
BEGIN
    DELETE FROM reglement WHERE reglement_id = p_id;
END$$

CREATE PROCEDURE sp_reglement_list()
BEGIN
    SELECT t.*, CASE WHEN j1.achat_id IS NULL THEN '' ELSE CONCAT('ACH-', LPAD(j1.achat_id, 4, '0'), ' – ', j1.achat_description) END AS achat_libelle, COALESCE(j2.ser_trav_nom, '') AS ser_trav_nom
    FROM reglement t LEFT JOIN achat j1 ON j1.achat_id = t.achat_id LEFT JOIN service_travail j2 ON j2.ser_trav_id = t.ser_trav_id
    ORDER BY t.reglement_date DESC;
END$$

CREATE PROCEDURE sp_controle_qualite_create(
    IN p_controle_date DATE,
    IN p_ser_trav_id INT,
    OUT p_id INT)
BEGIN
    INSERT INTO controle_qualite (controle_date, ser_trav_id)
    VALUES (p_controle_date, p_ser_trav_id);
    SET p_id = LAST_INSERT_ID();
END$$

CREATE PROCEDURE sp_controle_qualite_get(IN p_id INT)
BEGIN
    SELECT t.*, j1.ser_trav_nom AS ser_trav_nom
    FROM controle_qualite t INNER JOIN service_travail j1 ON j1.ser_trav_id = t.ser_trav_id
    WHERE t.controle_id = p_id;
END$$

CREATE PROCEDURE sp_controle_qualite_update(
    IN p_id INT,
    IN p_controle_date DATE,
    IN p_ser_trav_id INT)
BEGIN
    UPDATE controle_qualite SET
        controle_date = p_controle_date,
        ser_trav_id = p_ser_trav_id
    WHERE controle_id = p_id;
END$$

CREATE PROCEDURE sp_controle_qualite_delete(IN p_id INT)
BEGIN
    DELETE FROM controle_qualite WHERE controle_id = p_id;
END$$

CREATE PROCEDURE sp_controle_qualite_list()
BEGIN
    SELECT t.*, j1.ser_trav_nom AS ser_trav_nom
    FROM controle_qualite t INNER JOIN service_travail j1 ON j1.ser_trav_id = t.ser_trav_id
    ORDER BY t.controle_date DESC;
END$$

CREATE PROCEDURE sp_rapport_controle_create(
    IN p_rapport_date DATE,
    IN p_rapport_recommandation TEXT,
    IN p_controle_id INT,
    OUT p_id INT)
BEGIN
    INSERT INTO rapport_controle (rapport_date, rapport_recommandation, controle_id)
    VALUES (p_rapport_date, p_rapport_recommandation, p_controle_id);
    SET p_id = LAST_INSERT_ID();
END$$

CREATE PROCEDURE sp_rapport_controle_get(IN p_id INT)
BEGIN
    SELECT t.*, j2.ser_trav_nom AS ser_trav_nom, j1.controle_date AS controle_date
    FROM rapport_controle t INNER JOIN controle_qualite j1 ON j1.controle_id = t.controle_id INNER JOIN service_travail j2 ON j2.ser_trav_id = j1.ser_trav_id
    WHERE t.rapport_id = p_id;
END$$

CREATE PROCEDURE sp_rapport_controle_update(
    IN p_id INT,
    IN p_rapport_date DATE,
    IN p_rapport_recommandation TEXT,
    IN p_controle_id INT)
BEGIN
    UPDATE rapport_controle SET
        rapport_date = p_rapport_date,
        rapport_recommandation = p_rapport_recommandation,
        controle_id = p_controle_id
    WHERE rapport_id = p_id;
END$$

CREATE PROCEDURE sp_rapport_controle_delete(IN p_id INT)
BEGIN
    DELETE FROM rapport_controle WHERE rapport_id = p_id;
END$$

CREATE PROCEDURE sp_rapport_controle_list()
BEGIN
    SELECT t.*, j2.ser_trav_nom AS ser_trav_nom, j1.controle_date AS controle_date
    FROM rapport_controle t INNER JOIN controle_qualite j1 ON j1.controle_id = t.controle_id INNER JOIN service_travail j2 ON j2.ser_trav_id = j1.ser_trav_id
    ORDER BY t.rapport_date DESC;
END$$

CREATE PROCEDURE sp_utilisateur_create(
    IN p_utilisateur_login VARCHAR(50),
    IN p_utilisateur_nom_complet VARCHAR(100),
    IN p_mot_de_passe VARCHAR(100),
    IN p_utilisateur_role VARCHAR(20),
    OUT p_id INT)
BEGIN
    DECLARE v_sel CHAR(36);
    SET v_sel = UUID();
    INSERT INTO utilisateur (utilisateur_login, utilisateur_nom_complet, utilisateur_mot_de_passe_hash,
                             utilisateur_sel, utilisateur_role, utilisateur_actif)
    VALUES (p_utilisateur_login, p_utilisateur_nom_complet, SHA2(CONCAT(v_sel, p_mot_de_passe), 256),
            v_sel, p_utilisateur_role, 1);
    SET p_id = LAST_INSERT_ID();
END$$

CREATE PROCEDURE sp_utilisateur_get(IN p_id INT)
BEGIN
    SELECT utilisateur_id, utilisateur_login, utilisateur_nom_complet, utilisateur_role, utilisateur_actif
    FROM utilisateur WHERE utilisateur_id = p_id;
END$$

CREATE PROCEDURE sp_utilisateur_list()
BEGIN
    SELECT utilisateur_id, utilisateur_login, utilisateur_nom_complet, utilisateur_role, utilisateur_actif
    FROM utilisateur ORDER BY utilisateur_login;
END$$

CREATE PROCEDURE sp_utilisateur_update(
    IN p_id INT,
    IN p_utilisateur_nom_complet VARCHAR(100),
    IN p_utilisateur_role VARCHAR(20),
    IN p_utilisateur_actif TINYINT(1))
BEGIN
    UPDATE utilisateur SET
        utilisateur_nom_complet = p_utilisateur_nom_complet,
        utilisateur_role = p_utilisateur_role,
        utilisateur_actif = p_utilisateur_actif
    WHERE utilisateur_id = p_id;
END$$

CREATE PROCEDURE sp_utilisateur_delete(IN p_id INT)
BEGIN
    DELETE FROM utilisateur WHERE utilisateur_id = p_id;
END$$

-- Connexion : renvoie 1 ligne si login + mot de passe corrects et compte actif, sinon 0 ligne
CREATE PROCEDURE sp_utilisateur_authentifier(
    IN p_utilisateur_login VARCHAR(50),
    IN p_mot_de_passe VARCHAR(100))
BEGIN
    SELECT utilisateur_id, utilisateur_login, utilisateur_nom_complet, utilisateur_role, utilisateur_actif
    FROM utilisateur
    WHERE utilisateur_login = p_utilisateur_login
      AND utilisateur_actif = 1
      AND utilisateur_mot_de_passe_hash = SHA2(CONCAT(utilisateur_sel, p_mot_de_passe), 256);
END$$

CREATE PROCEDURE sp_utilisateur_changer_mot_de_passe(
    IN p_id INT,
    IN p_ancien_mot_de_passe VARCHAR(100),
    IN p_nouveau_mot_de_passe VARCHAR(100))
BEGIN
    DECLARE v_sel CHAR(36);
    SET v_sel = UUID();
    UPDATE utilisateur SET
        utilisateur_sel = v_sel,
        utilisateur_mot_de_passe_hash = SHA2(CONCAT(v_sel, p_nouveau_mot_de_passe), 256)
    WHERE utilisateur_id = p_id
      AND utilisateur_mot_de_passe_hash = SHA2(CONCAT(utilisateur_sel, p_ancien_mot_de_passe), 256);
    SELECT ROW_COUNT() AS lignes_modifiees;
END$$

DELIMITER ;

-- ----------------------------------------------------------------------------
-- JEU DE DONNÉES
-- ----------------------------------------------------------------------------

INSERT INTO client (client_nom, client_telephone, client_email) VALUES
('Groupe Kouassi Immobilier', '+225 27 21 45 67 89', 'contact@kouassi-immo.ci'),
('Mme Affoua Bernadette Yao', '+225 07 08 12 34 56', 'b.yao@gmail.com'),
('SCI Les Palmiers d''Assinie', '+225 05 44 21 90 12', 'gestion@palmiers-assinie.ci'),
('Ets Traoré & Fils', '+225 01 02 33 44 55', 'traore.fils@yahoo.fr'),
('Coopérative Agricole du Sud-Comoé', '+225 27 21 30 11 22', 'cascom@coop-sudcomoe.ci'),
('Clinique Les Cocotiers', '+225 27 22 48 00 10', 'direction@cocotiers-sante.ci');

INSERT INTO chantier (chantier_nom, chantier_adresse, chantier_statut, chantier_date_debut, chantier_date_fin, chantier_budget, client_id) VALUES
('Résidence Les Flamboyants', 'Cocody Riviera Palmeraie, Abidjan', 'En cours', '2026-03-02', '2027-02-26', 185000000, 1),
('Villa Yao – Grand-Bassam', 'Quartier France, Grand-Bassam', 'En cours', '2026-05-18', '2026-12-18', 62000000, 2),
('Complexe hôtelier Assinie Beach', 'Assinie-Mafia', 'Planifié', '2027-01-11', '2027-12-17', 420000000, 3),
('Entrepôt Traoré – Yopougon', 'Zone industrielle de Yopougon, Abidjan', 'Terminé', '2025-09-01', '2026-04-30', 95000000, 4),
('Magasin de stockage coopérative', 'Aboisso', 'Suspendu', '2026-06-08', '2026-11-27', 38000000, 5),
('Extension Clinique Les Cocotiers', 'Bingerville', 'En cours', '2026-07-06', '2027-01-29', 128000000, 6);

INSERT INTO phase (phase_libelle, phase_ordre, chantier_id) VALUES
('Terrassement et fondations', 1, 1), ('Gros œuvre', 2, 1), ('Second œuvre', 3, 1), ('Finitions', 4, 1),
('Fondations', 1, 2), ('Élévation et toiture', 2, 2), ('Finitions et aménagements', 3, 2),
('Études et autorisations', 1, 3), ('Terrassement', 2, 3),
('Fondations et dallage', 1, 4), ('Charpente métallique', 2, 4), ('Couverture et bardage', 3, 4),
('Fondations', 1, 5), ('Maçonnerie', 2, 5),
('Démolition partielle', 1, 6), ('Gros œuvre', 2, 6), ('Équipements médicaux et finitions', 3, 6);

INSERT INTO intervenant (intervenant_nom, intervenant_specialite, intervenant_taux_horaire) VALUES
('Koffi Konan Jean', 'Maçon', 3500), ('Diallo Mamadou', 'Ferrailleur', 3000), ('N''Guessan Paul', 'Électricien', 4500),
('Soro Ibrahim', 'Plombier', 4000), ('Bamba Seydou', 'Carreleur', 3800), ('Ouattara Adama', 'Chef de chantier', 8000),
('Zadi Marcel', 'Peintre', 3200), ('Tano Emmanuel', 'Soudeur', 5000);

INSERT INTO service_travail (ser_trav_nom, `type`, phase_id, intervenant_id) VALUES
('Coulage des semelles', 'Interne', 1, 1), ('Ferraillage des fondations', 'Interne', 1, 2),
('Élévation des murs R+1', 'Interne', 2, 1), ('Installation électrique générale', 'Externe', 3, 3),
('Plomberie sanitaire', 'Externe', 3, 4), ('Pose de carrelage', 'Externe', 4, 5), ('Peinture intérieure', 'Externe', 4, 7),
('Coulage des fondations villa', 'Interne', 5, 1), ('Montage de la charpente', 'Externe', 6, 8),
('Pose du dallage industriel', 'Interne', 10, 1), ('Soudure de la charpente métallique', 'Externe', 11, 8),
('Maçonnerie des murs', 'Interne', 14, 1), ('Démolition de l''ancien mur', 'Interne', 15, 1),
('Suivi technique du gros œuvre', 'Interne', 16, 6);

INSERT INTO fournisseur (fournisseur_nom, fournisseur_adresse, fournisseur_telephone, fournisseur_mail) VALUES
('Matériaux & Ciments d''Abidjan', 'Zone 4, Marcory', '+225 27 21 24 56 78', 'ventes@mca-abidjan.ci'),
('Quincaillerie Générale du Sud', 'Boulevard VGE, Marcory', '+225 27 21 26 10 10', 'contact@qgsud.ci'),
('Ivoire Acier', 'Zone industrielle de Vridi', '+225 27 21 27 33 44', 'commercial@ivoire-acier.ci'),
('Électro-Pro CI', 'Plateau, Abidjan', '+225 27 20 32 88 90', 'info@electropro.ci'),
('Sanitaire & Carrelage Plus', 'Treichville', '+225 27 21 35 20 20', 'sanicarrelage@gmail.com');

INSERT INTO article (article_nom, article_unite, article_prix_unitaire) VALUES
('Ciment CPJ 42,5', 'Sac 50 kg', 5200), ('Sable lagunaire', 'm³', 12000), ('Gravier 15/25', 'm³', 18000),
('Fer à béton HA 12', 'Barre 12 m', 7800), ('Fer à béton HA 8', 'Barre 12 m', 3600), ('Parpaing de 15', 'Unité', 450),
('Câble électrique 2,5 mm²', 'Rouleau 100 m', 32000), ('Tuyau PVC Ø100', 'Barre 4 m', 6500),
('Carreaux grès cérame 60x60', 'm²', 9500), ('Peinture vinylique', 'Seau 25 kg', 28000),
('Tôle bac alu', 'm²', 7200), ('Bois de coffrage', 'Planche', 2800);

INSERT INTO facture_achat (facture_total_ttc, facture_date, fournisseur_id) VALUES
(0, '2026-03-12', 1), (0, '2026-03-25', 3), (0, '2026-05-27', 1), (0, '2026-06-15', 2),
(0, '2026-07-20', 3), (0, '2026-08-14', 4), (0, '2026-09-10', 5), (0, '2026-10-05', 1);

INSERT INTO achat (achat_date, achat_description, chantier_id, facture_id) VALUES
('2026-03-12', 'Ciment et agrégats pour semelles', 1, 1), ('2026-03-25', 'Fers à béton des fondations', 1, 2),
('2026-05-27', 'Matériaux de fondations villa', 2, 3), ('2026-06-15', 'Parpaings et quincaillerie', 2, 4),
('2026-07-20', 'Acier pour charpente et ferraillage', 6, 5), ('2026-08-14', 'Câbles et tableau électrique', 1, 6),
('2026-09-10', 'Carrelage et peinture', 1, 7), ('2026-10-05', 'Ciment pour gros œuvre clinique', 6, 8),
('2026-03-12', 'Bois de coffrage', 1, 1), ('2026-10-05', 'Sable et gravier clinique', 6, 8);

INSERT INTO porte_sur (achat_id, article_id, quantite, prix_achat) VALUES
(1, 1, 120, 5200), (1, 2, 15, 12000), (1, 3, 18, 18000),
(2, 4, 200, 7800), (2, 5, 150, 3600),
(3, 1, 60, 5200), (3, 2, 8, 12000), (3, 4, 80, 7800),
(4, 6, 1500, 450), (4, 1, 40, 5200),
(5, 4, 120, 7800), (5, 5, 90, 3600), (5, 11, 150, 7200),
(6, 7, 6, 32000), (6, 8, 20, 6500),
(7, 9, 180, 9500), (7, 10, 10, 28000),
(8, 1, 150, 5200), (8, 3, 12, 18000),
(9, 12, 300, 2800),
(10, 2, 20, 12000), (10, 3, 15, 18000);

UPDATE facture_achat f
SET facture_total_ttc = ROUND(COALESCE((SELECT SUM(ps.quantite * ps.prix_achat)
                                         FROM achat a INNER JOIN porte_sur ps ON ps.achat_id = a.achat_id
                                         WHERE a.facture_id = f.facture_id), 0) * 1.18, 0);

INSERT INTO reglement (reglement_date, reglement_montant, achat_id, ser_trav_id) VALUES
('2026-03-20', 1000000, 1, NULL), ('2026-04-02', 800000, 2, NULL), ('2026-06-05', 900000, 3, NULL),
('2026-07-01', 650000, 4, NULL), ('2026-08-02', 1800000, 5, NULL),
('2026-04-30', 1250000, NULL, 1), ('2026-06-30', 1750000, NULL, 3), ('2026-09-30', 2400000, NULL, 4),
('2026-10-15', 900000, NULL, 10);

INSERT INTO controle_qualite (controle_date, ser_trav_id) VALUES
('2026-04-10', 1), ('2026-06-22', 3), ('2026-09-05', 4), ('2026-04-25', 10), ('2026-07-30', 12), ('2026-10-08', 14);

INSERT INTO rapport_controle (rapport_date, rapport_recommandation, controle_id) VALUES
('2026-04-11', 'Résistance du béton conforme. Prévoir un arrosage supplémentaire pendant 7 jours.', 1),
('2026-06-23', 'Alignement des murs conforme ; reprendre deux joints de maçonnerie au niveau R+1.', 2),
('2026-09-06', 'Installation conforme à la norme ; ajouter un repérage des circuits sur le tableau.', 3),
('2026-04-26', 'Planéité du dallage conforme ; protéger les joints de dilatation avant la livraison.', 4),
('2026-07-31', 'Contrôle réalisé avant la suspension du chantier ; sécuriser le stock de parpaings.', 5),
('2026-10-09', 'Gros œuvre conforme aux plans ; compléter le chaînage horizontal sur la zone nord.', 6);

CALL sp_utilisateur_create('admin',   'Ketsia Kouadio',        'Admin@2026',   'Admin',        @id);
CALL sp_utilisateur_create('gestion', 'Gestionnaire Chantier', 'Gestion@2026', 'Gestionnaire', @id);
CALL sp_utilisateur_create('consult', 'Consultant Externe',    'Consult@2026', 'Consultant',   @id);
