using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnUI : MonoBehaviour
{
    public RectTransform MainCanvas;

    public List<RectTransform> ListBtn;
    // Start is called before the first frame update
    void Start()
    {
        foreach(RectTransform btn in ListBtn){
            float x = MainCanvas.sizeDelta.x;
            int width = Mathf.FloorToInt(x / 9);

            btn.sizeDelta = new Vector2(width, width);
        }
    }
}
