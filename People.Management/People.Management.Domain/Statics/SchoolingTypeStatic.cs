using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace People.Management.Domain.Statics
{
    public class SchoolingTypeStatic
    {
        /// <summary>
        /// Object instance.
        /// </summary>
        public SchoolingTypeStatic(Guid id, string name) 
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; } 

        public static SchoolingTypeStatic Kindergarten = new SchoolingTypeStatic(Guid.Parse("25ea9187-4a1f-4b9f-b5a8-7aec8dc0f839"), "Infantil");
        public static SchoolingTypeStatic ElementarySchool = new SchoolingTypeStatic(Guid.Parse("8a2d312d-e804-4f51-934a-fc5634c1940a"), "Fundamental"); 
        public static SchoolingTypeStatic HighSchool = new SchoolingTypeStatic(Guid.Parse("0850abfa-209e-4c0e-b83f-34e62e492a89"), "Médio"); 
        public static SchoolingTypeStatic University = new SchoolingTypeStatic(Guid.Parse("f67a3dac-3365-4994-abb8-5a9059c4e58f"), "Superior"); 

        public static List<SchoolingTypeStatic> GetAll()
        {
            return new List<SchoolingTypeStatic>()
            {
                Kindergarten,
                ElementarySchool,
                HighSchool,
                University
            };
        }

        public static SchoolingTypeStatic GetById(Guid id) 
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }

        public static SchoolingTypeStatic[] DataArray()
        {
            return GetAll().Select(x => new SchoolingTypeStatic(x.Id, x.Name)).ToArray(); 
        }
    }
}
