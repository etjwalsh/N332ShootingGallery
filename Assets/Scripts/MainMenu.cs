using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void onStartClicked()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void onExitClicked()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
