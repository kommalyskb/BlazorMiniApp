using BlazorMiniApp.Shared.DTOs;
using BlazorMiniApp.Shared.Entities;
using BlazorMiniApp.Shared.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using MyCouch;
using MyCouch.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMiniApp.Server.Helpers
{
    public class MovieRepository: IMovie
    {
        private string host = "http://admin:1qaz2wsx@127.0.0.1:5984";
        private string db = "movie";
        // Get by ID
        public async Task<Movie> Get(string id)
        {
            using (var client = new MyCouchClient(host, db))
            {
                // Get by ID
                var result = await client.Entities.GetAsync<Movie>(id);

                // return Movie content
                return result.Content;
            }
        }
        // Insert by entity
        public async Task<bool> Insert(Movie movie)
        {
            using (var client = new MyCouchClient(host, db))
            {
                // Post new document
                var result = await client.Entities.PostAsync(movie);

                return result.IsSuccess;
            }
        }
        // Update by entity
        public async Task<bool> Update(MovieDto movie)
        {
            using (var client = new MyCouchClient(host, db))
            {
                // Update a document
                var result = await client.Entities.PutAsync(movie);

                return result.IsSuccess;
            }
        }
        // Delete by id
        public async  Task<bool> Delete(string id, string rev)
        {
            using (var client = new MyCouchClient(host, db))
            {
                // Delete a document
                var result = await client.Documents.DeleteAsync(id, rev);

                return result.IsSuccess;
            }
        }
        // List all
        public async Task<GetMovies> GetList()
        {
            using (var client = new MyCouchClient(host, db))
            {
                // View
                var req = new QueryViewRequest("search", "all");

                var result = await client.Views.QueryAsync<Movie>(req);
                
                var movies = result.Rows.Select
                    (
                        x => new Movie(x.Id, x.Value.Title,
                        x.Value.Summary, x.Value.InTheaters,
                        x.Value.Trailer, x.Value.ReleaseDate,
                        x.Value.Poster)
                    ).ToList();

                return new GetMovies(result.IsSuccess, result.RowCount, movies);
            }
        }
    }
}
