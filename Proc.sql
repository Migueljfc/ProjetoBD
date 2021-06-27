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
		
--			UPDATE Cliente
--			SET nome = @nome, apelido = @apelido, telefone = @telefone, CC = @CC, email = @email
--			WHERE ID = @ID 
		
--			SET @message = 'Editado com sucesso'

--		END TRY

--	BEGIN CATCH
--		SET @message = error_message()
--	END CATCH
--	END


--GO

--CREATE PROC DeleteCliente
--    @ID Int,
--    @message Varchar(20) output

--	AS
--	BEGIN
--        SET NOCOUNT ON
        
--        BEGIN TRY
--            DELETE Cliente WHERE ID = @ID
            
--            SET @message='Apagdo com successo'
        
--        END TRY

--        BEGIN CATCH
--            SET @message=error_message()
--        END CATCH
--END
 

--GO

---------------------------------------------------------

--GO
--CREATE PROCEDURE AddClient
--	@ID Int,
--	@CC Int,
--	@nome Varchar(20),
--	@apelido Varchar(20),
--	@email Varchar(20),
--	@telefone Int,
--	@FK_idAdmin Int,
--	@message Varchar(20) output
--AS
--BEGIN

--	SET NOCOUNT ON
	
--	BEGIN TRY

--		INSERT INTO Cliente(ID, CC, nome, apelido, email, telefone,FK_IdAdmin)
--		VALUES ( @ID,@CC, @nome, @apelido, @email, @telefone,@FK_idAdmin)

--		SET @message = 'Criado com successo'
--	END TRY
--	BEGIN CATCH
--		SET @message = error_message()
--	END CATCH
--END
--GO


-----------------------------------------------

--GO

--CREATE PROC AddViagem
--	@ID Int,
--	@dataInicial DATE,
--	@dataFinal DATE,
--	@numVagas Int,
--	@precoTotal Int,
--	@FK_IdAdmin Int,
--	@FK_IdAloj Int ,
--	@FK_IdTrans Int,
--  @FK_IdDest Int,
--	@FK_Pag  Int, 
--	@Pago Int,
--	@FK_Client Int,
--	@message Varchar(20) output


--AS

--BEGIN
	
--	SET NOCOUNT ON
	
--	BEGIN TRY
--		INSERT INTO Viagem(ID, dataInicial, dataFinal, numVagas, precoTotal, FK_IdAdmin, FK_IdAloj, FK_IdTrans, FK_Pag,FK_Client,FK_IdDest)
--		VALUES (@ID, @dataInicial, @dataFinal, @numVagas, @precoTotal,@FK_IdAdmin, @FK_IdAloj, @FK_IdTrans,@FK_Pag,@FK_Client, @FK_IdDest);
--		INSERT INTO Pagamento(ID, Pago) VALUES (@ID, @Pago);
--		SET @message = 'Criado com successo'

--	END TRY
--	BEGIN CATCH
--		SET @message = error_message()
--	END CATCH
--END
--GO

-----------------------------------------------

----drop proc AddAlojamento
--CREATE PROC AddAlojamento
--	@ID Int,
--	@tipo Varchar(20),
--	@nome Varchar(30),
--	@preco Int,
--	@FK_Dest Int,
--	@message Varchar(20) output

--AS

--BEGIN
	
--	SET NOCOUNT ON
	
--	BEGIN TRY
--		INSERT INTO Alojamento(ID, tipo, nome, preco,FK_Dest)
--		VALUES (@ID, @tipo, @nome, @preco, @FK_Dest)

--		SET @message = 'Criado com successo'

--	END TRY
--	BEGIN CATCH
--		SET @message = error_message()
--	END CATCH
--END
--GO

-----------------------------------------------

--GO

--CREATE PROC AddTransporte
--	@ID Int,
--	@tipo Varchar(20),
--	@dataPartida DATE,
--	@dataChegada DATE,
--	@preco Int,
--	@companhia Varchar(20),
--	@numPassageiros Int,
--	@FK_Dest Int,
--	@message Varchar(20) output

--AS

--BEGIN
	
--	SET NOCOUNT ON
	
--	BEGIN TRY
--		INSERT INTO Transporte(ID, tipo, dataPartida, dataChegada, preco, companhia, numPassageiros, FK_Dest)
--		VALUES (@ID, @tipo, @dataPartida, @dataChegada, @preco, @companhia, @numPassageiros, @FK_Dest)

--		SET @message = 'Criado com successo'

--	END TRY
--	BEGIN CATCH
--		SET @message = error_message()
--	END CATCH
--END
--GO

---------------------------------------------

--GO

--CREATE PROC AddDestino
--	@ID INT,
--	@codPostal VarChar(20),
--	@pais Varchar(15),
--	@cidade Varchar(15),
--	@message Varchar(20) output

--AS

--BEGIN
	
--	SET NOCOUNT ON
	
--	BEGIN TRY
--		INSERT INTO Destino(ID,codPostal, pais, cidade)
--		VALUES (@ID,@codPostal, @pais, @cidade)

--		SET @message = 'Criado com successo'

--	END TRY
--	BEGIN CATCH
--		SET @message = error_message()
--	END CATCH
--END
--GO



--CREATE PROC DeleteDestino
--	@ID INT,
--	@message Varchar(20) output
--	AS
--	BEGIN
--	SET NOCOUNT ON
--		BEGIN TRY
--			DELETE Destino WHERE ID = @ID
--			SET @message = 'Apagdo com successo'
--		END TRY
--		BEGIN CATCH
--			SET @message = error_message()
--		END CATCH
--	END

--GO

--CREATE PROC DeleteAlojamento
--	@ID INT,
--	@message Varchar(20) output
--	AS
--	BEGIN
--	SET NOCOUNT ON
--		BEGIN TRY
--			Delete from Tem_2 WHERE ID2 = @ID;
--			Update Viagem Set FK_IdAloj = NULL Where FK_IdAloj = @ID
--			DELETE Alojamento WHERE ID = @ID;
--			SET @message = 'Apagado com Sucesso'
--		END TRY
--		BEGIN CATCH
--			SET @message = error_message()
--		END CATCH
--	END
--GO

--GO

--CREATE PROC DeleteTransporte
--	@ID INT,
--	@message Varchar(20) output
--	AS
--	BEGIN
--	SET NOCOUNT ON
--		BEGIN TRY
--			Delete from Tem_3 WHERE ID2 = @ID;
--			DELETE Tem WHERE ID1 = @ID;
--			Delete Transporte Where ID = @ID;
--			SET @message = 'Apagado com Sucesso'
--		END TRY
--		BEGIN CATCH
--			SET @message = error_message()
--		END CATCH
--	END
--GO