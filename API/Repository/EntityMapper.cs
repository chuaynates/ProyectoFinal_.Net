using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using AutoMapper;
using Domain;

namespace API.Repository
{
    public class EntityMapper<TSource, TDestination> where TSource : class where TDestination : class
    {

        public EntityMapper()
        {
            Mapper.CreateMap<Models.ProductoModel, Producto>();
            Mapper.CreateMap<Producto, Models.ProductoModel>();

        }

        public TDestination Translate(TSource obj)
        {
            return Mapper.Map<TDestination>(obj);
        }

    }
}