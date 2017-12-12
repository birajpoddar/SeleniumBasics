using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;
using System.Diagnostics;
using NUnit.Framework;

namespace SeleniumBasics.Tests
{
    [TestFixture]
    public class TestBase
    {
        private StackTrace stackTrace = new StackTrace();
        protected readonly ILog Log;
        
        public TestBase()
        {
            Log = LogManager.GetLogger(stackTrace.GetFrame(1).GetMethod().ReflectedType.ToString());
        }

        [TearDown]
        public void GenerateReport()
        {
            
        }
    }
}
