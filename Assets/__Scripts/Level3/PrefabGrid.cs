using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// this is to set the prefabs on the grid
public class PrefabGrid : MonoBehaviour
{/*
    public static PrefabGrid Instance { get; private set; }

    [SerializeField] 
    private Transform pfGridPrefabVisualNode;

    [SerializeField]
    private Sprite flagSprite;

    [SerializeField]
    private Sprite mineSprite;

    private List<Transform> visualNodeList;
    private Transform[,] visualNodeArray;
    private Grid<PrefabGridObject> grid;
    private bool revealEntireMap;

    private void Awake()
    {
        Instance = this;
        visualNodeList = new List<Transform>();

    }

    public void SetRevealEntireMap(bool revealEntireMap)
    {
        this.revealEntireMap = revealEntireMap;
    }

    public void Setup(Grid<PrefabGridObject> grid)
    {
        this.grid = grid;
        visualNodeArray = new Transform[grid.GetWidth(), grid.GetHeight()];

        for (int x = 0; x < grid.GetWidth(); x++)
        {
            for (int y = 0; y < grid.GetHeight(); y++)
            {
                Vector3 gridPosition = new Vector3(x, y) * grid.GettCellSize() + Vector3.one * grid.GetCellSize() * .5f;
                Transform visualNode = CreateVisualNode(gridPosition);
                visualNodeArray[x, y] = visualNode;
                visualNodeList.Add(visualNode);
            }
        }
        HideNodeVisuals();

        grid.OnGridObjectChanged += Grid_OnGridObjectChanged;
    }

    private void Grid_OnGridObjectChanged(object sender, Grid<PrefabGridObject>.OnGridObjectChangedEventArgs e)
    {
        UpdateVisual(grid);
    }

    public void UpdateVisual(Grid<PrefabGridObject> grid)
    {
        HideNodeVisuals();
        for (int x = 0; x < grid.GetWidth(); x++)
        {
            for (int y = 0; y < grid.GetHeight(); y++)
            {
                PrefabGridObject gridObject = grid.GetGridObject(x, y);

                Transform visualNode = visualNodeArray[x, y];
                visualNode.gameObject.SetActive(true);
                SetupVisualNode(visualNode, gridObject);
            }
        }
    }

    private void HideNodeVisuals()
    {
        foreach (Tranform visualNodeTransform in visualNodeList)
        {
            visualNodeTransform.gameObject.SetActive(false);
        }
    }
    private Transform CreateVisualNode(Vector3 position)
    {
        Transform visualNodeTransform = Instantiate(pfGridPrefabVisualNode, position, Quaternion.idenity);
        return visualNodeTransform;
    }

    private void SetupVisualNode(Transform visualNodeTransform, GridObject gridObject)
    {
        Transform background = visualNodeTransform.Find("backgroundSprite"); // unsure for this part need to create a node
        TextMeshPro indicatorText = visualNodeTransform.Find("mindIndicatorText").GetComponent<TextMeshPro>();
        Transform hiddenTransform = visualNodeTransform.Find("hiddenTransform");

        if (mapGridObject.IsRevealed() | revealEntireMap) // for if node is revealed
        {
            hiddenTransform.gameObject.SetActive(false);

            switch (gridObject.GetGridType())
            {
                default:
                // if empty, hide icon and number
                case GridObject.Type.Empty:
                    indicatorText.gameObject.SetActive(false);
                    iconSpriteRenderer.gameObject.SetActive(false);
                    break;
                // show mine if theres a mine
                case GridObject.Type.Mine:
                    indicatorText.gameObject.SetActive(false);
                    iconSpriteRenderer.gameObject.SetActive(true);
                    iconSpriteRenderer.sprite = mineSprite;
                    break;
                case GridObject.Type.MineNum_1:
                case GridObject.Type.MineNum_2:
                case GridObject.Type.MineNum_3:
                case GridObject.Type.MineNum_4:
                case GridObject.Type.MineNum_5:
                case GridObject.Type.MineNum_6:
                case GridObject.Type.MineNum_7:
                case GridObject.Type.MineNum_8:
                    indicatorText.gameObject.SetActive(true);
                    iconSpriteRenderer.gameObject.SetActive(true);
                    switch (mapGridObject.GetGridType())
                    {
                        default:
                        case gridObject.Type.MineNum_1: indicatorText.SetText("1"); break;
                        case gridObject.Type.MineNum_2: indicatorText.SetText("2"); break;
                        case gridObject.Type.MineNum_3: indicatorText.SetText("3"); break;
                        case gridObject.Type.MineNum_4: indicatorText.SetText("4"); break;
                        case gridObject.Type.MineNum_5: indicatorText.SetText("5"); break;
                        case gridObject.Type.MineNum_6: indicatorText.SetText("6"); break;
                        case gridObject.Type.MineNum_7: indicatorText.SetText("7"); break;
                        case gridObject.Type.MineNum_8: indicatorText.SetText("8"); break;
                    }
                    break;


            }
        }else
        {
            hiddenTransform.gameObject.SetActive(true);

            if (mapGridObject.IsFlagged())
            {
                iconSptriteRenderer.sprite = flagSprite;
            }
        }
    } */
}
