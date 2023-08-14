using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDomain.DTOs.Category;

public class InsertCategoryDTO
{
    public string Title { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;
    public int UseCount { get; set; } = 0;
    public string IconLink { get; set; } = String.Empty;
    public string AccentColor { get; set; } = String.Empty;
}
