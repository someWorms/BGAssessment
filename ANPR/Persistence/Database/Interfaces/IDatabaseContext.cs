using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ANPR.Persistence.Models;

namespace ANPR.Persistence.Database.Interfaces
{
    public interface IDatabaseContext : IDisposable
    {
        /// <summary>
        ///     Sets
        /// </summary>
        DbSet<PlateModel> Plates { get; set; }
        DbSet<ProcessedFileModel> ProcessedFiles { get; set; }

        /// <summary>
        ///     Save changes
        /// </summary>
        /// <returns></returns>
        int SaveChanges();

        /// <summary>
        ///     Save changes async
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    }
}
