using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Pingis.Core.Models
{
    public class GameDTO
    {
        public GameDTO()
        {
            this.Players = new List<Player>();
        }

        public int Id { get; set; }
        public int Player1Score { get; set; }
        public int Player2Score { get; set; }
        public int Winner { get; set; }

       
        public List<Player> Players { get; set; }
    }
}
