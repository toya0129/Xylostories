using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleController : MonoBehaviour {

    [SerializeField]
    private GameObject gameController;
    private CanvasSizeChange canvasSizeChange;

    [SerializeField]
    private CanvasScaler canvasScaler;

    [SerializeField]
    private RectTransform background_size;

    [SerializeField]
    private RectTransform logo_size;

    [SerializeField]
    private RectTransform start_button;

    // Use this for initialization
    private void Start()
    {
        SetUI();
    }

    private void SetUI()
    {
        canvasSizeChange = gameController.GetComponent<CanvasSizeChange>();
        canvasSizeChange.CanvasScalerSet(canvasScaler);
        canvasSizeChange.SizeDeltaSet(background_size);
        canvasSizeChange.LogoSizeDeltaSet(logo_size);
        canvasSizeChange.StartButtonSize(start_button);
    }

}
