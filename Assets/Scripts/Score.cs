using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Hits;
    [SerializeField] private TextMeshProUGUI Misses;
    [SerializeField] private GameController resetTrigger;
    [SerializeField] private GameObject crosshairs;

    // Update is called once per frame
    void Update()
    {
        Hits.text = resetTrigger.numHit.ToString();
        Misses.text = resetTrigger.numMissed.ToString();
        crosshairs.transform.position = Input.mousePosition;
    }

    public void ExitClicked()
    {
        Debug.Log("Exit clicked");
        UnityEditor.EditorApplication.isPlaying = false;

        //for actual build of game 
        //Application.Quit();
    }
}
