using System;
using System.Diagnostics;

namespace Doranco132.Console.DesignPattern.Factory
{
    public class FactoryMethod
    {
        public static void Connect(ConnectionType connectionType)
        {
            switch (connectionType)
            {
                case ConnectionType.Oracle:
                   new  FactoryMethod().ConnectToOracle();
                    break;
                case ConnectionType.SqlServer:
                    new FactoryMethod().ConnectToSqlServer();
                    break;
                case ConnectionType.PostgreSQL:
                    new FactoryMethod().ConnectToPostgeSQL();
                    break;
                default:
                    break;
            }
        }

        void ConnectToOracle()
        {
            Debug.WriteLine("Connect to oracle");
        }

        void ConnectToSqlServer()
        {
            Debug.WriteLine("Connect to sql server");
        }

        void ConnectToPostgeSQL()
        {
            Debug.WriteLine("Connect to PostgreSQL");
        }

    }

    public enum ConnectionType
    {
        Oracle,SqlServer,PostgreSQL
    }
}
