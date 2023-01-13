//#define query
#define proc

using Doranco132.Model;
using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Doranco132.ADOSqlServer
{
    public class DepConnectedAdoContext
    {
        //Pour le mode connecté de ADO.NET  on a besoin de ces trois objets
        protected SqlConnection _connection;
        protected SqlCommand _command;
        SqlDataReader _reader;
        protected string _query = string.Empty;
        protected string connstring;

        //Remarque: Noubliez pas de changer le nom du serveur au niveau du fichier App.config
        public DepConnectedAdoContext()
        {
            connstring = ConfigurationManager
                .ConnectionStrings["firmconnection"].ConnectionString;
            _connection = new SqlConnection(connstring);  
        }

        public void Add(Department departement)
        {
            _query = $"INSERT INTO [dbo].[Departement]([Id],[Name],[Region])" +
                $" VALUES({departement.Id},'{departement.Name}',{departement.Region})";
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
            _query = $"DELETE [dbo].[Department] where [Id] = {id}";
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

        public void Update(int id,Department newdepartment)
        {
            Department current = Get(id);
            if(current!=null)
            {
                _query = $"UPDATE [dbo].[Department] SET [Id] = {id} ,[Name] ='{newdepartment.Name}' " +
                      $" ,[Salary] = {newdepartment.Region} WHERE Id = {id}";
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

#if query
        public virtual Department Get(int id)
                {
                    Department current = new Department();
                    _query = $"SELECT [Id] ,[Name],[Region] FROM [dbo].[Department] WHERE  [Id]={id}";
                    _command = new SqlCommand(_query, _connection);
                        try
                        {
                            _connection.Open();
                            _reader =_command.ExecuteReader();
                            _reader.Read();
                            current.Id = int.Parse(_reader["Id"].ToString());
                            current.Name = _reader["Name"].ToString();
                            current.Salary = decimal.Parse(_reader["Region"].ToString());
                    
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
#endif

#if proc
        public virtual Department Get(int id)
        {
            Department current = new Department();
            _query = $"sp_getDepartment";
            _command = new SqlCommand(_query, _connection);
            _command.CommandType = CommandType.StoredProcedure;
            SqlParameter idparam = new SqlParameter("@id", SqlDbType.Int);
            idparam.Direction = ParameterDirection.Input;
            idparam.Value = id;
            
            try
            {
                _connection.Open();
                _reader = _command.ExecuteReader();
                _reader.Read();
                current.Id = int.Parse(_reader["Id"].ToString());
                current.Name = _reader["Name"].ToString();
                current.Region = _reader["Region"].ToString();

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
#endif


        public virtual IQueryable<Department> GetList()
        {
            List<Department> departments = new List<Department>();
            Department current;
            _query = $"SELECT [Id] ,[Name],[Region] FROM [dbo].[Department]";
            _command = new SqlCommand(_query, _connection);
            try
            {
                _connection.Open();
                _reader = _command.ExecuteReader();

                while (_reader.Read())
                {
                    current = new Department();
                    current.Id = int.Parse(_reader["Id"].ToString());
                    current.Name = _reader["Name"].ToString();
                    current.Region = _reader["Salary"].ToString();
                    departments.Add(current);
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
