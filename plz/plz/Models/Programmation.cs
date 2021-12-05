using System;
using System.Collections.Generic;
using System.Text;

namespace plz.Models
{
    public class Programmation
    {
        public int Id { get; set; }
        public DateTime Heure { get; set; }
        public int artiste_id { get; set; }
        public int scene_id { get; set; }   
        public Artiste artiste { get; set; }
        public Scene Scene { get; set; }
    }
}
