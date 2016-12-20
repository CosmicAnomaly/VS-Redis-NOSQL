using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using ServiceStack.Redis;

namespace Lab9
{
    class Program
    {
        static void Main(string[] args)
        {
            string host = ConfigurationManager.AppSettings["RedisHost"];
            int port = Convert.ToInt32(ConfigurationManager.AppSettings["RedisPort"]);
            string password = ConfigurationManager.AppSettings["RedisPassword"];

            RedisUtil redisUtil = new RedisUtil(host, port, password);

            Random random = new Random(200); //will always procuce the same sequence
            List<int> numberList = new List<int>();
            //List<int> returnedNumberList;
            for (int x = 0; x < 20; x++)
                numberList.Add(random.Next());

            ////Singular add
            //Player player1 = new Player { FirstName = "Wayne", LastName = "Rooney", Team = "Manchester United", Id = 1 };
            //redisUtil.StoreOnePlayer(player1);
            //Console.WriteLine(player1.FirstName + " " + player1.LastName + " Team: "+ player1.Team + ". ID#: " + player1.Id);

            ////List add
            //List<Player> player = new List<Player>();
            //player.Add(new Player { FirstName = "Zlatan", LastName = "Ibrahimovic", Team = "Manchester United", Id = 2 });
            //player.Add(new Player { FirstName = "Paul", LastName = "Pogba", Team = "Manchester United", Id = 3 });
            //player.Add(new Player { FirstName = "Ander", LastName = "Herrera", Team = "Manchester United", Id = 4 });

            //redisUtil.StoreManyPlayer(player);

            //IList<Player> returnedPlayer = redisUtil.GetAllPlayers();
            //Console.WriteLine("All people:");
            //foreach (Player p in returnedPlayer)
            //{
            //    Console.WriteLine(p.FirstName + " " + p.LastName + " Team: " + p.Team + ". ID#: " + p.Id);
            //}

            ////Singular delete
            redisUtil.DeletePlayer(4);

            Console.ReadLine();
        }
    }
}
