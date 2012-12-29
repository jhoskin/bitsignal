using System;
using System.Linq;
using System.Configuration;
using System.Collections.Generic;
using ServiceStack.Configuration;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.SqlServer;
using ServiceStack.Razor;
using ServiceStack.ServiceInterface;
using ServiceStack.ServiceInterface.Auth;
using ServiceStack.ServiceInterface.ServiceModel;
using ServiceStack.WebHost.Endpoints;
using bitsignal.web.Services;

[assembly: WebActivator.PreApplicationStartMethod(typeof(bitsignal.web.App_Start.AppHost), "Start")]


/**
 * Entire ServiceStack Starter Template configured with a 'Hello' Web Service and a 'Todo' Rest Service.
 *
 * Auto-Generated Metadata API page at: /metadata
 * See other complete web service examples at: https://github.com/ServiceStack/ServiceStack.Examples
 */

namespace bitsignal.web.App_Start
{
	public class AppHost
		: AppHostBase
	{		
		public AppHost() //Tell ServiceStack the name and where to find your web services
			: base("Bitcoin price alerts", typeof(AlertsService).Assembly) { }

		public override void Configure(Funq.Container container)
		{
			//Set JSON web services to return idiomatic JSON camelCase properties
			//ServiceStack.Text.JsConfig.EmitCamelCaseNames = true;
		
			//Configure User Defined REST Paths
            //Routes
            //  .Add<HomeRequest>("/");

			//Uncomment to change the default ServiceStack configuration
			//SetConfig(new EndpointHostConfig {
			//});

			//Enable Authentication
			ConfigureAuth(container);

            Plugins.Add(new RazorFormat());

			//Register all your dependencies
			//container.Register(new TodoRepository());			
		}

		private void ConfigureAuth(Funq.Container container)
		{
            try
            {

                var appSettings = new AppSettings();

                //Default route: /auth/{provider}
                Plugins.Add(new AuthFeature(() => new AuthUserSession(),
                    new IAuthProvider[] {
					new CredentialsAuthProvider(appSettings)
				}));

                //Default route: /register
                Plugins.Add(new RegistrationFeature());

                //Requires ConnectionString configured in Web.Config
                var connectionString = ConnStr.Get();
                container.Register<IDbConnectionFactory>(c =>
                    new OrmLiteConnectionFactory(connectionString, PostgreSqlDialect.Provider));

                container.Register<IUserAuthRepository>(c =>
                    new OrmLiteAuthRepository(c.Resolve<IDbConnectionFactory>()));

                var authRepo = (OrmLiteAuthRepository)container.Resolve<IUserAuthRepository>();
                authRepo.CreateMissingTables();
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.ToString());
            }
		}

		public static void Start()
		{
			new AppHost().Init();
		}
	}

    public class ConnStr
    {
        public static string Get()
        {
            var uriString = ConfigurationManager.AppSettings["ELEPHANTSQL_URL"] ??
                ConfigurationManager.AppSettings["LOCAL_URL"];
            var uri = new Uri(uriString);
            var db = uri.AbsolutePath.Trim('/');
            var user = uri.UserInfo.Split(':')[0];
            var passwd = uri.UserInfo.Split(':')[1];
            var port = uri.Port > 0 ? uri.Port : 5432;
            var connStr = string.Format("Server={0};Database={1};User Id={2};Password={3};Port={4}",
                uri.Host, db, user, passwd, port);
            return connStr;
        }
    }
}
