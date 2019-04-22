using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour {

    [SerializeField]
    private GameObject titleButton, mainButton, endButton;

    private void Awake()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        titleButton.active = true;
        mainButton.active = true;
        endButton.active = true;
        switch (sceneName)
        {
            case "Title":
                titleButton.active = false;
                break;
            case "Main":
                mainButton.active = false;
                break;
            case "End":
                endButton.active = false;
                break;
        }
    }

    public void GoToTileScene()
    {
        Debug.Log("Tile Button is clicked.");
        SceneManager.LoadScene("Title");
    }

    public void GoToMainScene()
    {
        Debug.Log("Main Button is clicked.");
        SceneManager.LoadScene("Main");
    }

    public void GoToEndScene()
    {
        Debug.Log("End Button is clicked.");
        SceneManager.LoadScene("End");
    }
}
