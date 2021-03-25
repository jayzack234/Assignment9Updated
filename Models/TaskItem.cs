using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment9Updated.Models
{
    //Properties for each of the properties in the movie submission requirements
    public class TaskItem
    {
        //Primary Key
        [Key]
        [Required]
        public int MovieId { get; set; }
        //Below we will make the first 5 inputs required, and the last three optional. 
        //Note that lent will have a max character limit
        [Required]
        public string Category { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Rating { get; set; }
        public string Edited { get; set; }
        public string Lent { get; set; }
        [MaxLength(25)]
        public string Notes { get; set; }
    }
}
