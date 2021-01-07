using RemindDrinking.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace RemindDrinking.Core.DataAccess
{
    /// <summary>
    /// 定时配置 数据库操作类
    /// </summary>
    public class daSchedulerConfig
    {
        /// <summary>
        /// 写入一个任务数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool InsertSchedulerConfig(SchedulerConfig data)
        {
            try
            {
                string cmdText = "INSERT INTO SCHEDULERCONFIG (SEG_DATE, SEG_TITEL) VALUES (@SEG_DATE, @SEG_TITEL) ";

                Dictionary<string, string> param = new Dictionary<string, string>()
                {
                    {SchedulerConfig.DBCOL_SEG_DATE, data.Date},
                    {SchedulerConfig.DBCOL_SEG_STORY, data.Story}
                };

                SqliteHelper.ExecuteNonQuery(cmdText, param);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 查询任务数据
        /// </summary>
        /// <returns></returns>
        public List<SchedulerConfig> GetSchedulerConfig()
        {
            string cmdText = "SELECT * FROM SCHEDULERCONFIG";

            DataSet ds = SqliteHelper.ExecuteDataset(cmdText, null);

            List<SchedulerConfig> resList = new List<SchedulerConfig>();
            foreach (DataRow row in ds.Tables[0].Rows)
                resList.Add(new SchedulerConfig(row));
            return resList;
        }
    }
}
