using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class match
    {
        [Key]
        public int Id { get; set; }
        public int homeTeamId { get; set; }
        public int guestTeamId { get; set; }
        public DateTime Date { get; set; }
        public string Stadium { get; set; }
        public team guestTeam { get; set; }
        public team homeTeam { get; set; }
    }
}
