using System;

namespace SportsStore.WebUI.Models {

    //A view model is not part of our domain model, it is just a convenient class for passing data between controller and view
    public class PagingInfo {

        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }

        public int TotalPages {
            get { return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage); }
        }
    }
}