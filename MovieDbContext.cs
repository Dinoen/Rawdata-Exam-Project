using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Raw5MovieDb_WebApi.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Text;

namespace Raw5MovieDb_WebApi.Services
{
    public class MovieDbContext : DbContext
    {
        public DbSet<Actor> actors { get; set; }
        //public DbSet<AppSettings> appSettings { get; set; }
        public DbSet<BookmarkActor> bookmarkActors { get; set; }
        public DbSet<BookmarkTitle> bookmarkTitles { get; set; }
        public DbSet<Genre> genres { get; set; }
        public DbSet<OmdbData> omdbData { get; set; }
        public DbSet<Title> titles { get; set; }
        public DbSet<TitleAkas> titleAkas { get; set; }
        public DbSet<TitleCrew> titleCrews { get; set; }
        public DbSet<TitleEpisode> titleEpisodes { get; set; }
        public DbSet<TitlePrincipals> titlePrincipals { get; set; }
        public DbSet<TitleRating>  titleRatings { get; set; }
        public DbSet<UserAccount> userAccounts { get; set; }
        public DbSet<UserRating> userRatings { get; set; }
        public DbSet<UserSearchHistory> userSearchHistories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);

            //optionsBuilder.UseNpgsql("host=rawdata.ruc.dk;db=raw5;uid=raw5;pwd=I4YpESyL");
            optionsBuilder.UseNpgsql("host=localhost;db=imdb_small2;uid=postgres;pwd=Palle0410");

            //optionsBuilder.EnableSensitiveDataLogging();

        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Actor>().ToTable("name_basics");
            modelBuilder.Entity<Actor>().Property(x => x.Nconst).HasColumnName("nconst");
            modelBuilder.Entity<Actor>().Property(x => x.Primaryname).HasColumnName("primaryname");
            modelBuilder.Entity<Actor>().Property(x => x.Birthyear).HasColumnName("birthyear");
            modelBuilder.Entity<Actor>().Property(x => x.Deathyear).HasColumnName("deathyear");
            modelBuilder.Entity<Actor>().Property(x => x.Primaryprofession).HasColumnName("primaryprofession");
            modelBuilder.Entity<Actor>().Property(x => x.Knownfortitles).HasColumnName("knownfortitles");
            modelBuilder.Entity<Actor>().Property(x => x.Namerating).HasColumnName("namerating");



            modelBuilder.Entity<BookmarkActor>().ToTable("bookmark_actor").HasKey(c => new { c.Nconst, c.Uconst });
            modelBuilder.Entity<BookmarkActor>().Property(x => x.Uconst).HasColumnName("uconst");
            modelBuilder.Entity<BookmarkActor>().Property(x => x.Nconst).HasColumnName("nconst");



            modelBuilder.Entity<BookmarkTitle>().ToTable("bookmark_title").HasKey(c => new { c.Tconst, c.Uconst });
            modelBuilder.Entity<BookmarkTitle>().Property(x => x.Tconst).HasColumnName("tconst");
            modelBuilder.Entity<BookmarkTitle>().Property(x => x.Uconst).HasColumnName("uconst");

            modelBuilder.Entity<Genre>().ToTable("genre");
            modelBuilder.Entity<Genre>().Property(x => x.Id).HasColumnName("id");
            modelBuilder.Entity<Genre>().Property(x => x.Name).HasColumnName("name");

            modelBuilder.Entity<TitleGenre>().ToTable("title_genre").HasKey(c => new { c.TitleTconst, c.GenreId });
            modelBuilder.Entity<TitleGenre>().Property(x => x.TitleTconst).HasColumnName("tconst");
            modelBuilder.Entity<TitleGenre>().Property(x => x.GenreId).HasColumnName("genreid");

            modelBuilder.Entity<OmdbData>().ToTable("omdb_data");
            modelBuilder.Entity<OmdbData>().HasOne(x => x.Title).WithOne(x => x.OmdbData).HasForeignKey<Title>(x => x.Tconst);
            modelBuilder.Entity<OmdbData>().Property(x => x.Tconst).HasColumnName("tconst");
            modelBuilder.Entity<OmdbData>().Property(x => x.Poster).HasColumnName("poster");
            modelBuilder.Entity<OmdbData>().Property(x => x.Awards).HasColumnName("awards");
            modelBuilder.Entity<OmdbData>().Property(x => x.Plot).HasColumnName("plot");

            modelBuilder.Entity<Title>().ToTable("title_basics");
            modelBuilder.Entity<Title>().Property(x => x.Tconst).HasColumnName("tconst");
            modelBuilder.Entity<Title>().Property(x => x.Titletype).HasColumnName("titletype");
            modelBuilder.Entity<Title>().Property(x => x.Primarytitle).HasColumnName("primarytitle");
            modelBuilder.Entity<Title>().Property(x => x.Originaltitle).HasColumnName("originaltitle");
            modelBuilder.Entity<Title>().Property(x => x.Isadult).HasColumnName("isadult");
            modelBuilder.Entity<Title>().Property(x => x.Startyear).HasColumnName("startyear");
            modelBuilder.Entity<Title>().Property(x => x.Endyear).HasColumnName("endyear");
            modelBuilder.Entity<Title>().Property(x => x.Runtimeminutes).HasColumnName("runtimeminutes");

