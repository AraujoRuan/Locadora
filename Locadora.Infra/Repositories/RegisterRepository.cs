using Locadora.Infra.Interfaces;
using Locadora.Infra.Models;
using Microsoft.EntityFrameworkCore;

namespace Locadora.Infra.Repositories
{
    public class RegisterRepository : IRegisterRepository
    {
        private readonly AgenciaContext _context;


        public RegisterRepository(AgenciaContext context)
        {
            _context = context;
        }

        public void Create(Register register)
        {
            _context.Registers.Add(register);
            _context.SaveChanges();
        }

        public void DeleteById(Register register)
        {
            _context.Registers.Remove(register);
            _context.SaveChanges();
        }

        public IEnumerable<Register> Get()
        {
            var registers = _context.Registers.ToList();
            return registers;
        }

        public Register GetById(Guid id)
        {
            return _context.Registers.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Register register)
        {
            _context.Entry(register).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
