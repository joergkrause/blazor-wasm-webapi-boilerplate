using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop.Blazor.DomainModels
{
    public class Event : EntityBase
    {
        [Required, StringLength(80)]
        public string Name { get; set; } = String.Empty;

        [StringLength(1024)]
        public string? Description { get; set; }

        [Column(TypeName = "date")]
        public DateTime Begin { get; set; }

        [Column(TypeName = "date")]
        public DateTime End { get; set; }

        //[Column(TypeName = "datetime2")]
        //public DateTime? StartTime { get; set; }

        public int Hour { get; set; }
        public int Minute { get; set; }

        [NotMapped]
        public DateTime StartTime
        {
            get {
                return new DateTime(Begin.Year, Begin.Month, Begin.Day, Hour, Minute, 0);
            }
            set {
                Hour = value.Hour;
                Minute = value.Minute;
            }
        }

        public ICollection<Seat> Seats { get; set; } = new HashSet<Seat>(); // null ? event123.Seats.Count == 0

    }
}
