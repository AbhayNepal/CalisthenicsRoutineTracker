namespace CalisthenicsRoutineTracker.Models
{
    public class Carrier
    {
        public IEnumerable<Workout> carrier_workouts { get; set; }
        public IEnumerable<Date> carrier_date { get; set; }

        public Workout workout_view { get; set; }
        public Date date_view { get; set; }
        public string currentDate { get; set; }
        public int incDateId { get; set; }
        public Date dateTypeDate { get; set; }
    }
}
