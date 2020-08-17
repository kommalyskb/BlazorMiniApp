using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlazorMiniApp.Shared.Entities
{
    public class Movie
    {
        public Movie(string id, string title, string summary, bool intheaters,
            string trailer, DateTime? release, string poster)
        {
            Id = id;
            Title = title;
            Summary = summary;
            InTheaters = intheaters;
            Trailer = trailer;
            ReleaseDate = release;
            Poster = poster;
        }
        public Movie()
        {

        }
        [JsonIgnore]
        public string Id { get; set; }

        [JsonProperty("title")]
        [Required(ErrorMessage = "Could not empty")]
        public string Title { get; set; }

        [JsonProperty("summary")]
        public string Summary { get; set; }

        [JsonProperty("intheaters")]
        public bool InTheaters { get; set; }

        [JsonProperty("trailer")]
        public string Trailer { get; set; }

        [JsonProperty("release")]
        public DateTime? ReleaseDate { get; set; }

        [JsonProperty("poster")]
        public string Poster { get; set; }

        [JsonIgnore]
        public string TitleBrief
        {
            get
            {
                if (string.IsNullOrEmpty(Title))
                {
                    return null;
                }

                if (Title.Length > 60)
                {
                    return Title.Substring(0, 60) + "...";
                }
                else
                {
                    return Title;
                }
            }
        }
    }
}
