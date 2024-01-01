namespace TaskBoard.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;
    using TaskBoard.Core.Contracts;
    using TaskBoard.Core.Models.Board;
    using TaskBoard.Core.Models.Task;
    using TaskBoard.Infrastructure.Data;
    public class BoardService : IBoardService
    {
        private readonly TaskBoardAppDbContext dbContext;
        public BoardService(TaskBoardAppDbContext dbContext) 
        { 
            this.dbContext = dbContext;         
        }

        public async Task<IEnumerable<BoardViewModel>> GetAllAsync()
        {
            return await dbContext.Boards
                         .Select(b => new BoardViewModel
                         {
                             Id = b.Id,
                             Name = b.Name,
                             Tasks = b.Tasks
                                     .Select(t => new TaskViewModel
                                     {
                                         Id = t.Id.ToString(),
                                         Title = t.Title,
                                         Description = t.Description,
                                         Owner = t.Owner.UserName

                                     }).ToList()

                         })
                         .ToListAsync();
        }

        public async Task<IEnumerable<BoardSelectViewModel>> GetBoardsForSelectAsync()
        {
            return await dbContext.Boards
                        .Select(b => new BoardSelectViewModel
                        {
                            Id = b.Id,
                            Name = b.Name
                        })
                        .ToListAsync();
        }

        public async Task<bool> DoesExists(int id)
        {
            return await dbContext.Boards
                   .AnyAsync(b => b.Id ==  id);
        }

        public async Task<ICollection<string>> GetBoardNamesAsync()
        {
            return await dbContext.Boards
                         .Select(b => b.Name)
                         .Distinct()
                         .ToListAsync();
                      
        }

        public async Task<ICollection<HomeBoardModel>> GetHomeBoardsAsync()
        {
            var boards = await GetBoardNamesAsync();

            ICollection<HomeBoardModel> result = new List<HomeBoardModel>();

            foreach(var boardName in boards)
            {
                HomeBoardModel tasksInBoard = new HomeBoardModel
                {
                    BoardName = boardName
                };

                result.Add(tasksInBoard);
            }

            return result;
        }
    }
}
