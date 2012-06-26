using System;
using Ninject;
using Remindr.Model.Services;
using Remindr.Model.Database;
using Remindr.Twilio;

namespace Remindr.Model.Ninject
{
    public static class NinjectProvider
    {
        private static StandardKernel kernel = CreateKernel();

        private static StandardKernel CreateKernel()
        {
            kernel = new StandardKernel();
            RegisterServices(kernel);
            return kernel;
        }

        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ITextService>().To<TextService>();
            kernel.Bind<IDatabaseAccess>().To<MongoAccess>();
        }

        public static T GetInstance<T>()
        {
            return kernel.Get<T>();
        }        
    }
}
