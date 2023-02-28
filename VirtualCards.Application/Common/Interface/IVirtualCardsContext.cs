using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VirtualCards.Application.Common.Model;

namespace VirtualCards.Application.Common.Interface
{
    public interface IVirtualCardsContext
    {
        DbSet<tblRequestandResponseLogs> tblRequestAndResponse { get; set; }
    }
}
