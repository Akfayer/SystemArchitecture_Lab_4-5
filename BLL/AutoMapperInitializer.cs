using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DAL;

namespace BLL
{
    class AutoMapperInitializer
    {
        //public AutoMapperProfile()
        //{
        //    CreateMap<Designer, DesignerBLL>();
        //    CreateMap<Designer, DesignerBLL>().ReverseMap();
        //}

        public static Mapper InitializeAutomapper()
        {
            //Provide all the Mapping Configuration
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                //Configuring Employee and EmployeeDTO
                cfg.CreateMap<Designer, DesignerBLL>();
                cfg.CreateMap<Designer, DesignerBLL>().ReverseMap();
                //Any Other Mapping Configuration ....
            });
            //Create an Instance of Mapper and return that Instance
            Mapper mapper = new Mapper(config);
            return mapper;
        }
    }
}
