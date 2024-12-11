using AzadCharity.DAL.Data;
using AzadCharity.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzadCharity.DAL.Repositories
{
    public class CharityCaseRepository : Repository<CharityCase>, ICharityCaseRepository
    {
        private readonly CharityContext _context;

        public CharityCaseRepository(CharityContext context) : base(context)
        {
            _context = context;
        }
    }
}