            modelBuilder.Entity<TitleAkas>().ToTable("title_akas");
            modelBuilder.Entity<TitleAkas>().Property(x => x.Titleid).HasColumnName("titleid");
            modelBuilder.Entity<TitleAkas>().Property(x => x.Ordering).HasColumnName("Ordering");
            modelBuilder.Entity<TitleAkas>().Property(x => x.Title).HasColumnName("Title");
            modelBuilder.Entity<TitleAkas>().Property(x => x.Region).HasColumnName("region");
            modelBuilder.Entity<TitleAkas>().Property(x => x.Language).HasColumnName("language");
            modelBuilder.Entity<TitleAkas>().Property(x => x.Types).HasColumnName("types");
            modelBuilder.Entity<TitleAkas>().Property(x => x.Attributes).HasColumnName("attributes");
            modelBuilder.Entity<TitleAkas>().Property(x => x.Isoriginaltitle).HasColumnName("isoriginaltitle");


            modelBuilder.Entity<TitleCrew>().ToTable("title_crew");
            modelBuilder.Entity<TitleCrew>().Property(x => x.Tconst).HasColumnName("tconst");
            modelBuilder.Entity<TitleCrew>().Property(x => x.Directors).HasColumnName("directors");
            modelBuilder.Entity<TitleCrew>().Property(x => x.Writers).HasColumnName("writers");

            modelBuilder.Entity<TitleEpisode>().ToTable("title_episode");
            modelBuilder.Entity<TitleEpisode>().Property(x => x.Tconst).HasColumnName("tconst");
            modelBuilder.Entity<TitleEpisode>().Property(x => x.Parenttconst).HasColumnName("parenttconst");
            modelBuilder.Entity<TitleEpisode>().Property(x => x.Seasonnumber).HasColumnName("seasonnumber");
            modelBuilder.Entity<TitleEpisode>().Property(x => x.Episodenumber).HasColumnName("episodenumber");

            modelBuilder.Entity<TitlePrincipals>().ToTable("title_principals");
            modelBuilder.Entity<TitlePrincipals>().Property(x => x.Tconst).HasColumnName("tconst");
            modelBuilder.Entity<TitlePrincipals>().Property(x => x.Ordering).HasColumnName("ordering");
            modelBuilder.Entity<TitlePrincipals>().Property(x => x.Nconst).HasColumnName("nconst");
            modelBuilder.Entity<TitlePrincipals>().Property(x => x.Category).HasColumnName("category");
            modelBuilder.Entity<TitlePrincipals>().Property(x => x.Job).HasColumnName("job");
            modelBuilder.Entity<TitlePrincipals>().Property(x => x.Characters).HasColumnName("characters");

            modelBuilder.Entity<TitleRating>().ToTable("title_ratings");
            modelBuilder.Entity<TitleRating>().HasOne(x => x.Title).WithOne(x => x.TitleRating).HasForeignKey<Title>(x => x.Tconst);
            modelBuilder.Entity<TitleRating>().Property(x => x.TitleRatingTconst).HasColumnName("tconst");
            modelBuilder.Entity<TitleRating>().Property(x => x.Averagerating).HasColumnName("averagerating");
            modelBuilder.Entity<TitleRating>().Property(x => x.Numvotes).HasColumnName("numvotes");

            modelBuilder.Entity<UserAccount>().ToTable("user_account");
            modelBuilder.Entity<UserAccount>().Property(x => x.Uconst).HasColumnName("uconst");
            modelBuilder.Entity<UserAccount>().Property(x => x.UserName).HasColumnName("username");
            modelBuilder.Entity<UserAccount>().Property(x => x.Email).HasColumnName("email");
            modelBuilder.Entity<UserAccount>().Property(x => x.Birthdate).HasColumnName("birthdate");
            modelBuilder.Entity<UserAccount>().Property(x => x.Password).HasColumnName("password");

            modelBuilder.Entity<UserRating>().ToTable("user_rating").HasKey(c => new { c.Tconst, c.Uconst });
            modelBuilder.Entity<UserRating>().Property(x => x.Rating).HasColumnName("rating");
            modelBuilder.Entity<UserRating>().Property(x => x.Uconst).HasColumnName("uconst");
            modelBuilder.Entity<UserRating>().Property(x => x.Tconst).HasColumnName("tconst");

            modelBuilder.Entity<UserSearchHistory>().ToTable("user_search_history");
            modelBuilder.Entity<UserSearchHistory>().Property(x => x.SearchId).HasColumnName("search_id");
            modelBuilder.Entity<UserSearchHistory>().Property(x => x.Query).HasColumnName("query");
            modelBuilder.Entity<UserSearchHistory>().Property(x => x.Uconst).HasColumnName("uconst");



















        }


    }
}
