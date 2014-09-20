using BusinessLogic.Interfaces;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using CommonUtils;
using DAO;
using NUnit.Framework;

namespace NUnit.Environment {
    public class DbResetBase {
        [SetUp]
        public void SetUp() {
            ConfigHelper.LoadXml(true);
            Connector.ConnectionString = ConfigHelper.FirstTagWithPropertyText("db-connection", "db-name", "master");
            InitBusinessLogic();
        }

        private void InitBusinessLogic() {
            var container = new WindsorContainer();
            container.Register(
                Component.For<IBusinessLogic>().LifestyleSingleton().Instance(new BusinessLogic.BusinessLogic()));
            ServiceManager<IBusinessLogic>.Instance.DependencyContainer = container;
        }
    }
}