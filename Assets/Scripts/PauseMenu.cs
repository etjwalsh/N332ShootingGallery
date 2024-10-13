using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject crosshairs;
    [SerializeField] private GameController resetTrigger;
    [SerializeField] private GameObject menuUI;
    [SerializeField] private GameObject gameUI;


    // Update is called once per frame
    void Update()
    {
        crosshairs.transform.position = Input.mousePosition;
    }

    public void OnResumeClicked()
    {
        Debug.Log("resume clicked");
        //set correct UI
        menuUI.SetActive(false);
        gameUI.SetActive(true);
        //resume time scale
        Time.timeScale = 1;

        resetTrigger.currentState = GameController.GameState.PlayUpdate;
    }
}
