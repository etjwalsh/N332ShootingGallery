using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreDisplay;
    [SerializeField] private GameController resetTrigger;
    [SerializeField] private GameObject crosshairs;

    // Update is called once per frame
    void Update()
    {
        scoreDisplay.text = resetTrigger.numHit.ToString();
        crosshairs.transform.position = Input.mousePosition;
    }

    public void ExitClicked()
    {
        UnityEditor.EditorApplication.isPlaying = false;

        //for actual build of game 
        // Application.Quit();
    }

    public void RetryClicked()
    {
        resetTrigger.currentState = GameController.GameState.MenuEnter;
    }
}
