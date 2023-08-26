using System;
using UnityEngine;

namespace JueguitosPro
{
    public class MainUI : MonoBehaviour
    {
        [SerializeField] private RectTransform overlayCanvas;
        [SerializeField] private RectTransform debugCanvas;
        
        public enum CanvasLayer
        {
            Overlay,
            Debug,
        }

        public RectTransform GetCanvasLayer(CanvasLayer layer)
        {
            switch (layer)
            {
                case CanvasLayer.Overlay:
                    return overlayCanvas;
                case CanvasLayer.Debug:
                    return debugCanvas;
                default:
                    throw new ArgumentOutOfRangeException(nameof(layer), layer, "Unsupported CanvasLayer");
            }
        }
    }
}
