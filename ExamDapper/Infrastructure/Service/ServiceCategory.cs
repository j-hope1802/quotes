using Domain.Dtos;
using Dapper;
using Npgsql;
namespace Infrastructure.ServiceCategory

{
    public class CategoryService{
    private string  _connectionString = "Server=127.0.0.1;Port=5432;Database=Quotes;User Id=postgres;Password=11042004;";

   public List<Category> GetInfoCategory()
    {
        using (var conn = new NpgsqlConnection(_connectionString))
        {
            var sql = "Select * from Category";
            
            return conn.Query<Category>(sql).ToList();
        }
    }
       public int InsertCategory(Category category)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                var sql =
                    $"insert into Category (CategoryName) VALUES " +
                    $"('{category.CategoryName}')" ;
                
                var result = conn.Execute(sql);

                return result;
            }
        }

         public int UpdateCategory(Category category)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                var sql = 
                    $"UPDATE Category SET " +
                    $"CategoryName = '{category.CategoryName}', " +
                  
                    $"id = '{category.id}', " +
                    $"WHERE Id = {category.id}";

                var result = conn.Execute(sql);

                return result;
            }
        }

          public int DeleteCategory(int id)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                var sql = $"DELETE FROM Category WHERE id = {id}";

                var result = conn.Execute(sql);

                return result;
            }}
      

        }
}