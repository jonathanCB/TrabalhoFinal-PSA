using Entities.Models;
using Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Interfaces
{

    public interface IProdutoDAO
    {
        //Todos os produtos do banco:
        public List<Produto> ListaDeProdutos();

        //retorna uma lista IQuerable com todos os produtos disponiveis para venda no banco de dados
        public IQueryable<Produto> IQuerDeProdutosDisponiveis();

        //Salva um produto novo no banco
        public void CadastroNovoProduto(Produto prod);

        //realiza a venda de um produto
        public Boolean VendaProduto(long id, String userName);

        //realiza o cancelamento da venda de um produto
        public Boolean CancelarVendaProduto(long id);

        //Recebe um ID de produto e retorna o mesmo
        public Produto ItemPorId(long ProdutoID);

        //Recebe um id e deleta o produto
        public void deletaProduto(long ProdutoID);

        //Recebe um id e informa se o produto existe ou nao
        public Boolean existe(long ProdutoID);

        //relatorio de itens disponiveis para venda
        public List<Produto> ItensDisponiveis();

        //relatorio de itens por uma determinada categoria
        public List<Produto> ItensPorCategoria(String cat);

        //relatorio de itens disponiveis por uma determinada categoria
        public IQueryable<Produto> ItensPorCategoriaDisponiveis(String cat);

        //recebe uma palavra chave e retorna um produto
        public List<Produto> ItensPalChav(string palChave);

        //recebe uma palavra chave e retorna produtos disponiveis
        public IQueryable<Produto> ItensPalChavDisponiveis(string palChave);

        //relatorio de itens por uma determinada categoria e palavra
        public List<Produto> ItensPalChavCat(String palChave, String cat);

        //relatorio de itens por uma determinada faixa de valores
        public List<Produto> ItensFaixaDeValores(decimal valIni, decimal valFin);

        //relatorio de itens por Status do produto de um determinado usuario
        public List<Produto> ItensPorStatusUsu(String usu);

        ////relatorio do total de vendas em um determinado periodo de tempo
        public IQueryable<TotalVendaPorPeriodo> NroTotalVendaPeriodo(DateTime dtIni, DateTime dtFin);

        //recebe um produto e salva as modificacoes
        public void editProduto(Produto prod);

        //recebe um id do comprador e retorna uma lista de todos os produtos
        //comprados por ele ordenados pelo status
        public List<Produto> ItensDoComprador(String usu);

        //retorna uma lista de produtos prontos para serem entregados
        public List<Produto> ItensParaEntrega();

        //retorna uma lista de produtos em rota de entrega
        public List<Produto> ItensEmRotaDeEntrega();

        //recebe o id de um produto e o email de um entregador e coloca o produto
        //para rota de entregada
        public Boolean EntregaProduto(long id, String entregador);

        //recebe o id de um produto e confirma sua entrega
        public Boolean ProdutoEntregue(long id);
    }
}
