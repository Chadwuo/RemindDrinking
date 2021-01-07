namespace RemindDrinking.Config
{
    /// <summary>
    /// ConfigDefault class
    /// </summary>
    public class ConfigDefault
    {
        /// <summary>
        /// Bing每日壁纸api
        /// </summary>
        public const string BingImageUrl = @"https://cn.bing.com/HPImageArchive.aspx?format=js&idx=0&n=1";
        
        /// <summary>
        /// Bing主页地址
        /// </summary>
        public const string BingBaseUrl = @"https://cn.bing.com";

        /// <summary>
        /// 图片保存路径
        /// </summary>
        public const string SavePath = @"{0}AppData\DownloadImages\{1}.jpg";

        /// <summary>
        /// 定时故事——毒鸡汤类别
        /// </summary>
        public const string Soul_Type_Darklessons = "DARKLESSONS";

        /// <summary>
        /// 定时故事——自定义类别
        /// </summary>
        public const string Soul_Type_Custom = "CUSTOM";
    }
}

