using BlazorMiniApp.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorMiniApp.Shared.DTOs
{
    public class GetMovies
    {
        public GetMovies(bool success, long count, List<Movie> movies)
        {
            IsSuccess = success;
            Count = count;
            Movies = movies;
        }
        public GetMovies()
        {

        }

        public bool IsSuccess { get; set; }
        public long Count { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
