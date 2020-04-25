using ENDASPNET_PROJECT.Models.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ENDASPNET_PROJECT.Models.Comments
{
    public class Comment
    {
        [Display(Name = "Comment id")]
        public int commentId { get; set; }

        [Display(Name = "Comment content")]
        public string commentContent { get; set; }

        [Display(Name = "Comment author ID")]
        public int commentAuthor { get; set; }//one comment one author

        [Display(Name = "Comment time")]
        public DateTime commentTime { get; set; }

        [Display(Name = "Id of post for comment")]
        public int compostID { get; set; }//one post many comment
    }
}