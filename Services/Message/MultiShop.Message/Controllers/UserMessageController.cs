using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Message.DTOs.UserMessageDTOs;
using MultiShop.Message.Services.UserMessageServices;

namespace MultiShop.Message.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserMessageController : ControllerBase
    {
        private readonly IUserMessageService _userMessageService;

        public UserMessageController(IUserMessageService userMessageService)
        {
            _userMessageService = userMessageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserMessagesList()
        {
            var values = await _userMessageService.GetAllUserMessagesAsync();
            return Ok(values);
        }

        [HttpGet("GetInboxUserMessagesList")]
        public async Task<IActionResult> GetInboxUserMessagesList(string id)
        {
            var values = await _userMessageService.GetInboxUserMessagesAsync(id);
            return Ok(values);
        }

        [HttpGet("GetSendboxUserMessagesList")]
        public async Task<IActionResult> GetSendboxUserMessagesList(string id)
        {
            var values = await _userMessageService.GetSendboxUserMessagesAsync(id);
            return Ok(values);
        }

        [HttpGet("GetUserMessageById/{id}")]
        public async Task<IActionResult> GetUserMessageById(int id)
        {
            var value = await _userMessageService.GetUserMessageByIdAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserMessage(CreateUserMessageDTO createUserMessageDTO)
        {
            await _userMessageService.CreateUserMessageAsync(createUserMessageDTO);
            return Ok("Yeni mesaj başarıyla eklendi!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserMessage(int id)
        {
            await _userMessageService.DeleteUserMessageAsync(id);
            return Ok("Mesaj başarıyla silindi!");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUserMessage(UpdateUserMessageDTO updateUserMessageDTO)
        {
            await _userMessageService.UpdateUserMessageAsync(updateUserMessageDTO);
            return Ok("Mesaj başarıyla güncellendi!");
        }

        [HttpPut("ChangeUserMessageReading/{id}")]
        public async Task<IActionResult> ChangeUserMessageReading(int id)
        {
            await _userMessageService.ChangeUserMessageReadingAsync(id);
            return Ok("Mesaj okunma durumu başarıyla değiştirildi!");
        }

        [HttpGet("GetTotalMessageCount")]
        public async Task<IActionResult> GetTotalMessageCount()
        {
            var value = await _userMessageService.GetTotalMessageCountAsync();
            return Ok(value);
        }

        [HttpGet("GetTotalMessageCountByReceiverIdAsync")]
        public async Task<IActionResult> GetTotalMessageCountByReceiverIdAsync(string id)
        {
            var value = await _userMessageService.GetTotalMessageCountByReceiverIdAsync(id);
            return Ok(value);
        }
    }
}
