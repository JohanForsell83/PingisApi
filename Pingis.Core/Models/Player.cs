using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Pingis.Core.Models
{
    public class Player
    {

        public Player()
        {
            this.Games = new HashSet<Game>();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DouchePoints { get; set; }
        public int Points { get; set; }
        
        public virtual ICollection<Game> Games { get; set; }

    }
}
