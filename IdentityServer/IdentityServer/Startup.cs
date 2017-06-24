using IdentityServer.Auth;
using IdentityServer3.Core.Configuration;
using Owin;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace IdentityServer
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseIdentityServer(new IdentityServerOptions
            {
                SiteName = "Embedded IdentityServer",
                SigningCertificate = LoadCertificate(),

                Factory = new IdentityServerServiceFactory()
                    .UseInMemoryUsers(Users.Get())
                    .UseInMemoryClients(Clients.Get())
                    .UseInMemoryScopes(Scopes.Get()),
                RequireSsl = false,
                LoggingOptions = new LoggingOptions
                {

                    EnableWebApiDiagnostics = true,
                    WebApiDiagnosticsIsVerbose = true,
                    EnableHttpLogging = true,
                    EnableKatanaLogging = true,
                }

            });


            Log.Logger = new LoggerConfiguration()
                        .WriteTo
                        .LiterateConsole(outputTemplate: "{Timestamp:HH:mm} [{Level}] ({Name:l}){NewLine} {Message}{NewLine}{Exception}")
                        .CreateLogger();
        }

        private static X509Certificate2 LoadCertificate()
        {
            var cert = new X509Certificate2();
            #region 如果由于csp原因无法解析privatekey，则直接生成证书文件

            try
            {
                cert = new X509Certificate2(
           Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"IdentityConfig\idsrv3.pfx"), "idsrv3test");

                var tempKey = cert.PrivateKey;
            }
            catch (System.Security.Cryptography.CryptographicException)
            {
                // 获取证书  
                X509Certificate2 c1 = DataCertificate.GetCertificateFromStore("Dysoft");
                if (c1 == null)
                {
                    // 在personal（个人）里面创建一个foo的证书  
                    DataCertificate.CreateCertWithPrivateKey("Dysoft", "C:\\Program Files (x86)\\Windows Kits\\8.1\\bin\\x64\\makecert.exe");
                    c1 = DataCertificate.GetCertificateFromStore("Dysoft");
                }
                cert = c1;
            }

            #endregion 
            return cert;
        }
    }
}