using System.Data;
using Dapper;
using People.Management.Domain.Contracts;
using People.Management.Domain.Entites;
using People.Management.Framework.DTOs.User;
using People.Management.Infra.Context;

namespace People.Management.Infra.Repositories
{
    public class UserDapperRepository : IUserDapperRepository
    {
        private readonly IDbConnection _connection;

        public UserDapperRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<UserReadDTO>> GetList(int pageIndex, int pageSize)
        {
            var parameters = new { PageIndex = pageIndex, PageSize = pageSize };
            string sql = @"SELECT [us].[Id], [us].[ReferenceId]  ,[us].[FirstName] ,[us].[LastName] ,[us].[Email] ,[us].[BirthDate] ,[us].[SchoolingId] ,[us].[SchoolRecordId] ,[us].[Adress] ,[us].[City] ,[us].[Country] ,[us].[Number] ,[us].[Uf] ,[us].[ZipCode],
                            [sct].Id as SchoolingTypeId, [sct].Name as SchoolingTypeName , [scr].Format as SchoolRecordFormat, [scr].Name as SchoolRecordName
                            FROM [u].[User] [us]
                            LEFT JOIN [u].Schooling [sc] ON [us].SchoolingId = [sc].Id
                            LEFT JOIN [u].ScholingType [sct] ON [sc].SchoolingId = [sct].Id
                            LEFT JOIN [u].SchoolRecord [scr] ON [us].SchoolRecordId = [scr].Id
                            ORDER BY [ReferenceId], [FirstName] DESC
                            OFFSET  @PageIndex  ROWS
                            FETCH NEXT @PageSize ROWS ONLY";
            return await _connection.QueryAsync<UserReadDTO>(sql, parameters);
        }

        public async Task<IEnumerable<UserReadDTO?>> GetById(Guid id)
        {
            var parameters = new { Id = id };
            string sql = @"SELECT [us].[Id] ,[us].[ReferenceId] ,[us].[FirstName] ,[us].[LastName] ,[us].[Email] ,[us].[BirthDate] ,[us].[SchoolingId] ,[us].[SchoolRecordId] ,[us].[Adress] ,[us].[City] ,[us].[Country] ,[us].[Number] ,[us].[Uf] ,[us].[ZipCode],
                            [sct].Id as SchoolingTypeId, [sct].Name as SchoolingTypeName , [scr].Format as SchoolRecordFormat, [scr].Name as SchoolRecordName
                            FROM [u].[User] [us]
                            LEFT JOIN [u].Schooling [sc] ON [us].SchoolingId = [sc].Id
                            LEFT JOIN [u].ScholingType [sct] ON [sc].SchoolingId = [sct].Id
                            LEFT JOIN [u].SchoolRecord [scr] ON [us].SchoolRecordId = [scr].Id
                            WHERE [us].[Id] = @Id";
            return await _connection.QueryAsync<UserReadDTO>(sql, parameters);

        }
    }
}
