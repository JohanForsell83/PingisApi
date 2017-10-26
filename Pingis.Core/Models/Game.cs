using Pingis.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Pingis.Core.Models
{
    public class Game
    {
        public Game()
        {
            this.Players = new HashSet<Player>();
            this.Tournaments = new HashSet<Tournament>();
        }

        public int Id { get; set; }
        public int Player1Score { get; set; }
        public int Player2Score { get; set; }
        public int WinnerId { get; set; }
        public virtual ICollection<Player> Players { get; set; }
        public virtual ICollection<Tournament> Tournaments { get; set; }
    }
}
