using CompassIT.Domain.Entities;
using CompassIT.Domain.Interfaces;
using CompassIT.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompassIT.Persistence.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AppDbContext _context;

        public ProdutoRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Create(Produto entity)
        {
            _context.Produtos.Add(entity);
        }

        public void Update(Produto entity)
        {
            _context.Produtos.Update(entity);
        }

        public void Delete(Produto entity)
        {
            _context.Produtos.Remove(entity);
        }

        public async Task<Produto> GetbyIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Produtos.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
        }

        public async Task<List<Produto>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Produtos.ToListAsync(cancellationToken);
        }

        public async Task CommitAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
