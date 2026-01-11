using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.DTOs.ContactDTOs;
using MultiShop.Catalog.Services.ContactServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public async Task<IActionResult> GetContactsList()
        {
            var values = await _contactService.GetAllContactAsync();
            return Ok(values);
        }


        [HttpGet("GetReadContactsList")]
        public async Task<IActionResult> GetReadContactsList()
        {
            var values = await _contactService.GetReadContactsAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactById(string id)
        {
            var value = await _contactService.GetContactByIdAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactDTO createContactDTO)
        {
            await _contactService.CreateContactAsync(createContactDTO);
            return Ok("Yeni mesaj başarıyla eklendi!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(string id)
        {
            await _contactService.DeleteContactAsync(id);
            return Ok("Mesaj başarıyla silindi!");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateContact(UpdateContactDTO updateContactDTO)
        {
            await _contactService.UpdateContactAsync(updateContactDTO);
            return Ok("Mesaj başarıyla güncellendi!");
        }

        [HttpPut("ChangeContactReading/{id}")]
        public async Task<IActionResult> ChangeContactReading(string id)
        {
            await _contactService.ChangeContactReadingAsync(id);
            return Ok("Mesaj okunma durumu başarıyla değiştirildi!");
        }
    }
}
