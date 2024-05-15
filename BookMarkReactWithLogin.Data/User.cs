using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BookMarkReactWithLogin.Data
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        [JsonIgnore]
        public List<UsersBookmarks> UsersBookmarks { get; set; }
        public string PasswordHash { get; set; }
    }
}
