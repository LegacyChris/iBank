using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace ATM.Models
{
    public interface IApplicationDbContext
    {
        IDbSet<CheckingAccount> CheckingAccounts { get; set; }
        IDbSet<Transaction> Transactions { get; set; }

        int SaveChanges();
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
        {
       
            public ApplicationDbContext()
                : base("DefaultConnection", throwIfV1Schema: false)
            {
            }

            public static ApplicationDbContext Create()
            {
                return new ApplicationDbContext();
            }

            public IDbSet<CheckingAccount> CheckingAccounts { get; set; }

            public IDbSet<Transaction> Transactions { get; set; }

            public override int SaveChanges()
            {
                try
                {
                    return base.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    string errorMessages = string.Join("; ", ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.PropertyName + ": " + x.ErrorMessage));
                    throw new DbEntityValidationException(errorMessages);
                }
            }
    }

    public class FakeApplicationDbContext : IApplicationDbContext
    {
        public IDbSet<CheckingAccount> CheckingAccounts { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IDbSet<Transaction> Transactions { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int SaveChanges()
        {
            return 0;
        }
    }
}