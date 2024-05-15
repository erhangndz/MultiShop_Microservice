using Multishop.WebDTO.DTOs.CommentDtos;
using System.Drawing;

namespace Multishop.WebUI.Services.CommentServices
{
    public interface ICommentService
    {
        Task<List<ResultCommentDto>> GetAllCommentsAsync();

        Task CreateCommentAsync(CreateCommentDto createCommentDto);
        Task UpdateCommentAsync(UpdateCommentDto updateCommentDto);

        Task DeleteCommentAsync(int id);

        Task<UpdateCommentDto> GetCommentByIdAsync(int id);

        Task<List<ResultCommentDto>> GetCommentsByProductIdAsync(string id);

    }
}
