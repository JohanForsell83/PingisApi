using System;
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
    public class TournamentController : ApiController
    {

        private readonly IUnitOfWork _uow;
        private readonly ITournamentService _tournamentService;

        public TournamentController(IUnitOfWork uow, ITournamentService tournamentService)
        {
            _uow = uow;
            _tournamentService = tournamentService;
        }

      
        public IHttpActionResult GetAllTournaments()
        {
            try
            {
                var tournaments = _tournamentService.GetAll();
                return Ok(tournaments);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        public IHttpActionResult AddTournament([FromBody] Tournament tournament)
        {
            try
            {
                _uow.TournamentService.Create(tournament);
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
