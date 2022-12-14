using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Stango.Shared.Models
{
    public class Developer
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
