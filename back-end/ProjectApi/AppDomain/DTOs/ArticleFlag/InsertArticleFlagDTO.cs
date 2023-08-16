using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDomain.DTOs.ArticleFlag
{
    public class InsertArticleFlagDTO
    {
        public string Title { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public string IconLink { get; set; } = String.Empty;
        public string AccentColor { get; set; } = String.Empty;
    }
}
