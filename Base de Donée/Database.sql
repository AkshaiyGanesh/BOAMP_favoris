


CREATE TABLE AppelsOffres (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    IDWeb VARCHAR(255) UNIQUE,
    AnnonceReferenceSchema VARCHAR(255),
    Objet TEXT,
    Filename VARCHAR(255),
    Famille VARCHAR(255),
    FamilleLibelle TEXT,
    DateParution DATE,
    DateFinDiffusion DATE,
    DateLimiteReponse DATETIME,
    NomAcheteur VARCHAR(255),
    Perimetre VARCHAR(255),
    TypeProcedure VARCHAR(255),
    ProcedureLibelle VARCHAR(255),
    Nature VARCHAR(255),
    SousNature VARCHAR(255),
    NatureLibelle VARCHAR(255),
    Etat VARCHAR(255),
    URLAvis VARCHAR(255)
);

CREATE TABLE CodesDepartement (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    AppelOffreID INT,
    Code VARCHAR(255),
    FOREIGN KEY (AppelOffreID) REFERENCES AppelsOffres(ID)
);

CREATE TABLE Descripteurs (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    AppelOffreID INT,
    Code VARCHAR(255),
    Libelle VARCHAR(255),
    FOREIGN KEY (AppelOffreID) REFERENCES AppelsOffres(ID)
);

CREATE TABLE TypesMarche (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    AppelOffreID INT,
    Type VARCHAR(255),
    FOREIGN KEY (AppelOffreID) REFERENCES AppelsOffres(ID)
);
