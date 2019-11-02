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
    public void TitleSizeDeltaSet(RectTransform rectTransform)
    {
        rectTransform.sizeDelta = new Vector2(size_date.x, 200);
        rectTransform.gameObject.GetComponent<Text>().fontSize = (int)size_date.x / 10 - 50;
    }

    // Menu Scene
    public void MenuAreaSet(GameObject obj)
    {
        Vector2 waku_size = new Vector2(size_date.x / 3 - 30, size_date.y / 3);
        Vector2 size = new Vector2(waku_size.x * 0.95f, waku_size.y - waku_size.x * 0.05f);
        obj.GetComponent<GridLayoutGroup>().cellSize = waku_size;

        for (int i = 0; i < obj.transform.childCount; i++)
        {
            for (int j = 0; j < obj.transform.GetChild(i).childCount; j++)
            {
                // waku
                if (j == 0)
                {
                    obj.transform.GetChild(i).GetChild(j).gameObject.GetComponent<RectTransform>().sizeDelta = waku_size;
                }
                // background
                else
                {
                    obj.transform.GetChild(i).GetChild(j).gameObject.GetComponent<RectTransform>().sizeDelta = size;
                }

                // Text
                if (j == obj.transform.GetChild(i).childCount - 1)
                {
                    int font = (int)(size.x * 0.15f);
                    obj.transform.GetChild(i).GetChild(j).gameObject.GetComponent<Text>().fontSize = font;
                    obj.transform.GetChild(i).GetChild(j).gameObject.GetComponent<Outline>().effectDistance = new Vector2(font * 0.05f, font * 0.05f);
                }

                if (obj.transform.GetChild(i).GetChild(j).childCount != 0)
                {
                    for (int k = 0; k < obj.transform.GetChild(i).GetChild(j).childCount; k++)
                    {
                        switch (i)
                        {
                            case 0:
                                obj.transform.GetChild(i).GetChild(j).GetChild(k).gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(size.x / 6, size.y / 4);
                                break;
                            case 2:
                                // バナナ
                                if (k == 0)
                                {
                                    obj.transform.GetChild(i).GetChild(j).GetChild(k).gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(size.x / 2, size.y * 2 / 3);
                                }
                                // ニンジン
                                else
                                {
                                    obj.transform.GetChild(i).GetChild(j).GetChild(k).gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(size.x * 2 / 3, size.y);
                                }
                                break;
                            case 5:
                                obj.transform.GetChild(i).GetChild(j).GetChild(k).gameObject.GetComponent<RectTransform>().sizeDelta = size;
                                if (k == 1)
                                {
                                    obj.transform.GetChild(i).GetChild(j).GetChild(k).gameObject.GetComponent<RectTransform>().localPosition = new Vector3(size.x / 2, 0, 0);
                                }
                                break;
                            default:
                                obj.transform.GetChild(i).GetChild(j).GetChild(k).gameObject.GetComponent<RectTransform>().sizeDelta = size;
                                break;
                        }
                    }
                }
            }
        }
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
