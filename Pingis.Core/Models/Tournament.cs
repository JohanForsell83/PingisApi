using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pingis.Core.Models
{
    public class Tournament
    {

        public Tournament()
        {
            this.Players = new HashSet<Player>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfPlayers { get; set; }
        public virtual ICollection<Player> Players { get; set; }
        public virtual ICollection<Game> Games { get; set; }
    }
}
