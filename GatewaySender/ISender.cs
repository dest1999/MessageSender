using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GatewaySender
{
    public interface ISender
    {
        bool Send(string to, string message);
    }
}
