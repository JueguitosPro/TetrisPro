using System;
using UnityEngine;
using JueguitosPro.Views;

namespace JueguitosPro
{
    public class ViewManager
    {
        private MainUI _mainUI;
        
        public ViewManager()
        {
            _mainUI = GameObject.FindObjectOfType<MainUI>();
        }
        
        public T InstantiateView<T>(string prefabPath, MainUI.CanvasLayer canvasLayer, Action<T> callback = null) where T : ViewBase
        {
            RectTransform parent = _mainUI.GetCanvasLayer(canvasLayer);

            var prefab = GetPrefabFromResources<T>(prefabPath);
            
            var view = GameObject.Instantiate(prefab);
            view.gameObject.name = prefab.gameObject.name;
            view.SetActive(false);
            view.transform.SetParent(parent != null ? parent : _mainUI.GetCanvasLayer(MainUI.CanvasLayer.Overlay), false);
            view.transform.localScale = prefab.transform.localScale;
            
            callback?.Invoke(view);
            return view;
        }

        private T GetPrefabFromResources<T>(string prefabPath) where T : ViewBase
        {
            ResourceRequest loadRequest = Resources.LoadAsync<T>(prefabPath);
            var prefab = loadRequest.asset as T;
            if (prefab == null)
            {
                string message = $"Unable to find asset {prefabPath} of type {typeof(T)}";
                throw new UnityException(message);
            }

            return prefab;
        }
    }
}
