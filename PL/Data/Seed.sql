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
INSERT INTO [dbo].[Produtos] ([ProdutoId], [Name], [Descricao], [Estado], [Valor], [Vendedor], [CategoriaID]) VALUES (1, N'samsung s10 plus', N'celular com 1 ano de uso',0 ,499.0 ,1 ,1)
INSERT INTO [dbo].[Produtos] ([ProdutoId], [Name], [Descricao], [Estado], [Valor], [Vendedor], [CategoriaID]) VALUES (2, N'TV lg 50 polegadas', N'tv plasma em bom estado',0 ,499.0 ,2 ,10)
INSERT INTO [dbo].[Produtos] ([ProdutoId], [Name], [Descricao], [Estado], [Valor], [Vendedor], [CategoriaID]) VALUES (3, N'sony cyber shot', N'camera para video e fotos digital',1 ,199.99 ,1 ,2)
INSERT INTO [dbo].[Produtos] ([ProdutoId], [Name], [Descricao], [Estado], [Valor], [Vendedor], [CategoriaID]) VALUES (4, N'Kit Acessórios P/ Banheiro Aco Inox 5 Pecas', N'O Kit e composto pelos seguintes materiais: 01 Porta Toalha de banho (47 cm), 01 Porta Toalha de Rosto, 01 Saboneteira, 01 Papeleira, 01 Cabide duplo, Fixacao dupla: Acompanha parafusos e buchas',0 ,39.90 ,2 ,3)
INSERT INTO [dbo].[Produtos] ([ProdutoId], [Name], [Descricao], [Estado], [Valor], [Vendedor], [CategoriaID]) VALUES (5, N'quadro floresta', N'pintado a mao con tinta invisivel',1 ,10.0 ,3 ,5)
INSERT INTO [dbo].[Produtos] ([ProdutoId], [Name], [Descricao], [Estado], [Valor], [Vendedor], [CategoriaID]) VALUES (6, N'console xbox one', N'1tb de armazenamento 2 anos de uso',0 ,499.99 ,1 ,4)
INSERT INTO [dbo].[Produtos] ([ProdutoId], [Name], [Descricao], [Estado], [Valor], [Vendedor], [CategoriaID]) VALUES (7, N'secador de cabelo taiff', N'1500w de potencia 220v',1 ,299.0 ,2 ,6)
INSERT INTO [dbo].[Produtos] ([ProdutoId], [Name], [Descricao], [Estado], [Valor], [Vendedor], [CategoriaID]) VALUES (8, N'robo transformes', N'robo Optimus Prime vira e desvira caminhao',0 ,358.0 ,3 ,7)
INSERT INTO [dbo].[Produtos] ([ProdutoId], [Name], [Descricao], [Estado], [Valor], [Vendedor], [CategoriaID]) VALUES (9, N'Suporte para celular', N'suporte com ventosa para, grupo em qualquer vidro',1 ,99.99 ,1 ,8)
INSERT INTO [dbo].[Produtos] ([ProdutoId], [Name], [Descricao], [Estado], [Valor], [Vendedor], [CategoriaID]) VALUES (10, N'violao', N'sem cordas marca yamaha',0 ,150.0 ,2 ,9)
INSERT INTO [dbo].[Produtos] ([ProdutoId], [Name], [Descricao], [Estado], [Valor], [Vendedor], [CategoriaID]) VALUES (11, N'TV Samsung 23 polegadas', N'TV lcd com pouco uso',1 ,299.0 ,3 ,10)
INSERT INTO [dbo].[Produtos] ([ProdutoId], [Name], [Descricao], [Estado], [Valor], [Vendedor], [CategoriaID]) VALUES (12, N'lg k10', N'32gb de armazenamento 512mb de memoria',0 ,225.50 ,1 ,1)
INSERT INTO [dbo].[Produtos] ([ProdutoId], [Name], [Descricao], [Estado], [Valor], [Vendedor], [CategoriaID]) VALUES (13, N'flauta', N'flauta de plastico em bom estado',1 ,26.91 ,2 ,9)
INSERT INTO [dbo].[Produtos] ([ProdutoId], [Name], [Descricao], [Estado], [Valor], [Vendedor], [CategoriaID]) VALUES (14, N'parachoque de desmanche', N'novinho, recem cortado',0 ,169.20 ,2 ,8)
INSERT INTO [dbo].[Produtos] ([ProdutoId], [Name], [Descricao], [Estado], [Valor], [Vendedor], [CategoriaID]) VALUES (15, N'Boneco Chucky', N'amigavel e amavel',1 ,9.90 ,3 ,7)
INSERT INTO [dbo].[Produtos] ([ProdutoId], [Name], [Descricao], [Estado], [Valor], [Vendedor], [CategoriaID]) VALUES (16, N'pente', N'pente de madeira',0 ,48.90 ,1 ,6)
INSERT INTO [dbo].[Produtos] ([ProdutoId], [Name], [Descricao], [Estado], [Valor], [Vendedor], [CategoriaID]) VALUES (17, N'quadro romero brito', N'um horro nao aguento mais olhar pra isso',1 ,0.99 ,4 ,5)
INSERT INTO [dbo].[Produtos] ([ProdutoId], [Name], [Descricao], [Estado], [Valor], [Vendedor], [CategoriaID]) VALUES (18, N'console play 2', N'novinho 15 anos de uso',0 ,156.30 ,1 ,4)
SET IDENTITY_INSERT [dbo].[Produtos] OFF