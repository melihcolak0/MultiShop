using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using MultiShop.Message.DAL.Context;
using MultiShop.Message.DAL.Entities;
using MultiShop.Message.DTOs.UserMessageDTOs;


namespace MultiShop.Message.Services.UserMessageServices
{
    public class UserMessageService : IUserMessageService
    {
        private readonly MessageContext _context;
        private readonly IMapper _mapper;
       
        public UserMessageService(IMapper mapper, MessageContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task ChangeUserMessageReadingAsync(int id)
        {
            var message = await _context.UserMessages.FindAsync(id);
            if (message != null)
            {
                message.IsRead = !message.IsRead;
                await _context.SaveChangesAsync();
            }
        }

        public async Task CreateUserMessageAsync(CreateUserMessageDTO createUserMessageDTO)
        {
            var userMessage = _mapper.Map<UserMessage>(createUserMessageDTO);
            userMessage.SendDate = DateTime.UtcNow;
            _context.UserMessages.Add(userMessage);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserMessageAsync(int id)
        {
            var message = await _context.UserMessages.FindAsync(id);
            if (message != null)
            {
                _context.UserMessages.Remove(message);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<ResultUserMessageDTO>> GetAllUserMessagesAsync()
        {
            return await _context.UserMessages
                .ProjectTo<ResultUserMessageDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<List<ResultInboxDTO>> GetInboxUserMessagesAsync(string id)
        {
            return await _context.UserMessages
                .Where(x => x.ReceiverId == id)
                .ProjectTo<ResultInboxDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<List<ResultSendboxDTO>> GetSendboxUserMessagesAsync(string id)
        {
            return await _context.UserMessages
                .Where(x => x.SenderId == id)
                .ProjectTo<ResultSendboxDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<int> GetTotalMessageCountAsync()
        {
            return await _context.UserMessages.CountAsync();
        }              

        public async Task<int> GetTotalMessageCountByReceiverIdAsync(string id)
        {
            return await _context.UserMessages.CountAsync(x => x.ReceiverId == id);
        }

        public async Task<GetUserMessageDTO> GetUserMessageByIdAsync(int id)
        {
            var message = await _context.UserMessages
                .Where(x => x.UserMessageId == id)
                .ProjectTo<GetUserMessageDTO>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
            return message ?? throw new Exception("Mesaj bulunamadı");
        }

        public async Task UpdateUserMessageAsync(UpdateUserMessageDTO updateUserMessageDTO)
        {
            var userMessage = await _context.UserMessages.FindAsync(updateUserMessageDTO.UserMessageId);
            if (userMessage != null)
            {
                _mapper.Map(updateUserMessageDTO, userMessage);
                await _context.SaveChangesAsync();
            }
        }
    }
}
