using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AppNotasMaui.Models
{
    public class Nota
    {
        public required int Id { get; set; }
        public required string Title { get; set; }
        public string? Content { get; set; }
        public required DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public required bool IsFavorite { get; set; } = false;
    }
}
