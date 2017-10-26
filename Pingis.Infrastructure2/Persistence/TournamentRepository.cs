using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pingis.Core.Models;
using Pingis.DataModel.Core.Repository;
using Pingis.DataModel.Database;

namespace Pingis.DataModel.Persistence
{
    public class TournamentRepository : Repository<Tournament>, ITournamentRepository
    {

        public PingisContext DbContext => Context as PingisContext;

        public TournamentRepository(PingisContext context) : base(context)
        {
        }
    }
}
