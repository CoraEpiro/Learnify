using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tasks.Commands.Delete.DeleteCategory
{
    public class DeleteCategoryCommand : IRequest<string>
    {
        public string CategoryId { get; set; }
    }
}
