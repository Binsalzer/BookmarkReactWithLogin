using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;

namespace BookMarkReactWithLogin.Data
{
    public class BookmarksRepository
    {
        private readonly string _connection;

        public BookmarksRepository(string connection)
        {
            _connection = connection;
        }

        private int Add(int userId, Bookmark bookmark)
        {
            using var context = new BookmarkWithLoginDataContext(_connection);

            var check = context.Bookmarks.FirstOrDefault(b => b.URL == bookmark.URL);
            if (check != null)
            {
                return check.Id;
            }

            context.Bookmarks.Add(bookmark);
            context.SaveChanges();
            return bookmark.Id;

        }

        public void AddBookmark(int userId, Bookmark bookmark)
        {
            int bookmarkId = Add(userId, bookmark);
            using var context = new BookmarkWithLoginDataContext(_connection);
            var check = context.UsersBookmarks.Where(ub => ub.UserId == userId).FirstOrDefault(ub => ub.BookmarkId == bookmarkId);

            if (check != null)
            {
                return;
            }

            context.UsersBookmarks.Add(new UsersBookmarks { UserId = userId, BookmarkId = bookmarkId });
            context.SaveChanges();
        }

        public Bookmark GetBookmarkById(int id)
        {
            using var context = new BookmarkWithLoginDataContext(_connection);
            return context.Bookmarks.FirstOrDefault(bm => bm.Id == id);
        }

        public List<BookmarkCounter> GetTop5()
        {
            using var context = new BookmarkWithLoginDataContext(_connection);
            var UBList = context.UsersBookmarks.ToList();

            Dictionary<int, BookmarkCounter> BDic = new();

             //setting the dictionary to one instance of each bookmarkId with bookmarkId as key and ammount of userIds for that BookMarkId as value

            foreach(UsersBookmarks ub in UBList)
            {
                if(BDic.ContainsKey(ub.BookmarkId))
                {
                    BDic[ub.BookmarkId].UserCount++;
                }
                else
                {
                    BDic.Add(ub.BookmarkId, new BookmarkCounter { BookmarkId = ub.BookmarkId, UserCount = 1 });
                }
            }

            //turning the dictionary back into a sorted list and then returning the first 5 elements (or total ammount if list is shorter than 5)

            var CondensedSortedUBList = BDic.Select(kp => kp.Value).OrderByDescending(bmc => bmc.UserCount).ToList();
            foreach (BookmarkCounter c in CondensedSortedUBList)
            {
                c.Bookmark = GetBookmarkById(c.BookmarkId);
            }

            int amnt = 5;
            if (CondensedSortedUBList.Count() < 5)
            {
                amnt = CondensedSortedUBList.Count();
            }

            return CondensedSortedUBList.Take(amnt).ToList();
        }

    }
}
