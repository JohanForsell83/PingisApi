using Pingis.Core;
using Pingis.DataModel.Database;
using Pingis.DataModel.Persistence;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Pingis.Core.Models;
using Pingis.DataModel.Core.Service;
using Pingis.DataModel.Core.UnitOfWork;

namespace PingsiAPI.Controllers
{
    public class PlayersController : ApiController
    {
        private readonly IUnitOfWork _uow;
        private readonly IPlayerService _playerService;

        public PlayersController(IUnitOfWork uow, IPlayerService playerService)
        {
            _playerService = playerService;
            _uow = uow;
        }
        
        public IHttpActionResult GetAllPlayers()
        {
            try
            {
                var players = _playerService.GetAll();
                return Ok(players);
            }
            catch (Exception e)
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult GetPlayer(int id)
        {
            try
            {
                var player = _playerService.GetById(id);

                if (player == null)
                {
                    return NotFound();
                }

                return Ok(player);
            }
            catch (Exception e)
            {
                return InternalServerError(e.InnerException);
            }
        }

        [HttpPost]
        public IHttpActionResult AddPlayer([FromBody] Player player)
        {
            try
            {
                _uow.PlayerService.Create(player);
                _uow.Complete();
                return Ok();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpDelete]
        public IHttpActionResult DeletePlayer([FromBody] int id)
        {
            try
            {
                _uow.Players.RemoveById(id);
                _uow.Complete();
                return Ok();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpPut]
        public IHttpActionResult UpdatePlayer([FromBody] Player player)
        {
            try
            {
                _uow.Players.UpdatePlayer(player);
                _uow.Complete();
                return Ok(player);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpGet]
        [Route("api/Player/{id:int}/Games/")]
        public IHttpActionResult GetGamesByPlayerId(int id)
        {
            try
            {
                var player = _playerService.GetGamesByPlayerId(id);
                return Ok(player);
            }
            catch (Exception e)
            {
                return InternalServerError();
            }
        }

    }
}
