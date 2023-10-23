using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locadora.Domain.Entities;
using Locadora.Domain.Interfaces;
using Locadora.Domain.Validation;
using Locadora.Infra.Models;
using Microsoft.EntityFrameworkCore;

namespace Locadora.Infra.Repositories
{
    public class RegisterRepository : IRegisterRepository
    {
        public readonly AgenciaContext _context;
        
        public RegisterRepository(AgenciaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Register>> GetAllRegistersAsync()
            => await _context.Registers.Include(x => x.name).
                Include(x => x.email).AsNoTracking().ToListAsync();

        public async Task<Register> GetRegisterIdAsync(int id)
            => await _context.Registers.Include(x => x.name)
                   .Include(x => x.email)
                   .FirstOrDefaultAsync(x => x.Id == id) ??
               throw new DomainExceptionValidation($"Register cannot be found by id - {id}");

        public async Task<IEnumerable<Register>> GetRegistersNameAsync(string registersName)
        {
            var names = registersName.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var query = _context.Registers.Include(x => x.name)
                .Include(x => x.email);

            foreach (var name in names)
            {
                query.Where(x => x.name.FirstName.Contains(name) || x.name.LastName.Contains(name));
            }

            var registers = await query.ToListAsync();

            if (registers.Count == 0)
                throw new DomainExceptionValidation($" Register cannot be found by name - {registersName}");
            return registers;
        }

        public async Task<Register> CreateRegisterAsync(Register register)
        {
            await _context.Registers.AddAsync(register);
            await _context.SaveChangesAsync();

            return register;
        }

        public async Task<Register> UpdateRegisterAsync(Register register)
        {
            _context.Registers.Update(register);
            await _context.SaveChangesAsync();

            return register;
        }

        public async Task<Register> DeleteRegisterAsync(Register register)
        {
            _context.Remove(register);
            await _context.SaveChangesAsync();

            return register;
        }
    }
}
