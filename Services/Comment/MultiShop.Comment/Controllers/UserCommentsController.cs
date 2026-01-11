using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiShop.Comment.Context;
using MultiShop.Comment.DTOs.UserCommentDTOs;
using MultiShop.Comment.Entities;

namespace MultiShop.Comment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserCommentsController : ControllerBase
    {
        private readonly CommentContext _context;
        private readonly IMapper _mapper;

        public UserCommentsController(CommentContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetUserCommentsList()
        {
            var values = _context.UserComments.ToList();
            return Ok(values);
        }

        //[HttpGet("GetUserCommentsListWithProduct")]
        //public IActionResult GetUserCommentsListWithProduct()
        //{
        //    var values = _context.UserComments.Include(x => x.Product).ToList();
        //    return Ok(values);
        //}

        [HttpGet("{id}")]
        public IActionResult GetUserCommentById(int id)
        {
            var value = _context.UserComments.Find(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateUserComment(CreateUserCommentDTO createUserCommentDTO)
        {
            var value = _mapper.Map<UserComment>(createUserCommentDTO);
            _context.UserComments.Add(value);
            _context.SaveChanges();
            return Ok("Yorum başarıyla eklendi!");
        }

        [HttpPut]
        public IActionResult UpdateUserComment(UpdateUserCommentDTO updateUserCommentDTO)
        {
            var value = _mapper.Map<UserComment>(updateUserCommentDTO);
            _context.UserComments.Update(value);
            _context.SaveChanges();
            return Ok("Yorum başarıyla güncellendi!");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUserComment(int id)
        {
            var value = _context.UserComments.Find(id);
            if(value != null)
            {
                _context.UserComments.Remove(value);
                _context.SaveChanges();
                return Ok("Yorum başarıyla silindi!");
            }
            return Ok("Yorum bulunamadı!");
        }

        [HttpGet("GetUserCommentsListByProductId/{id}")]
        public IActionResult GetUserCommentsListByProductId(string id)
        {
            var values = _context.UserComments.Where(x => x.ProductId == id).ToList();
            return Ok(values);
        }

        [HttpPut("ChangeUserCommentStatus/{id}")]
        public IActionResult ChangeUserCommentStatus(int id)
        {
            var value = _context.UserComments.Find(id);
            if (value != null)
            {
                value.Status = !value.Status;
                _context.UserComments.Update(value);
                _context.SaveChanges();
            }
           
            return Ok("Yorum durumu başarıyla değiştirildi!");
        }

        [HttpGet("GetActiveCommentCount")]
        public IActionResult GetActiveCommentCount()
        {
            return Ok(_context.UserComments.Count(x => x.Status == true));
        }

        [HttpGet("GetPassiveCommentCount")]
        public IActionResult GetPassiveCommentCount()
        {
            return Ok(_context.UserComments.Count(x => x.Status == false));
        }

        [HttpGet("GetTotalCommentCount")]
        public IActionResult GetTotalCommentCount()
        {
            return Ok(_context.UserComments.Count());
        }
    }
}
