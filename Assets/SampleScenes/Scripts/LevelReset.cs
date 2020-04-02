using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelReset :MonoBehaviour
{
    public void ResetLevel()
    {
        // reload the scene
        SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
    }

}
