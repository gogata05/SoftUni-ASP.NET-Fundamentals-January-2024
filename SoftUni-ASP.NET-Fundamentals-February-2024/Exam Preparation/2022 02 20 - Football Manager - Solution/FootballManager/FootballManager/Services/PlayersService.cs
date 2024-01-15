using FootballManager.Data;
using FootballManager.Data.Models;
using FootballManager.ViewModels.Players;
using System.Collections.Generic;
using System.Linq;

namespace FootballManager.Services
{
    public class PlayersService : IPlayersService
    {
        private readonly FootballManagerDbContext db;

        public PlayersService(FootballManagerDbContext db)
        {
            this.db = db;
        }

        public int AddPlayer(AddPlayerInputModel model, string userId)
        {
            var player = new Player
            {
                FullName = model.FullName,
                Position = model.Position,
                ImageUrl = model.ImageUrl,
                Endurance = model.Endurance,
                Speed = model.Speed,
                Description = model.Description,
            };

            var user = this.db.Users.Find(userId);
            this.db.Players.Add(player);
            this.db.SaveChanges();

            var userPlayer = new UserPlayer
            {
                PlayerId = player.Id,
                UserId = user.Id,
            };
            this.db.UserPlayers.Add(userPlayer);
            this.db.SaveChanges();
            return player.Id;
        }

        public void AddPlayerToCollection(string userId, int playerId)
        {
            var usersPlayer = this.GetUserPlayer(userId, playerId);
            if (usersPlayer == null)
            {
                var userPlayer = new UserPlayer
                {
                    PlayerId = playerId,
                    UserId = userId,
                };
                this.db.UserPlayers.Add(userPlayer);
                this.db.SaveChanges();
            }
        }

        public ICollection<Player> GetAll()
        {
            var players = this.db.Players.ToList();
            return players;
        }

        public ICollection<Player> GetAllFromCollection(string userId)
        {
            var playersId = this.db.UserPlayers
                .Where(x => x.UserId == userId)
                .Select(x => x.PlayerId)
                .ToList();

            var players = new List<Player>();
            foreach (var id in playersId)
            {
                var player = this.db.Players.Where(x => x.Id == id).FirstOrDefault();
                players.Add(player);
            }

            return players;
        }

        public UserPlayer GetUserPlayer(string userId, int playerId)
        {
            var userPlayer = this.db.UserPlayers
                .Where(x => x.UserId == userId && x.PlayerId == playerId)
                .FirstOrDefault();
            if (userPlayer == null)
            {
                return null;
            }
            return userPlayer;
        }

        public bool RemoveFromCollection(string userId, int playerId)
        {
            var userPlayer = this.GetUserPlayer(userId, playerId);

            if (userPlayer == null)
            {
                return false;
            }

            this.db.UserPlayers.Remove(userPlayer);
            this.db.SaveChanges();
            return true;
        }
    }
}
