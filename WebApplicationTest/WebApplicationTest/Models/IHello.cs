using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationTest.Models
{
    public interface IHello
    {
        string Hello { get; set; }

        string SayHello();
    }
}
