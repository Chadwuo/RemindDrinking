using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemindDrinking
{
    sealed class AppSetting : ApplicationSettingsBase
    {
        private AppSetting() {; }
        private static readonly Lazy<AppSetting> lazy = new Lazy<AppSetting>(() => new AppSetting());
        public static AppSetting Set
        {
            get { return lazy.Value; }
        }


        [UserScopedSetting]
        public Dictionary<string, string> TimeSet
        {
            get
            {
                Dictionary<string, string> result = (Dictionary<string, string>)this["TimeSet"];
                if (result == null)
                {
                    result = TimeSetDefault();
                }
                return result;

            }
            set { this["TimeSet"] = value; }
        }

        Dictionary<string, string> TimeSetDefault()
        {
            Dictionary<string, string> timeDft = new Dictionary<string, string>();
            timeDft.Add("9", "用最美的心情来迎接朝阳和第一杯水！");
            timeDft.Add("10", "小公主~ 要记得喝水哦！");
            timeDft.Add("11", "科学研究表明，此时喝水有助于瘦身！");
            timeDft.Add("12", "吃完饭，喝杯水，休息一会！");
            timeDft.Add("14", "喝最大杯的水，做最靓的仔！");
            timeDft.Add("15", "娘娘，喝水的时间到了！");
            timeDft.Add("16", "菇凉，喝口水吧！");
            timeDft.Add("17", "注意，再喝一杯水，马上要下班了！");
            return timeDft;
        }
    }
}
