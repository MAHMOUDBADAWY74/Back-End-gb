using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrary.Service.HandleResponse
{
    public class ValidationErrorResopnse : UserException
    {
        public ValidationErrorResopnse() : base(400)
        {

        }
        public IEnumerable<string> Errors { get; set; }
    }
}

