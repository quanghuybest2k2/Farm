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

        private DateTime GetVietnamDateTime()
        {
            // Lấy thời gian hiện tại của UTC
            DateTime utcNow = DateTime.UtcNow;
            // Tìm múi giờ của Việt Nam
            TimeZoneInfo vnTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
            // Chuyển đổi từ UTC sang giờ Việt Nam
            DateTime vnTime = TimeZoneInfo.ConvertTimeFromUtc(utcNow, vnTimeZone);
            return vnTime;
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
                DateTime nowInVietnam = GetVietnamDateTime();
                ((IModifier)entityEntry.Entity).UpdateAt = nowInVietnam;

                if (entityEntry.State == EntityState.Added)
                {
                    ((IModifier)entityEntry.Entity).CreateAt = nowInVietnam;
                }
            }
        }

        /// <inheritdoc />
        public void Save()
        {
            try
            {
                ChangeModifiedAt();
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw new Exception("Conflict Forinkey ,Cannot Remove");
            }

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

