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
--	ID Int PRIMARY KEY NOT NULL
--);

--CREATE TABLE Alojamento(
--	ID Int NOT NULL,
--	tipo Varchar(20) NOT NULL,
--	nome Varchar(30) NOT NULL,
--	preco Int NOT NULL,
--	localizacao VarChar(20),
--	FK_Tem2 Int,
--	PRIMARY KEY(ID),
--	UNIQUE(FK_Tem2)
--);

--CREATE TABLE Viagem(
--	ID Int NOT NULL,
--	dataInicial DATE NOT NULL,
--	dataFinal DATE NOT NULL,
--	numVagas Int,
--	precoTotal Int NOT NULL,
--	FK_Tem Int,
--	FK_IdAdmin Int REFERENCES Administrador(ID),
--	FK_IdAloj Int REFERENCES Alojamento(ID),
--	FK_Pag Int REFERENCES Pagamento(ID), 
--	FK_Client Int REFERENCES Cliente(ID),
--	PRIMARY KEY(ID),
--	UNIQUE(FK_Tem)
--);

--CREATE TABLE Destino(
--	codPostal Int NOT NULL,
--	pais Varchar(15) NOT NULL,
--	cidade Varchar(15) NOT NULL,
--	FK_Tem3 Int,
--	PRIMARY KEY(codPostal),
--	UNIQUE(FK_Tem3)
--);


--CREATE TABLE Transporte(
--	ID Int NOT NULL,
--	tipo Varchar(20) NOT NULL,
--	dataPartida DATE NOT NULL,
--	dataChegada DATE NOT NULL,
--	preco Int NOT NULL,
--	companhia Varchar(20) NOT NULL,
--	numPassageiros Int NOT NULL,
--	FK_Tem Int,
--	FK_Dest Int REFERENCES Destino(codPostal),
--	PRIMARY KEY(ID),
--	UNIQUE(FK_Tem)	
--);

--CREATE TABLE Tem(
--	ID1 Int NOT NULL,
--	ID2 Int NOT NULL,
--	PRIMARY KEY(ID1, ID2),
--	FOREIGN KEY (ID1) REFERENCES Transporte(FK_Tem),
--	FOREIGN KEY (ID2) REFERENCES Viagem(FK_Tem) 
--);


--CREATE TABLE Pacote(
--	ID Int NOT NULL,
--	precoTotal Int NOT NULL,
--	preco Int NOT NULL,
--	FK_Tem2 Int,
--	FK_Tem3 Int,
--	FK_IdAdmin Int REFERENCES Administrador(ID),
--	FK_Dest Int REFERENCES Destino(codPostal),
--	UNIQUE(FK_Tem3),
--	UNIQUE(FK_Tem2)
--);

--CREATE TABLE Tem_2(
--	ID1 Int NOT NULL,
--	ID2 Int NOT NULL,
--	preco Int NOT NULL,
--	PRIMARY KEY(ID1, ID2),
--	FOREIGN KEY (ID1) REFERENCES Pacote(FK_Tem2),
--	FOREIGN KEY (ID2) REFERENCES Alojamento(FK_Tem2)
--);

--CREATE TABLE Tem_3(
--	ID Int NOT NULL,
--	codPostal Int NOT NULL,
--	preco Int NOT NULL,
--	PRIMARY KEY(codPostal, ID),
--	FOREIGN KEY (codPostal) REFERENCES Destino(FK_Tem3),
--	FOREIGN KEY (ID) REFERENCES Pacote(FK_Tem3)
--);

--GO

--CREATE PROC UpdateCliente
--	@ID Int,
--	@CC Int,
--	@nome Varchar(20),
--	@apelido Varchar(20),
--	@email Varchar(20),
--	@telefone Int,
--	@message Varchar(20) output

--	AS

--	BEGIN
--		SET NOCOUNT ON
--		BEGIN TRY
--		UPDATE Cliente
--		SET nome = @nome, apelido = @apelido, telefone = @telefone, CC = @CC, email = @email
--		WHERE ID = @ID
--		SET @message = 'Success'

--	END TRY

