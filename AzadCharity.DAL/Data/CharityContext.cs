using AzadCharity.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzadCharity.DAL.Data
{
    public class CharityContext : DbContext
    {
        public CharityContext(DbContextOptions<CharityContext> options) : base(options)
        {
            
        }

        public DbSet<CharityCase> CharityCases { get; set; }
    }
}
