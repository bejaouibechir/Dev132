using Doranco132.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Doranco132.ADOSqlServer
{
    public class EmpDisConnectedAdoContext : EmpConnectedAdoContext
    {
        SqlDataAdapter _adapter;
        DataSet _dataset;
        
        public override Employee Get(int id)
        {
            //TAF : Remplacer ce code par le mode déconnecté de ADO 
            return base.Get(id);
        }

        public override IQueryable<Employee> GetList()
        {
            //TAF : Remplacer ce code par le mode déconnecté de ADO 
            return base.GetList();
        }
    }
}
