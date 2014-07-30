using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

namespace AndroidService
{
    /// <summary>
    /// Service 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://GreenShadow.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [SoapDocumentService(RoutingStyle = SoapServiceRoutingStyle.RequestElement)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class Service : System.Web.Services.WebService
    {

        DataBase DB = new DataBase();

        [WebMethod(Description = "返回所有值")]
        public List<string> AllInfo(int firstCount, int secondCount)
        {
            if (firstCount < 0 || secondCount < 0)
                return null;

            return DB.AllInfo(firstCount, secondCount);
        }
    }
}