using CalisthenicsRoutineTracker.Data;
using CalisthenicsRoutineTracker.Models;
using Microsoft.AspNetCore.Mvc;


namespace CalisthenicsRoutineTracker.Controllers
{
    public class WorkoutController : Controller
    {
    private readonly ApplicationDbContext _db;

        public WorkoutController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var ControllerToViewCarrier = new Carrier();

            IEnumerable<Workout> workouts = _db.Workouts;
            IEnumerable<Date> date = _db.date;
            ControllerToViewCarrier.carrier_date = date;
            ControllerToViewCarrier.carrier_workouts = workouts;
            
            return View(ControllerToViewCarrier);
        }
    }
}
