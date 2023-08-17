using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tasks.Commands.Update.UpdateCategory
{
    public class IncrementCategoryUseCountCommand : IRequest<int>
    {
        public List<string> CategoryIdList { get; set; }
    }
}
