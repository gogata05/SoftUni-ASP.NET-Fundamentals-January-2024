using TaskBoard.Core.Models.Board;

namespace TaskBoard.Core.Contracts
{
    public interface IBoardService
    {
        public Task<IEnumerable<BoardViewModel>> GetAllAsync();

        public Task<IEnumerable<BoardSelectViewModel>> GetBoardsForSelectAsync();

        public Task<bool> DoesExists(int id);

        public Task<ICollection<string>> GetBoardNamesAsync();

        public Task<ICollection<HomeBoardModel>> GetHomeBoardsAsync();
    }
}
