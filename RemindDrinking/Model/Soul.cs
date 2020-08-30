namespace RemindDrinking.Model
{
    public class Soul
    {
        /// <summary>
        /// 表名称：有趣的灵魂
        /// </summary>
        public const string TABLENAME = "SOUL";

        /// <summary>
        /// 字段SOU_CONTENT: 内容
        /// </summary>
        public const string DBCOL_SOU_CONTENT = "SOU_CONTENT";

        /// <summary>
        /// 内容
        /// </summary>
        public System.String Content { get; set; }

        /// <summary>
        /// 字段SOU_TYPE: 类别
        /// </summary>
        public const string DBCOL_SOU_TYPE = "SOU_TYPE";

        /// <summary>
        /// 类别
        /// </summary>
        public System.String Type { get; set; }

        public void LoadFromDataRow(System.Data.DataRow row)
        {
            Content = row[DBCOL_SOU_CONTENT].ToString();
            Type = row[DBCOL_SOU_TYPE].ToString();
        }

        /// <summary>
        /// 默认构造函数。
        /// </summary>
        public Soul()
        {
        }

        /// <summary>
        /// 从数据行对象中初始化类实例。
        /// </summary>
        /// <param name="row">数据行对象。</param>
        public Soul(System.Data.DataRow row)
            : this()
        {
            LoadFromDataRow(row);
        }
    }
}
