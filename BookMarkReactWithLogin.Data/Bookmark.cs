using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BookMarkReactWithLogin.Data
{
    public class Bookmark
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string URL { get; set; }

        [JsonIgnore]
        public List<UsersBookmarks> UsersBookmarks { get; set; }
    }
}
