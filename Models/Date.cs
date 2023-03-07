using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CalisthenicsRoutineTracker.Models
{
    public class Date
    {
        
        [Key]
        public int DateId { get; set; }


        public DateTime date { get; set; } = DateTime.Now.Date;
    }

}