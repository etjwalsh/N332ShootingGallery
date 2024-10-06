using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Hits;
    [SerializeField] private TextMeshProUGUI Misses;

    // Start is called before the first frame update
    void Start()
    {
        Hits.text = "hi";
        Misses.text = "bye";
    }

    // Update is called once per frame
    void Update()
    {
    }
}
