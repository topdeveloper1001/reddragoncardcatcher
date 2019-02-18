using System.Windows.Data;

namespace RedDragonCardCatcher.Common.Wpf.ResX
{   
    public abstract class ResXParamBase : Binding
    {
        protected ResXParamBase()
            : this(null)
        {
        }

        protected ResXParamBase(string path)
            : base(path)
        {
            Mode = BindingMode.OneWay;
            FallbackValue = string.Empty;
        }
    }
}