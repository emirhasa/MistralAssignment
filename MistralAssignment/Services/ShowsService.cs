using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MistralAssignment.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ViewModels;
using ViewModels.Requests;

namespace MistralAssignment.Services
{
    public class ShowsService : IShowsService
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public ShowsService(IMapper mapper, ApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<List<ShowVM>> GetAsync(ShowSearchRequestVM searchParams)
        {
            var query = _context.Shows.AsQueryable();

            if(searchParams.ShowTypeId != null)
                query = query.Where(show => show.ShowTypeId == searchParams.ShowTypeId);

            if (!string.IsNullOrWhiteSpace(searchParams.SearchString))
            {
                //checks if the search string matches "X stars" where X is a number from 1 to 5
                if (Regex.IsMatch(searchParams.SearchString, "^[1-5] stars$"))
                {
                    //if it matches the format in the above comment extract the integer value 
                    var extractedStarRating = int.Parse(Regex.Match(searchParams.SearchString, @"\d+").Value);

                    //extract the integer part of the average rating and match shows with the extracted star rating
                    query = query.Where(show => Math.Truncate(show.AverageRating) == extractedStarRating);
                }

                //check if the search string matches "at least X stars" where X is a number from 1 to 5
                //you could make a case for or against excluding 1 because all movies with a rating are at least 1 avg rating
                else if (Regex.IsMatch(searchParams.SearchString, "^at least [1-5] stars$"))
                {
                    var extractedStarRating = int.Parse(Regex.Match(searchParams.SearchString, @"\d+").Value);

                    query = query.Where(show => show.AverageRating >= extractedStarRating);
                }

                //check if search string matches "after X" where X is a year from 1900 to 2020
                else if (Regex.IsMatch(searchParams.SearchString, "^after (?:19\\d\\d|20[01]\\d|2020)$"))
                {
                    var extractedYear = int.Parse(Regex.Match(searchParams.SearchString, @"\d+").Value);

                    query = query.Where(show => show.ReleaseDate.Year > extractedYear);
                }

                //check if search string matches "older than X years" where X is a number from 1 to 120
                else if (Regex.IsMatch(searchParams.SearchString, "^older than (?:[1-9]|[1-9]\\d|1[01]\\d|120) years$")) {
                    var extractedYears = int.Parse(Regex.Match(searchParams.SearchString, @"\d+").Value);

                    query = query.Where(show => (DateTime.Now.Year - show.ReleaseDate.Year) > extractedYears);
                }

                else
                {
                    query = query.Where(show => show.Title.Contains(searchParams.SearchString) || show.Description.Contains(searchParams.SearchString));
                }
            }

            return _mapper.Map<List<ShowVM>>(
                    await query.Include(show => show.Cast)
                    .ThenInclude(showActor => showActor.Actor)
                    .OrderByDescending(show => show.AverageRating)
                    .Skip(searchParams.Skip)
                    .Take(searchParams.Take)
                    .ToListAsync()
                );
        }

        public async Task<ShowVM> GetByIdAsync(long showId)
        {
            return _mapper.Map<ShowVM>(await _context.Shows.FindAsync(showId));
        }
    }
}
