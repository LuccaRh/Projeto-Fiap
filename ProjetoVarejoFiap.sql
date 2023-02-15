CREATE DATABASE SiteVarejoFiap;

CREATE TABLE SiteVarejoFiap.dbo.Varejo(
	Id INT PRIMARY KEY IDENTITY,
	Email VARCHAR(500) NOT NULL,
	Nome VARCHAR(200) NOT NULL,
	Telefone VARCHAR(30),
	DataDeNascimento NVARCHAR(10), 
	Cpf VARCHAR(20),
) 

/*Emails �nicos*/
ALTER TABLE SiteVarejoFiap.dbo.Varejo ADD CONSTRAINT email_unico UNIQUE (Email);

/*Cpf �nico, mas podem ter m�ltiplos nulls*/
CREATE UNIQUE NONCLUSTERED INDEX UniqueCpf ON SiteVarejoFiap.dbo.Varejo (Cpf) WHERE Cpf IS NOT NULL;

SELECT * FROM SiteVarejoFiap.dbo.Varejo;