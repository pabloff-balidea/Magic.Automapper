﻿// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
{
    using AutoMapper;
    using Magic.AutoMapper;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;


    internal class MapperUtilsBuilder : IMapperUtilsBuilder
    {
        private readonly IServiceCollection _services;

        public MapperUtilsBuilder(IServiceCollection services)
        {
            this._services = services;
        }

        public IServiceCollection AddAutomapper(params Assembly[] assemblies)
            =>
                _services.AddAutoMapper((_, cfg) =>
                {
                    cfg.AddMagicAutoMapperProfile(assemblies);
                    // cfg.AddProfile(new GenericProfile(assemblies));
                }, assemblies);


        public IServiceCollection AddAutomapper(Action<IMapperConfigurationExpression> configAction, params Assembly[] assemblies)
            => _services.AddAutoMapper((_, cfg) =>
            {
                configAction?.Invoke(cfg);
                cfg.AddMagicAutoMapperProfile(assemblies);
                // cfg.AddProfile(new GenericProfile(assemblies));
            }, assemblies);


        public IServiceCollection AddAutomapper(Action<IServiceProvider, IMapperConfigurationExpression> configAction, params Assembly[] assemblies)
            => _services.AddAutoMapper((sp, cfg) =>
            {
                configAction?.Invoke(sp, cfg);
                cfg.AddMagicAutoMapperProfile(assemblies);
                // cfg.AddProfile(new GenericProfile(assemblies));
            }, assemblies);


        public IServiceCollection AddAutomapper(Action<IMapperConfigurationExpression> configAction, IEnumerable<Assembly> assemblies, ServiceLifetime serviceLifetime = ServiceLifetime.Transient)
        {
            IEnumerable<Assembly> assembliesList = assemblies.ToList();
            return _services.AddAutoMapper((_, cfg) =>
            {
                configAction?.Invoke(cfg);
                cfg.AddMagicAutoMapperProfile(assembliesList);
                //cfg.AddProfile(new GenericProfile(assembliesList));
            }, assembliesList, serviceLifetime);
        }


        public IServiceCollection AddAutomapper(Action<IServiceProvider, IMapperConfigurationExpression> configAction, IEnumerable<Assembly> assemblies, ServiceLifetime serviceLifetime = ServiceLifetime.Transient)
        {
            IEnumerable<Assembly> assembliesList = assemblies.ToList();

            return _services.AddAutoMapper((sp, cfg) =>
            {
                configAction?.Invoke(sp, cfg);
                cfg.AddMagicAutoMapperProfile(assembliesList);
                //cfg.AddProfile(new GenericProfile(assembliesList));
            }, assembliesList, serviceLifetime);
        }


        public IServiceCollection AddAutomapper(IEnumerable<Assembly> assemblies, ServiceLifetime serviceLifetime = ServiceLifetime.Transient)
        {
            IEnumerable<Assembly> assembliesList = assemblies.ToList();
            return _services
                .AddAutoMapper(
                    (_, cfg) =>
                        cfg.AddMagicAutoMapperProfile(assembliesList)
                    //cfg.AddProfile(new GenericProfile(assembliesList))
                    , assembliesList
                    , serviceLifetime
                );
        }


        public IServiceCollection AddAutomapper(params Type[] profileAssemblyMarkerTypes)
        {
            var assembliesList = profileAssemblyMarkerTypes.Select(t => t.GetTypeInfo().Assembly).ToList();
            return _services.AddAutoMapper(
                (_, cfg) => cfg.AddMagicAutoMapperProfile(assembliesList)
            //cfg.AddProfile(new GenericProfile(assembliesList))
            , assembliesList);
        }


        public IServiceCollection AddAutomapper(Action<IMapperConfigurationExpression> configAction, params Type[] profileAssemblyMarkerTypes)
        {
            var assembliesList = profileAssemblyMarkerTypes.Select(t => t.GetTypeInfo().Assembly).ToList();
            return _services.AddAutoMapper((_, cfg) =>
            {
                configAction?.Invoke(cfg);
                cfg.AddMagicAutoMapperProfile(assembliesList);
                //cfg.AddProfile(new GenericProfile(assembliesList))

            }, assembliesList);
        }


        public IServiceCollection AddAutomapper(Action<IServiceProvider, IMapperConfigurationExpression> configAction, params Type[] profileAssemblyMarkerTypes)
        {
            var assembliesList = profileAssemblyMarkerTypes.Select(t => t.GetTypeInfo().Assembly).ToList();

            return _services.AddAutoMapper((sp, cfg) =>
            {
                configAction?.Invoke(sp, cfg);
                cfg.AddMagicAutoMapperProfile(assembliesList);
                //cfg.AddProfile(new GenericProfile(assembliesList))

            }, assembliesList);
        }


        public IServiceCollection AddAutomapper(Action<IMapperConfigurationExpression> configAction,
            IEnumerable<Type> profileAssemblyMarkerTypes, ServiceLifetime serviceLifetime = ServiceLifetime.Transient)
        {
            var assembliesList = profileAssemblyMarkerTypes.Select(t => t.GetTypeInfo().Assembly).ToList();

            return _services.AddAutoMapper((cfg) =>
            {
                configAction?.Invoke(cfg);
                cfg.AddMagicAutoMapperProfile(assembliesList);
                //cfg.AddProfile(new GenericProfile(assembliesList));

            }, assembliesList);
        }


        public IServiceCollection AddAutomapper(Action<IServiceProvider, IMapperConfigurationExpression> configAction,
            IEnumerable<Type> profileAssemblyMarkerTypes, ServiceLifetime serviceLifetime = ServiceLifetime.Transient)
        {
            var assembliesList = profileAssemblyMarkerTypes.Select(t => t.GetTypeInfo().Assembly).ToList();

            return _services.AddAutoMapper((sp, cfg) =>
            {
                configAction?.Invoke(sp, cfg);

                cfg.AddMagicAutoMapperProfile(assembliesList);
                //cfg.AddProfile(new GenericProfile(assembliesList));

            }, assembliesList, serviceLifetime);
        }




    }
}