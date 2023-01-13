using Doranco132.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Doranco132.ADOSqlServer
{
    public class EmpConnectedAdoContext
    {
        //Pour le mode connecté de ADO.NET  on a besoin de ces trois objets
        SqlConnection _connection;
        SqlCommand _command;
        SqlDataReader _reader;
        string _query = string.Empty;

        public EmpConnectedAdoContext()
        {
            _connection = new SqlConnection("Data Source=PC2022\\DORANCOSRV;" +
                "Initial Catalog=FirmDB;Integrated Security=True");  
        }

        public void Add(Employee employee)
        {
            _query = $"INSERT INTO [dbo].[Employee]([Id],[Name],[Salary])" +
                $" VALUES({employee.Id},'{employee.Name}',{employee.Salary})";
            _command = new SqlCommand(_query, _connection);
            try
            {
                _connection.Open();
                _command.ExecuteNonQuery();
            }
            catch (SqlException erreur)
            {
                Debug.WriteLine(erreur.Message);
            }
            finally
            {
                _connection.Close();
            }
        }
        public void Delete(int id)
        {
            _query = $"DELETE [dbo].[Employee] where [Id] = {id}";
            _command = new SqlCommand(_query, _connection);
            try
            {
                _connection.Open();
                _command.ExecuteNonQuery();
            }
            catch (SqlException erreur)
            {
                Debug.WriteLine(erreur.Message);
            }
            finally
            {
                _connection.Close();
            }
        }

        public void Update(int id,Employee newemployee)
        {
            Employee current = Get(id);
            if(current!=null)
            {
                _query = $"UPDATE [dbo].[Employee] SET [Id] = {id} ,[Name] ='{newemployee.Name}' " +
                      $" ,[Salary] = {newemployee.Salary} WHERE Id = {id}";
               _command = new SqlCommand(_query, _connection);
                        try
                        {
                            _connection.Open();
                            _command.ExecuteNonQuery();
                        }
                        catch (SqlException erreur)
                        {
                            Debug.WriteLine(erreur.Message);
                        }
                        finally
                        {
                            _connection.Close();
                        }
             }
        }

        public virtual Employee Get(int id)
        {
            Employee current = new Employee();
            _query = $"SELECT [Id] ,[Name],[Salary] FROM [dbo].[Employee] WHERE  [Id]={id}";
            _command = new SqlCommand(_query, _connection);
                try
                {
                    _connection.Open();
                    _reader =_command.ExecuteReader();
                    _reader.Read();
                    current.Id = int.Parse(_reader["Id"].ToString());
                    current.Name = _reader["Name"].ToString();
                    current.Salary = decimal.Parse(_reader["Salary"].ToString());
                    
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

        public virtual IQueryable<Employee> GetList()
        {
            List<Employee> employees = new List<Employee>();
            Employee current;
            _query = $"SELECT [Id] ,[Name],[Salary] FROM [dbo].[Employee]";
            _command = new SqlCommand(_query, _connection);
            try
            {
                _connection.Open();
                _reader = _command.ExecuteReader();

                while (_reader.Read())
                {
                    current = new Employee();
                    current.Id = int.Parse(_reader["Id"].ToString());
                    current.Name = _reader["Name"].ToString();
                    current.Salary = decimal.Parse(_reader["Salary"].ToString());
                    employees.Add(current);
                }
            }
            catch (SqlException erreur)
            {
                Debug.WriteLine(erreur.Message);
                employees = null;
            }
            finally
            {
                _connection.Close();
            }
            return employees.AsQueryable();
        }

    }
}
