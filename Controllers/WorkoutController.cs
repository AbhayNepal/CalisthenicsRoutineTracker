using CalisthenicsRoutineTracker.Data;
using CalisthenicsRoutineTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using System.Threading;
using static System.Runtime.InteropServices.JavaScript.JSType;


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
                ControllerToViewCarrier.carrier_workouts = _db.Workouts.Where(w => w.DateId == int.Parse(date));
                ControllerToViewCarrier.currentDate = _db.date.Find(int.Parse(date)).date.ToString();
            }
            else
            {
                ControllerToViewCarrier.currentDate = "AllDate";
            }

            ControllerToViewCarrier.carrier_date = _db.date;

            return View(ControllerToViewCarrier);
        }
        //Get
        public IActionResult AddWorkout()
        {
            var carrytoView = new Carrier();
            carrytoView.carrier_date = _db.date;


            return View(carrytoView);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddWorkout(Carrier newWorkout)
        {

            if (newWorkout.date_view != null)
            {
                if (!_db.date.Any(d => d.date == newWorkout.date_view.date))
                {
                    _db.date.Add(newWorkout.date_view);
                    _db.SaveChanges();
                }

            }

            if (newWorkout.workout_view != null)
            {
                if (!_db.date.Any(d => d.date == newWorkout.date_view.date))
                {
                    newWorkout.workout_view.DateId = (_db.date.OrderByDescending(x => x.DateId).First().DateId);
                    _db.Workouts.Add(newWorkout.workout_view);
                }
                else
                {
                    newWorkout.workout_view.DateId = _db.date.Where(d => d.date == newWorkout.date_view.date).FirstOrDefault().DateId;
                    _db.Workouts.Add(newWorkout.workout_view);
                }


            }
            _db.SaveChanges();
            return RedirectToAction("Index");


        }
        //Get
        public IActionResult Edit(int? id)
        {
            Carrier workoutToUpdate = new Carrier();
           if(id == null || id ==0)
            {
                return NotFound();
            }
            workoutToUpdate.workout_view = _db.Workouts.Find(id);
            workoutToUpdate.date_view = _db.date.Find(workoutToUpdate.workout_view.DateId);

            if(workoutToUpdate == null)
            {
                return NotFound();
            }


            return View(workoutToUpdate);
        }


    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Carrier newWorkout)
        {
            if (newWorkout.workout_view != null)
            {
                 _db.Workouts.Update(newWorkout.workout_view);
            }
            _db.SaveChanges();
            return RedirectToAction("Index");


        }
        //Get
        public IActionResult Delete(int? id)
        {
            Carrier workoutToDelete = new Carrier();
            if (id == null || id == 0)
            {
                return NotFound();
            }
            workoutToDelete.workout_view = _db.Workouts.Find(id);
            workoutToDelete.date_view = _db.date.Where(d=> d.DateId == workoutToDelete.workout_view.DateId).First();

            if (workoutToDelete == null)
            {
                return NotFound();
            }


            return View(workoutToDelete);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Carrier newWorkout)
        {
            if (newWorkout.workout_view != null)
            {
                _db.Workouts.Remove(newWorkout.workout_view);
            }
            _db.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}

//todo - Everything is fine, jst you need to find a way to save the date first such that dateid is present in the date table, before adding
//data to the workout table.