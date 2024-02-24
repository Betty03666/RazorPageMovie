﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPageMovie.Data;
using RazorPageMovie.Models;

namespace RazorPageMovie.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly RazorPageMovie.Data.RazorPageMovieContext _context;

        public IndexModel(RazorPageMovie.Data.RazorPageMovieContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; } = default!;
        [BindProperty(SupportsGet =true)]
        public string? SearchString { get; set; }
        public SelectList? General { get; set; }
        [BindProperty(SupportsGet =true)]

        public string? MovieGenre { get; set; }

        public async Task OnGetAsync()
        {

            //Movie = await _context.Movie.ToListAsync();
            IQueryable<string> genreQuery = from m in _context.Movie
                                            orderby m.General
                                            select m.General;

            var movies = from m in _context.Movie 
                         select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(s => s.Title.Contains(SearchString));
            }
            if(!string.IsNullOrEmpty(MovieGenre))
            {
                movies = movies.Where(x => x.General == MovieGenre);
            }

            if(_context.Movie != null)
            {
                General = new SelectList(await genreQuery.Distinct().ToListAsync());
                Movie = await movies.ToListAsync();
            }
            
                         
        }
    }
}