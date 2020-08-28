using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemindDrinking.Config
{
    public sealed class ConfigManage
    {
        private static readonly Lazy<ConfigManage> lazy =
        new Lazy<ConfigManage>(() => new ConfigManage());

        public static ConfigManage Instance { get { return lazy.Value; } }
        private ConfigManage()
        {
        }

    }
}
