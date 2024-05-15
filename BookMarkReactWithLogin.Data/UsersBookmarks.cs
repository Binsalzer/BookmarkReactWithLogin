using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BookMarkReactWithLogin.Data
{
    public class UsersBookmarks
    {
        public int UserId { get; set; }
        public int BookmarkId { get; set; }

        [JsonIgnore]
        public User User { get; set; }
        public Bookmark Bokmark { get; set; }
    }
}
