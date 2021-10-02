

using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;

namespace WalletApi.Middleware.Mapper
{
    public class MapperConfigurationProfiles
    {
        public static MapperConfiguration GetProfileConfig()
        {
            MapperConfiguration mappingConfig = new MapperConfiguration(x =>
            {
                x.AddExpressionMapping();
                x.AddProfile(new MappingProfile());
            });
            return mappingConfig;
        }
    }
}
