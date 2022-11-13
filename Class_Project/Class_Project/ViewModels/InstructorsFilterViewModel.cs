// ViewModels stay in the view only; doesn't go to the database
// Created the ViewModel when adding the filter/search bar to the Index page

using Class_Project.Models;

namespace Class_Project.ViewModels
{
    public class InstructorsFilterViewModel
    {
        public string FilterVM { get; set; }
        public IEnumerable<Instructor> InstructorsListVM { get; set; }
    }
}
