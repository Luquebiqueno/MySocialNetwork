Use MySocialNetwork


If Object_Id('SistemaMenu') Is Null 
Begin
	Create Table SistemaMenu 
	(
		 SistemaMenuId	Int Identity(1,1) Primary Key
		,ParentId		Int					Null
		,Descricao		Varchar(256)	Not Null
		,Icone			Varchar(256)		Null
		,RouterLink		Varchar(512)		Null
		,Ordem			Int				Not Null
		,Ativo			Bit				Not Null Default(1)
	)
End
Go

If Object_Id('Usuario') Is Null 
Begin
	Create Table Usuario 
	(
		 UsuarioId				Int Identity(1,1) Primary Key
		,Nome					Varchar(256)	Not Null
		,Email					Varchar(100)	Not Null Unique
		,Telefone				Varchar(20)			Null Unique
		,Senha					Varchar(400)	Not Null
		,DataCadastro			Datetime		Not	Null
		,DataAlteracao			DateTime			Null
		,RefreshToken			Varchar(500)		Null
		,RefreshTokenExpiryTime	DateTime			Null
		,Ativo					Bit				Not Null Default(1)
	)
End
Go
