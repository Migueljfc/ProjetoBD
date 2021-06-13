CREATE TABLE Administrador(
	ID Int NOT NULL,
	nome Varchar(10) NOT NULL,
	apelido Varchar(20) NOT NULL,
	PRIMARY KEY(ID)
);

CREATE TABLE Cliente(
	CC Int NOT NULL,
	nome Varchar(10) NOT NULL,
	apelido Varchar(20) NOT NULL,
	email Varchar(50) NOT NULL,
	telefone Int NOT NULL,
	FK_IdAdmin Int REFERENCES Administrador(ID),
	PRIMARY KEY(CC)
);

CREATE TABLE Pagamento(
	ID Int PRIMARY KEY NOT NULL
);

CREATE TABLE Alojamento(
	ID Int NOT NULL,
	tipo Varchar(20) NOT NULL,
	nome Varchar(30) NOT NULL,
	preco Int NOT NULL,
	localizacao VarChar(20),
	FK_Tem2 Int,
	PRIMARY KEY(ID),
	UNIQUE(FK_Tem2)
);

CREATE TABLE Viagem(
	ID Int NOT NULL,
	dataInicial DATE NOT NULL,
	dataFinal DATE NOT NULL,
	numVagas Int,
	precoTotal Int NOT NULL,
	FK_Tem Int,
	FK_IdAdmin Int REFERENCES Administrador(ID),
	FK_IdAloj Int REFERENCES Alojamento(ID),
	FK_Pag Int REFERENCES Pagamento(ID), 
	PRIMARY KEY(ID),
	UNIQUE(FK_Tem)
);

CREATE TABLE Destino(
	codPostal Int NOT NULL,
	pais Varchar(15) NOT NULL,
	cidade Varchar(15) NOT NULL,
	FK_Tem3 Int,
	PRIMARY KEY(codPostal),
	UNIQUE(FK_Tem3)
);


CREATE TABLE Transporte(
	ID Int NOT NULL,
	tipo Varchar(20) NOT NULL,
	dataPartida DATE NOT NULL,
	dataChegada DATE NOT NULL,
	preco Int NOT NULL,
	companhia Varchar(20) NOT NULL,
	numPassageiros Int NOT NULL,
	FK_Tem Int,
	FK_Dest Int REFERENCES Destino(codPostal),
	PRIMARY KEY(ID),
	UNIQUE(FK_Tem)	
);

CREATE TABLE Tem(
	ID1 Int NOT NULL,
	ID2 Int NOT NULL,
	PRIMARY KEY(ID1, ID2),
	FOREIGN KEY (ID1) REFERENCES Transporte(FK_Tem),
	FOREIGN KEY (ID2) REFERENCES Viagem(FK_Tem) 
);


CREATE TABLE Pacote(
	ID Int NOT NULL,
	precoTotal Int NOT NULL,
	preco Int NOT NULL,
	FK_Tem2 Int,
	FK_Tem3 Int,
	FK_IdAdmin Int REFERENCES Administrador(ID),
	FK_Dest Int REFERENCES Destino(codPostal),
	UNIQUE(FK_Tem3),
	UNIQUE(FK_Tem2)
);

CREATE TABLE Tem_2(
	ID1 Int NOT NULL,
	ID2 Int NOT NULL,
	preco Int NOT NULL,
	PRIMARY KEY(ID1, ID2),
	FOREIGN KEY (ID1) REFERENCES Pacote(FK_Tem2),
	FOREIGN KEY (ID2) REFERENCES Alojamento(FK_Tem2)
);

CREATE TABLE Tem_3(
	ID Int NOT NULL,
	codPostal Int NOT NULL,
	preco Int NOT NULL,
	PRIMARY KEY(codPostal, ID),
	FOREIGN KEY (codPostal) REFERENCES Destino(FK_Tem3),
	FOREIGN KEY (ID) REFERENCES Pacote(FK_Tem3)
);

