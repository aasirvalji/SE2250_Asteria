using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Grid<TGridObject>
{

    public event EventHandler<OnGridObjectChangedEventArgs> OnGridObjectChanged;
    public class OnGridObjectChangedEventArgs : EventArgs
    {
        public int x;
        public int y;
    }


    private int width;
    private int height;
    private float cellSize;
    private Vector3 originPosition;
    private int[,] gridArray;

    public Grid(int width, int height, float cellSize, Vector3 originPosition, Func<Grid<TGridObject>, int, int, TGridObject> createGridObject)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.originPosition = originPosition;
        /*
        gridArray = new TGridObject[width, height];

        gridArray = new int[width, height];

        
        for (int i =0; i<gridArray.GetLength(0); i++)
        {
            for (int j = 0; j < gridArray.GetLength(1); j++)
            {
                gridArray[x, y] = createGridObject(this, x, y);
            }
        }

        bool showDebug = true;
        if (showDebug)
        {
            TextMesh[,]debugTextArray = new TextMesh[width, height];

            for (int x = 0; x<gridArray.GetLength(0); x++)
            {
                for (int y = 0; y < gridArray.GetLength(0); y++)
                {
                    debugTextArray[x, y] = UtilsClass.CreateWorldText(gridArray[x, y]?.ToString(), null, GetWorldPosition(x, y) + new Vector3(cellSize, cellSize) * .5f, 30, Color.white, TextAnchor.MiddleCenter);
                    Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), ConsoleColor.White, 100f);
                    Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), ConsoleColor.White, 100f);

                }
            }
            Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), ConsoleColor.White, 100f);
            Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), ConsoleColor.White, 100f);


        }

    }

    private Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * cellSize + originPosition;
    }

    private void GetXY(Vector3 worldPosition, out int x, out int y)
    {
        x = Mathf.FloorToInt((worldPosition - originPosition).x / cellSize);
        y = Mathf.FloorToInt((worldPosition - originPosition).y / cellSize);
    }

    public void SetValue(int x, int y, TGridObject value)
    {
        if (x >= 0 && y >= 0 && width && y < height)
        {
            gridArray[x, y] = value;
            if (OnGridObjectChanged != null) OnGridObjectChanged(this, new OnGridObjectChangedEventArgs { x = x, y = y });
        }
    }

    public void SetValue(Vector3 worldPosition, TGridObject value)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        SetValue(x, y, value);
    }

    public TGridObject GetValue(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            return gridArray[x, y];
        } else
        {
            return default(TGridObject);
        }
        
    }
    
    public TGridObject GetValue(Vector3 worldPosition)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        return GetValue(x, y);
    }

        */


        /* for heat map
        public void AddValue(Vector3 worldPosition, int value, int fullValueRange, int totalRange)
        {
            int lowerValueAmount = Mathf.RoundToInt((float)value / (totalRange - fullValueRange));

            GetXY(worldPosition, out int originX, out int originY);
            for (int x = 0; x < totalRange; x++)
            {
                for (int y = 0; y < totalRange - x; y++)
                {
                    int radius = x + y;
                    int addValueAmount = value;
                    if(radius >= fullValueRange)
                    {
                        addValueAmount -= lowerValueAmount * (radius - fullValueRange);
                    }

                    AddValue(originX + x, originY + y, addValueAmount);

                    if (x!=0)
                    {
                        AddValue(originaX - x, originY + y, addValueAmount);
                    }

                    if(y!=0)
                    {
                        AddValue(originX + x, originY - y, addValueAmount);
                        if (x!= 0)
                        {
                            AddValue(originX - x, originY - y, addValueAmount);
                        }
                    }
                }
            }
        } */
    }
}
/*
    private Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * cellSize;
    }

    public static TextMesh CreateWorldText(string text, Transform parent = null, Vector3 localPosition = default(Vector3), int fontSize = 40, 
        Color color, TextAnchor textAnchor, TextAlignment textAlignment, SortingOrder sortingOrder)
    {
        if (color = null) color = Color.white;
        return CreateWorldText(parent, text, localPosition, fontSize, (Color)color, textAnchor, textAlignment, sortingOrder);
    }

    public static TextMesh CreateWorldText(Transform parent, string text, Vector3 localPosition, int fontSize, Color color, TextAnchor textAnchor, TextAlignment textAlignment, SortingOrder sortingOrder)
    {
        GameObject gameObject = new GameObject("World_Text", typeof(TextMesh));
        Transform transform = gameObject.transform;
        transform.SetParent(parent, false);
        transform.localPosition = localPosition;
        TextMesh textMesh = gameObject.GetComponent<textMesh>();
        textMesh.anchor = textAnchor;
        textMesh.alignment = textAlignment;
        textMesh.text = text;
        textMesh.fontSize = fontSize;
        textMesh.color = color;
        textMesh.GetComponent<MeshRenderer>().sortingOrder = sortingOrder;
        return textMesh;
    }
    
} */
