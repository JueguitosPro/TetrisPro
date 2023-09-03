using JueguitosPro.Models;
using JueguitosPro.Views;

namespace JueguitosPro.Controllers
{
    /// <summary>
    /// Base class for the Controllers that handles Game States, used to hold game logic as MVC patter recommends
    /// </summary>
    /// <typeparam name="T">Game State's Model, must be an inheritor of <see cref="ModelBase"/></typeparam>
    /// <typeparam name="U">Game State's View, must be an inheritor of <see cref="ViewBase"/></typeparam>
    public abstract class ControllerBase<T, U>  where T: ModelBase where U : ViewBase
    {
        protected readonly T model;
        protected readonly U view;

        /// <summary>
        /// Constructs a new Controller and assign its model and view fields
        /// </summary>
        /// <param name="model">Game State's Model, must be an inheritor of <see cref="ModelBase"/></param>
        /// <param name="view">Game State's View, must be an inheritor of <see cref="ViewBase"/></param>
        protected ControllerBase(T model, U view)
        {
            this.model = model;
            this.view = view;
        }
    }
}
