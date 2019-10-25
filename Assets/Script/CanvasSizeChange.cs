using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasSizeChange : MonoBehaviour
{
    private Vector2 size_date;

    public void CanvasScalerSet(CanvasScaler canvasScaler)
    {
        canvasScaler.referenceResolution = size_date;
    }
    public void SizeDeltaSet(RectTransform rectTransform)
    {
        rectTransform.sizeDelta = size_date;
    }
    public void LogoSizeDeltaSet(RectTransform rectTransform)
    {
        rectTransform.sizeDelta = new Vector2(size_date.x - 100, size_date.y / 2);
    }


    private void Awake()
	{
		SetCanvasSize();
	}

    private void SetCanvasSize()
	{
        size_date = new Vector2(Screen.width, Screen.height);
	}

	#region Setter and Getter
    public Vector2 Size_Data
    {
        get { return size_date; }
    }
	#endregion
}
