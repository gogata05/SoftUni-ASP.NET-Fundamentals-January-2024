using Forum.Core.Contracts;
using Forum.Core.Models.Post;
using Forum.Infrastructure;
using Forum.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;


namespace Forum.Core.Services
{
    public class PostService : IPostService
    {
        private readonly ForumDbContext _context;
        public PostService(ForumDbContext context) 
        {
            this._context = context;
        }

    

        public async Task<ICollection<PostViewModel>> GetAllAsync()
        {
            var allPosts = await _context.Posts
                   .AsNoTracking()
                   .Select(p => new PostViewModel
                   {
                       Id = p.Id.ToString(),
                       Title = p.Title,
                       Content = p.Content
                   }
                   )
                   .ToListAsync();

            return allPosts;
        }

        public async Task CreateAsync(PostFormModel model)
        {
            Post postToAdd = new Post()
            {
                Content = model.Content,
                Title = model.Title,
            };

            await _context.Posts.AddAsync(postToAdd);
            await _context.SaveChangesAsync();

            
        }

        public async Task<Post> GetByIdAsync(string id)
        => await _context.Posts.FirstOrDefaultAsync(p => p.Id.ToString() == id);

        public async Task UpdateAsync(string id, PostFormModel model)
        {
            Post postToEdit = await GetByIdAsync(id);
            postToEdit.Title = model.Title;
            postToEdit.Content = model.Content;

            await _context.SaveChangesAsync();
        }

        public async Task Delete(string id)
        {
            Post postToDelete = await GetByIdAsync(id);
            _context.Posts.Remove(postToDelete);

            await _context.SaveChangesAsync();
        }
    }
}


