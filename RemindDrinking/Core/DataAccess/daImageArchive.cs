using RemindDrinking.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace RemindDrinking.Core.DataAccess
{
    /// <summary>
    /// ImageArchive数据库操作类
    /// </summary>
    public class daImageArchive
    {
        /// <summary>
        /// 写入一条图片数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool InsertImageArchive(ImageArchive data)
        {
            try
            {
                string cmdText = "INSERT INTO IMAGEARCHIVE (IMG_DATE, IMG_TITLE, IMG_COPYRIGHT, IMG_STORY, IMG_FULLPATH) VALUES (@IMG_DATE, @IMG_TITLE, @IMG_COPYRIGHT, @IMG_STORY, @IMG_FULLPATH) ";

                Dictionary<string, string> param = new Dictionary<string, string>()
                {
                    {ImageArchive.DBCOL_IMG_DATE, data.Date},
                    {ImageArchive.DBCOL_IMG_TITLE, data.Title},
                    {ImageArchive.DBCOL_IMG_COPYRIGHT, data.Copyright},
                    {ImageArchive.DBCOL_IMG_STORY, data.Story},
                    {ImageArchive.DBCOL_IMG_FULLPATH, data.Fullpath}
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
        /// 随机获取一条图片数据
        /// </summary>
        /// <returns></returns>
        public ImageArchive GetImageRandomly()
        {
            string cmdText = "SELECT * FROM IMAGEARCHIVE ORDER BY RANDOM() limit 1";
            DataRow row = SqliteHelper.ExecuteDataRow(cmdText, null);
            if (row == null)
            {
                return null;
            }
            return new ImageArchive(row);
        }

        /// <summary>
        /// 获取今日的图片数据
        /// </summary>
        /// <returns></returns>
        public ImageArchive GetImageToday()
        {
            string cmdText = "SELECT * FROM IMAGEARCHIVE where IMG_DATE= @IMG_DATE";
            Dictionary<string, string> param = new Dictionary<string, string>()
            {
                {ImageArchive.DBCOL_IMG_DATE, DateTime.Now.ToString("yyyyMMdd")}
            };

            DataRow row = SqliteHelper.ExecuteDataRow(cmdText, param);
            if (row == null)
            {
                return null;
            }
            return new ImageArchive(row);
        }
    }
}
