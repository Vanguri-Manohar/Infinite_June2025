using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MVC_CC9.Models;
using MVC_CC9.Repository;

namespace MVC_CC9.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieRepository _repository;

        public MovieController()
        {
            _repository = new MovieRepository();
        }

        public ActionResult Index()
        {
            var movies = _repository.GetAll();
            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var movie = _repository.GetById(id);
            return View(movie);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(movie);
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        public ActionResult Edit(int id)
        {
            var movie = _repository.GetById(id);
            return View(movie);
        }

        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(movie);
                return RedirectToAction("Index");
            }
            return View(movie);
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            var movie = _repository.GetById(id);
            return View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Movie movie)
        {
            _repository.Delete(movie.MovieId);
            return RedirectToAction("Index");
        }




    }
}
