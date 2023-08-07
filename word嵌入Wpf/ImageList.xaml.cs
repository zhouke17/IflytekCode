using Newtonsoft.Json;
using System.Collections.Generic;
using System.Windows;

namespace WPFApp
{
    /// <summary>
    /// ImageList.xaml 的交互逻辑
    /// </summary>
    public partial class ImageList : Window
    {
        public List<Notes> ImageLists = new List<Notes>()
        {
            new Notes{ Url = "https://devhknginx.iflysec.com/hk-fdfs/G1/M00/28/BB/rB-5_WR1kfOAP9UOAAFxgEikWPQ77.jpeg",Sort = 1 },
            new Notes{Url = "https://devhknginx.iflysec.com/hk-fdfs/G1/M00/28/BB/rB-5_WR1kfOAKHALAACqRazAxHc47.jpeg",Sort = 2 }
        };
        public ImageList()
        {
            InitializeComponent();
            this.BoardListView.ItemsSource = ImageLists;
        }
    }
    public class Notes
    {
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("sort")]
        public int Sort { get; set; }
    }
}
