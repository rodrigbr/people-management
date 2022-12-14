using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace People.Management.Domain.ValueObjects
{
    public class AdressInformation
    {
        public string Adress { get; private set; }
        public string City { get; private set; }
        public string Country { get; private set; }
        public int? Number { get; private set; }
        public string Uf { get; private set; }
        public string ZipCode { get; private set; }

        public AdressInformation(string adress, string city, string country, int? number, string uf, string zipCode)
        {
            Adress = adress;
            City = city;
            Country = country;
            Number = number;
            Uf = uf;
            ZipCode = zipCode;
        }
    }
}
