using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ButtonManufacture.Models;

namespace ButtonManufacture.Data
{
    public class ButtonManufactureContext : IdentityDbContext
    {
        public ButtonManufactureContext(DbContextOptions<ButtonManufactureContext> options)
            : base(options)
        {
        }
        public DbSet<ButtonManufacture.Models.Button> Button { get; set; }
    }
}
