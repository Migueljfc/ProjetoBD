--CREATE TABLE Administrador(
--	ID Int NOT NULL,
--	nome Varchar(20) NOT NULL,
--	pass Varchar(20) NOT NULL,
--	apelido Varchar(20) NOT NULL,
--	PRIMARY KEY(ID)
--);

--CREATE TABLE Cliente(
--	ID Int NOT NULL,
--	CC Int NOT NULL,
--	nome Varchar(10) NOT NULL,
--	apelido Varchar(20) NOT NULL,
--	email Varchar(50) NOT NULL,
--	telefone Int NOT NULL,
--	FK_IdAdmin Int REFERENCES Administrador(ID),
--	PRIMARY KEY(ID)
--);

--CREATE TABLE Pagamento(
--	ID Int PRIMARY KEY NOT NULL,
--	Pago Int,
--);

--CREATE TABLE Destino(
--	ID Int NOT NULL, 
--	codPostal Varchar(10) NOT NULL,
--	pais Varchar(15) NOT NULL,
--	cidade Varchar(15) NOT NULL,
--	PRIMARY KEY(ID)
--);

--CREATE TABLE Alojamento(
--	ID Int NOT NULL,
--	tipo Varchar(20) NOT NULL,
--	nome Varchar(30) NOT NULL,
--	preco Int NOT NULL,
--	PRIMARY KEY(ID),
--	FK_Dest Int REFERENCES Destino(ID)
--);

--CREATE TABLE Transporte(
--	ID Int NOT NULL,
--	tipo Varchar(20) NOT NULL,
--	dataPartida DATE NOT NULL,
--	dataChegada DATE NOT NULL,
--	preco Int NOT NULL,
--	companhia Varchar(20) NOT NULL,
--	numPassageiros Int NOT NULL,
--	FK_Dest Int REFERENCES Destino(ID),
--	PRIMARY KEY(ID)
--);

--CREATE TABLE Viagem(
--	ID Int NOT NULL,
--	dataInicial DATE NOT NULL,
--	dataFinal DATE NOT NULL,
--	numVagas Int,
--	precoTotal Int NOT NULL,
--	FK_IdAdmin Int REFERENCES Administrador(ID),
--	FK_IdAloj Int REFERENCES Alojamento(ID),
--	FK_IdTrans Int REFERENCES Transporte(ID),
--	FK_IdDest Int REFERENCES Destino(ID),
--	FK_Pag Int REFERENCES Pagamento(ID), 
--	FK_Client Int REFERENCES Cliente(ID),
--	PRIMARY KEY(ID)
--);




--CREATE TABLE Tem(
--	ID1 Int NOT NULL,
--	ID2 Int NOT NULL,
--	PRIMARY KEY(ID1, ID2),
--	FOREIGN KEY (ID1) REFERENCES Transporte(ID),
--	FOREIGN KEY (ID2) REFERENCES Viagem(ID) 
--);



--CREATE TABLE Pacote(
--	ID Int NOT NULL,
--	precoTotal Int NOT NULL,
--	preco Int NOT NULL,
--	FK_IdAdmin Int REFERENCES Administrador(ID),
--	FK_Dest Int REFERENCES Destino(ID),
--	PRIMARY KEY(ID)
--);

--CREATE TABLE Tem_2(
--	ID1 Int NOT NULL,
--	ID2 Int NOT NULL,
--	preco Int NOT NULL,
--	PRIMARY KEY(ID1, ID2),
--	FOREIGN KEY (ID1) REFERENCES Pacote(ID),
--	FOREIGN KEY (ID2) REFERENCES Alojamento(ID)
--);



--CREATE TABLE Tem_3(
--	ID1 Int NOT NULL,
--	ID2 Int NOT NULL,
--	preco Int NOT NULL,
--	PRIMARY KEY (ID1, ID2),
--	FOREIGN KEY (ID2) REFERENCES Transporte(ID),
--	FOREIGN KEY (ID1) REFERENCES Pacote(ID)
--);

----------------------------------------------------------------------------

