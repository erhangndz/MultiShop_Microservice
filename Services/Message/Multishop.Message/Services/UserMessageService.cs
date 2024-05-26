using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Multishop.Message.DataAccess.Context;
using Multishop.Message.DataAccess.Entities;
using Multishop.Message.Dtos;

namespace Multishop.Message.Services
{
    public class UserMessageService(MessageContext _context, IMapper _mapper) : IUserMessageService
    {
        public async Task CreateMessageAsync(CreateMessageDto message)
        {
            await _context.UserMessages.AddAsync(_mapper.Map<UserMessage>(message));
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMessageAsync(int id)
        {
            var values = _context.UserMessages.Find(id);
            _context.UserMessages.Remove(values);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ResultMessageDto>> GetAllMessagesAsync()
        {
            return _mapper.Map<List<ResultMessageDto>>(await _context.UserMessages.ToListAsync());
        }

        public async Task<List<ResultMessageDto>> GetInboxMessagesAsync(string id)
        {
            return _mapper.Map<List<ResultMessageDto>>(await _context.UserMessages.Where(x => x.ReceiverId == id).ToListAsync());
        }

        public async Task<UpdateMessageDto> GetMessageByIdAsync(int id)
        {
            return _mapper.Map<UpdateMessageDto>(await _context.UserMessages.FindAsync(id));
        }

        public async Task<int> GetMessageCountByReceiverIdAsync(string id)
        {
            return await _context.UserMessages.CountAsync(x => x.ReceiverId == id);
        }

        public async Task<List<ResultMessageDto>> GetSentBoxMessagesAsync(string id)
        {
            return _mapper.Map<List<ResultMessageDto>>(await _context.UserMessages.Where(x => x.SenderId == id).ToListAsync());
        }

        public async Task<int> GetTotalMessageCountAsync()
        {
           return await _context.UserMessages.CountAsync();
        }

        public async Task UpdateMessageAsync(UpdateMessageDto message)
        {
            _context.UserMessages.Update(_mapper.Map<UserMessage>(message));
            await _context.SaveChangesAsync();
        }
    }
}
