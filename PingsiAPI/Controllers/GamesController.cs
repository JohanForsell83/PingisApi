using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Pingis.Core.Models;
using Pingis.DataModel.Core.Repository;
using Pingis.DataModel.Core.Service;
using Pingis.DataModel.Core.UnitOfWork;
using Pingis.DataModel.Database;
using Pingis.DataModel.Persistence;
using Pingis.DataModel.Service;


namespace PingsiAPI.Controllers
{
    public class GamesController : ApiController
    {
        private readonly IUnitOfWork _uow;
        private readonly IGameService _gameService;

        public GamesController(IUnitOfWork uow, IGameService gameService)
        {
            _gameService = gameService;
            _uow = uow;
        }

        public IHttpActionResult GetAllGames()
        {
            try
            {
                var games = _gameService.GetAll();
                return Ok(games);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult GetGame(int id)
        {
            var game = _gameService.GetById(id);

            if (game == null)
            {
                return NotFound();
            }

            return Ok(game);
        }

        [HttpGet]
        [Route("api/Game/{id:int}/Player/")]
        public IHttpActionResult GetPlayerByGameId(int id)
        {
            var game = _gameService.GetGamesIncludingPlayerByGameId(id);

            if (game == null)
            {
                return NotFound();
            }

            return Ok(game);
        }

        [HttpPost]
        public IHttpActionResult AddGame([FromBody] Game game)
        {
            try
            {
                _uow.GamesService.Create(game);
                _uow.Complete();
                return Ok();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpDelete]
        public IHttpActionResult DeleteGame([FromBody] int id)
        {
            try
            {
                _uow.GamesService.Delete(id);
                _uow.Complete();
                return Ok();
            }
            catch (Exception e)
            {
                return InternalServerError(e.InnerException);
            }
        }

        [HttpPut]
        public IHttpActionResult UpdateGame([FromBody] Game game)
        {
            try
            {
                _uow.GamesService.Update(game);
                _uow.Complete();
                return Ok();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

    }
}
