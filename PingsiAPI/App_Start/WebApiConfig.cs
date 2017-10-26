using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using Newtonsoft.Json;
using Pingis.Core.Models;
using Pingis.DataModel;
using System.Data.Entity.Core.Metadata.Edm;
using System.Web.Services.Description;
using Microsoft.Practices.Unity;
using Pingis.DataModel.Core.Repository;
using Pingis.DataModel.Core.UnitOfWork;
using Pingis.DataModel.Persistence;
using Pingis.DataModel.Resolver;
using Pingis.DataModel.Service;
using Pingis.DataModel.Core.Service;

namespace PingsiAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //Configuration Unity
            var container = new UnityContainer();
            container.RegisterType<IPlayerRepository, PlayerRepository>();
            container.RegisterType<IGameRepository, GameRepository>();
            container.RegisterType<ITournamentRepository, TournamentRepository>();
            container.RegisterType<IGameService, GamesService>();
            container.RegisterType<IPlayerService, PlayersService>();
            container.RegisterType<ITournamentService, TournamentService>();
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            config.DependencyResolver = new UnityResolver(container);

            config.Formatters.XmlFormatter.SupportedMediaTypes.Clear();

            config.Formatters.JsonFormatter.SerializerSettings.Formatting =
                Newtonsoft.Json.Formatting.Indented;

            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver =
                new CamelCasePropertyNamesContractResolver();

            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            Mapper.Initialize(cfg => {
                cfg.CreateMap<Player, PlayerDTO>();
                cfg.CreateMap<Game, GameDTO>();
            });


            //config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new ProgramContractResolver();

        }
    }
}
