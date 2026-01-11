using Dapper;
using MultiShop.Discount.Context;
using MultiShop.Discount.DTOs;
using MultiShop.Discount.Entities;

namespace MultiShop.Discount.Services
{
    public class CouponService : ICouponService
    {
        private readonly DapperContext _context;

        public CouponService(DapperContext context)
        {
            _context = context;
        }

        public async Task CreateCouponAsync(CreateCouponDTO createCouponDTO)
        {
            string query = "INSERT INTO Coupons(CouponCode, Rate, IsActive, ValidDate) VALUES(@CouponCode, @Rate, @IsActive, @ValidDate)";
            var parameters = new DynamicParameters();
            parameters.Add("@CouponCode", createCouponDTO.CouponCode);
            parameters.Add("@Rate", createCouponDTO.Rate);
            parameters.Add("@IsActive", createCouponDTO.IsActive);
            parameters.Add("@ValidDate", createCouponDTO.ValidDate);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteCouponAsync(string id)
        {
            string query = "DELETE FROM Coupons WHERE CouponId = @CouponId";
            var parameters = new DynamicParameters();
            parameters.Add("@CouponId", id);           

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultCouponDTO>> GetAllCouponAsync()
        {
            string query = "SELECT * FROM Coupons";

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultCouponDTO>(query);
                return values.ToList();
            }
        }

        public async Task<GetCouponDTO> GetCouponByCodeAsync(string code)
        {
            string query = "SELECT * FROM Coupons WHERE CouponCode = @CouponCode";
            var parameters = new DynamicParameters();
            parameters.Add("@CouponCode", code);

            using (var connection = _context.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<GetCouponDTO>(query, parameters);
                return value;
            }
        }

        public async Task<GetCouponDTO> GetCouponByIdAsync(string id)
        {
            string query = "SELECT * FROM Coupons WHERE CouponId = @CouponId";
            var parameters = new DynamicParameters();
            parameters.Add("@CouponId", id);

            using (var connection = _context.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<GetCouponDTO>(query, parameters);
                return value;
            }
        }

        public async Task<int> GetCouponCount()
        {
            string query = "SELECT Count(*) FROM Coupons";

            using (var connection = _context.CreateConnection())
            {
                return await connection.QuerySingleAsync<int>(query);
            }
        }

        public async Task InActivateCouponByCodeAsync(string code)
        {
            const string query = @"UPDATE Coupons SET IsActive = 0 WHERE CouponCode = @CouponCode";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { CouponCode = code });
            }
        }

        public async Task UpdateCouponAsync(UpdateCouponDTO updateCouponDTO)
        {
            string query = "UPDATE Coupons SET CouponCode = @CouponCode, Rate = @Rate, IsActive = @IsActive, ValidDate = @ValidDate WHERE CouponId = @CouponId";
            var parameters = new DynamicParameters();
            parameters.Add("@CouponCode", updateCouponDTO.CouponCode);
            parameters.Add("@Rate", updateCouponDTO.Rate);
            parameters.Add("@IsActive", updateCouponDTO.IsActive);
            parameters.Add("@ValidDate", updateCouponDTO.ValidDate);
            parameters.Add("@CouponId", updateCouponDTO.CouponId);            

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
