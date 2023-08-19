using System;
using UnityEngine;
using JueguitosPro.Views;

namespace JueguitosPro
{
    public class ViewManager
    {
        private RootUI _rootUI;
        
        public ViewManager()
        {
            _rootUI = GameObject.FindObjectOfType<RootUI>();
        }
        
        public T CreateView<T>(string viewPrefabPath, RootUI.CanvasLayer canvasLayer, Action<T> callback = null) where T : ViewBase
        {
            return CreateView<T>(viewPrefabPath, _rootUI.GetCanvasLayer(canvasLayer), callback);
        }

        public T CreateView<T>(string viewPrefabPath, Transform parent = null, Action<T> callback = null) where T : ViewBase
        {
            var loadRequest = Resources.LoadAsync<T>(viewPrefabPath);
            // TODO Find the way to wait if this takes more time than expected

            var asset = loadRequest.asset as T;
            if (asset == null)
            {
                string message = $"Unable to find asset {viewPrefabPath} of type {typeof(T)}";
                throw new UnityException(message);
            }

            return CreateView(asset, parent, callback);
        }

        public T CreateView<T>(T prefab, Transform parent = null, Action<T> callback = null) where T : ViewBase
        {
            var view = GameObject.Instantiate<T>(prefab);
            view.gameObject.name = prefab.gameObject.name;
            view.SetActive(false);
            view.transform.SetParent(parent != null ? parent : _rootUI.GetCanvasLayer(RootUI.CanvasLayer.Overlay), false);
            view.transform.localScale = prefab.transform.localScale;
            
            callback?.Invoke(view);
            return view;
        }
    }
}