--	BEGIN CATCH
--		SET @message = error_message()
--	END CATCH

--	END
--GO
--------------------------------------------------------
drop proc DeleteCliente
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
 

--GO
--drop proc AddClient


--GO
--CREATE PROCEDURE AddClient
--	@ID Int,
--	@CC Int,
--	@nome Varchar(20),
--	@apelido Varchar(20),
--	@email Varchar(20),
--	@telefone Int,
--	@message Varchar(20) output
--AS
--BEGIN

--	SET NOCOUNT ON
	
--	BEGIN TRY

--		INSERT INTO Cliente(ID, CC, nome, apelido, email, telefone)
--		VALUES ( @ID,@CC, @nome, @apelido, @email, @telefone)

--		SET @message = 'Success'
--	END TRY
--	BEGIN CATCH
--		SET @message = error_message()
--	END CATCH
--END
--GO
--------------------------------------------------------------------------
--INSERT INTO Cliente([ID],[CC],[nome],[apelido],[email],[telefone]) VALUES(1,509418,'Karina','Paula','mi.tempor.lorem@sempercursusInteger.net',' 919013812'),(2,971045,'Sacha','Briar','Curabitur.ut.odio@arcu.net',' 917290607'),(3,606324,'Quin','Hyatt','Morbi.non.sapien@Cum.org','961367432 '),(4,259685,'Jessica','Veronica','tellus@inmagna.org','964763480 '),(5,493737,'Jana','Yoshi','elit@mitemporlorem.com',' 913348867'),(6,283398,'Ciaran','Burton','iaculis.nec.eleifend@facilisis.edu',' 918187775'),(7,226257,'Mary','Cooper','nec.ante.Maecenas@convallis.co.uk','969387793 '),(8,229472,'Stephen','Summer','Sed.nunc@nisinibhlacinia.net','969975128 '),(9,949154,'Abbot','Brielle','auctor.velit@Duissit.ca','963720584 '),(10,734933,'Oren','Ariel','odio.Aliquam@massa.org',' 914655303');
--INSERT INTO Cliente([ID],[CC],[nome],[apelido],[email],[telefone]) VALUES(11,432812,'Vladimir','Fay','id.mollis.nec@a.ca',' 918216801'),(12,313455,'Samson','Rosalyn','mollis.lectus.pede@Nullam.edu',' 915101531'),(13,337572,'Raven','Denton','Donec@augueutlacus.net',' 915892387'),(14,766885,'Zena','Russell','vel.mauris@etmagnisdis.co.uk','969325622 '),(15,946542,'Ella','Brenden','et.ultrices.posuere@vitae.co.uk','962664339 '),(16,397851,'Nola','Adrienne','Sed@turpisNullaaliquet.net','961694485 '),(17,788861,'Moses','Fulton','placerat.Cras.dictum@lacus.edu',' 914058516'),(18,347913,'Mary','George','Cras.interdum.Nunc@erat.edu','963927882 '),(19,291925,'Priscilla','Cassandra','lorem@lectusconvallisest.org',' 916366836'),(20,242507,'Maisie','Farrah','dolor.Fusce.feugiat@ultricesiaculis.ca',' 914262842');
--INSERT INTO Cliente([ID],[CC],[nome],[apelido],[email],[telefone]) VALUES(21,932181,'Abra','Cassidy','faucibus.lectus@euodio.com','961290834 '),(22,510404,'Stephen','Marny','consectetuer@Praesenteunulla.com','962976540 '),(23,457383,'Orlando','Zephania','felis.purus@orciluctus.net','968709973 '),(24,252031,'Rhoda','Lewis','lacinia@fringillami.ca',' 910999121'),(25,787574,'Hop','Yuli','fames.ac.turpis@Craseu.ca','962761799 '),(26,723455,'Dakota','Jana','sit.amet@posuerecubiliaCurae.org','963893696 '),(27,829470,'Katelyn','Jerome','ante.bibendum@enimSuspendisse.org',' 916025496'),(28,405384,'Levi','Shelley','porttitor.eros.nec@egestasSed.org','962555802 '),(29,654047,'Robin','Hermione','aliquam.enim@egetmagna.ca','964320352 '),(30,626656,'Keane','Marny','eu.sem.Pellentesque@semelit.com','963386401 ');
--INSERT INTO Cliente([ID],[CC],[nome],[apelido],[email],[telefone]) VALUES(31,985992,'Yolanda','Russell','sem.semper.erat@Sed.net',' 914355769'),(32,325397,'Lionel','Danielle','semper.dui@egestas.org','963580193 '),(33,451504,'Berk','Risa','egestas@odio.com',' 916052523'),(34,581409,'Kessie','Fatima','ut.pharetra@Phasellus.com','962930432 '),(35,579866,'Zachary','Alan','egestas@neque.ca',' 913371673'),(36,664419,'Rinah','Lucius','arcu@Uttincidunt.ca','961321372 '),(37,430427,'Madeline','Cherokee','vel@Maecenas.co.uk','961259713 '),(38,956401,'Henry','Lucian','Proin@justonec.net',' 917624481'),(39,910035,'Kelsey','Hall','iaculis.nec.eleifend@sit.com',' 918785030'),(40,300432,'Edan','Ila','parturient@tempuseu.com',' 914487169');
--INSERT INTO Cliente([ID],[CC],[nome],[apelido],[email],[telefone]) VALUES(41,709352,'Cade','Lila','Praesent.eu.nulla@Donec.com','966085812 '),(42,642853,'Kareem','Louis','et@luctusCurabituregestas.net','968291647 '),(43,265878,'Shellie','Brent','tempus.non.lacinia@ipsumprimisin.com',' 910192768'),(44,364752,'Bianca','Camden','nulla@quamelementum.ca','962784330 '),(45,178698,'Claudia','Ima','lorem@velitAliquamnisl.edu',' 916487054'),(46,344074,'Odette','Brooke','Donec@hymenaeosMauris.edu',' 916353169'),(47,976245,'Amir','Vance','orci.Phasellus@sit.net',' 915703993'),(48,156584,'Madison','Salvador','Nunc.ut.erat@fermentumfermentumarcu.org','968653112 '),(49,464765,'Martha','Kasimir','arcu.Sed@Aenean.org','967627949 '),(50,719145,'Yardley','Jeremy','Class.aptent.taciti@sitamet.ca','967018701 ');
--INSERT INTO Cliente([ID],[CC],[nome],[apelido],[email],[telefone]) VALUES(51,159021,'Ethan','Quemby','aliquet.libero.Integer@mi.co.uk','966411182 '),(52,907126,'Sylvester','Barbara','vel.est.tempor@atiaculisquis.co.uk',' 911563377'),(53,709427,'Zelda','Cadman','pede@neque.ca',' 918203162'),(54,121702,'Randall','Hanna','gravida.sagittis.Duis@dolor.co.uk',' 914230701'),(55,323737,'Pamela','Sean','Proin.vel.arcu@porttitorerosnec.edu','963564954 '),(56,750721,'Rogan','Tyrone','sit.amet.ante@ridiculusmusProin.net','960125602 '),(57,785752,'Dawn','Kevin','commodo@feugiatnonlobortis.com','967286764 '),(58,444898,'Jameson','Aphrodite','primis.in.faucibus@diamdictumsapien.net','965527604 '),(59,694470,'Amery','Lacota','eget@Pellentesque.net',' 916578713'),(60,279681,'Debra','Yardley','neque.Morbi@adipiscing.ca',' 919798605');
--INSERT INTO Cliente([ID],[CC],[nome],[apelido],[email],[telefone]) VALUES(61,939396,'Jane','Tasha','tellus@arcu.edu','967332781 '),(62,360419,'Lyle','Kerry','ligula.Aenean@Nullam.net',' 911528991'),(63,468529,'Tallulah','Fatima','ipsum.porta.elit@at.edu',' 916292356'),(64,328545,'Allistair','Darius','placerat@nunc.co.uk',' 916049140'),(65,587567,'Cade','Ira','egestas@vulputateullamcorper.ca','965166965 '),(66,236296,'Duncan','Victoria','dapibus@Duis.net','960678829 '),(67,283193,'Dawn','Timothy','Curabitur.vel@fermentum.com','960941727 '),(68,645059,'Emery','Meredith','dui.Fusce@penatibusetmagnis.org',' 910636056'),(69,164374,'Bethany','Unity','faucibus@fringilla.edu','963354713 '),(70,664847,'Halla','Molly','augue.scelerisque@idmagnaet.ca','963344948 ');
--INSERT INTO Cliente([ID],[CC],[nome],[apelido],[email],[telefone]) VALUES(71,217225,'Rinah','Lee','sapien.imperdiet.ornare@conubia.org','964355459 '),(72,118522,'Callum','Elijah','risus.Duis.a@laoreetlibero.edu',' 913119946'),(73,535366,'Molly','Todd','sem@magnaa.net','965894990 '),(74,885205,'Diana','Magee','augue.ac.ipsum@malesuadaaugueut.co.uk','961480779 '),(75,865201,'Halee','Ahmed','pulvinar.arcu@Donecegestas.edu',' 911215247'),(76,244185,'Darrel','Otto','ipsum@velarcuCurabitur.edu','969816679 '),(77,586238,'Renee','Raphael','dictum.eleifend.nunc@pretium.com',' 918776673'),(78,621199,'Mannix','Aurora','rhoncus.id@eudoloregestas.co.uk','963945205 '),(79,292438,'Grace','Phyllis','Mauris.quis@Quisqueac.ca',' 916713948'),(80,116338,'Yardley','Theodore','neque.et@ligulaconsectetuer.co.uk',' 916688411');
--INSERT INTO Cliente([ID],[CC],[nome],[apelido],[email],[telefone]) VALUES(81,621662,'Quinn','Hop','euismod.urna.Nullam@turpisegestas.org',' 914428603'),(82,475186,'Byron','Carla','lectus.ante@dolorFusce.co.uk','969088303 '),(83,916048,'Lucy','Laith','malesuada@sedturpis.edu',' 913889123'),(84,702124,'Donovan','Brendan','urna@Phasellus.edu',' 919421051'),(85,746599,'Chadwick','Kennedy','odio.vel.est@Nullatincidunt.net','964101033 '),(86,407491,'Wayne','Keelie','sit@bibendumfermentummetus.ca',' 914372278'),(87,518235,'Edward','Ishmael','primis.in.faucibus@Vestibulumaccumsan.ca',' 918806288'),(88,928040,'Uriel','Charissa','convallis@atfringilla.edu',' 913573062'),(89,803251,'Florence','Lesley','montes.nascetur@sedturpis.co.uk',' 913494451'),(90,919342,'Glenna','Driscoll','et.risus@aaliquetvel.org',' 914253399');
--INSERT INTO Cliente([ID],[CC],[nome],[apelido],[email],[telefone]) VALUES(91,105433,'Yen','Darrel','mauris.erat.eget@sedsemegestas.org','965276504 '),(92,813143,'Maisie','Hadley','cursus.et.magna@rutrum.ca','963792987 '),(93,163516,'Tasha','Amy','a@vulputatenisisem.com',' 911233283'),(94,734933,'Amela','Sasha','Vestibulum.ut.eros@congue.ca',' 916130230'),(95,883623,'Kiona','Teegan','aliquam.enim@liberoProin.net',' 918468235'),(96,227534,'Dominic','Lilah','a.ultricies.adipiscing@Phasellusornare.com',' 918553528'),(97,708932,'Georgia','Tanek','faucibus@aultricies.co.uk','962653933 '),(98,477171,'Sheila','Maryam','nascetur@adipiscingfringilla.org','965160999 '),(99,921499,'Haley','Lysandra','nibh.enim.gravida@mauris.com','963061807 '),(100,607531,'Paki','Hunter','sed@orciPhasellus.edu',' 919973070');
--INSERT INTO Cliente([ID],[CC],[nome],[apelido],[email],[telefone]) VALUES(0,509568,'Paula','Da','paulada@sempercursusInteger.net',' 919014512')
Select * from Cliente;