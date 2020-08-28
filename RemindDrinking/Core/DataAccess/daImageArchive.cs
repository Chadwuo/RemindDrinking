using RemindDrinking.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace RemindDrinking.Core.DataAccess
{
    public class daImageArchive
    {
        public bool InsertImageArchive(ImageArchiveModel data)
        {
            try
            {
                string cmdText = "INSERT INTO IMAGEARCHIVE (IMG_DATE, IMG_TITLE, IMG_COPYRIGHT, IMG_STORY, IMG_FULLPATH) VALUES (@IMG_DATE, @IMG_TITLE, @IMG_COPYRIGHT, @IMG_STORY, @IMG_FULLPATH) ";

                Dictionary<string, string> param = new Dictionary<string, string>()
                {
                    {ImageArchiveModel.DBCOL_IMG_DATE, data.Date},
                    {ImageArchiveModel.DBCOL_IMG_TITLE, data.Title},
                    {ImageArchiveModel.DBCOL_IMG_COPYRIGHT, data.Copyright},
                    {ImageArchiveModel.DBCOL_IMG_STORY, data.Story},
                    {ImageArchiveModel.DBCOL_IMG_FULLPATH, data.Fullpath}
                };

                SqliteHelper.ExecuteNonQuery(cmdText, param);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ImageArchiveModel GetImageRandomly()
        {
            string cmdText = "SELECT * FROM IMAGEARCHIVE ORDER BY RANDOM() limit 1";
            DataRow row = SqliteHelper.ExecuteDataRow(cmdText, null);
            if (row == null)
            {
                return null;
            }
            return new ImageArchiveModel(row);
        }

        public ImageArchiveModel GetImageToday()
        {
            string cmdText = "SELECT * FROM IMAGEARCHIVE where IMG_DATE= @IMG_DATE";
            Dictionary<string, string> param = new Dictionary<string, string>()
            {
                {ImageArchiveModel.DBCOL_IMG_DATE, DateTime.Now.ToString("yyyyMMdd")}
            };

            DataRow row = SqliteHelper.ExecuteDataRow(cmdText, param);
            if (row == null)
            {
                return null;
            }
            return new ImageArchiveModel(row);
        }
    }
}
