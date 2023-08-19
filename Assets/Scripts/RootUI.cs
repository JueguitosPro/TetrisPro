using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JueguitosPro
{
    public class RootUI : MonoBehaviour
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
