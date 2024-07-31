using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;


public class Grid
{
    public int[,] gridArray;

    private int _width;
    private int _height;
    private float _size;
    private Vector3 _originPosition;
    private TextMesh[,] debugTextArray;
    


    public Grid(int width, int height, float size, Vector3 originPosition)
    {
        _width = width;
        _height = height;
        _size = size;
        _originPosition = originPosition;

        gridArray = new int[width, height];
        debugTextArray = new TextMesh[width, height];

        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                // debugTextArray[x, y] = UtilsClass.CreateWorldText(gridArray[x, y].ToString(), null, GetWorldPosition(x, y) + new Vector3(_size, size) * 0.5f, 10, Color.white, TextAnchor.MiddleCenter);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.white, 100f);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.white, 100f);
            }
        }

        Debug.DrawLine(GetWorldPosition(0, _height), GetWorldPosition(width, height), Color.white, 100f);
        Debug.DrawLine(GetWorldPosition(_width, 0), GetWorldPosition(width, height), Color.white, 100f);

       // SetValue(2, 1, 56);
    }

    public Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * _size + _originPosition;
    }

    public void SetValue(int x, int y, int value)
    {
        if (x >= 0 && y >= 0 && x < _width && y < _height) {
            gridArray[x, y] = value;
            debugTextArray[x,y].text = gridArray[x, y].ToString();
        }
    }
    
    public void GetXY(Vector3 worldPositon, out int x, out int y)
    {
        x = Mathf.FloorToInt((worldPositon - _originPosition).x / _size);
        y = Mathf.FloorToInt((worldPositon - _originPosition).y / _size);
    }

    public void SetValue(Vector3 worldPosition, int value)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        SetValue(x, y, value);
    }

}

