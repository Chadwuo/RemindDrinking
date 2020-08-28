namespace RemindDrinking.Model
{
    public class ImageArchiveModel
    {
        /// <summary>
        /// 表名称：取号机设备菜单
        /// </summary>
        public const string TABLENAME = "IMAGEARCHIVE";

        /// <summary>
        /// 字段IMG_DATE: 图片日期
        /// </summary>
        public const string DBCOL_IMG_DATE = "IMG_DATE";

        /// <summary>
        /// 图片日期
        /// </summary>
        public System.String Date { get; set; }

        /// <summary>
        /// 字段IMG_TITLE: 图片标题
        /// </summary>
        public const string DBCOL_IMG_TITLE = "IMG_TITLE";

        /// <summary>
        /// 图片标题
        /// </summary>
        public System.String Title { get; set; }

        /// <summary>
        /// 字段IMG_STORY: 图片故事
        /// </summary>
        public const string DBCOL_IMG_STORY = "IMG_STORY";

        /// <summary>
        /// 图片故事
        /// </summary>
        public System.String Story { get; set; }

        /// <summary>
        /// 字段IMG_COPYRIGHT: 图片版权
        /// </summary>
        public const string DBCOL_IMG_COPYRIGHT = "IMG_COPYRIGHT";

        /// <summary>
        /// 图片版权
        /// </summary>
        public System.String Copyright { get; set; }

        /// <summary>
        /// 字段IMG_FULLPATH: 图片路径
        /// </summary>
        public const string DBCOL_IMG_FULLPATH = "IMG_FULLPATH";

        /// <summary>
        /// 图片路径
        /// </summary>
        public System.String Fullpath { get; set; }


        public void LoadFromDataRow(System.Data.DataRow row)
        {
            Date = row[DBCOL_IMG_DATE].ToString();
            Title = row[DBCOL_IMG_TITLE].ToString();
            Story = row[DBCOL_IMG_STORY].ToString();
            Copyright = row[DBCOL_IMG_COPYRIGHT].ToString();
            Fullpath = row[DBCOL_IMG_FULLPATH].ToString();
        }

        /// <summary>
        /// 默认构造函数。
        /// </summary>
        public ImageArchiveModel()
        {
        }

        /// <summary>
        /// 从数据行对象中初始化类实例。
        /// </summary>
        /// <param name="row">数据行对象。</param>
        public ImageArchiveModel(System.Data.DataRow row)
            : this()
        {
            LoadFromDataRow(row);
        }
    }
}
