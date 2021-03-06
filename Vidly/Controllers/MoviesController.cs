﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
       
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context=new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
       
        public ViewResult Index()
        {
            if (User.IsInRole(RoleName.CanManageMovies))

                return View("List");
            
                return View("ReadOnlyList");
        }
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var genre = _context.Genres.ToList();
            var viewModel=new MovieFormViewModel
            {
                Genres = genre
            };
            return View("MovieForm",viewModel);
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id ==id);
            if (movie==null)
            
                HttpNotFound();
            

            var viewModel = new MovieFormViewModel(movie)
            {
                
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm",viewModel);
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == id);
            if (movie==null)
            
                HttpNotFound();
            

            return View(movie);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Svae(Movie movie)
        {
            if (!ModelState.IsValid)
            {
               var viewModel=new MovieFormViewModel(movie)
               {
                   Genres = _context.Genres.ToList()
               };
                return View("MovieForm", viewModel);
            }
            if (movie.Id==0)
            {
                movie.DateAdded=DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id ==movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.Genre = movie.Genre;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;

            }
            _context.SaveChanges();
            return RedirectToAction("Index","Movies");
        }
        


    }
}