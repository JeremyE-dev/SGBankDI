using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using SGBank.Models.Interfaces;
using System.Configuration;
using SGBank.Data;

namespace SGBank.BLL
{
    public static class DIContainer
    {
        public static IKernel Kernel = new StandardKernel();
        
        static DIContainer()
        {
            string chooserType = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (chooserType)
            {
                case "FreeTest":
                    Kernel.Bind<IAccountRepository>().To<FreeAccountTestRepository>();
                    break;
                    
                case "BasicTest":
                    Kernel.Bind<IAccountRepository>().To<BasicAccountTestRepository>();
                    break;
                
                case "PremiumTest":
                    Kernel.Bind<IAccountRepository>().To<PremiumAccountTestRepository>();
                    break;
                
                case "File":
                    Kernel.Bind<IAccountRepository>().To<FileAccountRepository>();
                    break;
                
                default:
                    throw new Exception("Mode value in app config is not valid");
            }



        }
    }
}
