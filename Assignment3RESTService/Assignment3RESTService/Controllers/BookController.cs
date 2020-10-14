using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyClassLibary;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Assignment3RESTService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private static List<Book> Library = new List<Book>
        {
            new Book("Witcher", "Andrzej Sapkowski", 489, "9780316029186"),
            new Book("Call Me By Your Name", "André Aciman", 256,"1298364542832"),
            new Book("The Bible","God",456,"1111111111111")
        };

        // GET: api/<BookController>
        [HttpGet]
        public IEnumerable<Book> GetAll()
        {
            return Library;
        }

        // GET api/<BookController>/5
        [HttpGet("{isbn13}")]
        public Book Get(string isbn13)
        {

            return Library.Find(x => x.Isbn13 == isbn13);
        }

        // POST api/<BookController>
        [HttpPost]
        public void Post([FromBody] Book newBook)
        {
            Library.Add(newBook);
        }

        // PUT api/<BookController>/5
        [HttpPut("{isbn13}")]
        public void Put(string isbn13, [FromBody] Book newBook)
        {
            int index = Library.FindIndex(x => x.Isbn13 == isbn13);
            newBook.Isbn13 = isbn13;
            Library[index] = newBook;
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{isbn13}")]
        public void Delete(string isbn13)
        {
            Library.RemoveAll(x => x.Isbn13 == isbn13);

        }
    }
}
