using Budget.Domain.Entities;
using Budget.Domain.Interfaces;
using Budget.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Infrastructure.Repositories
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly BudgetDbContext _context;

        public RefreshTokenRepository(BudgetDbContext context)
        {
            _context = context;
        }

        public void Add(RefreshToken model)
        {
            _context.RefreshTokens.Add(model);
        }

        public async Task AddAsync(RefreshToken model)
        {
            await _context.RefreshTokens.AddAsync(model);
        }

        public async Task<RefreshToken> Get(string jti)
        {
            return await _context.RefreshTokens.SingleOrDefaultAsync(f => f.JwtId == jti);
        }

        public void Update(RefreshToken model)
        {
            _context.RefreshTokens.Update(model);
        }
    }
}
