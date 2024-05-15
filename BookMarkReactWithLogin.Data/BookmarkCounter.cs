using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMarkReactWithLogin.Data
{
    public class BookmarkCounter
    {
        public int BookmarkId { get; set; }
        public int UserCount { get; set; }
        public Bookmark Bookmark { get; set; }
    }
}
