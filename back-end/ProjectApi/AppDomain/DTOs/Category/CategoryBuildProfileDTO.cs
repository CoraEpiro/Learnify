using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDomain.DTOs.Category;

public class CategoryBuildProfileDTO
{
    public string Id { get; set; } = String.Empty;
    public string Title { get; set; } = String.Empty;
    public int UseCount { get; set; }
}
