using FootballManager.Data.Models;
using FootballManager.ViewModels.Players;

namespace FootballManager.Services
{
    public interface IPlayersService
    {
        ICollection<Player> GetAll();

        int AddPlayer(AddPlayerInputModel model, string userId);

        ICollection<Player> GetAllFromCollection(string userId);

        bool RemoveFromCollection(string userId, int playerId);

        void AddPlayerToCollection(string userId, int playerId);

        UserPlayer GetUserPlayer(string userId, int playerId);
    }
}
