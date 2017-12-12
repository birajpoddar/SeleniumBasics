using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;

namespace SeleniumBasics.Pages
{
    class PageBase
    {
        protected static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
        static PageBase()
        {
            //XmlConfigurator.Configure();
        }
    }
}
