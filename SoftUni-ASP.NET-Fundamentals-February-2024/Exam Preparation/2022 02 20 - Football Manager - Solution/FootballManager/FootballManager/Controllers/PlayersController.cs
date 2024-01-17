using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using FootballManager.Services;
using FootballManager.ViewModels.Players;

namespace FootballManager.Controllers
{
    public class PlayersController : Controller
    {
        private readonly IPlayersService playersService;

        public PlayersController(Request request, IPlayersService playersService)
          : base(request)
        {
            this.playersService = playersService;

        }

        public Response All()
        {
            if (!this.User.IsAuthenticated)
            {
                return this.Redirect("/Users/Login");
            }
            var allPlayers = this.playersService.GetAll().Select(x => new PralyersViewModel
            {
                Id = x.Id,
                FullName = x.FullName,
                ImageUrl = x.ImageUrl,
                Speed = x.Speed,
                Endurance = x.Endurance,
                Position = x.Position,
                Description = x.Description,
            }).ToList();

            var viewModel = new
            {
                IsAuthenticated = true,
                Players = allPlayers,
            };
            return this.View(viewModel);
        }

        public Response Add()
        {
            if (User.IsAuthenticated)
            {
                return this.View(new { IsAuthenticated = true });
            }
            return this.Redirect("/Users/Login");
        }

        [HttpPost]
        public Response Add(AddPlayerInputModel model)
        {
            if (!this.User.IsAuthenticated)
            {
                return this.Redirect("/Users/Login");
            }
            if (model.FullName.Length < 5 || model.FullName.Length > 80 || string.IsNullOrEmpty(model.FullName))
            {
                return this.View(model);
            }
            if (model.Description.Length > 200 || string.IsNullOrEmpty(model.Description))
            {
                return this.View(model);
            }
            if (string.IsNullOrEmpty(model.ImageUrl))
            {
                return this.View(model);
            }
            if (model.Position.Length < 5 || model.Position.Length > 20 || string.IsNullOrEmpty(model.Position))
            {
                return this.View(model);
            }
            if (model.Speed < 0 || model.Speed > 10)
            {
                return this.View(model);
            }
            if (model.Endurance < 0 || model.Endurance > 10)
            {
                return this.View(model);
            }
            var userId = this.User.Id;
            var playerId = this.playersService.AddPlayer(model, userId);

            return this.Redirect("/Players/All");
        }

        public Response Collection()
        {
            if (!this.User.IsAuthenticated)
            {
                return this.Redirect("/Users/Login");
            }
            var userId = this.User.Id;
            var result = this.playersService.GetAllFromCollection(userId)
                .Select(x => new PralyersViewModel
                {
                    Id = x.Id,
                    FullName = x.FullName,
                    ImageUrl = x.ImageUrl,
                    Speed = x.Speed,
                    Endurance = x.Endurance,
                    Position = x.Position,
                    Description = x.Description,
                }).ToList();

            var viewModel = new
            {
                IsAuthenticated = true,
                Players = result
            };
            return this.View(viewModel);
        }

        public Response RemoveFromCollection(int playerId)
        {
            if (!this.User.IsAuthenticated)
            {
                return this.Redirect("/Users/Login");
            }
            var userId = this.User.Id;

            var isRemoved = this.playersService.RemoveFromCollection(userId, playerId);
            return this.Redirect("/Players/Collection");
        }

        public Response AddToCollection(int playerId)
        {
            if (!this.User.IsAuthenticated)
            {
                return this.Redirect("/Users/Login");
            }
            var userId = this.User.Id;
            var usersPlayer = this.playersService.GetUserPlayer(userId, playerId);
            if (usersPlayer != null)
            {
                return this.Redirect("/Players/All");
            }

            this.playersService.AddPlayerToCollection(userId, playerId);
            return this.Redirect("/Players/All");
        }
    }
}
