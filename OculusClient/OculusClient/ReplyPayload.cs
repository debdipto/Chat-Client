using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmaranthineServer
{
    public class ReplyPayload<T>
    {
        public String source;

        public T[] reply;

        public Int16 status;
        
    }
}
