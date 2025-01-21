using Dapper;
using Npgsql;
using ShopMicroservices.DiscountApi.Application.Models;
using ShopMicroservices.DiscountApi.Domain.Models;
using ShopMicroservices.DiscountApi.Domain.Repositories;

namespace ShopMicroservices.DiscountApi.Application.Repositories;

public class DiscountRepository : IDiscountRepository
{
    private readonly IConfiguration _configuration;

    public DiscountRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<Coupon?> GetDiscount(string productName)
    {
        NpgsqlConnection connection = GetConnectionPostgreSql();

        var coupon = await connection.QueryFirstOrDefaultAsync<Coupon>
            (
                "SELECT * FROM Coupon WHERE ProductName = @ProductName",
                new { ProductName = productName }
            );

        return coupon;
    }

    public async Task<bool> CreateDiscount(Coupon coupon)
    {
        return await ExecuteAsync(
                "INSERT INTO Coupon (ProductName, Description, Amount) VALUES (@ProductName, @Description, @Amount)",
                 new { coupon.ProductName, coupon.Description, coupon.Amount }
            );
    }

    public async Task<bool> UpdateDiscount(Coupon coupon)
    {
        return await ExecuteAsync(
               "UPDATE Coupon SET ProductName=@ProductName, Description=@Description, Amount=@Amount WHERE Id = @Id",
                new { coupon.ProductName, coupon.Description, coupon.Amount, coupon.Id }
           );
    }

    public async Task<bool> DeleteDiscount(string productName)
    {
        return await ExecuteAsync(
               "DELETE FROM Coupon WHERE ProductName=@ProductName",
                new { ProductName = productName }
           );
    }

    public async Task InitializeDb()
    {
        await ExecuteAsync(
            "CREATE DATABASE DiscountDb"
            );
        await ExecuteAsync(
            "CREATE TABLE Coupon( ID SERIAL PRIMARY KEY NOT NULL, ProductName VARCHA(24) NOT NULL, Description TEXT, Amount INT"
            );
    }


    private NpgsqlConnection GetConnectionPostgreSql()
    {
        return new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
    }

    private async Task<bool> ExecuteAsync(string sql, params object[] args)
    {
        NpgsqlConnection connection = GetConnectionPostgreSql();

        var affected = await connection.ExecuteAsync
            (
                sql,
                args
            );

        if (affected == 0)
        {
            return false;
        }

        return true;
    }
}
