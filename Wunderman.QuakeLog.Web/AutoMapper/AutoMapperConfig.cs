using AutoMapper;
using Wunderman.QuakeLog.Web.AutoMapper;


namespace Wunderman.QuakeLog.Web.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(a =>
            {
                a.AddProfile<MappingProfile>();
            });
        }
    }
}