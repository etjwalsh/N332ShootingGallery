using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject crosshairs;
    [SerializeField] private GameController resetTrigger;

    private void Update()
    {
        crosshairs.transform.position = Input.mousePosition;
    }
    public void OnStartClicked()
    {
        resetTrigger.currentState = GameController.GameState.Play;
    }
    public void OnExitClicked()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
