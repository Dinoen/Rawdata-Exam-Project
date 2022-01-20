using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Npgsql;
using Raw5MovieDb_WebApi.Services;
using Microsoft.EntityFrameworkCore;
using Raw5MovieDb_WebApi.Model;

namespace Raw5MovieDb_WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
                        


            var ds = new DataService();
            var ctx = new MovieDbContext();

            // var user = ctx.userAccounts.Find("2");
            // System.Console.WriteLine(ctx.userAccounts.Find("2"));
            // user.Uconst = user.Uconst.Trim();
            // System.Console.WriteLine(user.Uconst.Count());
            // ctx.userAccounts.Remove(user);
            // ctx.SaveChanges();

        


            // var input = "tt10850402";
            // var ds = new DataService();
            // var findsimilarsearch = ds.FindSimilarSearch(input);
            // Console.WriteLine("best match:");
            // foreach (var Title in findsimilarsearch)
            // {
            //     Console.WriteLine(Title.Primarytitle);
            // }



            /*string[] input = {"apple"};
            var ds = new DataService();
            var exactmatch = ds.ExactMatchDynamicSearch(input);
            Console.WriteLine("best match:");
            foreach (var Title in exactmatch)
            {
                Console.WriteLine(Title.Primarytitle);
            }*/


            /* var input1 = "a";
             var input2 = "b";
             var input3 = "c";
             var ds = new DataService();
             var bestmatch = ds.BestMatchFunction(input1, input2, input3);
             Console.WriteLine("best match:");
             foreach (var Title in bestmatch)
             {
                 Console.WriteLine(Title.Primarytitle);
             }*/

            /*
             ATTEMPT TO MAKE GETALLBOOKMARKSBYUSER TO WORK, NOT DONE
            var input = "1";
            var ds = new DataService();
            var titlebookmarks = ds.GetAllBookmarksByUser(input);
            Console.WriteLine("best match:");
            foreach (var BookmarkTitle in titlebookmarks)
            {
                Console.WriteLine(BookmarkTitle.Tconst, BookmarkTitle.Uconst);
            }*/

            /*
            var ds = new DataService();
            var userratings = ds.GetAllUserRatings();
            Console.WriteLine("User ratings:");
            foreach (var userrating in userratings)
            {
                Console.WriteLine(userrating.Uconst);
            }*/
            /*
            var input = "tt10850402";
            var ds = new DataService();
            var titles = ds.GetPopularActorsRankedByTitles(input);
            Console.WriteLine("popular actors: ");
            foreach (var title in titles)
            {
                Console.WriteLine(title.Originaltitle);
            }*/

            /*
            var searchparams = "apple";
            var useridinput = "1";
            var ds = new DataService();
            var titles = ds.StringSearch(searchparams,useridinput);
            Console.WriteLine("popular actors: ");
            foreach (var title in titles)
            {
                Console.WriteLine(title.Originaltitle);
            }*/


            /*var input = "apple";
            var ds = new DataService();
            var actors = ds.StructuredNameSearch(input);
            Console.WriteLine("actors: ");
            foreach (var actor in actors)
            {
                Console.WriteLine(actor.Primaryname);
            }*/


            /* var input1 = "a";
             var input2 = "b";
             var input3 = "c";
             var input4 = "d";
             var input5 = "1";
             var ds = new DataService();
             var titles = ds.StructuredStringSearch(input1, input2, input3, input4, input5);
             Console.WriteLine("actors: ");
             foreach (var title in titles)
             {
                 Console.WriteLine(title.Primarytitle);
             }*/


            /*string[] input = { "apple" };
            var ds = new DataService();
            var titles = ds.WordToWord(input);
            Console.WriteLine("best match:");
            foreach (var title in titles)
            {
                Console.WriteLine(title.Primarytitle);
            }*/



            CreateHostBuilder(args).Build().Run();

            IHostBuilder CreateHostBuilder(string[] args) =>
                Host.CreateDefaultBuilder(args)
                    .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });




        }


    }
}
