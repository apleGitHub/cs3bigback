using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMainMenu : MonoBehaviour
{
    public string SceneName;

    public void go() {
        SceneManager.LoadScene(SceneName);
    }
}
