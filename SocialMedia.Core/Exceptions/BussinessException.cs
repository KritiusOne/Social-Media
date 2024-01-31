using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Exceptions
{
    public class BussinessException : Exception
    {
        public BussinessException()
        {
            
        }
        public BussinessException(string msg) : base(msg)
        {

            
        }
    }
}
