using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tasks.Commands.Update.UpdateCategory
{
    public class UpdateCategoryUseCountCommand : IRequest<int>
    {
        public string CategoryId { get; set; }
    }
}
