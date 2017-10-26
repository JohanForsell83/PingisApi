using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pingis.Core.Models;

namespace Pingis.DataModel.Core.DbContext
{
    public interface IPingisContext : IDisposable
    {
        DbSet<Player> Players { get; set; }
        DbSet<Game> Games { get; set; }
        int SaveChanges();

    }
}
