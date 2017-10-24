using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Pingis.Core.Models
{
    public class PlayerDTO
    {
        public PlayerDTO()
        {
            this.Games = new List<Game>();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DouchePoints { get; set; }
        public int Points { get; set; }

      
        public List<Game> Games { get; set; }

    }
}
