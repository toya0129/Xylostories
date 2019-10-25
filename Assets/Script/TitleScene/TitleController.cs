using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleController : MonoBehaviour {

    [SerializeField]
    private GameObject gameController;

    [SerializeField]
    private CanvasScaler canvasScaler;

    [SerializeField]
    private RectTransform background_size;

    [SerializeField]
    private RectTransform logo_size;

    // Use this for initialization
    private void Start()
    {
        SetUI();
    }

    private void SetUI()
    {
        gameController.GetComponent<CanvasSizeChange>().CanvasScalerSet(canvasScaler);
        gameController.GetComponent<CanvasSizeChange>().BackgroundSizeDeltaSet(background_size);
        gameController.GetComponent<CanvasSizeChange>().LogoScaleSet(logo_size);
    }

}
