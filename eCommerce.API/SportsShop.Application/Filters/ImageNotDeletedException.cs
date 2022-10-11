using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsShop.Application.Filters
{
    public class ImageNotDeletedException : Exception
    {
        public ImageNotDeletedException(string message) : base(message)
        {
        }
    }
}
