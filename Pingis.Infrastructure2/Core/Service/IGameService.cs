using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Pingis.Core.Models;

namespace Pingis.DataModel.Core.Service
{
    public interface IGameService : IService<Game>
    {
        void AddGameIncludingPlayerId(Game game);
        GameDTO GetGamesIncludingPlayerByGameId(int id);
        IEnumerable<GameDTO> GetAllGamesIncludingPlayer();
    }
}
