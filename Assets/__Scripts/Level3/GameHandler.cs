using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
  /*  [SerializeField] private GridPrefabVisual gridPrefabVisual;
    [SerializeField] private TMPro.TextMeshPro timerText;
    private Map map;
    private float timer;
    private bool isGameActive;

    // Start is called before the first frame update
    private void Start()
    {
        map = new Map();
        gridPrefabVisual.Setup(map.GetGrid());

        isGameActive = true;

        map.OnEntireMapRevealed += Map_OnEntireMapRevealed;
    }

    private void Map_OnEntireMapRevealed(object sender, System.EventArgs e)
    {
        CMDebug.TextPopupMouse("You Win!");
        isGameActive = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 worldPosition = UtilsClass.GetMouseWorldPosition();
            MapGridObject.Type gridType = map.RevealGridPosition(worldPosition);

            // game over if you hit a mine
            if (gridType == MapGridObjectType.Type.Mine)
            {
                CMDebug.TextPopupMouse("Game Over!");
                isGameActive = false;

            }
        }

        if(Input.GetMouseButtonDown(1))
        {
            map.FlagGridPosition(worldPosition);
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            gridPrefabVisual.SetRevealEntireMap(true);
        }
        if (Input.GetKeyUp(KeyCode.T))
        {
            gridPrefabVisual.SetRevealEntireMap(false);
        }

        HandleTimer();
    }

    private void HandleTimer()
    {
        if(isGameActive)
        {
            timer += timer.deltaTime;
            timerText.text = Mathf.FloorToInt(timer).ToString();
        }
    }






    // getting mouse click position at z = 0;
    public static Vector3 GetMouseWorldPosition()
    {
        Vector3 vec = GetMouseWorldPosition(Input.mousePosition, Camera.main);
        vec.z = 0f;
        return vec;
    }
    public static Vector3 GetMouseWorldPositionWithZ()
    {
        return GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
    }
    public static Vector3 GetMouseWorldPositionWithZ(Camera worldCamera)
    {
        return GetMouseWorldPositionWithZ(Input.mousePosition, wordCamera);
    }
    public static Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera)
    {
        Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
        return worldPosition;
    } */
}
