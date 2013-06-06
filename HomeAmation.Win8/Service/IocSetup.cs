using GalaSoft.MvvmLight.Ioc;
using HomeAmation.Pcl.Service;

namespace HomeAmation.Service
{
    public class IocSetup
    {
        static IocSetup()
        {
            // SimpleIoc.Default.Register<IWeightService>(() => new WeightService());
            SimpleIoc.Default.Register<IHomeAmationDataService>(() => new HomeAmationDataService());
            // SimpleIoc.Default.Register<INavigationService>(() => new NavigationService());
            // SimpleIoc.Default.Register<SkyDriveWeightService>(() => new SkyDriveWeightService());
        }
    }
}
