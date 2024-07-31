using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class WorldHandler : MonoBehaviour
{
    public int _width = 10;
    public int _height = 10;
    public float _size = 2f;
    public float yPosition = 0;
    Grid grid;

    // Start is called before the first frame update
    void Start()
    {
        grid = new Grid(_width, _height, _size, new Vector3(0, yPosition));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // grid.SetValue(UtilsClass.GetMouseWorldPosition(), 56);
        }
    }
}
