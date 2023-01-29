using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InlamningDatabaser
{
    class ArtistClass
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string education { get; set; }

        public static List<ArtistClass> artists = new List<ArtistClass>();

        public ArtistClass(int id, string firstName, string lastName, string education)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.education = education;
        }

        public override string? ToString() => this.firstName + " " + this.lastName;

        public void popArtistClass()
        {
            
        }
    }
}
