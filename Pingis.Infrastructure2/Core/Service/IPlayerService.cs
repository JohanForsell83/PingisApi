using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pingis.Core.Models;

namespace Pingis.DataModel.Core.Service
{
    public interface IPlayerService : IService<Player>
    {
        IEnumerable<PlayerDTO> GetPlayerWithMostPoints();

        PlayerDTO GetPlayerWithMostDouchePoints();

        PlayerDTO GetPlayerAndGamesByPlayerId(int id);

        void UpdatePlayer(Player player);

        IEnumerable<GameDTO> GetGamesByPlayerId(int id);
    }
}
