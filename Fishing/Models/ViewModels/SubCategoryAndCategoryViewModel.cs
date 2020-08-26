using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fishing.Models.ViewModels
{
    public class SubCategoryAndCategoryViewModel
    {
        public IEnumerable<Category> categoryList { get; set; }
        public SubCategory SubCategory { get; set; }
        public List<string> SubCategoryList { get; set; }
        public string StatusMessage { get; set; }

    }
}
