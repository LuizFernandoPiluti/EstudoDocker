

using EstudoDocker.Application.Request;
using EstudoDocker.Application.Response;

namespace EstudoDocker.Application.Interfaces
{
    public interface IPessoaService
    {
        Task<IEnumerable<PessoaResponse>> GetAllAsync();
        Task<PessoaResponse> GetByIdAsync(Guid id);
        Task AddAsync(PessoaRequest pesssoa);
        Task UpdateAsync(PessoaUpdateRequest pesssoa);
        Task DeleteAsync(Guid id);
    }
}
