using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{
    // Start is called before the first frame update
    public string sceneName;

    public void Open()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ExitGame()
    {
          #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
          #else
              Application.Quit();
          #endif
    }
}
