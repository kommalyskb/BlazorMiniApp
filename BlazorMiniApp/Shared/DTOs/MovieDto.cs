using BlazorMiniApp.Shared.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorMiniApp.Shared.DTOs
{
    public class MovieDto
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("_rev")]
        public string Rev { get; set; }

        [JsonProperty("title")]
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
    }
}
