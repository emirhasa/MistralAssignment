using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;
using ViewModels.Requests;

namespace MistralAssignment.Services
{
    public interface IRatingsService
    {
        Task InsertAsync(RatingInsertRequestVM insertRequest);
    }
}
