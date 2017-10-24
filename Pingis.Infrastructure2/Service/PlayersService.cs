using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pingis.Core.Models;
using Pingis.DataModel.Core.Repository;
using Pingis.DataModel.Core.Service;
using Pingis.DataModel.Service;
using Pingis.DataModel.Persistence;

namespace Pingis.DataModel.Service
{
    public class PlayersService : Service<Player>, IPlayerService
    {
        private readonly IPlayerRepository _repository;
        public PlayersService(IPlayerRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public IEnumerable<GameDTO> GetGamesByPlayerId(int id)
        {
            return _repository.GetGamesByPlayerId(id);
        }

        public PlayerDTO GetPlayerAndGamesByPlayerId(int id)
        {
           return _repository.GetPlayerAndGamesByPlayerId(id);
        }

        public PlayerDTO GetPlayerWithMostDouchePoints()
        {
            return GetPlayerWithMostDouchePoints();
        }

        public IEnumerable<PlayerDTO> GetPlayerWithMostPoints()
        {
            return GetPlayerWithMostPoints();
        }

        public void UpdatePlayer(Player player)
        {
            throw new NotImplementedException();
        }
    }
}
