using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppNotasMaui.Models;

namespace AppNotasMaui.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions <DataContext> options) : base(options)
        {
        }

        public DbSet<Nota> Notas { get; set; }
    }
}
