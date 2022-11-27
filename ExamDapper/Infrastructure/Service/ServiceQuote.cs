using Domain.Dtos;
using Dapper;
using Npgsql;
namespace Infrastructure.ServiceQuote;
public class QuoteService
{
    private string  _connectionString = "Server=127.0.0.1;Port=5432;Database=Quotes;User Id=postgres;Password=11042004;";

   public List<Quote> GetInfoQuotes()
    {
        using (var conn = new NpgsqlConnection(_connectionString))
        {
            var sql = "Select * from Quotes";
            
            return conn.Query<Quote>(sql).ToList();
        }
    }
       public int InsertQuotes(Quote  quote)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                var sql =
                    $"insert into Quotes (Author, QuoteText,categ_id) VALUES " +
                    $"('{quote.author}', " +
                    $"'{quote.quotetext}', " +
                    $"'{quote.categ_id}')";
                var result = conn.Execute(sql);

                return result;
            }
        }

         public int UpdateQuotes(Quote quote)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                var sql = 
                    $"UPDATE Quotess SET " +
                    $"Quotesname = '{quote.author}', " +
                    $"company = '{quote.quotetext}', " +
                    $"Quotescount = '{quote.categ_id}', " +
                    $"WHERE Id = {quote.id}";

                var result = conn.Execute(sql);

                return result;
            }
        }

          public int DeleteQuotes(int id)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                var sql = $"DELETE FROM Quotes WHERE id = {id}";

                var result = conn.Execute(sql);

                return result;
            }}
                public List <Quote> GetById(int id)
    {
       using (var conn = new NpgsqlConnection(_connectionString))
        {
            var sql = 
            $"Select * from Quotes where categ_id = {id}";  
            
          return conn.Query<Quote>(sql).ToList();
        }
    }

        public List<Quote> GetRandomQuotes()
    {
        using (var conn = new NpgsqlConnection(_connectionString))
        {
            var sql = "select * from quotes order by random() limit 1";
            
            return conn.Query<Quote>(sql).ToList();
        }
    }
    }
        
    
