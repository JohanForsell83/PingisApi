using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pingis.Core.Models;

namespace Pingis.DataModel.Core.Repository
{
    public interface IGameRepository : IRepository<Game>
    {
        void UpdateGame(Game game);
        void AddGameIncludingPlayerId(Game game);
        GameDTO GetGamesIncludingPlayerByGameId(int id);
        IEnumerable<GameDTO> GetAllGamesIncludingPlayer();
    }
}
