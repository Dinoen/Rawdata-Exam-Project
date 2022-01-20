using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;

namespace Raw5MovieDb_WebApi.Model
{
    public class UserAccount
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Uconst { get; set; }
        public string UserName { get; set; }

        public string Email { get; set; }

        public DateTime Birthdate { get; set; }

        public string Password { get; set; }

        // public List<UserRating> Ratings { get; set; }
        // public List<UserSearchHistory> SearchHistory { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }

    }
}