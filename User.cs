using System;
using System.Collections.Generic;

namespace Stitch_BackEnd
{
    public class User
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public IEnumerable<int> Projects { get; set; }
    }
}
