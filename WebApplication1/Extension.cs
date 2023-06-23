using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.Dto;

namespace WebApplication1
{
    public static class Extension
    {
        public static IEnumerable<GetDoctorsDto> Sort(this IEnumerable<GetDoctorsDto> obj, string orderBy)
        {
            IEnumerable<GetDoctorsDto> result = orderBy?.ToLower() switch
            {
                "fullname" => obj.OrderBy(column => column.FullName),
                "cabinet" => obj.OrderBy(column => column.NumberOfCab),
                "region" => obj.OrderBy(column => column.NumberOfRegion),
                "specialty" => obj.OrderBy(column => column.NameOfSpecialty),
                _ => obj
            };
            return result;
        }
        
        public static IEnumerable<GetPatientsDto> Sort(this IEnumerable<GetPatientsDto> obj, string sort)
        {
            IEnumerable<GetPatientsDto> result = sort?.ToLower() switch
            {
                "family" => obj.OrderBy(column => column.Family),
                "firstname" => obj.OrderBy(column => column.FirstName),
                "secondname" => obj.OrderBy(column => column.SecondName),
                "address" => obj.OrderBy(column => column.Address),
                "dateofbirth" => obj.OrderBy(column => column.DateOfBirth),
                "sex" => obj.OrderBy(column => column.Sex),
                "numberofregion" => obj.OrderBy(column => column.NumberOfRegion),
                _ => obj
            };
            return result;
        }
    }
}
