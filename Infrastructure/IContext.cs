using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public interface IContext
    {
        DatabaseFacade Database { get; }
        void Migrate();
        void SaveChanges();
        void SaveChangesAsync(CancellationToken cancellationToken);
    }
}
