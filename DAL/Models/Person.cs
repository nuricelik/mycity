using System;
using System.Collections.Generic;
using GeoAPI.Geometries;

namespace mycity.DAL.Models
{
    public partial class Person
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string Tel { get; set; }
        public string Department { get; set; }
        public string Lname { get; set; }
        public IGeometry Location { get; set; }
    }
}
