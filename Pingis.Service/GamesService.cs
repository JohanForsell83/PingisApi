using System.Data.Entity;
using Pingis.Core.Models;
using Pingis.DataModel.Core.Service;
using Pingis.DataModel.Database;
using System.Linq;
using System;
using System.Collections.Generic;
using Pingis.DataModel.Core.Repository;

namespace Pingis.Service
{
    public class GamesService : IGameService, IService<Game>
    {
        private readonly IGameRepository _gameRepository;

        public GamesService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public void AddGameWithPlayerIds(Game game)
        {
            throw new NotImplementedException();
        }
        
        public IEnumerable<GameDTO> GetAllGamesIncludingPlayer()
        {
            throw new NotImplementedException();
        }
        
        public GameDTO GetGamesIncludingPlayerByGameId(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Game entity)
        {
            throw new NotImplementedException();
        }
        public void Create(Game entity)
        {
            _gameRepository.Add(entity);
        }

        public void Delete(int id)
        {
            _gameRepository.RemoveById(id);
        }

        public IEnumerable<Game> GetAll()
        {
            return _gameRepository.GetAll();
        }

        public Game GetById(int id)
        {
            return _gameRepository.Get(id);
        }


    }
}
