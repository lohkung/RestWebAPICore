using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RestWebAPICore.Models
{
    public class CreditCardContext : DbContext 
    {
        public CreditCardContext(DbContextOptions<CreditCardContext> options) : base (options)
        {

        }
        public DbSet<CreditCardItem> creditCardItems { get; set; }

    }
}
