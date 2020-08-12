using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlazorMiniApp.Shared.Entities
{
    public class Actor
    {
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Biography { get; set; }
        public string Picture { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
