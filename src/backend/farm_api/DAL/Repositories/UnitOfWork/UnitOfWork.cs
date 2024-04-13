using Core.Common;
using DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FarmContext _context;

        /// <inheritdoc />
        public void Dispose()
        {
            _context.Dispose();
        }


        private void ChangeModifiedAt()
        {
            var entries = _context.ChangeTracker
        .Entries()
        .Where(e => e.Entity is IModifier && (
                e.State == EntityState.Added
                || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((IModifier)entityEntry.Entity).UpdateAt = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((IModifier)entityEntry.Entity).CreateAt = DateTime.Now;
                }
            }
        }

        /// <inheritdoc />
        public void Save()
        {
             //ChangeModifiedAt();

            _context.SaveChanges();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="context"></param>
        public UnitOfWork(FarmContext context)
        {
            _context = context;
        }
    }
}

