using CompassIT.Application.DTOs;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CompassIT.Application.Interfaces
{
    public interface IProdutoService
    {
        Task<IEnumerable<ProdutoDTO>> GetAllProdutosAsync(CancellationToken cancellationToken);
        Task<ProdutoDTO> GetProdutoByIdAsync(int id, CancellationToken cancellationToken);
        ProdutoDTO AddProduto(ProdutoDTO produtoDto);
        bool UpdateProduto(int id, ProdutoDTO produtoDto);
        bool DeleteProduto(int id);
    }
}
