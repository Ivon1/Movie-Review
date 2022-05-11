using Movie_Review.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Movie_Review.ViewModels
{
    public class FilterViewModel
    {
        public IEnumerable<Film> Films { get; set; }
        public SelectList Janres { get; set; }
        public SelectList Producers { get; set; }
        public PageViewModel PageViewModel { get; set; }  
    }
}
