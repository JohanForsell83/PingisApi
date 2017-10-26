using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pingis.DataModel.Core.Repository;
using Pingis.DataModel.Core.Service;
using Pingis.DataModel.Core.UnitOfWork;
using Pingis.DataModel.Database;
using Pingis.DataModel.Service;



namespace Pingis.DataModel.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PingisContext _context;
        
        public IPlayerRepository Players { get; private set; }
        public IGameRepository Games { get; private set; }
        public ITournamentRepository Tournament { get; private set; }
        public IGameService GamesService { get; private set; }
        public IPlayerService PlayerService { get; private set; }
        public ITournamentService TournamentService { get; private set; }


        public UnitOfWork(PingisContext context)
        {
            _context = context;
            Players = new PlayerRepository(_context);
            Games = new GameRepository(_context);
            Tournament = new TournamentRepository(_context);
            GamesService = new GamesService(Games);
            PlayerService = new PlayersService(Players);
            TournamentService = new TournamentService(Tournament);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
