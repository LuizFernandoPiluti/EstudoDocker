
using AutoMapper;
using EstudoDocker.DataBase.Context;
using EstudoDocker.Domain.Dto;
using EstudoDocker.Domain.Interfaces.Repository;
using EstudoDocker.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace EstudoDocker.DataBase.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly EstudoDockerDbContext _context;
        private readonly IMapper _mapper;   
        public PessoaRepository(EstudoDockerDbContext estudoDockerDbContext, IMapper mapper)
        {
            _context = estudoDockerDbContext;
            _mapper = mapper;
        }

        public async Task AddAsync(PesssoaDto pesssoaDto)
        {
           var pessoa =  _mapper.Map<Pesssoa>(pesssoaDto);
            _context.Pessoa.Add(pessoa);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task DeleteAsync(PesssoaDto pesssoaDto)
        {
            try
            {
                var pessoa = _mapper.Map<Pesssoa>(pesssoaDto);
                _context.Pessoa.Remove(pessoa);
                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (Exception e)
            {

                throw ;
            }
        
        }

        public async Task DeleteAsync(Guid id)
        {
            var obj = await GetByIdAsync(id).ConfigureAwait(false);
            await DeleteAsync(obj);
        }

        public async Task<IEnumerable<PesssoaDto>> GetAllAsync()
        {
            var pessoa = await _context.Pessoa.AsNoTracking().ToListAsync().ConfigureAwait(false);
            return _mapper.Map<List<PesssoaDto>>(pessoa);    
        }

        public async Task<PesssoaDto> GetByIdAsync(Guid id)
        {
            var pessoa = await _context.Pessoa.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);
            if (pessoa == null)
            {
                return null;
            }
            else
            {
                return _mapper.Map<PesssoaDto>(pessoa);
            }
        }

        public async Task UpdateAsync(PesssoaDto pesssoaDto)
        {
            var pessoa = _mapper.Map<Pesssoa>(pesssoaDto);
            _context.Pessoa.Update(pessoa);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
