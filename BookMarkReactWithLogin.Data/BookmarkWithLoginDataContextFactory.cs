using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMarkReactWithLogin.Data;

public class BookmarkWithLoginDataContextFactory : IDesignTimeDbContextFactory<BookmarkWithLoginDataContext>
{
    public BookmarkWithLoginDataContext CreateDbContext(string[] args)
    {
        var config = new ConfigurationBuilder()
           .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), 
           $"..{Path.DirectorySeparatorChar}BookMarkReactWithLogin.Web"))
           .AddJsonFile("appsettings.json")
           .AddJsonFile("appsettings.local.json", optional: true, reloadOnChange: true).Build();

        return new BookmarkWithLoginDataContext(config.GetConnectionString("ConStr"));
    }
}