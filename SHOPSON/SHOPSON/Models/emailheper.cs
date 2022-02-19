using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHOPSON.Models
{
    public interface emailheper
    {
         void Send(string email, string subject, string body, List<string> cc);
    }
}
