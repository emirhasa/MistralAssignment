using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MistralAssignment.Database;
using MistralAssignment.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ViewModels;
using ViewModels.Requests;

namespace MistralAssignment.Services
{
    public class RatingsService : IRatingsService
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public RatingsService(IMapper mapper, ApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task InsertAsync(RatingInsertRequestVM insertRequest)
        {
            try
            {
                var newRating = _mapper.Map<Rating>(insertRequest);

                await _context.Ratings.AddAsync(newRating);

                var showDb = await _context.Shows.Include(show => show.Ratings).FirstAsync(show => show.ShowId == insertRequest.ShowId);
                showDb.AverageRating = showDb.Ratings.Select(rating => (decimal)rating.Grade).Average();

                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw new UserException("Error adding rating. " + ex.Message);
            }
        }
    }
}
