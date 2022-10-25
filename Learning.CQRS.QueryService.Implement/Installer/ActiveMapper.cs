using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Learning.CQRS.QueryService.Implement.Modules.LearningCenterModule.Mappers;
using Learning.CQRS.QueryService.Implement.Modules.LearningCenterModule.Mappers.ElectronicDocument;

namespace Learning.CQRS.QueryService.Implement.Installer
{
    public static class ActiveMapper
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<ElectronicDocumentMapperProfile>();
                cfg.AddProfile<ElectronicSourceMapperProfile>();

            });
        }
    }
}
