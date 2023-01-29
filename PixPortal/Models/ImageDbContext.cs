using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PixPortal.Models
{
    public class ImageDbContext : IdentityDbContext<IdentityUser>
    {
        public ImageDbContext(DbContextOptions<ImageDbContext> options) : base(options)
        { }
        public DbSet<Image> Images { get; set; }

    }
}
