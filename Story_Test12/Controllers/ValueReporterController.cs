//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using System.Data.SqlClient;
//using System.Configuration;
//using System.Web.Routing;
//using STORY_Test6.Models;

//namespace StoryTest12.Controllers
//{
//    public class ValueReporter : ActionFilterAttribute
//    {
//        SqlConnection Conn = new SqlConnection
//        (ConfigurationManager.ConnectionStrings["STORY_Test7"].ConnectionString);
//        SqlCommand cmd = new SqlCommand();

//        void executeSql(string sql)
//        {
//            Conn.Open();
//            cmd.Connection = Conn;
//            cmd.CommandText = sql;
//            cmd.ExecuteNonQuery();

//            Conn.Close();
//        }

//        void LogValues(RouteData routeData)
//        {
//            cmd.Parameters.Clear();
//            var controllerName = routeData.Values["controller"];
//            var actionName = routeData.Values["action"];
//            var parame = routeData.Values["id"] == null ? "N/A" : routeData.Values["id"];

//            string sql = "insert into ActionLog(controllerName,actionName,parame) values(@controllerName,@actionName,@parame)";

//            cmd.Parameters.AddWithValue("@controllerName", controllerName);
//            cmd.Parameters.AddWithValue("@actionName", actionName);
//            cmd.Parameters.AddWithValue("@parame", parame);

//            executeSql(sql);
//        }

//        void ResquesLog()
//        {
//            cmd.Parameters.Clear();

//            var ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
//            var host = HttpContext.Current.Request.ServerVariables["REMOTE_HOST"];
//            var browser = HttpContext.Current.Request.ServerVariables["HTTP_USER_AGENT"];

//            var requestType = HttpContext.Current.Request.RequestType;
//            var userHostAddress = HttpContext.Current.Request.UserHostAddress;
//            var userHostName = HttpContext.Current.Request.UserHostName;
//            var httpMethod = HttpContext.Current.Request.HttpMethod;

//            string sql = "insert into  RequestLog(ip,host,browser,requestType,userHostAddress,userHostName,httpMethod) ";
//            sql += "values(@ip,@host,@browser,@requestType,@userHostAddress,@userHostName,@httpMethod)";

//            cmd.Parameters.AddWithValue("@ip", ip);
//            cmd.Parameters.AddWithValue("@host", host);
//            cmd.Parameters.AddWithValue("@browser", browser);
//            cmd.Parameters.AddWithValue("@requestType", requestType);
//            cmd.Parameters.AddWithValue("@userHostAddress", userHostAddress);
//            cmd.Parameters.AddWithValue("@userHostName", userHostName);
//            cmd.Parameters.AddWithValue("@httpMethod", httpMethod);

//            executeSql(sql);
//        }

//        public override void OnActionExecuting(ActionExecutingContext filterContext)
//        {
//            LogValues(filterContext.RouteData);
//        }

//        public override void OnResultExecuted(ResultExecutedContext filterContext)
//        {
//            //base.OnResultExecuted(filterContext);
//            ResquesLog();
//        }
//    }



//}
