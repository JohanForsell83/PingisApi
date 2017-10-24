using System;
using System.Collections;
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
    public class PlayerControllerTest
    {
        private Mock<IUnitOfWork> _uow;
        private Mock<IPlayerService> _playerService;
        private PlayersController _playerController;
        private Player _player;
        private PlayerDTO _playerDTO; 

        [TestInitialize]
        public void TestSetup()
        {
            _uow = new Mock<IUnitOfWork>();
            _playerService = new Mock<IPlayerService>();
            _playerController = new PlayersController(_uow.Object, _playerService.Object);
            _player = new Player() {Id = 1, DouchePoints = 0, FirstName = "Johan", LastName = "Forsell"};
            _playerDTO = new PlayerDTO() { Id = 10, DouchePoints = 0, FirstName = "Johan", LastName = "Forsell" };

        }


        [TestMethod]
        public void GetAllPlayers_ShouldReturnListOfPlayers()
        {
            //Arrange
            _playerService
                .Setup(p => p.GetAll())
                .Returns(listOfPlayers());

            //Act
            var actionResult = _playerController.GetAllPlayers();
            var contentResult = actionResult as OkNegotiatedContentResult<Player>;

            //Assert
            Assert.AreEqual(4, listOfPlayers().Count());
        }

        [TestMethod]
        public void GetAllPlayers_ShouldReturnInternalServerError()
        {
            //Arrange
            _playerService
                .Setup(p => p.GetAll())
                .Throws<Exception>();

            //Act
            var actionResult = _playerController.GetAllPlayers();
     
            //Assert
            Assert.IsInstanceOfType(actionResult, typeof(InternalServerErrorResult));
        }

        [TestMethod]
        public void AddPlayer_ShouldReturnOk()
        {
            //Arrange
            _uow
                .Setup(p => p.PlayerService.Create(_player));
            
            //Act
            var actionResult = _playerController.AddPlayer(_player);
            
            //Assert
            Assert.IsInstanceOfType(actionResult, typeof(OkResult));
        }

        [TestMethod]
        public void AddPlayer_ShouldReturnInternalServerError()
        {
            //Arrange
            _uow
                .Setup(p => p.PlayerService.Create(_player))
                .Throws<Exception>();

            //Act
            var actionResult = _playerController.AddPlayer(_player);

            //Assert
            Assert.IsInstanceOfType(actionResult, typeof(InternalServerErrorResult));
        }

        [TestMethod]
        public void DeletePlayer_ShouldReturnOk()
        {
            //Arrange
            _uow
                .Setup(p => p.Players.RemoveById(1));

            //Act
            var actionResult = _playerController.DeletePlayer(1);

            //Assert
            Assert.IsInstanceOfType(actionResult, typeof(OkResult));

        }

        [TestMethod]
        public void DeletePlayer_ShouldReturnInternalServerErrorResult()
        {
            //Arrange
            _uow
                .Setup(p => p.Players.RemoveById(1))
                .Throws<Exception>();
            //Act
            var actionResult = _playerController.DeletePlayer(1);

            //Assert
            Assert.IsInstanceOfType(actionResult, typeof(InternalServerErrorResult));

        }

        [TestMethod]
        public void UpdatePlayer_ShouldReturnOk()
        {
            //Arrange
            _uow
                .Setup(p => p.Players.UpdatePlayer(_player));

            //Act
            var actionResult = _playerController.UpdatePlayer(_player);

            //Assert
            Assert.IsInstanceOfType(actionResult, typeof(OkNegotiatedContentResult<Player>));
        }


        [TestMethod]
        public void UpdatePlayer_ShouldReturnInternalServerErrorResult()
        {
            //Arrange
            _uow
                .Setup(p => p.Players.UpdatePlayer(_player))
                .Throws<Exception>();
            //Act
            var actionResult = _playerController.UpdatePlayer(_player);

            //Assert
            Assert.IsInstanceOfType(actionResult, typeof(InternalServerErrorResult));

        }


        [TestMethod]
        public void GetGamesByPlayerId_ShouldReturnOk()
        {
            //Arrange
            _playerService
                .Setup(p => p.GetGamesByPlayerId(10))
                .Returns(listOfGames());

            //Act
            var actionResult = _playerController.GetGamesByPlayerId(10);

            //Assert
            Assert.IsInstanceOfType(actionResult, typeof(OkNegotiatedContentResult<IEnumerable<GameDTO>>));
        }


        [TestMethod]
        public void GetGamesByPlayerId_ShouldReturnInternalServerErrorResult()
        {
            //Arrange
            _playerService
                .Setup(p => p.GetGamesByPlayerId(10))
                .Throws<Exception>();
            //Act
            var actionResult = _playerController.GetGamesByPlayerId(10);

            //Assert
            Assert.IsInstanceOfType(actionResult, typeof(InternalServerErrorResult));

        }


        private IEnumerable<Player> listOfPlayers()
        {
            return new List<Player>
            {
                new Player() {Id = 1, DouchePoints = 0, FirstName = "Johan", LastName = "Forsell"},
                new Player() {Id = 2, DouchePoints = 0, FirstName = "Carl", LastName = "Forsell"},
                new Player() {Id = 3, DouchePoints = 0, FirstName = "Test", LastName = "Forsell"},
                new Player() {Id = 4, DouchePoints = 100, FirstName = "Jonas", LastName = "Forsell"}

            };
        }

        private IEnumerable<GameDTO> listOfGames()
        {
            return new List<GameDTO>
            {
                new GameDTO() {Player1Score = 10, Player2Score = 20, Id = 1,},
                new GameDTO() {Player1Score = 10, Player2Score = 20, Id = 2,},
                new GameDTO() {Player1Score = 10, Player2Score = 20, Id = 3,},
                new GameDTO() {Player1Score = 10, Player2Score = 20, Id = 4,}
            };
        }

    }

}
