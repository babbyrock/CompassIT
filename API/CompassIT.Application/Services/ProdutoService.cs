using AutoMapper;
using CompassIT.Application.DTOs;
using CompassIT.Application.Interfaces;
using CompassIT.Domain.Entities;
using CompassIT.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CompassIT.Application.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public ProdutoService(IProdutoRepository produtoRepository, IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProdutoDTO>> GetAllProdutosAsync(CancellationToken cancellationToken)
        {
            var produtos = await _produtoRepository.GetAllAsync(cancellationToken);
            return _mapper.Map<IEnumerable<ProdutoDTO>>(produtos);
        }

        public async Task<ProdutoDTO> GetProdutoByIdAsync(int id, CancellationToken cancellationToken)
        {
            var produto = await _produtoRepository.GetbyIdAsync(id, cancellationToken);
            return _mapper.Map<ProdutoDTO>(produto);
        }

        public ProdutoDTO AddProduto(ProdutoDTO produtoDto)
        {
            var produto = _mapper.Map<Produto>(produtoDto);
            _produtoRepository.Create(produto);
            return _mapper.Map<ProdutoDTO>(produto);
        }

        public bool UpdateProduto(int id, ProdutoDTO produtoDto)
        {
            var produtoExistente = _produtoRepository.GetbyIdAsync(id, CancellationToken.None).Result;
            if (produtoExistente == null)
                return false;

            _mapper.Map(produtoDto, produtoExistente);
            _produtoRepository.Update(produtoExistente);
            return true;
        }

        public bool DeleteProduto(int id)
        {
            var produtoExistente = _produtoRepository.GetbyIdAsync(id, CancellationToken.None).Result;
            if (produtoExistente == null)
                return false;

            _produtoRepository.Delete(produtoExistente);
            return true;
        }
    }
}
