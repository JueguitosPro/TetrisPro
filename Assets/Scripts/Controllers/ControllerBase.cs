using JueguitosPro.Models;
using JueguitosPro.Views;

namespace JueguitosPro.Controllers
{
    public abstract class ControllerBase<T, U>  where T: ModelBase where U : ViewBase
    {
        protected readonly T model;
        protected readonly U view;

        protected ControllerBase(T model, U view)
        {
            this.model = model;
            this.view = view;
        }
    }
}
