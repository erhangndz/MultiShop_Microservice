using Multishop.WebDTO.DTOs.CommentDtos;

namespace Multishop.WebUI.Services.CommentServices
{
    public class CommentService(HttpClient _client) : ICommentService
    {
        public async Task CreateCommentAsync(CreateCommentDto createCommentDto)
        {
            await _client.PostAsJsonAsync("comments",createCommentDto);
        }

        public async Task DeleteCommentAsync(int id)
        {
            await _client.DeleteAsync("comments/" + id);
        }

        public async Task<List<ResultCommentDto>> GetAllCommentsAsync()
        {
            return await _client.GetFromJsonAsync<List<ResultCommentDto>>("comments");
        }

        public async Task<UpdateCommentDto> GetCommentByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<UpdateCommentDto>("comments/" + id);
        }

        public async Task<List<ResultCommentDto>> GetCommentsByProductIdAsync(string id)
        {
            return await _client.GetFromJsonAsync<List<ResultCommentDto>>("comments/getByProductId/" + id);
        }

        public async Task UpdateCommentAsync(UpdateCommentDto updateCommentDto)
        {
            await _client.PutAsJsonAsync("comments", updateCommentDto);
        }
    }
}
