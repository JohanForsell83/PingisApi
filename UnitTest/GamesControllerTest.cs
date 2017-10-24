using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Pingis.DataModel.Core.UnitOfWork;
using PingsiAPI.Controllers;
using Pingis.Core.Models;
using Pingis.DataModel.Core.Service;
using Pingis.DataModel.Persistence;


namespace UnitTest
{
    [TestClass]
    public class GamesControllerTest
    {
        private Mock<IUnitOfWork> _uow;
        private Mock<GameRepository> _gameRepo;
        private GamesController _gamesController;
        private Game _game;
        private GameDTO _gameDTO;
        private Mock<IGameService> _gameService;

        [TestInitialize]
        public void TestSetup()
        {
            _gameRepo = new Mock<GameRepository>();
            _uow = new Mock<IUnitOfWork>();
            _gameService = new Mock<IGameService>();
            _gamesController = new GamesController(_uow.Object, _gameService.Object);
            _game = new Game() {Player1Score = 10, Player2Score = 20, Id = 1};
            _gameDTO = new GameDTO() { Player1Score = 10, Player2Score = 20, Id = 10};
        }

        [TestMethod]
        public void GetAllGames_ShouldReturnAllGames()
        {
            // Arrange
            _uow
                .Setup(u => u.GamesService.GetAll())
                .Returns(listOfGames());

            //Act
            var actionResult = _gamesController.GetAllGames();
            var contentResult = actionResult as OkNegotiatedContentResult<GameDTO>;

            //Assert
            Assert.AreEqual(listOfGames().Count(), 4);
        }

        [TestMethod]
        public void GetAllGames_ShouldReturnInternalServerError()
        {
            // Arrange
            _gameService
                .Setup(g => g.GetAll())
                .Throws(new Exception());

            //Act
            var actionResult = _gamesController.GetAllGames();

            //Assert
            Assert.IsInstanceOfType(actionResult, typeof(InternalServerErrorResult));
        }

        [TestMethod]
        public void GetGame_ShouldReturnCorrectGame()
        {
            //Arrange
            _gameService
                        .Setup(g => g.GetById(1))
                        .Returns(_game);

            //Act
            var actionResult = _gamesController.GetGame(1);
            var contentResult = actionResult as OkNegotiatedContentResult<Game>;

            //Assert
            Assert.AreEqual(game().Id, contentResult.Content.Id);
        }

        [TestMethod]
        public void GetGame_ShouldReturnNotFound()
        {
            //Arrange
            _game = null;

            _gameService
                .Setup(g => g.GetById(1))
                .Returns(_game);

            //Act
            var actionResult = _gamesController.GetGame(5);

            //Assert
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
        }

        [TestMethod]
        public void AddGame_ShouldReturnOk()
        {
            //Arrange
            _uow
                .Setup(g => g.GamesService.Create(_game));

            //Act
            var actionResult = _gamesController.AddGame(_game);

            //Assert
            Assert.IsInstanceOfType(actionResult, typeof(OkResult));
        }

        [TestMethod]
        public void AddGame_ShouldReturnInternalServerError()
        {
            //Arrange
            _uow
                  .Setup(g => g.GamesService.Create(_game))
                  .Throws<Exception>();

            //Act
            var actionResult = _gamesController.AddGame(_game);

            //Assert
            Assert.IsInstanceOfType(actionResult, typeof(InternalServerErrorResult));
        }

        [TestMethod]
        public void UpdateGame_ShouldReturnOk()
        {
            //Arrange
            _uow
                .Setup(g => g.GamesService.Update(_game));

            //Act
            var actionResult = _gamesController.UpdateGame(_game);

            //Assert
            Assert.IsInstanceOfType(actionResult, typeof(OkResult));
        }

        [TestMethod]
        public void UpdateGame_ShouldReturnInternalServerError()
        {
            //Arrange
            _uow
                .Setup(g => g.GamesService.Update(_game))
                .Throws<Exception>();

            //Act
            var actionResult = _gamesController.UpdateGame(_game);

            //Assert
            Assert.IsInstanceOfType(actionResult, typeof(InternalServerErrorResult));
        }

        [TestMethod]
        public void GetPlayerByGameId_ShouldReturnCorrectGame()
        {
            //Arrange
            _gameService
                .Setup(g => g.GetGamesIncludingPlayerByGameId(10))
                .Returns(_gameDTO);

            //Act
            var actionResult = _gamesController.GetPlayerByGameId(10);
            var contentResult = actionResult as OkNegotiatedContentResult<GameDTO>;

            Assert.AreEqual(_gameDTO.Id, 10);
        }

        [TestMethod]
        public void GetPlayerByGameId_ShouldReturnNotFound()
        {
            //Arrange
            _gameDTO = null;

            _gameService
                .Setup(g => g.GetGamesIncludingPlayerByGameId(10))
                .Returns(_gameDTO)
;
            //Act
            var actionResult = _gamesController.GetPlayerByGameId(10);
          
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
        }


        private IEnumerable<Game> listOfGames()
        {
            return new List<Game>
            {
                new Game() {Player1Score = 10, Player2Score = 20, Id = 1,},
                new Game() {Player1Score = 10, Player2Score = 20, Id = 2,},
                new Game() {Player1Score = 10, Player2Score = 20, Id = 3,},
                new Game() {Player1Score = 10, Player2Score = 20, Id = 4,}
            };
        }

        private Game game()
        {
            return new Game()
            {
                Id = 1
            };
        }


    }
}
