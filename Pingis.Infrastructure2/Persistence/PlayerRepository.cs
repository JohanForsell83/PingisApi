
using Pingis.Core;
using Pingis.DataModel.Core.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Pingis.Core.Models;
using Pingis.DataModel.Database;
using System;
using System.Collections;
using AutoMapper;

namespace Pingis.DataModel.Persistence
{
    public class PlayerRepository : Repository<Player>, IPlayerRepository
    {
        public PlayerRepository(PingisContext context) : base(context)
        {
        }

        public PingisContext DbContext => Context as PingisContext;

        public IEnumerable<GameDTO> GetGamesByPlayerId(int id)
        {
            var games = from p in DbContext.Players
                        join g in DbContext.Games on p.Id equals id
                        select new GameDTO
                        {
                            Id = g.Id,
                            Player1Score = g.Player1Score,
                            Player2Score = g.Player2Score,
                            Winner = g.WinnerId,
                            Players = g.Players.Where(a => a.Id != id).ToList()
                        };


            return games;

        }

        public PlayerDTO GetPlayerAndGamesByPlayerId(int id)
        {
            var player = (from p in DbContext.Players
                          where p.Id == id
                          select new PlayerDTO()
                          {
                              Id = p.Id,
                              DouchePoints = p.DouchePoints,
                              FirstName = p.FirstName,
                              LastName = p.LastName,
                              Games = p.Games.ToList(),
                              Points = p.Points,

                          }).FirstOrDefault();

            return player;
        }

        public PlayerDTO GetPlayerWithMostDouchePoints()
        {
            var player = DbContext.Players.OrderByDescending(p => p.DouchePoints).First();

            var playerDTO = Mapper.Map<PlayerDTO>(player);

            return playerDTO;
        }

        public IEnumerable<PlayerDTO> GetPlayerWithMostPoints()
        {
            var players = DbContext.Players.OrderByDescending(p => p.Points);

            List<PlayerDTO> playersDTO = new List<PlayerDTO>();
            
            foreach (var player in players)
            {
                playersDTO.Add(Mapper.Map<PlayerDTO>(player));
            }
            
            return playersDTO;
        }

        public void UpdatePlayer(Player player)
        {
            DbContext.Entry(player).State = EntityState.Modified;
        }
    }
}
