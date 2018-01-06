using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSO.StimmApp.Core.Maps
{
    public class PlacesException : Exception
    {
        public PlacesException()
        {

        }

        public PlacesException(string message)
            : base(message)
        {

        }

        public PlacesException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
