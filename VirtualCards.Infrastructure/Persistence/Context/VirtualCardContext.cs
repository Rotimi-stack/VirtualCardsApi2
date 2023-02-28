using Microsoft.EntityFrameworkCore;
using System;
using VirtualCards.Application.Common.Interface;
using VirtualCards.Application.Common.Model;

namespace VirtualCards.Infrastructure.Persistence.Context
{
    public class VirtualCardContext : DbContext, IVirtualCardsContext
    {
        public VirtualCardContext(DbContextOptions<VirtualCardContext> options)
            : base(options)
        {

        }

        protected VirtualCardContext()
        {

        }

        
        public DbSet<tblRequestandResponseLogs> tblRequestAndResponse { get ; set; }
    }
}
