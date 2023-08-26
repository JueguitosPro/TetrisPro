using Cysharp.Threading.Tasks;
using UnityEngine;
using JueguitosPro.Views;
using Object = UnityEngine.Object;

namespace JueguitosPro
{
    public class ViewManager
    {
        private MainUI mainUI;
        
        public ViewManager()
        {
            mainUI = GameObject.FindObjectOfType<MainUI>();
        }
        
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
