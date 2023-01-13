//#define postgres
#define sqlserver

using Doranco132.Model;
using Doranco132.ADOSqlServer;
using System.Linq;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Xml.Linq;
using System.Dynamic;

namespace Doranco132.Console
{

   

    //Client
    internal class Program
    {
        static public void Main(string[] args)
        {

            //En cas de fichier xml utilisez Load en passant le chemin vers le fichier
            //En cas de chaine xml utilisez parse en passant la chaine qui représente le xml
            var document = XDocument.Load("D:\\employees.xml");
            var root = document.Root;

           
           

            var elements = from el in root.Descendants()
                           let attributes = el.Attributes()
                           from attribute in attributes
                           select new
                           {
                               PropertyName = attribute.Name,
                               PropertyValue = attribute.Value
                           };


            System.Console.ReadLine();

      }
       
    }
}



//------------------------Code d'appel mode ADO Déconnecté-------------------------
//DepDisConnectedAdoContext context = new DepDisConnectedAdoContext();
//var departments = context.GetList();


//------------------------Code d'appel ADO Connecté--------------------------------
//Employee emp = new Employee { Id = 2, Name = "Mona", Salary = 8000 };
//EmpConnectedAdoContext adoContext = new EmpConnectedAdoContext();
//adoContext.Add(emp);
//System.Console.WriteLine("L'employee est mis(e) à jour");
//System.Console.ReadLine();

//EmpConnectedAdoContext adoContext = new EmpConnectedAdoContext();
//var employees = adoContext.GetList();
//var emp = employees.SingleOrDefault(e => e.Id == 2);





//Code d'appel à MethodFactory
//FactoryMethod.Connect(ConnectionType.Oracle);


//--------------------------Appel à Factory---------------------------------

////Appel direct du PostgreSQLHandler
////PostgreSQLHandler handler = new PostgreSQLHandler();

////Appel par le biais de Factory pattern
//ConcreteCreator concreteCreator = new ConcreteCreator();
//#if postgres
//       PostgreSQLHandler handler =  (PostgreSQLHandler)concreteCreator
//                .FactoryMethod(ConnectionKind.PostgreSQL);
//            handler.Read();
//#endif
//#if sqlserver
//SqlServerHandler handler = (SqlServerHandler)concreteCreator
//    .FactoryMethod(ConnectionKind.SqlServer);
//handler.Read();
//#endif

//------------------------------DAO-------------------------------

//using sqlserverdep = Doranco132.Console.DesignPattern
//        .RepositoryPattern.ImplSqlServer.DepartementRepository;
//    using sqlserveremp = Doranco132.Console.DesignPattern
//        .RepositoryPattern.ImplSqlServer.EmployeeRepository;

//    using postgresdep = Doranco132.Console.DesignPattern
//       .RepositoryPattern.ImplSqlServer.DepartementRepository;
//    using postgresemp = Doranco132.Console.DesignPattern
//        .RepositoryPattern.ImplSqlServer.EmployeeRepository;


//string parametre = ConfigurationManager.AppSettings["connectionsource"].ToString();

//if (parametre == "0")
//{
//    IDepartement departement = new Departement { Id = 1, Nom = "Finance", Region = "Paris" };
//    IRepository<IDepartement, int> deprepository = new sqlserverdep();
//    deprepository.Add((Departement)departement);

//    IEmployee employee = new Employee { Id = 1, Nom = "Antoine", Salaire = 5000.0m };
//    IRepository<IEmployee, int> emprepository = new sqlserveremp();
//    emprepository.Add(employee);
//}
//else if (parametre == "1")
//{
//    IDepartement departement = new Departement { Id = 1, Nom = "Finance", Region = "Paris" };
//    IRepository<IDepartement, int> deprepository = new postgresdep();
//    deprepository.Add(departement);

//    IEmployee employee = new Employee { Id = 1, Nom = "Antoine", Salaire = 5000.0m };
//    IRepository<IEmployee, int> emprepository = new postgresemp();
//    emprepository.Add(employee);
//}
//if (parametre == "2")
//{
//    IDepartement departement = new DepartementV2 { Id = 1, Nom = "Finance", Region = "Paris" };
//    IRepository<IDepartement, int> deprepository = new sqlserverdep();
//    deprepository.Add((DepartementV2)departement);

//    var employee = new Employee { Id = 1, Nom = "Antoine", Salaire = 5000.0m };
//    IRepository<IEmployee, int> emprepository = new sqlserveremp();
//    emprepository.Add(employee);
//}
//else if (parametre == "3")
//{
//    var departement = new DepartementV2 { Id = 1, Nom = "Finance", Region = "Paris" };
//    IRepository<IDepartement, int> deprepository = new postgresdep();
//    deprepository.Add(departement);

//    var employee = new EmployeeV2 { Id = 1, Nom = "Antoine", Salaire = 5000.0m };
//    IRepository<IEmployee, int> emprepository = new postgresemp();
//    emprepository.Add(employee);
//}