using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ENDASPNET_PROJECT.Models.Users
{
    public class User
    {
        [Display(Name = "User id")]
        public int Id { get; set; }
      //  [Column(TypeName="number(1000)")]

        [Display(Name = "User name")]
        public string Name { get; set; }

        [Display(Name = "User role")]
        public string Role { get; set; }
    }
}
