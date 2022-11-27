using Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.ServiceQuote;
namespace Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuoteController
    {
        private QuoteService _quoteService;

        public QuoteController()
        {
            _quoteService = new QuoteService();
        }


        [HttpGet]
        public List<Quote> GetInfoQuotes()
        {
            return _quoteService.GetInfoQuotes();
        }
        [HttpPost("Insert")]
        public int InsertQuotes(Quote quote)
        {
            return _quoteService.InsertQuotes(quote);
        }

        [HttpPut]
        public int UpdateQuotes(Quote quote)
        {
            return _quoteService.UpdateQuotes(quote);
        }

        [HttpDelete]
        public int DeleteQuotes(int id)
        {
            return _quoteService.DeleteQuotes(id);
        }

        [HttpGet("Byid")]
        public List<Quote> GetById(int id)
        {
            return _quoteService.GetById(id);
        }


        [HttpGet("Random")]
        public List<Quote> GetRandom()
        {
            return _quoteService.GetRandomQuotes();
        }
    }
}
