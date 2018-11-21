using AutoMapper;
using Domain.entities;
using SiriusApp.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiriusApp.Api.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<UsuarioModel, UsuarioDomain>().ReverseMap();
            });
        }
    }
}