using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Channel_A_Doctor.BusinessLayer;

namespace Channel_A_Doctor_MVC_App.Models
{
    //Responsible for connecting and mapping models to Database using Entity framework.
    public class Channel_A_Doctor_MVC_DatabaseContext : DbContext
    {
        public Channel_A_Doctor_MVC_DatabaseContext (DbContextOptions<Channel_A_Doctor_MVC_DatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<Channel_A_Doctor.BusinessLayer.Appointment> Appointment { get; set; }

        public DbSet<Channel_A_Doctor.BusinessLayer.Doctor> Doctor { get; set; }

        public DbSet<Channel_A_Doctor.BusinessLayer.MedicalCentre> MedicalCentre { get; set; }

        public DbSet<Channel_A_Doctor.BusinessLayer.Patient> Patient { get; set; }
    }
}
