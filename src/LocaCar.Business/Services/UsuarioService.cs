using System;
using System.Threading.Tasks;
using LocaCar.Business.Intefaces;
using LocaCar.Business.Models;

namespace LocaCar.Business.Services
{
    public class UsuarioService : BaseService, IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository,
                              INotificador notificador) : base(notificador)
        {
            _usuarioRepository = usuarioRepository;
        }

        public Task<bool> Adicionar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Atualizar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        /*
public async Task<bool> Adicionar(Fornecedor fornecedor)
{
   if (!ExecutarValidacao(new UsuarioValidation(), fornecedor) 
       || !ExecutarValidacao(new EnderecoValidation(), fornecedor.Endereco)) return false;

   if (_fornecedorRepository.Buscar(f => f.Documento == fornecedor.Documento).Result.Any())
   {
       Notificar("Já existe um fornecedor com este documento informado.");
       return false;
   }

   await _fornecedorRepository.Adicionar(fornecedor);
   return true;
}

public async Task<bool> Atualizar(Fornecedor fornecedor)
{
   if (!ExecutarValidacao(new UsuarioValidation(), fornecedor)) return false;

   if (_fornecedorRepository.Buscar(f => f.Documento == fornecedor.Documento && f.Id != fornecedor.Id).Result.Any())
   {
       Notificar("Já existe um fornecedor com este documento infomado.");
       return false;
   }

   await _fornecedorRepository.Atualizar(fornecedor);
   return true;
}

public async Task AtualizarEndereco(Endereco endereco)
{
   if (!ExecutarValidacao(new EnderecoValidation(), endereco)) return;

   await _enderecoRepository.Atualizar(endereco);
}

public async Task<bool> Remover(Guid id)
{
   if (_fornecedorRepository.ObterFornecedorProdutosEndereco(id).Result.Produtos.Any())
   {
       Notificar("O fornecedor possui produtos cadastrados!");
       return false;
   }

   var endereco = await _enderecoRepository.ObterEnderecoPorFornecedor(id);

   if (endereco != null)
   {
       await _enderecoRepository.Remover(endereco.Id);
   }

   await _fornecedorRepository.Remover(id);
   return true;
}
*/
        public void Dispose()
        {
            _usuarioRepository?.Dispose();
        }

        public Task<bool> Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}