using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FriendSelect
{
    public class CanvasController : MonoBehaviour
    {
        private CanvasSizeChange canvasSizeChange;

        [SerializeField]
        private CanvasScaler[] canvasScaler;
        [SerializeField]
        private RectTransform[] background_and_other;
        [SerializeField]
        private RectTransform[] title_and_other;
        [SerializeField]
        private RectTransform button;

        [SerializeField]
        private List<GameObject> xylophone = new List<GameObject>();
        [SerializeField]
        private List<GameObject> character = new List<GameObject>();
        [SerializeField]
        private GameObject click_area;

        // Use this for initialization
        private void Start()
        {
            Initialized();
        }

        private void Initialized()
        {
            canvasSizeChange = GameObject.Find("GameController").GetComponent<CanvasSizeChange>();

            CanvasSizeSet();

            click_area.SetActive(true);
            for (int i = 0; i < xylophone.Count; i++)
            {
                xylophone[i].SetActive(true);
                xylophone[i].GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 100);
                character[i].SetActive(true);
                character[i].GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 100);
            }
        }

        private void CanvasSizeSet()
        {
            for (int i = 0; i < canvasScaler.Length; i++)
            {
                canvasSizeChange.CanvasScalerSet(canvasScaler[i]);
            }

            for (int j = 0; j < background_and_other.Length; j++)
            {
                canvasSizeChange.SizeDeltaSet(background_and_other[j]);
            }

            for (int k = 0; k < title_and_other.Length; k++)
            {
                canvasSizeChange.TitleSizeDeltaSet(title_and_other[k]);
            }

            canvasSizeChange.ButtonSizeSet(button);

            canvasSizeChange.SelectClickAreaSet(click_area);
        }

        public void SetCharacter(int number)
        {
            byte alpha = 0;
            if (xylophone[number - 1].GetComponent<SpriteRenderer>().color.a == 1)
            {
                alpha = 100;
            }
            else
            {
                alpha = 255;
            }
            xylophone[number - 1].GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, alpha);
            character[number - 1].GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, alpha);
        }
    }
}