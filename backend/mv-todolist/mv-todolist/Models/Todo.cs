using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MV_to_do_list.Models
{
    public class Todo
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool Status { get; set; } // false = pendente, true = concluída
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}