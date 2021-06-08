using Entities.Interfaces;
using Entities.Models;
using Entities.ViewModels;
using Microsoft.AspNetCore.Http;
using PL.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class BusinesFacade
    {
        private readonly IProdutoDAO _ProdutoDAO;
        private readonly IImagemDAO _ImagemDAO;
        private readonly IApplicationUserDAO _ApplicationUserDAO;
        private readonly ICategoriaDAO _CategoriaDAO;
        private readonly IPerguntaDAO _PerguntaDAO;

        //construtor busines facade

        public BusinesFacade(IProdutoDAO Pdao, IImagemDAO Idao, 
                             IApplicationUserDAO Adao, ICategoriaDAO Cdao,
                             IPerguntaDAO Perdao)
        {
            _ProdutoDAO = Pdao;
            _ImagemDAO = Idao;
            _ApplicationUserDAO = Adao;
            _CategoriaDAO = Cdao;
            _PerguntaDAO = Perdao;
        }        

        #region consultas em produtos

        //Todos os produtos do banco:
        public List<Produto> ListaDeProdutos()
        {
            return _ProdutoDAO.ListaDeProdutos();
        }

        //retorna uma lista IQuerable com todos os produtos disponiveis para venda no banco de dados
        public IQueryable<Produto> IQuerDeProdutosDisponiveis()
        {
            return _ProdutoDAO.IQuerDeProdutosDisponiveis();
        }

        //Salva um produto novo no banco
        public void CadNovoProduto(Produto prod)
        {
            _ProdutoDAO.CadastroNovoProduto(prod);
        }

        //Recebe um id e deleta o produto
        public void deletaProduto(long ProdutoID)
        {
            _ProdutoDAO.deletaProduto(ProdutoID);
        }

        //Recebe um id e informa se o produto existe ou nao
        public Boolean existe(long ProdutoID)
        {
            return _ProdutoDAO.existe(ProdutoID);
        }

        //Recebe um ID de produto e retorna o mesmo
        public Produto ItemPorId(long ProdutoID)
        {
            return _ProdutoDAO.ItemPorId(ProdutoID);
        }

        //relatorio de itens disponiveis para venda
        public List<Produto> ItensDisponiveis()
        {
            return _ProdutoDAO.ItensDisponiveis();
        }

        //relatorio de itens por uma determinada categoria
        public List<Produto> ItensPorCategoria(String cat)
        {
            return _ProdutoDAO.ItensPorCategoria(cat);
        }

        //relatorio de itens disponiveis por uma determinada categoria
        public IQueryable<Produto> ItensPorCategoriaDisponiveis(String cat)
        {
            return _ProdutoDAO.ItensPorCategoriaDisponiveis(cat);
        }

        //relatorio de itens por uma determinada categoria e palavra
        public List<Produto> ItensPalChavCat(String palChave, String cat)
        {
            return _ProdutoDAO.ItensPalChavCat(palChave, cat);
        }

        //recebe uma palavra chave e retorna um produto
        public List<Produto> ItensPalChav(string palChave)
        {
            return _ProdutoDAO.ItensPalChav(palChave);
        }

        //recebe uma palavra chave e retorna produtos disponiveis
        public IQueryable<Produto> ItensPalChavDisponiveis(string palChave)
        {
            return _ProdutoDAO.ItensPalChavDisponiveis(palChave);
        }

        //relatorio de itens por uma determinada faixa de valores
        public List<Produto> ItensFaixaDeValores(decimal valIni, decimal valFin)
        {
            return _ProdutoDAO.ItensFaixaDeValores(valIni, valFin);
        }

        //relatorio de itens por um determinado usuario
        public List<Produto> ItensPorStatusUsu(String usu)
        {
            return _ProdutoDAO.ItensPorStatusUsu(usu);
        }

        //relatorio do total de vendas em um determinado periodo de tempo
        public IQueryable<TotalVendaPorPeriodo> TotalVendaPeriodo(DateTime dtIni, DateTime dtFin)
        {
            return _ProdutoDAO.NroTotalVendaPeriodo(dtIni, dtFin);
        }

        //recebe um produto e salva as modificacoes
        public void editProduto(Produto prod)
        {
            _ProdutoDAO.editProduto(prod);
        }

        //realiza a venda de um produto
        public Boolean VendaProduto(long id, String userName)
        {
            return _ProdutoDAO.VendaProduto(id, userName);
        }

        //realiza o cancelamento da venda de um produto
        public Boolean CompradorCancelarVendaProduto(long id)
        {
            return _ProdutoDAO.CompradorCancelarVendaProduto(id);
        }

        //Comprador aceitou realizar a venda do produto, recebe um id e muda o status do produto
        public Boolean CompradoAceitouVendaProduto(long id)
        {
            return _ProdutoDAO.CompradoAceitouVendaProduto(id);
        }

        //Comprador negou realizar a venda do produto, recebe um id e muda o status do produto
        public Boolean CompradoNegouVendaProduto(long id)
        {
            return _ProdutoDAO.CompradoNegouVendaProduto(id);
        }

        //recebe um id do comprador e retorna uma lista de todos os produtos
        //comprados por ele ordenados pelo status
        public List<Produto> ItensDoComprador(String usu)
        {
            return _ProdutoDAO.ItensDoComprador(usu);
        }        

        //retorna uma lista de produtos prontos para serem entregados
        public List<Produto> ItensParaEntrega()
        {
            return _ProdutoDAO.ItensParaEntrega();
        }

        //retorna uma lista de produtos em rota de entrega
        public List<Produto> ItensEmRotaDeEntrega()
        {
            return _ProdutoDAO.ItensEmRotaDeEntrega();
        }

        //recebe o id de um produto e o email de um entregador e coloca o produto
        //para rota de entregada
        public Boolean EntregaProduto(long id, String entregador)
        {
            return _ProdutoDAO.EntregaProduto(id, entregador);
        }

        //recebe o id de um produto e confirma sua entrega
        public Boolean ProdutoEntregue(long id)
        {
            return _ProdutoDAO.ProdutoEntregue(id);
        }


        #endregion

        #region consultas em imagem

        //Salva uma imagens novo no banco
        public void CadImagem(long ProdutoId, List<IFormFile> files)
        {
            _ImagemDAO.LoadFiles(ProdutoId,files);
        }

        //recebe um id de imagem e retorna o resultado
        public Imagem GetImagem(int ImagemId)
        {
            return _ImagemDAO.GetImagem(ImagemId);
        }              
        

            #endregion

        #region consultas em application user

        //retorna o id de um usuario
        public String getUserID(String userName)
        {
            return _ApplicationUserDAO.getUserID(userName);
        }
        public ApplicationUser PerfilVendedor(long id)
        {
            return _ApplicationUserDAO.PerfilVendedor(id);
        }
        

        #endregion

        #region consultas em categorias

        //retorna o nome de todas as categorias de produtos cadastrados
        public IQueryable<String> categoriasNomes()
        {
            return _CategoriaDAO.categoriasNomes();
        }

        //retorna um IEnumerable de categorias
        public IEnumerable<Categoria> categoriasIEnumerable()
        {
            return _CategoriaDAO.categoriasIEnumerable();
        }

        #endregion

        #region

        //recebe uma pergunta e salva
        public void SalvaPergunta(long ProdId, String Per)
        {
            _PerguntaDAO.SalvaPergunta(ProdId, Per);
        }

        //recebe uma resposta para uma pergunta e salva
        public void SalvaResposta(long PerId, String Resp)
        {
            _PerguntaDAO.SalvaResposta(PerId, Resp);
        }

        //recebe um id de uma pergunta e retorna o resultado
        public Pergunta GetPergunta(long PerId)
        {
            return _PerguntaDAO.GetPergunta(PerId);
        }

        #endregion

    }
}
