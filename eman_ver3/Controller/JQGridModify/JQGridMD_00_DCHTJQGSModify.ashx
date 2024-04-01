<%@ WebHandler Language="C#" Class="JQGridMD_00_DCHTJQGSModify" %> using System;
using System.Web;
using System.Linq;
using System.Data.Linq;
using DataAcess;
using System.Diagnostics;
using System.Collections.Generic;
using System.Data.SqlClient;

public class JQGridMD_00_DCHTJQGSModify : IHttpHandler,
System.Web.SessionState.IRequiresSessionState
{
    public void ProcessRequest(HttpContext context)
    {
        
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}