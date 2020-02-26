using Abp.Authorization;
using AutoMapper;
using MyProject.Authorization.Permissions.Dto;

namespace MyProject
{
    internal static class CustomDtoMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            //Permission
            configuration.CreateMap<Permission, FlatPermissionDto>();
            configuration.CreateMap<Permission, FlatPermissionWithLevelDto>();
        }
    }
}