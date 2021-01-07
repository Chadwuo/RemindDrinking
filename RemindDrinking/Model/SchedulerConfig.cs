namespace RemindDrinking.Model
{
    public class SchedulerConfig
    {
        /// <summary>
        /// 表名称：图片档案表
        /// </summary>
        public const string TABLENAME = "SCHEDULERCONFIG";

        /// <summary>
        /// 字段SEG_DATE: 任务日期
        /// </summary>
        public const string DBCOL_SEG_DATE = "SEG_DATE";

        /// <summary>
        /// 任务日期
        /// </summary>
        public System.String Date { get; set; }

        /// <summary>
        /// 字段SEG_TITEL: 任务故事
        /// </summary>
        public const string DBCOL_SEG_STORY = "SEG_STORY";

        /// <summary>
        /// 任务故事
        /// </summary>
        public System.String Story { get; set; }

        public void LoadFromDataRow(System.Data.DataRow row)
        {
            Date = row[DBCOL_SEG_DATE].ToString();
            Story = row[DBCOL_SEG_STORY].ToString();
        }

        /// <summary>
        /// 默认构造函数。
        /// </summary>
        public SchedulerConfig()
        {
        }

        /// <summary>
        /// 从数据行对象中初始化类实例。
        /// </summary>
        /// <param name="row">数据行对象。</param>
        public SchedulerConfig(System.Data.DataRow row)
            : this()
        {
            LoadFromDataRow(row);
        }
    }
}
