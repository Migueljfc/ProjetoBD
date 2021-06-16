--CREATE TABLE Administrador(
--	ID Int NOT NULL,
--	nome Varchar(10) NOT NULL,
--	apelido Varchar(20) NOT NULL,
--	PRIMARY KEY(ID)
--);

--CREATE TABLE Cliente(
--	CC Int NOT NULL,
--	nome Varchar(10) NOT NULL,
--	apelido Varchar(20) NOT NULL,
--	email Varchar(50) NOT NULL,
--	telefone Int NOT NULL,
--	FK_IdAdmin Int REFERENCES Administrador(ID),
--	PRIMARY KEY(CC)
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
--		SET nome = @nome, apelido = @apelido, telefone = @telefone, CC = @CC
--		WHERE CC = @CC
--		SET @message = 'Success'

--	END TRY

--	BEGIN CATCH
--		SET @message = error_message()
--	END CATCH

--	END
--GO
------------------------------------------------------
INSERT INTO Cliente([nome],[apelido],[CC],[telefone],[email]) VALUES('Cairo','Leo',402986611,'969126695','sodales.Mauris.blandit@nonleo.net'),('Sebastian','Tarik',845350463,'962486468','in@accumsaninterdumlibero.org'),('Keefe','Len',616949788,'966609017','arcu.Sed.eu@ornarelectus.net'),('Abdul','Noah',451895119,'969545760','nisl@Duismi.co.uk'),('Burke','Hall',361442736,'963910493','posuere@imperdietnec.edu'),('Prescott','Hop',450128695,'960875342','nec@vulputate.ca'),('Justin','Jacob',629606792,'965715304','libero.Proin@Aeneaneget.edu'),('Aristotle','Otto',886509107,'968017685','nulla.Integer.vulputate@ametmassaQuisque.edu'),('Dustin','Jameson',110011967,'968172234','nisl.Quisque@nasceturridiculusmus.org'),('Castor','Gabriel',357974305,'966242904','ut.pellentesque@Quisque.net');
INSERT INTO Cliente([nome],[apelido],[CC],[telefone],[email]) VALUES('Norman','Gavin',132817452,'961949649','auctor.Mauris.vel@rhoncusProin.com'),('Kadeem','Jordan',87446538,'964406614','metus.Aliquam.erat@PraesentluctusCurabitur.co.uk'),('Cameron','Walker',35017911,'966817610','massa.Integer@Donec.com'),('Ezekiel','Octavius',643181501,'968696901','erat@scelerisqueneque.ca'),('Emmanuel','Jasper',798972789,'964601106','vulputate.posuere.vulputate@pellentesque.com'),('Curran','Brenden',72670190,'962634151','sagittis@enim.net'),('Burton','Carl',103150641,'967700180','imperdiet.dictum@arcuimperdiet.edu'),('Rogan','Travis',162863562,'968009589','Integer.mollis@Morbi.net'),('Garrett','Ciaran',365677425,'960343051','feugiat.placerat.velit@fringilla.net'),('Shad','Donovan',407923916,'960901356','odio@Duis.ca');
INSERT INTO Cliente([nome],[apelido],[CC],[telefone],[email]) VALUES('Ivor','Yardley',704083842,'966026421','consequat@semper.edu'),('Lance','Stephen',108639065,'964239640','vestibulum.massa.rutrum@non.net'),('Troy','Wing',555871214,'967292298','nec.cursus@sit.edu'),('Michael','Hasad',744762790,'968214975','nec@orciluctuset.co.uk'),('Jason','Quamar',335645640,'967278462','risus.varius@aliquetodioEtiam.co.uk'),('Elton','Quinlan',16930518,'961281899','sociis.natoque.penatibus@duiCraspellentesque.net'),('Odysseus','Kennedy',596453637,'969348367','tincidunt.orci@aultricies.edu'),('Cameron','Bradley',584833331,'969864307','Phasellus.ornare@vehiculaaliquet.org'),('Arthur','Carl',652020877,'968366214','Etiam.imperdiet.dictum@nuncacmattis.co.uk'),('Callum','Erasmus',147809830,'963408346','sem.mollis@ipsumCurabitur.net');
INSERT INTO Cliente([nome],[apelido],[CC],[telefone],[email]) VALUES('Ulysses','Keegan',491713695,'967793161','sed.turpis@lectus.ca'),('Addison','Dorian',413203310,'967912839','senectus@etmagnisdis.net'),('Lars','Honorato',657205370,'964822689','nunc.ullamcorper.eu@vitaealiquam.ca'),('Felix','Odysseus',637513905,'965926489','accumsan.laoreet.ipsum@atauctor.com'),('Dean','Deacon',64123406,'963846620','justo.eu.arcu@tincidunt.com'),('Brian','Cade',237874056,'963024533','diam.dictum@nisi.net'),('Thaddeus','Stephen',301528637,'964576345','ornare.In.faucibus@doloregestas.co.uk'),('Burke','Cruz',167416028,'965197591','non.vestibulum@quam.edu'),('Driscoll','Kaseem',559785734,'961015481','at.augue@suscipitnonummyFusce.edu'),('Barclay','Ivan',480242957,'963752103','Etiam.ligula.tortor@mattisvelit.org');
INSERT INTO Cliente([nome],[apelido],[CC],[telefone],[email]) VALUES('Kane','Carl',831287197,'969614577','dolor@diamDuismi.com'),('Alan','Rogan',750953331,'968507718','dapibus.rutrum@ornaresagittis.co.uk'),('Ryder','Ignatius',805983253,'960690311','magnis@nullaatsem.org'),('Wing','Ray',974796146,'963379155','sit@non.com'),('Mufutau','Jamal',406213417,'969156647','Proin@malesuada.com'),('Jonas','Guy',62594091,'968755582','Etiam.gravida.molestie@Integerinmagna.edu'),('Harding','Wing',186872952,'964559750','Ut.semper@ante.edu'),('Chaney','Merritt',213693587,'961763172','non@Nuncmauris.com'),('Walker','Dolan',86553628,'964468175','egestas@rutrumlorem.net'),('Jack','Wyatt',265603127,'965299041','nibh@pedenec.org');
INSERT INTO Cliente([nome],[apelido],[CC],[telefone],[email]) VALUES('Austin','Laith',359654636,'969324667','Integer.urna.Vivamus@congue.org'),('Aaron','Lyle',824850204,'962840520','felis.adipiscing@sedtortor.co.uk'),('Colt','Colt',200429498,'961217807','pede.blandit.congue@blanditcongue.ca'),('Zane','Colorado',377231070,'966047000','parturient@Donecest.com'),('Zephania','Carson',319372733,'966230248','eros.turpis.non@justo.ca'),('Rahim','Harrison',670769846,'968253983','et@ipsumSuspendisse.org'),('Brady','Ivor',498880872,'965852470','sagittis@erosturpis.co.uk'),('Carter','Jonas',291624853,'963522124','orci@Crassedleo.com'),('Alden','Carter',275194782,'963625065','malesuada@Proineget.net'),('Harrison','Timon',845459657,'966369183','accumsan.neque@lectus.org');
INSERT INTO Cliente([nome],[apelido],[CC],[telefone],[email]) VALUES('Clinton','Marshall',896581527,'966720560','eget@vulputateposuerevulputate.net'),('Louis','Kaseem',576997759,'967957353','a@tristiquesenectuset.edu'),('Kasper','Alvin',424241559,'961489071','blandit.mattis.Cras@commodoatlibero.org'),('Fuller','Hamilton',414837227,'969084516','est@sed.net'),('Brennan','Kennedy',372289157,'969104917','et@imperdieteratnonummy.edu'),('Colin','Hunter',805199034,'967184838','dolor.vitae@urnasuscipit.org'),('Clarke','Zachary',282437937,'965996793','id@egestas.ca'),('Fulton','Merritt',341988861,'969132246','nonummy.ultricies.ornare@tellusPhasellus.net'),('Cain','Gray',752345062,'963261163','et@eratvolutpatNulla.org'),('Ethan','Myles',691008340,'966719611','congue@Quisquelibero.ca');
INSERT INTO Cliente([nome],[apelido],[CC],[telefone],[email]) VALUES('Merritt','Colby',183101983,'960384888','Nam.porttitor@euismodet.edu'),('Josiah','Uriel',466121312,'965836651','at.pretium.aliquet@anteVivamus.ca'),('Porter','Nicholas',181330510,'964204342','nisi@atnisi.edu'),('Ian','Hakeem',661062403,'967923719','sagittis@gravidaAliquamtincidunt.ca'),('Nasim','Jared',778264377,'964890368','elit@dignissimpharetraNam.edu'),('Mufutau','Kuame',405031852,'969063575','erat.Sed.nunc@facilisiSedneque.edu'),('Ian','Malachi',388498187,'961389160','tincidunt@Nunclaoreetlectus.net'),('Gannon','Samuel',238534177,'962451620','Praesent.interdum@enimEtiam.net'),('Elmo','Brendan',79286527,'966802585','at.arcu@porttitorvulputateposuere.edu'),('Philip','Carlos',513053098,'963454314','odio.semper@eget.net');
INSERT INTO Cliente([nome],[apelido],[CC],[telefone],[email]) VALUES('Mannix','Micah',341236886,'962727614','arcu.Sed.et@imperdietullamcorper.org'),('Reese','Geoffrey',614401256,'968467948','ut.molestie.in@ac.ca'),('Marshall','Tobias',168513188,'962896074','Nullam.lobortis@sempertellusid.com'),('Abdul','Dale',451407073,'961017264','convallis.erat@vehiculaaliquetlibero.com'),('Preston','Abraham',143839057,'961892553','penatibus.et.magnis@Maurismagna.ca'),('Kibo','Hayden',584308326,'964466180','sed.libero@mollis.com'),('Tad','Hiram',852254569,'965788595','pulvinar@maurisutmi.net'),('Hasad','Armand',926387621,'962826811','est@interdumCurabiturdictum.org'),('Aquila','Isaac',322761379,'967517730','semper@Donecnibh.ca'),('Lester','Connor',539064579,'961656814','enim.Etiam@anteMaecenas.org');
INSERT INTO Cliente([nome],[apelido],[CC],[telefone],[email]) VALUES('Isaac','Wayne',230221413,'960186540','eget.tincidunt@feugiatmetus.edu'),('Emmanuel','Jacob',10545328,'963592946','sed@sit.co.uk'),('Shad','Dennis',389740808,'965700444','Duis.dignissim@pedeblanditcongue.org'),('Malcolm','Yoshio',563226218,'967751621','leo.Morbi@Crasvehiculaaliquet.co.uk'),('Kenneth','Xanthus',198628527,'966599626','lacus@risus.org'),('Elton','Erich',714597453,'967041769','in.faucibus@vulputateullamcorpermagna.co.uk'),('Eaton','Driscoll',115535920,'963789492','neque.Nullam@consequatpurusMaecenas.edu'),('Solomon','Howard',992691207,'968107362','aliquet.Proin.velit@cursus.co.uk'),('Tyrone','Marshall',651831157,'964963055','Sed.et.libero@nuncacmattis.ca'),('Lance','Harlan',864763266,'961668772','aliquet.magna.a@Suspendisse.ca');