using RemindDrinking.Model;
using System.Collections.Generic;
using System.Data;

namespace RemindDrinking.Core.DataAccess
{
    /// <summary>
    /// 定时故事 数据库操作类
    /// </summary>
    public class daSoul
    {
        /// <summary>
        /// 随机获取一条数据
        /// </summary>
        /// <returns></returns>
        public Soul GetSoulRandomly(string type)
        {
            string cmdText = "SELECT * FROM SOUL WHERE SOU_TYPE = @SOU_TYPE ORDER BY RANDOM() limit 1";
            Dictionary<string, string> param = new Dictionary<string, string>()
            {
                {Soul.DBCOL_SOU_TYPE, type}
            };

            DataRow row = SqliteHelper.ExecuteDataRow(cmdText, param);
            if (row == null)
            {
                return null;
            }
            return new Soul(row);
        }
    }
}
