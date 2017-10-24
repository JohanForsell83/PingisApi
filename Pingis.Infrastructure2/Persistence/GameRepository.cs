using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Pingis.DataModel.Core.Repository;
using Pingis.Core.Models;
using Pingis.DataModel.Database;
using System;

namespace Pingis.DataModel.Persistence
{
    public class GameRepository : Repository<Game>, IGameRepository
    {
        public GameRepository(PingisContext context) : base(context)
        {
        }

        public PingisContext DbContext => Context as PingisContext;

        public void AddGameIncludingPlayerId(Game game)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GameDTO> GetAllGamesIncludingPlayer()
        {
            throw new NotImplementedException();
        }

        public GameDTO GetGamesIncludingPlayerByGameId(int id)
        {
            var game = (from p in DbContext.Games
                        .Include(r => r.Players)
                        where p.Id == id
                        select new GameDTO()
                        {
                            Id = p.Id,
                            Players = p.Players.ToList(),
                            Player1Score = p.Player1Score,
                            Player2Score = p.Player2Score
                        }).FirstOrDefault();

            return game;
        }

        public void UpdateGame(Game game)
        {
            DbContext.Entry(game).State = EntityState.Modified;
        }
    }
}
