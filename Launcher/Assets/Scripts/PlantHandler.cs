using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlantHandler : MonoBehaviour
{
    public GameObject PlantBtn;
    public LayerMask Player;

    private Utils utils;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        utils = new Utils();    
    }

    // Update is called once per frame
    void Update()
    {
        if(utils.createBoxCast(transform, new Vector2(0.5f, 0.5f), 0, 0 , Player))
        {
            Debug.Log("Player is in range");
            PlantBtn.SetActive(true);
        }
        else
        {
            PlantBtn.SetActive(false);
        }
    }
}
