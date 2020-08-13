using BlazorMiniApp.Shared.DTOs;
using BlazorMiniApp.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorMiniApp.Shared.Repositories
{
    public interface IMovie
    {
        Task<bool> Delete(string id, string rev);
        Task<Movie> Get(string id);
        Task<GetMovies> GetList();
        Task<bool> Insert(Movie movie);
        Task<bool> Update(MovieDto movie);
    }
}
