using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace InlamningDatabaser
{
    public class Painting
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Year { get; set; }
        public string Dimension { get; set; }
        public string HistoricalContext { get; set; }
        public string Image { get; set; }

        public static List<Painting> paintings= new List<Painting>();

        public Painting (int id, string title, DateTime year, string dimension, string historicalContext, string image)
        {
            Id = id;
            Title = title;
            Year = year;
            Dimension = dimension;
            HistoricalContext = historicalContext;
            Image = image;
        }
        public Painting() { }
    }
}
