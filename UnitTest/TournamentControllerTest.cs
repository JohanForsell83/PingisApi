using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Pingis.Core.Models;
using Pingis.DataModel.Core.Service;
using Pingis.DataModel.Core.UnitOfWork;
using PingsiAPI.Controllers;

namespace UnitTest
{
    [TestClass]
    public class TournamentControllerTest
    {
        private Mock<IUnitOfWork> _uow;
        private Mock<ITournamentService> _tournamentService;
        private TournamentController _tournamentController;


        [TestInitialize]
        public void TestSetup()
        {
            _uow = new Mock<IUnitOfWork>();
            _tournamentService = new Mock<ITournamentService>();
            _tournamentController = new TournamentController(_uow.Object, _tournamentService.Object);
        }

        [TestMethod]
        public void GetAllTournaments_ShouldReturnOkAndAListOfTournaments()
        {
            //Arrange
            _tournamentService
                .Setup(t => t.GetAll())
                .Returns(listOfTournament());

            //Act
            var actionResult = _tournamentController.GetAllTournaments();
            var contentResult = actionResult as OkNegotiatedContentResult<IEnumerable<Tournament>>;

            //Assert
            Assert.IsInstanceOfType(contentResult, typeof(OkResult));

        }

        private IEnumerable<Tournament> listOfTournament()
        {
            return new List<Tournament>
            {
                new Tournament()
                {
                    Games = new List<Game>()
                    {
                        new Game() {Player1Score = 10, Player2Score = 20, Id = 1},
                        new Game() {Player1Score = 10, Player2Score = 20, Id = 1},
                        new Game() {Player1Score = 10, Player2Score = 20, Id = 1}
                    },
                    Id = 20,
                    Name = "Test",
                    NumberOfPlayers = 4,
                    Players = new List<Player>()
                    {
                        new Player() {Id = 1, DouchePoints = 0, FirstName = "Johan", LastName = "Forsell"},
                        new Player() {Id = 2, DouchePoints = 0, FirstName = "Carl", LastName = "Forsell"},
                        new Player() {Id = 3, DouchePoints = 0, FirstName = "Test", LastName = "Forsell"},
                        new Player() {Id = 4, DouchePoints = 100, FirstName = "Jonas", LastName = "Forsell"}
                    }
                }

            };
        }
    }
}
