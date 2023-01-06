using AutoMapper;
using ECommerceApp.Application.Models.DTOs;
using ECommerceApp.Application.Models.VMs;
using ECommerceApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Application.AutoMapper
{
    public class Mapping :Profile
    {
        public Mapping()
        {
            //Eşleştirme işlemi gerçekleştirilecek

            //Hangi türden veri gelirse diğerine otomatik çevir.
            //Ornek : CreateMap<T,TResult>().ReverseMap();

            CreateMap<Employee,AddManagerDTO>().ReverseMap();
            CreateMap<Employee,ListOfManagerVM>().ReverseMap();

        }
    }
}
