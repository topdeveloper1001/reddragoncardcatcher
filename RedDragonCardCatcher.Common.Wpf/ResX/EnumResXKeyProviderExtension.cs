using RedDragonCardCatcher.Common.Resources;

namespace RedDragonCardCatcher.Common.Wpf.ResX
{  
    public class EnumResXKeyProviderExtension : ResXKeyProviderExtension<CompositeKeyProvider>
    {
        public EnumResXKeyProviderExtension()
        {
            ResXKeyProvider.BaseKey = "Enum";
        }
    }
}