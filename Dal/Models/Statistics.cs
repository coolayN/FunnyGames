using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Models
{
    public class Statistics
    {
        [Key]
        [ForeignKey("Player")]
        public int Id { get; set; }
        public virtual Player Player { get; set; }

        public int LoseGames { get; set; }
        public int WinGames { get; set; }
    }
}
