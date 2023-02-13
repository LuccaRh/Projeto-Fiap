CREATE TABLE SiteVarejoFiap.dbo.Varejo(
	Id INT PRIMARY KEY IDENTITY,
	Rua VARCHAR(1000),
	Email VARCHAR(500) NOT NULL,
	Nome VARCHAR(200) NOT NULL,
	Numero VARCHAR(100),
	Telefone VARCHAR(30),
	DataDeNascimento VARCHAR(20),
	Cpf VARCHAR(20),
	Cep VARCHAR(10),
)

SELECT * FROM SiteVarejoFiap.dbo.Varejo;

/*DROP TABLE SiteVarejoFiap.dbo.Varejo;

DELETE FROM SiteVarejoFiap.dbo.Varejo;*/

ALTER TABLE SiteVarejoFiap.dbo.Varejo ADD CONSTRAINT email_unico UNIQUE (Email);