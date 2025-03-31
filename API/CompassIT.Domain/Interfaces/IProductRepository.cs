using CompassIT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompassIT.Domain.Interfaces
{
    public interface IProdutoRepository
    {
        void Create(Produto entity);
        void Update(Produto entity);
        void Delete(Produto entity);
        Task<Produto> GetbyIdAsync(int id, CancellationToken cancellationToken);
        Task<List<Produto>> GetAllAsync(CancellationToken cancellationToken);
        Task CommitAsync(CancellationToken cancellationToken);
    }
}
