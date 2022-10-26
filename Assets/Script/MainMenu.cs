using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public void OnsceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if ((int)mode + 1 == scene.buildIndex)
        {
            GameObject exit = GameObject.FindWithTag("Exit");
            Button button = exit.GetComponent<Button>();
            button.onClick.AddListener(Exit);
        }
    }
    public void Level1()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene("SampleScene");
        SceneManager.sceneLoaded += OnsceneLoaded;
    }
   public void Exit()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene("StartScene");
    }
}
