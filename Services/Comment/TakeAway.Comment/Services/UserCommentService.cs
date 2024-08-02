using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TakeAway.Comment.DAL.Context;
using TakeAway.Comment.DAL.Entities;
using TakeAway.Comment.Dtos;

namespace TakeAway.Comment.Services
{
    public class UserCommentService : IUserCommentService
    {
        private readonly CommentContext _context;
        private readonly IMapper _mapper;

        public UserCommentService(CommentContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateUserCommentAsync(CreateUserCommentDto userCommentDto)
        {
            var value = _mapper.Map<UserComment>(userCommentDto);
            await _context.UserComments.AddAsync(value);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserCommentAsync(int id)
        {
            var values = await _context.UserComments.FindAsync(id);
            _context.UserComments.Remove(values);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ResultUserCommentDto>> GetAllUserCommentAsync()
        {
            var values = await _context.UserComments.ToListAsync();
            return _mapper.Map<List<ResultUserCommentDto>>(values);
        }

        public async Task<GetByIdUserCommentDto> GetByIdUserCommentAsync(int id)
        {
            var values = await _context.UserComments.FindAsync(id);
            return _mapper.Map<GetByIdUserCommentDto>(values);

        }

        public async Task<List<ResultUserCommentDto>> GetProductUserCommentAsync(string productId)
        {
            var values = await _context.UserComments.Where(x => x.ProductId == productId).ToListAsync();
            return _mapper.Map<List<ResultUserCommentDto>>(values);
        }

        public async Task UpdateUserCommentAsync(UpdateUserCommentDto updateUserCommentDto)
        {
            var values = _mapper.Map<UserComment>(updateUserCommentDto);
            _context.UserComments.Update(values);
            await _context.SaveChangesAsync();
        }
    }
}
