
namespace WinFormsApp1
{
    public class MyData
    {
        public int id { get; set; }
        public int link_url_id { get; set; }
        public string top_level_url { get; set; }
        public string frame_url { get; set; }
        public int visit_count { get; set; }

        public MyData()
        {
            id = 0;
            link_url_id = 0;
            top_level_url = string.Empty;
            frame_url = string.Empty;
            visit_count = 0;
        }
    }
}
