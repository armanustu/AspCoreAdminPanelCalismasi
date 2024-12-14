using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntityLayer.Concrete
{
    public class About
    {
        [Key]
        public int AboutID { get; set; }
        public string? AboutDetails1 { get; set; }
        public string? AboutDetails2 { get; set; }
        public string? AboutImage { get; set; }
        public string? AboutImage2 { get; set; }
        public string? AboutMapLocation { get; set; }
        public bool? AboutStatus { get; set; }
    }
}

//Create Trigger AddScoreInComment
//On Comments
//After Insert
//As
//Declare @ID int
//Declare @Score int
//Declare @RaytingCount int
//Select @ID=BlogID , @Score = BlogScore from inserted  //commentten otomatikmen alınan değişkenler bir değere atılıyor
//Update BlogRaytings Set BlogTotalScore=BlogTotalScore+@Score, BlogRaytingCount+=1
//where BlogID=@ID