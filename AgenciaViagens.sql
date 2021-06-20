CREATE TABLE Administrador(
	ID Int NOT NULL,
	nome Varchar(20) NOT NULL,
	pass Varchar(20) NOT NULL,
	apelido Varchar(20) NOT NULL,
	PRIMARY KEY(ID)
);

CREATE TABLE Cliente(
	ID Int NOT NULL,
	CC Int NOT NULL,
	nome Varchar(10) NOT NULL,
	apelido Varchar(20) NOT NULL,
	email Varchar(50) NOT NULL,
	telefone Int NOT NULL,
	FK_IdAdmin Int REFERENCES Administrador(ID),
	PRIMARY KEY(ID)
);

CREATE TABLE Pagamento(
	ID Int PRIMARY KEY NOT NULL
);

CREATE TABLE Alojamento(
	ID Int NOT NULL,
	tipo Varchar(20) NOT NULL,
	nome Varchar(30) NOT NULL,
	preco Int NOT NULL,
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
	FK_Client Int REFERENCES Cliente(ID),
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


------------------------------------------------------




GO

CREATE PROC UpdateCliente
	@ID Int,
	@CC Int,
	@nome Varchar(20),
	@apelido Varchar(20),
	@email Varchar(20),
	@telefone Int,
	@message Varchar(20) output

	AS

	BEGIN
		SET NOCOUNT ON
		BEGIN TRY
		
			UPDATE Cliente
			SET nome = @nome, apelido = @apelido, telefone = @telefone, CC = @CC, email = @email
			WHERE ID = @ID 
		
			SET @message = 'Success'

		END TRY

	BEGIN CATCH
		SET @message = error_message()
	END CATCH

	END
GO

------------------------------------------------------------------


GO

CREATE PROC DeleteCliente
    @ID Int,
    @message Varchar(20) output


AS


BEGIN
        SET NOCOUNT ON
        
        BEGIN TRY
            DELETE Cliente WHERE ID = @ID
            
            SET @message='Success'
        
        END TRY

        BEGIN CATCH
            SET @message=error_message()
        END CATCH
END
 

GO

-----------------------------------------------------------


GO
CREATE PROCEDURE AddClient
	@ID Int,
	@CC Int,
	@nome Varchar(20),
	@apelido Varchar(20),
	@email Varchar(20),
	@telefone Int,
	@FK_idAdmin Int,
	@message Varchar(20) output
AS
BEGIN

	SET NOCOUNT ON
	
	BEGIN TRY

		INSERT INTO Cliente(ID, CC, nome, apelido, email, telefone,FK_IdAdmin)
		VALUES ( @ID,@CC, @nome, @apelido, @email, @telefone,@FK_idAdmin)

		SET @message = 'Success'
	END TRY
	BEGIN CATCH
		SET @message = error_message()
	END CATCH
END
GO


-------------------------------------------------

GO

CREATE PROC AddViagem
	@ID Int,
	@dataInicial DATE,
	@dataFinal DATE,
	@numVagas Int,
	@precoTotal Int,
	@message Varchar(20) output

AS

BEGIN
	
	SET NOCOUNT ON
	
	BEGIN TRY
		INSERT INTO Viagem(ID, dataInicial, dataFinal, numVagas, precoTotal)
		VALUES (@ID, @dataInicial, @dataFinal, @numVagas, @precoTotal)

		SET @message = 'Success'

	END TRY
	BEGIN CATCH
		SET @message = error_message()
	END CATCH
END
GO

-------------------------------------------------

GO

CREATE PROC AddAlojamento
	@ID Int,
	@tipo Varchar(20),
	@nome Varchar(30),
	@preco Int,
	@message Varchar(20) output

AS

BEGIN
	
	SET NOCOUNT ON
	
	BEGIN TRY
		INSERT INTO Alojamento(ID, tipo, nome, preco)
		VALUES (@ID, @tipo, @nome, @preco)

		SET @message = 'Success'

	END TRY
	BEGIN CATCH
		SET @message = error_message()
	END CATCH
END
GO

-------------------------------------------------

GO

CREATE PROC AddTransporte
	@ID Int,
	@tipo Varchar(20),
	@dataPartida DATE,
	@dataChegada DATE,
	@preco Int,
	@companhia Varchar(20),
	@numPassageiros Int,
	@message Varchar(20) output

AS

BEGIN
	
	SET NOCOUNT ON
	
	BEGIN TRY
		INSERT INTO Transporte(ID, tipo, dataPartida, dataChegada, preco, companhia, numPassageiros)
		VALUES (@ID, @tipo, @dataPartida, @dataChegada, @preco, @companhia, @numPassageiros)

		SET @message = 'Success'

	END TRY
	BEGIN CATCH
		SET @message = error_message()
	END CATCH
END
GO

-------------------------------------------------

GO

CREATE PROC AddDestino
	@codPostal Int,
	@pais Varchar(15),
	@cidade Varchar(15),
	@message Varchar(20) output

AS

BEGIN
	
	SET NOCOUNT ON
	
	BEGIN TRY
		INSERT INTO Destino(codPostal, pais, cidade)
		VALUES (@codPostal, @pais, @cidade)

		SET @message = 'Success'

	END TRY
	BEGIN CATCH
		SET @message = error_message()
	END CATCH
END
GO

------------------------------------------------------------------------
INSERT INTO Cliente([ID],[CC],[nome],[apelido],[email],[telefone],[FK_IdAdmin]) VALUES(1,119445,'Patience','Virginia','vitae@Fuscefeugiat.net','905426765','12345'),(2,486315,'Astra','Lacey','posuere.enim.nisl@gravidamaurisut.ca','917832862','12345'),(3,172727,'Dana','Kaden','ante.ipsum.primis@sitametrisus.com','932207241','12345'),(4,291570,'MacKensie','Wyatt','orci.Donec.nibh@sitametmassa.edu','944294355','12345'),(5,255197,'Curran','Callum','ultrices@accumsan.co.uk','916561562','12345'),(6,767801,'Samuel','Zeph','tellus.sem@Donecfelis.edu','964747706','12345'),(7,677589,'Maggy','Mikayla','placerat@massalobortis.net','917297159','12345'),(8,345030,'Quynn','Nehru','massa.Integer@elit.net','973678193','12345'),(9,924353,'Kay','Dolan','mi.Aliquam@nequevitae.com','961065062','12345'),(10,475599,'Mannix','Linus','at.fringilla@egetmassa.co.uk','974920781','12345');
INSERT INTO Cliente([ID],[CC],[nome],[apelido],[email],[telefone],[FK_IdAdmin]) VALUES(11,863486,'Magee','Gil','est@Donecat.co.uk','967141319','12345'),(12,420557,'Steven','Judith','vel.arcu.Curabitur@elit.edu','974468207','12345'),(13,160459,'Julie','Ezra','amet.orci@ultriciesadipiscing.com','920799746','12345'),(14,752518,'Griffith','Ebony','arcu.Vestibulum.ut@malesuadafames.net','962993628','12345'),(15,620031,'Ferdinand','Kevin','fringilla.purus.mauris@mollisduiin.co.uk','973021269','12345'),(16,571030,'Clark','Colorado','rutrum.urna.nec@luctusipsum.com','966389650','12345'),(17,518964,'Graham','Bruno','Ut.tincidunt@consectetueradipiscingelit.co.uk','957988198','12345'),(18,874276,'Ayanna','Clark','ligula.tortor@Innec.net','947104496','12345'),(19,782705,'Herman','Dominic','tellus@sodalesnisimagna.org','918856934','12345'),(20,250621,'Kristen','Olympia','Donec.tincidunt.Donec@nonlacinia.com','936364881','12345');
INSERT INTO Cliente([ID],[CC],[nome],[apelido],[email],[telefone],[FK_IdAdmin]) VALUES(21,449401,'Charlotte','Janna','elit.erat.vitae@metuseu.com','983417822','12345'),(22,905581,'Nichole','Mannix','in.sodales@sitamet.ca','946595441','12345'),(23,734524,'Ferris','Dante','risus@diamloremauctor.ca','991658495','12345'),(24,675942,'Duncan','Andrew','adipiscing@Donecnonjusto.edu','974633318','12345'),(25,688034,'Emma','Zephr','fringilla.ornare@nisi.net','984055301','12345'),(26,419519,'Tatum','Ariel','Aliquam.gravida.mauris@Maecenasmi.edu','992903917','12345'),(27,615888,'Dorian','Frances','ac.fermentum@laoreetipsum.com','918189437','12345'),(28,805059,'Nasim','Deanna','libero@imperdiet.org','963634934','12345'),(29,120931,'Maya','Lillian','urna@est.org','926889969','12345'),(30,206258,'Ruby','Wing','et.rutrum@sit.edu','975231580','12345');
INSERT INTO Cliente([ID],[CC],[nome],[apelido],[email],[telefone],[FK_IdAdmin]) VALUES(31,836132,'Aaron','Ignatius','pede.et.risus@posuerecubilia.co.uk','992731367','12345'),(32,796005,'Emi','Uta','Etiam.laoreet.libero@idsapien.com','966195418','12345'),(33,537186,'Kirestin','Kenyon','vel.convallis.in@arcuvelquam.co.uk','910643263','12345'),(34,973564,'Nigel','Hayden','eu@magna.com','905342561','12345'),(35,198469,'Ignatius','Christen','mi.tempor@consequatnec.net','933849427','12345'),(36,993468,'Lucy','Skyler','gravida.sagittis.Duis@portaelit.edu','934614026','12345'),(37,859680,'Demetrius','Althea','id.nunc@orciquis.org','948693273','12345'),(38,638235,'Xander','Lyle','lorem.vitae.odio@ipsumdolor.co.uk','942168596','12345'),(39,524473,'Zephr','Cyrus','Cras.vehicula.aliquet@perconubianostra.edu','966681872','12345'),(40,578796,'August','Kelly','elementum.lorem.ut@odiosemper.org','973977653','12345');
INSERT INTO Cliente([ID],[CC],[nome],[apelido],[email],[telefone],[FK_IdAdmin]) VALUES(41,502470,'Dean','Regan','metus@temporbibendumDonec.co.uk','920632809','12345'),(42,367053,'Lila','Cheryl','Maecenas.ornare.egestas@rutrumjusto.net','994110625','12345'),(43,652155,'Burke','Lois','a.auctor@Donec.edu','932075024','12345'),(44,742993,'Quinn','Hayley','hymenaeos.Mauris.ut@molestie.net','909147675','12345'),(45,383292,'Keane','Emily','fringilla.Donec@Nullasemper.co.uk','940911008','12345'),(46,517704,'Hakeem','Irma','dis@nislQuisquefringilla.edu','945854985','12345'),(47,212180,'Quinlan','Scarlet','massa.Suspendisse@lacinia.ca','965611927','12345'),(48,725685,'Avram','Travis','Nullam.ut@Loremipsum.org','998161538','12345'),(49,464588,'Graham','Ivor','molestie.in@gravidanonsollicitudin.co.uk','944328243','12345'),(50,673657,'Kellie','Logan','Donec@atrisusNunc.net','938089316','12345');
INSERT INTO Cliente([ID],[CC],[nome],[apelido],[email],[telefone],[FK_IdAdmin]) VALUES(51,122247,'Charde','Nicole','a@vitae.net','981843133','12345'),(52,450117,'Aristotle','Nicole','eget.tincidunt@Duisrisus.com','955093950','12345'),(53,240128,'Hadassah','Anjolie','Nullam.suscipit@diamPellentesquehabitant.co.uk','904211572','12345'),(54,959384,'Lacey','Byron','porttitor@Crasdictum.edu','986752175','12345'),(55,288217,'Riley','Chastity','diam.luctus.lobortis@mattis.org','921058634','12345'),(56,345221,'Clinton','Kevin','sit@Vestibulumanteipsum.ca','900567724','12345'),(57,347872,'Graiden','Kuame','Aenean@eu.ca','910461983','12345'),(58,201426,'Chiquita','Hiram','elit.pellentesque.a@ullamcorper.co.uk','906383653','12345'),(59,571186,'Paula','Kamal','bibendum.ullamcorper.Duis@Proinvel.net','998545600','12345'),(60,115759,'Teagan','Connor','nascetur.ridiculus@nislsemconsequat.net','907142191','12345');
INSERT INTO Cliente([ID],[CC],[nome],[apelido],[email],[telefone],[FK_IdAdmin]) VALUES(61,769994,'Inez','Dorothy','Nam@ornareegestas.ca','949682677','12345'),(62,805897,'Nissim','Brendan','blandit@vestibulumnec.ca','998194587','12345'),(63,648206,'Kirsten','Aubrey','penatibus@Quisquenonummy.com','998707833','12345'),(64,990954,'Emmanuel','Macaulay','augue.Sed@Nullam.ca','943961262','12345'),(65,699468,'Calvin','Zia','urna.justo@sapienNuncpulvinar.net','945335557','12345'),(66,199003,'Rogan','Sydney','quis@sitametmassa.net','936454585','12345'),(67,366497,'Alexandra','Trevor','tempor@tortor.org','978160235','12345'),(68,520737,'Marny','Austin','vel@euismodet.ca','934054398','12345'),(69,826326,'Samson','Xantha','eu.dui@asollicitudin.ca','988473562','12345'),(70,314715,'Hayfa','Gage','amet.dapibus.id@Nullam.net','986709513','12345');
INSERT INTO Cliente([ID],[CC],[nome],[apelido],[email],[telefone],[FK_IdAdmin]) VALUES(71,562207,'Renee','Jared','orci.Ut.semper@nonleoVivamus.net','994532058','12345'),(72,662623,'Oscar','Lars','eleifend.nec@euismodac.org','964554934','12345'),(73,423814,'Hiroko','Austin','turpis@tincidunt.co.uk','993471089','12345'),(74,768405,'Maggy','Margaret','cursus@sitamet.ca','953994537','12345'),(75,124647,'Urielle','Bernard','Suspendisse.aliquet.molestie@magnased.ca','953347601','12345'),(76,595711,'Dexter','Liberty','Sed.auctor@hendreritDonecporttitor.net','929403696','12345'),(77,533454,'Jordan','Hanae','convallis@aceleifend.co.uk','954161407','12345'),(78,410824,'Xaviera','Stella','nibh.Phasellus@lectusjustoeu.co.uk','986023682','12345'),(79,437529,'Amos','Lewis','elit.sed.consequat@tellusnon.edu','963638870','12345'),(80,850230,'Barclay','Nita','semper@Suspendisse.co.uk','912006365','12345');
INSERT INTO Cliente([ID],[CC],[nome],[apelido],[email],[telefone],[FK_IdAdmin]) VALUES(81,715940,'Uriel','Wanda','Cum.sociis@auctornuncnulla.org','995706417','12345'),(82,727151,'Kyle','Reagan','et.lacinia@convallisligulaDonec.ca','953275093','12345'),(83,353191,'Hilary','Timon','mi.fringilla@Pellentesquehabitantmorbi.com','948438658','12345'),(84,731088,'Graham','Linda','vitae@sagittisplacerat.com','972429803','12345'),(85,211512,'Octavius','Fulton','dolor.dapibus@laciniaat.com','913596178','12345'),(86,608170,'Gavin','Kevin','arcu.Nunc.mauris@ornare.edu','965825993','12345'),(87,264521,'Beverly','Felix','id.magna@Vivamussit.co.uk','941312244','12345'),(88,573395,'Kylynn','Naomi','nulla.Cras@lectusa.com','963878807','12345'),(89,133472,'Zenia','Tatyana','ultrices.Duis.volutpat@aliquetliberoInteger.com','923656108','12345'),(90,316719,'Hope','Hadley','nulla.Integer@liberoatauctor.ca','922617428','12345');
INSERT INTO Cliente([ID],[CC],[nome],[apelido],[email],[telefone],[FK_IdAdmin]) VALUES(91,692256,'Quin','Teegan','elit.pellentesque@penatibuset.ca','952917065','12345'),(92,477776,'Basil','Allistair','Nulla.dignissim@commodo.ca','936475644','12345'),(93,265638,'Zane','Joy','orci@Nuncmauris.co.uk','976171630','12345'),(94,196118,'Yoshio','Raven','Aliquam.fringilla.cursus@tristiqueneque.com','947813613','12345'),(95,955562,'Brett','Brenda','ornare.elit.elit@DonectinciduntDonec.co.uk','964778839','12345'),(96,431029,'Desirae','Caesar','cursus@infaucibus.org','995155158','12345'),(97,869257,'Cailin','Marny','ipsum.Donec@egetmetus.com','934681369','12345'),(98,976021,'Helen','Hillary','nascetur@sem.co.uk','996465206','12345'),(99,541843,'Ryder','Imogene','eleifend@velconvallisin.ca','998901355','12345'),(100,279448,'Tucker','Yardley','placerat.augue@SuspendisseeleifendCras.net','982867661','12345');

