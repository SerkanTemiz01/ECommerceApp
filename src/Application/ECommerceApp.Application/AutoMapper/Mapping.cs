using AutoMapper;
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

        }
    }
}
