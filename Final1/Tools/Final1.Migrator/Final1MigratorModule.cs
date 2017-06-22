using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Final1.EntityFramework;

namespace Final1.Migrator
{
    [DependsOn(typeof(Final1DataModule))]
    public class Final1MigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<Final1DbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}