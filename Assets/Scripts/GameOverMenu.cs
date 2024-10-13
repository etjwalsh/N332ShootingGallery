using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreDisplay;
    [SerializeField] private GameController resetTrigger;

    // Update is called once per frame
    void Update()
    {
        scoreDisplay.text = resetTrigger.numHit.ToString();
    }

    public void ExitClicked()
    {
        UnityEditor.EditorApplication.isPlaying = false;

        //for actual build of game 
        // Application.Quit();
    }
}
