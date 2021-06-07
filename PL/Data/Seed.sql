use SecondHand
SET IDENTITY_INSERT [dbo].[Categorias] ON
INSERT INTO [dbo].[Categorias] ([CategoriaId], [Name]) VALUES (1, N'Celular')
INSERT INTO [dbo].[Categorias] ([CategoriaId], [Name]) VALUES (2, N'Camera')
INSERT INTO [dbo].[Categorias] ([CategoriaId], [Name]) VALUES (3, N'Banheiro')
INSERT INTO [dbo].[Categorias] ([CategoriaId], [Name]) VALUES (4, N'Video game')
INSERT INTO [dbo].[Categorias] ([CategoriaId], [Name]) VALUES (5, N'Arte')
INSERT INTO [dbo].[Categorias] ([CategoriaId], [Name]) VALUES (6, N'Beleza e cuidado pessoal')
INSERT INTO [dbo].[Categorias] ([CategoriaId], [Name]) VALUES (7, N'Brinquedos')
INSERT INTO [dbo].[Categorias] ([CategoriaId], [Name]) VALUES (8, N'Acessorio para Veiculo')
INSERT INTO [dbo].[Categorias] ([CategoriaId], [Name]) VALUES (9, N'Instrumentos Musicais')
INSERT INTO [dbo].[Categorias] ([CategoriaId], [Name]) VALUES (10, N'TV')
SET IDENTITY_INSERT [dbo].[Categorias] OFF

SET IDENTITY_INSERT [dbo].[Produtos] ON                                                                                                           
INSERT INTO [dbo].[Produtos] ([ProdutoId], [Name], [Descricao], [Estado], [Valor], [DataEntrada], [DataVenda], [UsuarioIDVendedor], [NomeVendedor], [EnderecoRemetente], [UsuarioIDComprador], [NomeComprador], [EnderecoComprador], [UsuarioIDEntregador], [NomeEntregador], [CategoriaID]) VALUES (1, N'Samsung s10 Plus', N'celular com 1 ano de uso',0 ,499.0, N'2020-04-15 00:00:00', null, N'1f153105-b615-4d97-83d6-0f1290a1329a', N'1nomw@nome.com.br', null, null , null , null ,  null , null , 1)
INSERT INTO [dbo].[Produtos] ([ProdutoId], [Name], [Descricao], [Estado], [Valor], [DataEntrada], [DataVenda], [UsuarioIDVendedor], [NomeVendedor], [EnderecoRemetente], [UsuarioIDComprador], [NomeComprador], [EnderecoComprador], [UsuarioIDEntregador], [NomeEntregador], [CategoriaID]) VALUES (2, N'TV lg 50 polegadas', N'tv plasma em bom estado',0 ,499.0, N'2020-04-12 00:00:00' , null, N'b052bce1-4e72-4832-a8f1-0ed0bfc69ea8', N'2nomw@nome.com.br', null, null , null , null , null , null ,10)
SET IDENTITY_INSERT [dbo].[Produtos] OFF