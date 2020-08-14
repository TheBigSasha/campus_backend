using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Web.Http;
using Microsoft.Azure.Mobile.Server;
using Microsoft.Azure.Mobile.Server.Authentication;
using Microsoft.Azure.Mobile.Server.Config;
using ZUMOAPPNAMEService.DataObjects;
using ZUMOAPPNAMEService.Models;
using Owin;

namespace ZUMOAPPNAMEService
{
    public partial class Startup
    {
        public static void ConfigureMobileApp(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            //For more information on Web API tracing, see http://go.microsoft.com/fwlink/?LinkId=620686 
            config.EnableSystemDiagnosticsTracing();

            new MobileAppConfiguration()
                .UseDefaultConfiguration()
                .ApplyTo(config);

            //app.UseAppServiceAuthentication(config);
            // Use Entity Framework Code First to create database tables based on your DbContext
            Database.SetInitializer(new ZUMOAPPNAMEInitializer());

            // To prevent Entity Framework from modifying your database schema, use a null database initializer
            //Database.SetInitializer<ZUMOAPPNAMEContext>(null);      
            //^^^THis used to be commented. Uncommenting it made the change of database fields work. See:
            /*
             *https://social.msdn.microsoft.com/Forums/en-US/186460c0-0bf4-41ed-989e-c5aa1b2c21f8/inserting-record-into-table-error-cannot-insert-the-value-null-into-column-createdat?forum=azuremobile
             * 
             * To change data type:
             * 
             *      DROP TABLE [dbo].[TodoItems];
                    CREATE TABLE [dbo].[TodoItems](
                    Id nvarchar(4000) PRIMARY KEY,
                    Text nvarchar(4000) null,
                    Complete bit not null,
                    Version timestamp not null,
                    CreatedAt datetimeoffset not null,
                    UpdatedAt datetimeoffset null,
                    Deleted bit not null,
                    Name nvarchar(512) null
                    );
                    DROP TABLE [dbo].[TodoItems];

             * Then uncomment the null line, change data type in TodoItem.cs and its all gucci.
             * 
             * It worked on Android but added significant latency.
             */

            MobileAppSettingsDictionary settings = config.GetMobileAppSettingsProvider().GetMobileAppSettings();

            if (string.IsNullOrEmpty(settings.HostName))
            {
                // This middleware is intended to be used locally for debugging. By default, HostName will
                // only have a value when running in an App Service application.
                app.UseAppServiceAuthentication(new AppServiceAuthenticationOptions
                {
                    SigningKey = ConfigurationManager.AppSettings["SigningKey"],
                    ValidAudiences = new[] { ConfigurationManager.AppSettings["ValidAudience"] },
                    ValidIssuers = new[] { ConfigurationManager.AppSettings["ValidIssuer"] },
                    TokenHandler = config.GetAppServiceTokenHandler()
                });
            }
            app.UseWebApi(config);
        }
    }

    public class ZUMOAPPNAMEInitializer : CreateDatabaseIfNotExists<ZUMOAPPNAMEContext>
    {
        protected override void Seed(ZUMOAPPNAMEContext context)
        {
            List<TodoItem> todoItems = new List<TodoItem>
            {
                new TodoItem { Id = Guid.NewGuid().ToString(), Birthday =  "11/11/11", Name = "Bob", Text = "First item", Major = "Software Engineering", Department = "ECSE", Faculty = "Engineering", Rez = "Douglas", Year = 0, Gradyear = 2023, Oncampus = true, Hometown = "Toronto", Location = "McGill Ghetto", Email = "frank.ferrie@mail.mcgill.ca", Insta = "@kerimagical", Facebook = "haha lol", Linkedin = "Sasha Aleshchenko", Snap = "@infernalburrito", Phone = "22222222", Complete = false },
                new TodoItem { Id = Guid.NewGuid().ToString(), Birthday =  "11/11/11",  Name = "Jebediah", Text = "Second item", Major = "Mechanical Engineering", Department = "Mech", Faculty = "Engineering", Rez = "Upper", Year = 1, Gradyear = 2022, Oncampus = true, Hometown = "Vaudreil", Location = "Guy-Concordia", Email = "ben.dover@mail.mcgill.ca", Insta = "@instagram", Facebook = "zucc", Linkedin = "Aasha Sleshchenko", Snap = "@sSSS", Phone = "21421412412", Complete = false, Profilepicurl = "https://logos-download.com/wp-content/uploads/2017/11/McGill_logo.png" },
            };

            foreach (TodoItem todoItem in todoItems)
            {
                context.Set<TodoItem>().Add(todoItem);
            }

            base.Seed(context);
        }
    }
}

