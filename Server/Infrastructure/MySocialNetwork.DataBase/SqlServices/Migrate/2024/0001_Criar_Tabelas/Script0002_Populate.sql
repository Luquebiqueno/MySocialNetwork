Use MySocialNetwork
Go

If Not Exists (Select 1 From SistemaMenu (Nolock) Where Descricao = 'Home' And ParentId Is Null) 
Begin
	Insert Into SistemaMenu
	(
		 ParentId
		,Descricao
		,Icone
		,RouterLink
		,Ordem
		,Ativo
	)
	Select
		 ParentId	= Null
		,Descricao	= 'Home'
		,Icone		= 'home'
		,RouterLink	= 'home'
		,Ordem		= 1
		,Ativo		= 1
End
Go

If Not Exists (Select 1 From SistemaMenu (Nolock) Where Descricao = 'Dashboard' And ParentId Is Null) 
Begin
	Insert Into SistemaMenu
	(
		 ParentId
		,Descricao
		,Icone
		,RouterLink
		,Ordem
		,Ativo
	)
	Select
		 ParentId	= Null
		,Descricao	= 'Dashboard'
		,Icone		= 'dashboard'
		,RouterLink	= 'dashboard'
		,Ordem		= 2
		,Ativo		= 1
End
Go

If Not Exists (Select 1 From SistemaMenu (Nolock) Where Descricao = 'Perfil' And ParentId Is Null) 
Begin
	Insert Into SistemaMenu
	(
		 ParentId
		,Descricao
		,Icone
		,RouterLink
		,Ordem
		,Ativo
	)
	Select
		 ParentId	= Null
		,Descricao	= 'Perfil'
		,Icone		= 'person'
		,RouterLink	= 'perfil'
		,Ordem		= 3
		,Ativo		= 1
End
Go

