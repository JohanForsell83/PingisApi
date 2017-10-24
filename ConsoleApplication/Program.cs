using Pingis.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pingis.Core.Models;
using Pingis.DataModel.Database;
using Pingis.DataModel.Persistence;

namespace ConsoleApplication
{
    public class Program
    {
      
        static void Main(string[] args)
        {

            using (var context = new UnitOfWork(new PingisContext()))
            {
                Player player = context.Players.GetPlayerWithMostDouchePoints();

                Console.WriteLine(player.FirstName + " " + player.LastName);

                Console.ReadKey();

            }

        }
    }
}
