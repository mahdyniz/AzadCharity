using AzadCharity.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzadCharity.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CharityContext _context;
        public ICharityCaseRepository CharityCase { get; set; }
        public UnitOfWork(CharityContext context)
        {
            _context = context;
            CharityCase = new CharityCaseRepository(_context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
