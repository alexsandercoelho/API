using Domain.Interfaces.Generics;
using Infra.Configuracao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ContextBase _context;

        public UnitOfWork(ContextBase context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
