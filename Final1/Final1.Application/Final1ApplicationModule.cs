using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;

namespace Final1
{
    [DependsOn(typeof(Final1CoreModule), typeof(AbpAutoMapperModule))]
    public class Final1ApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Modules.AbpAutoMapper().Configurators.Add(mapper =>
            {
                //Add your custom AutoMapper mappings here...
                //mapper.CreateMap<,>()
            });
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
