using UnityEngine;

public class TimerText : MonoBehaviour
{
    private Renderer textRender;

    public void Start()
    {
        textRender = GetComponent<Renderer>();
        textRender.sortingLayerID = SortingLayer.NameToID("Foreground");
    }
}
