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
INSERT INTO [dbo].[Categorias] ([CategoriaId], [Name]) VALUES (11, N'Informatica')
SET IDENTITY_INSERT [dbo].[Categorias] OFF

SET IDENTITY_INSERT [dbo].[Usuarios] ON
INSERT INTO [dbo].[Usuarios] ([UsuarioId], [Name]) VALUES (1, N'Renata Alcantara Carvalheira')
INSERT INTO [dbo].[Usuarios] ([UsuarioId], [Name]) VALUES (2, N'Nataniel Martinho Soveral')
INSERT INTO [dbo].[Usuarios] ([UsuarioId], [Name]) VALUES (3, N'Alisha Albertini Mieiro')
SET IDENTITY_INSERT [dbo].[Usuarios] OFF

SET IDENTITY_INSERT [dbo].[Produtos] ON
INSERT INTO [dbo].[Produtos] ([ProdutoId], [Name], [Descricao], [Estado], [Valor], [DataEntrada], [DataVenda], [UsuarioId], [Categoria]) VALUES (1, N'Samsung S10 Plus', N'Celular com 1 ano de uso',0 ,499.0, N'2020-04-15 00:00:00', null, 1 ,N'Celular')
INSERT INTO [dbo].[Produtos] ([ProdutoId], [Name], [Descricao], [Estado], [Valor], [DataEntrada], [DataVenda], [UsuarioId], [Categoria]) VALUES (2, N'TV lg 50 polegadas', N'TV plasma em bom estado',0 ,499.0, N'2020-04-12 00:00:00' , null, 2 ,N'TV')
INSERT INTO [dbo].[Produtos] ([ProdutoId], [Name], [Descricao], [Estado], [Valor], [DataEntrada], [DataVenda], [UsuarioId], [Categoria]) VALUES (3, N'Sony Cyber Shot', N'Camera para video e fotos digital',1 ,199.99, N'2020-03-15 00:00:00' ,N'2020-04-15 00:00:00',1 ,N'Camera')
INSERT INTO [dbo].[Produtos] ([ProdutoId], [Name], [Descricao], [Estado], [Valor], [DataEntrada], [DataVenda], [UsuarioId], [Categoria]) VALUES (4, N'Kit Acessórios P/ Banheiro Aco Inox 5 Pecas', N'O Kit e composto pelos seguintes materiais: 01 Porta Toalha de banho (47 cm), 01 Porta Toalha de Rosto, 01 Saboneteira, 01 Papeleira, 01 Cabide duplo, Fixacao dupla: Acompanha parafusos e buchas',0 ,39.90, N'2020-04-01 00:00:00' , null,2 ,N'Banheiro')
INSERT INTO [dbo].[Produtos] ([ProdutoId], [Name], [Descricao], [Estado], [Valor], [DataEntrada], [DataVenda], [UsuarioId], [Categoria]) VALUES (5, N'Quadro Floresta', N'Pintado a mao con tinta invisivel',1 ,10.0, N'2020-04-15 00:00:00' ,N'2020-05-15 00:00:00',3 ,N'Arte')
INSERT INTO [dbo].[Produtos] ([ProdutoId], [Name], [Descricao], [Estado], [Valor], [DataEntrada], [DataVenda], [UsuarioId], [Categoria]) VALUES (6, N'Console Xbox One', N'1TB de armazenamento 2 anos de uso',0 ,499.99, N'2019-04-15 00:00:00' , null, 1 ,N'Video game')
INSERT INTO [dbo].[Produtos] ([ProdutoId], [Name], [Descricao], [Estado], [Valor], [DataEntrada], [DataVenda], [UsuarioId], [Categoria]) VALUES (7, N'Secador de Cabelo Taiff', N'1500w de potencia 220v',1 ,299.0, N'2020-02-15 00:00:00' ,N'2020-03-15 00:00:00',2 ,N'Beleza e cuidado pessoal')
INSERT INTO [dbo].[Produtos] ([ProdutoId], [Name], [Descricao], [Estado], [Valor], [DataEntrada], [DataVenda], [UsuarioId], [Categoria]) VALUES (8, N'Robo Transformers', N'Robo Optimus Prime vira e desvira caminhao',0 ,358.0, N'2020-12-15 00:00:00' , null, 3 ,N'Brinquedos')
INSERT INTO [dbo].[Produtos] ([ProdutoId], [Name], [Descricao], [Estado], [Valor], [DataEntrada], [DataVenda], [UsuarioId], [Categoria]) VALUES (9, N'Suporte para celular', N'suporte com ventosa para, grupo em qualquer vidro',1 ,99.99, N'2020-05-15 00:00:00' ,N'2020-06-15 00:00:00',1 ,N'Acessorio para Veiculo')
INSERT INTO [dbo].[Produtos] ([ProdutoId], [Name], [Descricao], [Estado], [Valor], [DataEntrada], [DataVenda], [UsuarioId], [Categoria]) VALUES (10, N'Violao', N'Sem cordas marca yamaha',0 ,150.0, N'2020-04-19 00:00:00' , null, 2 ,N'Instrumentos Musicais')
INSERT INTO [dbo].[Produtos] ([ProdutoId], [Name], [Descricao], [Estado], [Valor], [DataEntrada], [DataVenda], [UsuarioId], [Categoria]) VALUES (11, N'TV Samsung 23 polegadas', N'TV lcd com pouco uso',1 ,299.0, N'2020-04-22 00:00:00' ,N'2020-05-15 00:00:00',3 ,N'TV')
INSERT INTO [dbo].[Produtos] ([ProdutoId], [Name], [Descricao], [Estado], [Valor], [DataEntrada], [DataVenda], [UsuarioId], [Categoria]) VALUES (12, N'LG K10', N'32gb de armazenamento 512mb de memoria',0 ,225.50, N'2020-08-15 00:00:00' , null, 1 ,N'Celular')
INSERT INTO [dbo].[Produtos] ([ProdutoId], [Name], [Descricao], [Estado], [Valor], [DataEntrada], [DataVenda], [UsuarioId], [Categoria]) VALUES (13, N'Flauta', N'Flauta de plastico em bom estado yamaha',1 ,26.91, N'2020-04-11 00:00:00' ,N'2020-04-15 00:00:00',2 ,N'Instrumentos Musicais')
INSERT INTO [dbo].[Produtos] ([ProdutoId], [Name], [Descricao], [Estado], [Valor], [DataEntrada], [DataVenda], [UsuarioId], [Categoria]) VALUES (14, N'Parachoque de Desmanche', N'Novinho, recem cortado',0 ,169.20, N'2020-09-15 00:00:00' , null, 2 ,N'Acessorio para Veiculo')
INSERT INTO [dbo].[Produtos] ([ProdutoId], [Name], [Descricao], [Estado], [Valor], [DataEntrada], [DataVenda], [UsuarioId], [Categoria]) VALUES (15, N'Boneco Chucky', N'Amigavel e amavel',1 ,9.90, N'2020-04-26 00:00:00' ,N'2020-05-15 00:00:00',3 ,N'Brinquedos')
INSERT INTO [dbo].[Produtos] ([ProdutoId], [Name], [Descricao], [Estado], [Valor], [DataEntrada], [DataVenda], [UsuarioId], [Categoria]) VALUES (16, N'Pente', N'Pente de madeira',0 ,48.90, N'2020-04-15 00:00:00' , null, 1 ,N'Beleza e cuidado pessoal')
INSERT INTO [dbo].[Produtos] ([ProdutoId], [Name], [Descricao], [Estado], [Valor], [DataEntrada], [DataVenda], [UsuarioId], [Categoria]) VALUES (17, N'Quadro Romero Brito', N'Um horror nao aguento mais olhar pra isso',1 ,0.99, N'2020-02-05 00:00:00' ,N'2020-03-15 00:00:00',2 ,N'Arte')
INSERT INTO [dbo].[Produtos] ([ProdutoId], [Name], [Descricao], [Estado], [Valor], [DataEntrada], [DataVenda], [UsuarioId], [Categoria]) VALUES (18, N'Console Playstation 2', N'Novinho 15 anos de uso',0 ,156.30, N'2020-04-05 00:00:00' , null, 1 ,N'Video game')
SET IDENTITY_INSERT [dbo].[Produtos] OFF