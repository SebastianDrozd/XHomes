using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using XHomes.Models;

namespace XHomes.Data
{
    public class FileContext: DbContext
    {
        public DbSet<File> Files { get; set; }

        public FileContext(DbContextOptions<FileContext> opt) : base(opt)
        {

        }
    }
}
