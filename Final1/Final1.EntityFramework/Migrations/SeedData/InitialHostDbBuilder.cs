using Final1.EntityFramework;
using EntityFramework.DynamicFilters;

namespace Final1.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly Final1DbContext _context;

        public InitialHostDbBuilder(Final1DbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new DefaultEditionsCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
        }
    }
}
