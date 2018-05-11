using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using log4net;

namespace SRIS.Common.Log
{
    /// <summary>
    /// 日志帮助类
    /// </summary>
    public class LogHelper
    {
        #region 全局设置
        public static void InitLog4Net()
        {
            Assembly assebly = Assembly.GetExecutingAssembly();
            var xml = assebly.GetManifestResourceStream("SRIS.Common.Log.Log4Net.config");
            log4net.Config.XmlConfigurator.Configure(xml);
        }
        #endregion

        #region 利用Action委托封装Log4Net对方法的处理方法
        /// <summary>
        /// 利用Action委托封装Log4Net对方法的处理方法
        /// </summary>
        /// <param name="log">日志对象</param>
        /// <param name="function">方法名</param>
        /// <param name="errorHandle">异常处理方法</param>
        /// <param name="tryHandle">调试运行代码</param>
        /// <param name="catchHandle">异常处理方式</param>
        /// <param name="finallyHandle">最终处理方式</param>
        public static void Logger(ILog log, string function, ErrorHandle errorHandle, Action tryHandle, Action<Exception> catchHandle = null, Action finallyHandle = null)
        {
            try
            {
                log.Debug(function);
                tryHandle();
            }
            catch (Exception ex)
            {
                log.Error(function + "失败", ex);
                if (catchHandle != null)
                {
                    catchHandle(ex);
                }
                if (errorHandle == ErrorHandle.Throw)
                {
                    throw ex;
                }
            }
            finally
            {
                if (finallyHandle != null)
                {
                    finallyHandle();
                }
            }
        } 
        #endregion
    }
}
