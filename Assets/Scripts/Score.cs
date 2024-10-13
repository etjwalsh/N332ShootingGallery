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

    private void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Hits.text = resetTrigger.numHit.ToString();
        Misses.text = resetTrigger.numMissed.ToString();
        crosshairs.transform.position = Input.mousePosition;
    }

    public void PauseClicked()
    {
        resetTrigger.currentState = GameController.GameState.PauseEnter;
    }
}
