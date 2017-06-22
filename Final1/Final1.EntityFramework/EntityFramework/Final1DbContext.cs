using System.Data.Common;
using Abp.Zero.EntityFramework;
using Final1.Authorization.Roles;
using Final1.MultiTenancy;
using Final1.Users;

namespace Final1.EntityFramework
{
    public class Final1DbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        //TODO: Define an IDbSet for your Entities...

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public Final1DbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in Final1DataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of Final1DbContext since ABP automatically handles it.
         */
        public Final1DbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public Final1DbContext(DbConnection existingConnection)
         : base(existingConnection, false)
        {

        }

        public Final1DbContext(DbConnection existingConnection, bool contextOwnsConnection)
         : base(existingConnection, contextOwnsConnection)
        {

        }
    }
}
