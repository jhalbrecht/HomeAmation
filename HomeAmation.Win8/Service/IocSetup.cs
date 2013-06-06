using GalaSoft.MvvmLight.Ioc;
using HomeAmation.Pcl.Service;

namespace HomeAmation.Service
{
    public class IocSetup
    {
        static IocSetup()
        {
            // Interface from .Pcl implementation in .Win8 and .Wp8
            SimpleIoc.Default.Register<IHomeAmationDataService>(() => new HomeAmationDataService());
        }
    }
}
