using CalisthenicsRoutineTracker.Data;
using CalisthenicsRoutineTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading;


namespace CalisthenicsRoutineTracker.Controllers
{
    public class WorkoutController : Controller
    {
    private readonly ApplicationDbContext _db;

        public WorkoutController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index(string date)
        {
            var ControllerToViewCarrier = new Carrier();
            if (!string.IsNullOrEmpty(date))
            {
                ControllerToViewCarrier.carrier_workouts = _db.Workouts.Where(w=>w.DateId == int.Parse(date));
                ControllerToViewCarrier.currentDate = _db.date.Find(int.Parse(date)).date.ToString();
            }
            else
            {
                ControllerToViewCarrier.currentDate = "AllDate";
            }

            ControllerToViewCarrier.carrier_date = _db.date;
           
            return View(ControllerToViewCarrier);
        }
    }
}
