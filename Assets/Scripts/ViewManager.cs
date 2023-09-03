using Cysharp.Threading.Tasks;
using UnityEngine;
using JueguitosPro.Views;
using Object = UnityEngine.Object;

namespace JueguitosPro
{
    /// <summary>
    /// Handles instantiation of the views for each GameState
    /// </summary>
    public class ViewManager
    {
        private MainUI mainUI;
        
        /// <summary>
        /// Manager's constructor and takes the parent object of the Views
        /// </summary>
        public ViewManager()
        {
            mainUI = GameObject.FindObjectOfType<MainUI>();
        }
        
        /// <summary>
        /// Instantiates a new view from a prefabPath
        /// </summary>
        /// <param name="prefabPath">Location of the View Prefab, this should be under Resources folder</param>
        /// <param name="canvasLayer">Canvas used to hold the new View</param>
        /// <typeparam name="T">Type of the View, must be inheritor of <see cref="ViewBase"/></typeparam>
        /// <returns>Returns the View after instantiation, ready to use</returns>
        public async UniTask<T> InstantiateView<T>(string prefabPath, MainUI.CanvasLayer canvasLayer) where T : ViewBase
        {
            RectTransform parent = mainUI.GetCanvasLayer(canvasLayer);

            var prefab = await GetPrefabFromResources<T>(prefabPath);
            
            var view = GameObject.Instantiate(prefab);
            view.gameObject.name = prefab.gameObject.name;
            view.SetActive(false);
            view.transform.SetParent(parent != null ? parent : mainUI.GetCanvasLayer(MainUI.CanvasLayer.Overlay), false);
            view.transform.localScale = prefab.transform.localScale;
            
            return view;
        }

        private async UniTask<T> GetPrefabFromResources<T>(string prefabPath) where T : ViewBase
        {
            Object loadRequest = await Resources.LoadAsync<T>(prefabPath);
            var prefab = loadRequest as T;
            if (prefab == null)
            {
                string message = $"Unable to find asset {prefabPath} of type {typeof(T)}";
                throw new UnityException(message);
            }

            return prefab;
        }
    }
}
