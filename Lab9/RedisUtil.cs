using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ServiceStack.Redis;

namespace Lab9
{
    class RedisUtil
    {
        private String host;
        private int port = 6390;  // redis default port
        private String pw;

        public RedisUtil(String host, int port, String pw)
        {
            this.host = host;
            this.port = port;
            this.pw = pw;
        }
        public IRedisNativeClient GetNativeClient()
        {
            return new RedisNativeClient(host, port, pw);
        }

        public IRedisClient GetClient()
        {
            return new RedisClient(host, port, pw);
        }

        public IList<Player> GetAllPlayers()
        {
            IList<Player> storedPlayers = null;
            using (IRedisClient client = new RedisClient(host, port, pw))
            {
                //Note: .As<T> is a shorter alias for .GetTypedClient<T> 
                var playerClient = client.As<Player>();
                storedPlayers = playerClient.GetAll();
            }
            return storedPlayers;
        }

        public Player GetPlayerById(int id)
        {
            Player storedPlayer = null;
            using (IRedisClient client = new RedisClient(host, port, pw))
            {
                var playerClient = client.As<Player>();
                storedPlayer = playerClient.GetById(id);
            }
            return storedPlayer;
        }

        public Player StoreOnePlayer(Player player)
        {
            Player storedPlayer = null;
            using (IRedisClient client = new RedisClient(host, port, pw))
            {
                var playerClient = client.As<Player>();
                if (player.Id == 0)
                    player.Id = playerClient.GetNextSequence();
                storedPlayer = playerClient.Store(player);
            }
            return storedPlayer;
        }

        public void StoreManyPlayer(List<Player> player)
        {
            using (IRedisClient client = new RedisClient(host, port, pw))
            {
                var playerClient = client.As<Player>();
                playerClient.StoreAll(player);
            }
        }

        public void DeleteAllPlayers()
        {
            using (IRedisClient client = new RedisClient(host, port, pw))
            {
                var playerClient = client.As<Player>();
                playerClient.DeleteAll();

            }
        }

        public void DeletePlayer(int id)
        {
            using (IRedisClient client = new RedisClient(host, port, pw))
            {
                var playerClient = client.As<Player>();
                playerClient.DeleteById(id);
            }
        }
    }
}
