using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Showoff.Core.Features.Extensions;

namespace Showoff.Notices.DAL.Context
{
    public class DropDatabaseInitializer<T> : IDatabaseInitializer<T> where T : DbContext, new()
    {
        public DropDatabaseInitializer(Action<T> seed = null)
        {
            Seed = seed ?? delegate { };
        }

        public Action<T> Seed { get; set; }

        public void InitializeDatabase(T context)
        {
            string dbName = "[" + context.Database.Connection.Database + "]";
            string alterDB = "ALTER DATABASE {0} SET ".Frmt(dbName);

            //drop old DB
            //if (context.Database.Exists())
            //{
            //    context.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction,
            //                                        alterDB + "SINGLE_USER WITH ROLLBACK IMMEDIATE");
            //    context.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction,
            //                                        "USE master DROP DATABASE " + dbName);
            //}

            //recreate
            //context.Database.Create(); //exceptions here are normal for EF in Debug mode

            //configure
            //context.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction,
            //        alterDB + "ALLOW_SNAPSHOT_ISOLATION ON");
            //context.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction,
            //        alterDB + "READ_COMMITTED_SNAPSHOT ON");

            //reseed
            Seed(context);
        }
    }
}
