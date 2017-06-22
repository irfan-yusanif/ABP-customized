using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final1.Global
{
    public class StaticDictionaries
    {
        public static readonly Dictionary<string, string> UserRoles = new Dictionary<string, string>
        {
            //{ "File Send", PhoenixConsts.FileDeliveryProfileTypes.FileSend },
            { "Admin","Pages" },
            { "User","Pages.User" }
        };
    }
}
