using System.Linq;
using Final1.EntityFramework;
using Final1.MultiTenancy;

namespace Final1.Migrations.SeedData
{
    public class DefaultTenantCreator
    {
        private readonly Final1DbContext _context;

        public DefaultTenantCreator(Final1DbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateUserAndRoles();
        }

        private void CreateUserAndRoles()
        {
            //Default tenant

            var defaultTenant = _context.Tenants.FirstOrDefault(t => t.TenancyName == Tenant.DefaultTenantName);
            if (defaultTenant == null)
            {
                _context.Tenants.Add(new Tenant {TenancyName = Tenant.DefaultTenantName, Name = Tenant.DefaultTenantName});
                _context.SaveChanges();
            }
        }
    }
}
