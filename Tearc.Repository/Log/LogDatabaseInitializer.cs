﻿using System;
using System.Data.Entity;
using System.IO;
using System.Reflection;

namespace Tearc.Repository.Log
{
    public class LogDatabaseInitializer : DropCreateDatabaseIfModelChanges<LogContext>
    {
        protected override void Seed(LogContext context)
        {
            try
            {
                // add database initial data here
            }
            catch (Exception ex)
            {
                // delete database if initialization failed
                context.Database.Delete();
                throw ex;
            }
        }

        private void ExecuteSqlFile(LogContext context, string embededFileName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = typeof(LogDatabaseInitializer).Assembly.GetName().Name + "." + embededFileName;

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string sql = reader.ReadToEnd();

                    context.Database.ExecuteSqlCommand(sql);
                }
            }
        }
    }
}