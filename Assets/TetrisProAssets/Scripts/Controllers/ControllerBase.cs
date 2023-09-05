using JueguitosPro.Models;
using JueguitosPro.Views;

namespace JueguitosPro.Controllers
{
    /// <summary>
    /// Base class for controllers in the MVC pattern.
    /// </summary>
    /// <typeparam name="T">Type of the model that the controller operates on (must inherit from <see cref="ModelBase"/>).</typeparam>
    /// <typeparam name="U">Type of the view that the controller interacts with (must inherit from <see cref="ViewBase"/>).</typeparam>
    public abstract class ControllerBase<T, U>  where T: ModelBase where U : ViewBase
    {
        protected readonly T model;
        protected readonly U view;
        
        /// <summary>
        /// Constructor to initialize the controller with a model and view.
        /// </summary>
        /// <param name="model">The model instance to be associated with the controller.</param>
        /// <param name="view">The view instance to be associated with the controller.</param>
        protected ControllerBase(T model, U view)
        {
            this.model = model;
            this.view = view;
        }
    }
}
