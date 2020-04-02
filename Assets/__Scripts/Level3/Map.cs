using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map 
{
 /*   public event EventHandler OnEntireMapRevealed;
    private Grid<MapGridObject> grid;

    // randomly placing mines on a 16x32 map
    public Map()
    {
        grid = new Grid<GridObject>(16, 32, 10f, Vector3.zero, (grid<GridObject> global, int x, int y) => new GridObject(global, x, y));

        int minesPlaced = 0;
        int generateMineAmount = 200;

        // placing 200 mines
        while (minesPlaced < generateMineAmount)
        {
            int x = Random.Range(0, grid.GetWidth());
            int y = Random.Range(0, grid.GetHeight());
            
            MapGridObject mapGridObject = grid.GetGridObject(x, y);
            if (mapgridObject.GetGridType() != MapGridObject.Type.Mine)
            {
                mapGridObject.SetGridType(MapGridObject.Type.Mine);
            
                minesPlaced++;
            }
            
        }

        for (int x = 0; x < grid.GetWidth(); x++)
        {
            for (int y = 0; y < grid.GetHeight(); y++)
            {
                MapGridObject mapGridObject = grid.GetGridObject(x, y);
                if (mapGridObject.GetGridType() == MapGridObject.Type.Empty)
                {
                    //calculating neighbours with mines
                    List<MapGridObject> neighbourList = GetNeighborList(x, y);
                    int mineCount = 0;
                    foreach (MapGridObject neighbour in neighbourList)
                    {
                        if (neighbour.GetGridType() == MapGridObject.Type.Mine)
                        {
                            mineCount++;
                        }
                    }

                    switch (mineCount)
                    {
                        case 1: mapGridObject.SetGridType(MapGridObject.Type.MineNum_1); break;
                        case 2: mapGridObject.SetGridType(MapGridObject.Type.MineNum_2); break;
                        case 3: mapGridObject.SetGridType(MapGridObject.Type.MineNum_3); break;
                        case 4: mapGridObject.SetGridType(MapGridObject.Type.MineNum_4); break;
                        case 5: mapGridObject.SetGridType(MapGridObject.Type.MineNum_5); break;
                        case 6: mapGridObject.SetGridType(MapGridObject.Type.MineNum_6); break;
                        case 7: mapGridObject.SetGridType(MapGridObject.Type.MineNum_7); break;
                        case 8: mapGridObject.SetGridType(MapGridObject.Type.MineNum_8); break;

                    }
                }

            }
        }
    
    
    
    }

    public Grid<MapGridObject> GetGrid()
    {
        return grid;
    }

    private List<MapGridObject> GetNeighbourhoodList(MapGridObject mapGridObject)
    {
        return GetNeighborList(mapGridObject.GetX(), mapGridObject.GetY());
    }

    private List<MapGridObject> GetNeighborList(int x, int y)
    {
        List<MapGridObject> neighbourList = new List<MapGridObject>();

        if (x-1 >= 0)
        {
            //left
            neighbourList.Add(grid.GetGridObject(x - 1, y));
            //left down
            if (y - 1 >= 0) neighbourList.Add(grid.GetGridObject(x - 1, y - 1));
            //left up
            if (y + 1 < grid.GetHeight()) neighbourList.Add(grid.GetGridObject(x - 1, y + 1));

        }
        if (x + 1 < grid.GetWIdth())
        {
            //right
            neighbourList.Add(grid.GetGridObject(x + 1, y));
            //right down
            if (y - 1 >= 0) neighbourList.Add(grid.GetGridObject(x + 1, y - 1));
            //right up
            if (y + 1 < grid.GetHeight()) neighbourList.Add(grid.GetGridObject(x + 1, y + 1));
        }
        //up
        if (y - 1 >= 0) neighbourList.Add(grid.GetGridObject(x, y - 1));
        // down
        if (y + 1 < grid.GetHeight()) neighbourList.Add(grid.GetGridObject(x, y + 1));


        return neighbourList;
    }

    public void FlagGridPosition(Vector3 worldPosition)
    {
        MapGridObject mapGridObject = grid.GetGridObject(worldPosition);
        mapGridObject.SetFlagged();
    }

    public MapGridObject.Type RevealGridPosition(Vector3 worldPosition)
    {
        MapGridObject mapGridObject = grid.GetGridObject(worldPosition);
        return RevealGridPosition(mapGridObject);
    }

    public MapGridObject.Type RevealGridPosition(MapGridObject mapGridObject)
    {
        //revealing object
        mapGridObject.Reveal();

        // is empty grid object?
        if (mapGridObject.GetGridType() == MapGridObject.Type.Empty)
        {
            // if empty, reveal connected nodes, keep track of revealed nodes
            List<MapGridObject> alreadyCheckedNeighbourList = new List<MapGridObject>();
            // nodes queued for checking
            List<MapGridObject> checkNeighbourList = new List<MapGridObject>();
            // start checking this node
            checkNeighbourList.Add(mapGridObject);

            // while there's still nodes to check
            while (checkNeighbourList.Count > 0)
            {
                // taking first node to check
                MapGridObject checkMapGridObject = checkNeighbourList[0];
                // remove from queue
                checkNeighbourList.RemoveAt(0);
                alreadyCheckedNeighbourList.Add(checkMapGridObject);

                // go through each neighbour
                foreach (MapGridObject neighbour in GetNeighborList(mapGridObject))
                {
                    if (neighbour.GetGridType() != MapGridObject.Type.Mine)
                    {
                        // if not a mine, reveal
                        neighbour.Reveal();
                        if (!alreadyCheckedNeighbourList.Contains(neighbour))
                        {
                            // if empty, check and add it to queue
                            alreadyCheckedNeighbourList.Add(neighbour);
                        }
                    }
                }
            }
        }
        if (IsEntireMapRevealed())
        {
            //entire map revealed, game win!
            OnEntireMapRevealed?.Invoke(this, EventArgs.Empty);
        }
        return mapGridObject.GetGridType();
    }

    private bool IsEntireMapRevealed()
    {
        for (int x = 0; x < grid.GetWidth(); x++)
        {
            for (int y = 0; y < grid.GetWidth(); y++)
            {
                MapGridObject mapGridObject = grid.GetGridObject(x, y);
                if (mapGridObject.GetGridType() == MapGridObject.Type.Mine)
                {
                    if (!mapGridObject.IsRevealed())
                    {
                        return false; // it's not a mine, not revealed
                    }
                }
            }
        }
        return true;
    } */
}
