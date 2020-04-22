using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace PresentationApp.Models
{
    public class Presentation
    {
        [Key]
        public int Id {get; set;}
        public string VideoToken {get;set;}
        public ICollection<Slide> Slides {get;set;}
        public int CurrentSlide {get;set;}
    }
    public class Slide
    {
        public int Id {get;set;}
        public byte[] Picture {get;set;}
    }
}