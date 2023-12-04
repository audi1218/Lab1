using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// video game class
namespace VideoGameLab
{
    public  class VideoGame : IComparable<VideoGame>
    {
        //properties
        public string ?Name { get; set; }
        public string ?Platform { get; set; }
        public string ?Year {  get; set; }
        public string ?Genre { get; set; }
        public string ?Publisher { get; set; }
        public string NA_Sales { get; set; }
        public string EU_Sales { get; set; }
        public string JP_Sales { get; set; }
        public string Other_Sales { get; set; }
        public string Global_Sales { get; set; }

        public int CompareTo(VideoGame other)
        {
            return string.Compare(this.Name,other.Name, StringComparison.Ordinal);
        }


        public override string ToString()
        {
            return $"Name: {Name}, Platform: {Platform}, Year: {Year}, Genre: {Genre}, Publisher: {Publisher}, NA Sales: {NA_Sales}, EU Sales: {EU_Sales}, JP Sales: {JP_Sales}, OtherSales: {Other_Sales}, Global Sales: {Global_Sales}";
        }
    }
}
