using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ENDASPNET_PROJECT.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace ENDASPNET_PROJECT.Models.Posts
{
    public class Post
    {

        [Display(Name = "Post id")]
        public int postId { get; set; }

        [Display(Name = "Post title")]
        public string postTitle { get; set; }

        [Display(Name = "Post content")]
        public string postContent { get; set; }

        [Display(Name = "Post Author")]
        public string postAuthor{get;set;}

        [Display(Name = "Post category")]
        public string postCategory { get; set; }//many category many posts

        [Display(Name = "Post time")]
        public DateTime postTime { get; set; }
    }
}
