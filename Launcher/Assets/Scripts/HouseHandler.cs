using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseHandler : MonoBehaviour
{
    public GameObject House;
    Utils utils = new Utils();

    public LayerMask Player;
    

    // Update is called once per frame
    void Update()
    {
        if(utils.createBoxCast(transform, new Vector2(0.8f, 0.05f), 0, -0.08f, Player)){
            House.SetActive(false);
        }
        if(utils.createBoxCast(transform, new Vector2(0.8f, 0.05f), 0, -0.15f, Player)){
            House.SetActive(true);
        }
    }
}
