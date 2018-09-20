--Definição da estrutura da tabela de alunos
CREATE TABLE dbo.TB_ALUNO
(
	 Id BIGINT NOT NULL PRIMARY KEY IDENTITY(1000,1) --Campo de chave primário, auto-incremental, iniciando do valor 1000 e com incrementos de 1
	,CPF VARCHAR(11) NOT NULL
	,Nome VARCHAR(100) NOT NULL
	,Endereco VARCHAR(100) NOT NULL
	,UF CHAR(2) NOT NULL
	,Municipio VARCHAR(50) NOT NULL
	,Telefone VARCHAR(15) NOT NULL
	,Email VARCHAR(100) NOT NULL
	,Senha VARCHAR(1024) NOT NULL
)
GO

--Definição de índices a fim de garantir integridade das informações
CREATE UNIQUE NONCLUSTERED INDEX IX_ALUNO_CPF ON dbo.TB_ALUNO(CPF);
GO
CREATE UNIQUE NONCLUSTERED INDEX IX_ALUNO_Nome ON dbo.TB_ALUNO(Nome);
GO
CREATE UNIQUE NONCLUSTERED INDEX IX_ALUNO_Email ON dbo.TB_ALUNO(Email);
GO

--Definição de restrição de checagem de UFs a fim de garanti integridade das informações
ALTER TABLE dbo.TB_ALUNO ADD CONSTRAINT CHK_UF CHECK (UF IN('AC','AL','AM','AP','BA','CE','DF','ES','GO','MA','MG','MS','MT','PA','PB','PE','PI','PR','RJ','RN','RO','RR','RS','SC','SE','SP','TO'));

--Carga de dados de exemplo de alunos
--ALGORITMO DE HASH: SHA256
INSERT INTO dbo.TB_ALUNO(CPF, Nome, Endereco, UF, Municipio, Telefone, Email, Senha) VALUES
('87558857805','Adriana Selles', 'Rua Constelação de Sagitário, 121','SP','São Paulo','11987545623','adriana.selles@bol.com.br','0c65f376c526d32cf7b25a49715bcc6613485dfd511a599c5c2d87a29c0612cb'), -- @dri$E01#
('50562367640','Rodrigo Mendes Souza Lima', 'Rua das Pitombeiras, 35','SP','São Paulo','11934885452','rm.lima@terra.com.br','79b009791ece5e0a8f82658542a8a06d9d6c353d975f820b2a0df80824302985'), -- ry0tO!@
('44621389700','Cláudia Zakauskas Krzstoff', 'Avenida João gabeira, 4529','SP','São Paulo','11996624565','claudiazk@myrealbox.com','3881769b9e2d89df151838cc947a7a549a968e807bcb018990589ccd7f1e66f5'), -- cL@ud1@2018
('40491556489','Márcio Di Marzio', 'Avenida Rubem Berta, 1252','SP','São Paulo','11971005458','mdmz@outlook.com','ad977964c01b8315b6b6e0fefc48be1015178c08d83fa55ed9475ab917d5c30b'), -- M@rz!021082009
('56165063705','Suzana Tavares Alvarenga', 'Alameda Arapanés, 455','SP','São Paulo','11912129642','stalvarenga@hotmail.com','84ccd133d41f7f0d38c3dc72b6aec89659dc849c0e3c389c1618eaa6822df3ec') -- @lvarenga!$*
GO

--Procedimento de recuperação de dados do usuário com base no e-mail e senha (usado no processo de autenticação da aplicação)
CREATE PROCEDURE dbo.P_ALUNO_AUTENTICAR
(
	 @pEmail VARCHAR(100)
	,@pSenha VARCHAR(1024)
)
AS
BEGIN
	SELECT
		 Id
		,CPF
		,Nome
		,Endereco
		,UF
		,Municipio
		,Telefone
		,Email
	FROM dbo.TB_ALUNO
	WHERE
		Email = @pEmail AND Senha = @pSenha;
END;
GO

--Exemplo de chamada ao procedimento armazenado de pesquisa
dbo.P_ALUNO_AUTENTICAR 'adriana.selles@bol.com.br','0c65f376c526d32cf7b25a49715bcc6613485dfd511a599c5c2d87a29c0612cb'