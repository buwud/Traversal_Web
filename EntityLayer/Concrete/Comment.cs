﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }
        public string? CommentUser { get; set; }
        public DateTime CommentDate { get; set; }
        public string? CommentContent { get; set; }
        public bool CommentState { get; set; }
        public int DestinationID { get; set; }//yorum hangi destinationdan çekildi
        public Destination? Destination { get; set; }
        public int AppUserID { get; set; }//yorumu hangi kullanıcı yaptı
        public AppUser AppUser { get; set; }
    }
}