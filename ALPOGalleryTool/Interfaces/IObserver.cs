using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALPOGalleryTool.Interfaces
{
    public interface IObserver
    {
        string City { get; set; }
        string Country { get; set; }
        string Email { get; set; }
        string EmailName { get; set; }
        string FirstName { get; set; }
        string Initials { get; set; }
        string LastName { get; set; }
        string Region { get; set; }
    }
}
