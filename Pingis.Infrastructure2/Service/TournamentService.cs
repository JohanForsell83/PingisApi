using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pingis.Core.Models;
using Pingis.DataModel.Core.Repository;
using Pingis.DataModel.Core.Service;

namespace Pingis.DataModel.Service
{
    public class TournamentService : Service<Tournament>, ITournamentService
    {
        private readonly ITournamentRepository _tournamentRepository;

        public TournamentService(ITournamentRepository repository) : base(repository)
        {
            _tournamentRepository = repository;
        }
    }
}
