using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDomain.DTOs.Category
{
    public class UpdateCategoryDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int UseCount { get; set; } = 0;
        public string IconLink { get; set; }
        public string AccentColor { get; set; }
    }
}
