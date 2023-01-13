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
    public class DepDisConnectedAdoContext : DepConnectedAdoContext
    {
        SqlDataAdapter _adapter;
        DataSet _dataset;
        
        public override Department Get(int id)
        {
            Department current = new Department();
            _query = $"sp_getDepartment";
            _command = new SqlCommand(_query, _connection);
            _command.CommandType = CommandType.StoredProcedure;
            SqlParameter idparam = new SqlParameter("@id", SqlDbType.Int);
            idparam.Direction = ParameterDirection.Input;
            idparam.Value = id;
            _adapter = new SqlDataAdapter(_command);
            _dataset = new DataSet();

            try
            {
                _connection.Open();
                _adapter.Fill(_dataset);
                DataTable table = _dataset.Tables[0];
                DataRow datarow = table.Rows[0];
                current.Id = int.Parse(datarow["Id"].ToString());
                current.Name= datarow["Name"].ToString();
                current.Region = datarow["Region"].ToString();
            }
            catch (SqlException erreur)
            {
                Debug.WriteLine(erreur.Message);
                current = null;
            }
            finally
            {
                _connection.Close();
            }

            return current;
        }

        public override IQueryable<Department> GetList()
        {
            List<Department> departments = new List<Department>();

            _query = $"SELECT [Id] ,[Name],[Region] FROM [dbo].[Department]";
            _command = new SqlCommand(_query, _connection);
            _adapter = new SqlDataAdapter(_command);
            try
            {
                _connection.Open();
                _dataset = new DataSet();
                _adapter.Fill(_dataset);
                DataTable dataTable = _dataset.Tables[0];
                foreach (DataRow item in dataTable.Rows)
                {
                    departments.Add(new Department
                    {
                        Id = int.Parse(item["Id"].ToString()),
                        Name = item["Name"].ToString(),
                        Region = item["Region"].ToString()
                    });
                }

            }
            catch (SqlException erreur)
            {
                Debug.WriteLine(erreur.Message);
                departments = null;
            }
            finally
            {
                _connection.Close();
            }
            return departments.AsQueryable();
        }
    }
}
