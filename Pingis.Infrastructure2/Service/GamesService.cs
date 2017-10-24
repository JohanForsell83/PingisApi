using Pingis.Core.Models;
using System;
using System.Collections.Generic;
using Pingis.DataModel.Core.Repository;
using System.Runtime.Remoting.Contexts;
using Pingis.DataModel.Core.Service;

namespace Pingis.DataModel.Service
{
    public class GamesService : Service<Game>, IGameService
    {
        private readonly IGameRepository _repository;
        public GamesService(IGameRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public void AddGameIncludingPlayerId(Game game)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GameDTO> GetAllGamesIncludingPlayer()
        {
            return _repository.GetAllGamesIncludingPlayer();
        }

        public GameDTO GetGamesIncludingPlayerByGameId(int id)
        {
            return _repository.GetGamesIncludingPlayerByGameId(id);
        }
    }
}
