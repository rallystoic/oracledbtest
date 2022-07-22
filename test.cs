using System;
using Oracle.ManagedDataAccess.Client;
    public class odp_core_config
    {
        
        public async Task TestOracle() {
            // This sample demonstrates how to use ODP.NET Core Configuration API

            // Add connect descriptors and net service names entries.
            OracleConfiguration.OracleDataSources.Add("orclpdb", "(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=<hostname or IP>)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=<service name>)(SERVER=dedicated)))");
            OracleConfiguration.OracleDataSources.Add("orcl", "(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=<hostname or IP>)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=<service name>)(SERVER=dedicated)))");

            // Set default statement cache size to be used by all connections.
            OracleConfiguration.StatementCacheSize = 25;

            // Disable self tuning by default.
            OracleConfiguration.SelfTuning = false;

            // Bind all parameters by name.
            OracleConfiguration.BindByName = true;

            // Set default timeout to 60 seconds.
            OracleConfiguration.CommandTimeout = 60;

            // Set default fetch size as 1 MB.
            OracleConfiguration.FetchSize = 1024 * 1024;

            // Set tracing options
            OracleConfiguration.TraceOption = 1;
            OracleConfiguration.TraceFileLocation = @"D:\traces";
            // Uncomment below to generate trace files
            //OracleConfiguration.TraceLevel = 7;
            
            // Set network properties
            OracleConfiguration.SendBufferSize = 8192;
            OracleConfiguration.ReceiveBufferSize = 8192;
            OracleConfiguration.DisableOOB = true;

            OracleConnection orclCon = null;

            
                // Open a connection
                orclCon = new OracleConnection("user id=hr; password=<password>; data source=orclpdb");
                orclCon.Open();

                // Execute simple select statement that returns first 10 names from EMPLOYEES table
                OracleCommand orclCmd = orclCon.CreateCommand();
                orclCmd.CommandText = "select first_name from employees where rownum <= 10 ";
                OracleDataReader rdr = orclCmd.ExecuteReader();

                while (rdr.Read())
                    Console.WriteLine("Employee Name: " + rdr.GetString(0));

                Console.ReadLine();

                rdr.Dispose();
                orclCmd.Dispose();
                // Close the connection
                if (null != orclCon)
                    orclCon.Close();
        } // fn

        }

