using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalLayerVet
{
    public class VetDbContext:DbContext
    {
        public VetDbContext():base("name=DefaultConnection")
        {

        }
        public DbSet<Doctor> Doctors { get; set; }
    }
}
