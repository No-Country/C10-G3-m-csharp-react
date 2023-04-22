using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class AccessibilityNotFoundException : NotFoundException
    {
        public AccessibilityNotFoundException(Guid id) : base($"Accessibility with id {id} was not found.")
        {
        }
    }
}
