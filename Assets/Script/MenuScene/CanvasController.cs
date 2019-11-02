using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MenuScene
{
    public class CanvasController : MonoBehaviour
    {
        private CanvasSizeChange canvasSizeChange;

        private CanvasScaler canvasScaler;

        [SerializeField]
        private RectTransform[] background_and_other;

        [SerializeField]
        private RectTransform title;

        [SerializeField]
        private GameObject menu_area;

        // Use this for initialization
        private void Start()
        {
            Initialized();
        }

        private void Initialized()
        {
            canvasSizeChange = GameObject.Find("GameController").GetComponent<CanvasSizeChange>();
            canvasScaler = this.gameObject.GetComponent<CanvasScaler>();

            canvasSizeChange.CanvasScalerSet(canvasScaler);

            for (int i = 0; i < background_and_other.Length; i++)
            {
                canvasSizeChange.SizeDeltaSet(background_and_other[i]);
            }

            // Title
            canvasSizeChange.TitleSizeDeltaSet(title);

            // Menu
            canvasSizeChange.MenuAreaSet(menu_area);
        }
    }
}
