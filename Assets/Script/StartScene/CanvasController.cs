using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace StartScene
{
    public class CanvasController : MonoBehaviour
    {
        private CanvasSizeChange canvasSizeChange;

        private GameControllerScript gameControllerScript;

        [SerializeField]
        private RectTransform[] background_and_other;

        [SerializeField]
        private CanvasScaler canvasScaler;

        // Use this for initialization
        void Start()
        {
            gameControllerScript = GameObject.Find("GameController").GetComponent<GameControllerScript>();
            canvasSizeChange = GameObject.Find("GameController").GetComponent<CanvasSizeChange>();
            SetUI();
        }

        private void SetUI()
        {
            canvasSizeChange.CanvasScalerSet(canvasScaler);

            for(int i = 0; i < background_and_other.Length; i++)
            {
                canvasSizeChange.SizeDeltaSet(background_and_other[i]);
            }
        }

        public void LoadToMenuScene()
        {
            StopAllCoroutines();
            gameControllerScript.OnLoadMenuScene();
        }
    }
}
