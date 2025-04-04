﻿using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.User;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAccess.Repositories
{
    internal class UserRepository : IUserWriteOnlyRepository, IUserReadOnlyRepository
    {
        private readonly CashFlowDbContext _dbContext;

        public UserRepository(CashFlowDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task Add(User user)
        {
            await _dbContext.AddAsync(user);
        }

        public async Task<bool> ExistActiveUserWithEmail(string email)
        {
           return await _dbContext.Users.AnyAsync(user => user.Email.Equals(email));
            
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(user => user.Email.Equals(email));    
        }
    }
}
