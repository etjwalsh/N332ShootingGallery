using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject crosshairs;
    [SerializeField] private GameController resetTrigger;
    [SerializeField] private GameObject pauseUI;
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
        pauseUI.SetActive(false);
        gameUI.SetActive(true);

        //re-activate the cubes movement
        for (int i = 0; i < resetTrigger.cubesList.Count; i++)
        {
            //get cube at list position i and turn its gravity back on
            resetTrigger.cubesList[i].GetComponent<Rigidbody>().useGravity = true;
        }

        resetTrigger.currentState = GameController.GameState.PlayUpdate;
    }
}
