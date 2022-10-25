using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.CQRS.ReadApi.Activator.SeedWorks.Models
{
    public class ResponseContentModel : ResponseModel
    {
        public object Content { get; set; }
    }
}
