using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ServiceStack.Redis;

namespace Lab9
{
    class Player
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Team { get; set; }

        public string FullName => $"{FirstName?.Trim()} {LastName?.Trim()} {Team?.Trim()} #{Id}";
    }
}
