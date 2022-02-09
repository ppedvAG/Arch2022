using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ppedv.BooksManager.Logic;
using ppedv.BooksManager.Model;
using ppedv.BooksManager.UI.ASP_MVC.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ppedv.BooksManager.UI.ASP_MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksAPI : ControllerBase
    {

        BooksManagerService bms = new BooksManagerService(new BooksManager.Data.Ef.EfUnitOfWork());


        MapperConfiguration config = new(cfg => cfg.CreateMap<Book, BookDTO>().ReverseMap());

        // GET: api/<BooksAPI>
        [HttpGet]
        public IEnumerable<BookDTO> Get()
        {
            var mapper = config.CreateMapper();
            foreach (var book in bms.UnitOfWork.BooksRepository.Query().ToList())
            {
                yield return mapper.Map<BookDTO>(book);
            }

            //return bms.UnitOfWork.BooksRepository.Query().ToList().Select(x => new BookDTO() { Id = x.Id, Pages = x.PageCount, Title = x.Title });
        }

        // GET api/<BooksAPI>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BooksAPI>
        [HttpPost]
        public void Post([FromBody] BookDTO value)
        {
            var mapper = config.CreateMapper();
            var book = mapper.Map<Book>(value);
            bms.UnitOfWork.BooksRepository.Add(book);
            bms.UnitOfWork.SaveAll();
        }

        // PUT api/<BooksAPI>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BooksAPI>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
