using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;
using NSE.Catalogo.API.Data;
using NSE.Core.Data;

namespace NSE.Catalogo.API.Models
{
    public class ProdutoRepository : IProdutoRepository
    {
        public IUnitOfWork UnitOfWork => _context;

        private readonly CatalogoContext _context;

        public ProdutoRepository(CatalogoContext context)
        {
            _context = context;
        }

        public void Adicionar(Produto produto)
        {
            _context.Produtos.Add(produto);
        }

        public void Atualizar(Produto produto)
        {
            _context.Produtos.Update(produto);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

        public async Task<Produto> ObterPorId(Guid id)
        {
            return await _context.Produtos.FindAsync(id);
        }

        public Task<List<Produto>> ObterProdutosPorId(string ids)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Produto>> ObterTodos(int pageSize, int pageIndex, string query = null)
        {
            return await _context.Produtos.AsNoTracking().ToListAsync();
        }
    }
}