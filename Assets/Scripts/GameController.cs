using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //initialize list for cubes
    protected List<GameObject> cubesList;
    //initialize cube prefab reference
    public GameObject cubePrefab;

    // Start is called before the first frame update
    private void Start()
    {

        //for loop to spawn cubes
        for (int i = 0; i < 10; i++)
        {
            //get random position on screen
            //Camera.main.ViewportToWorldPoint(
            Vector3 randPosInView = new Vector3(Random.Range(-10, 10), 0, Random.Range(-7, 7));
            //instantiate cube at random position
            Instantiate(cubePrefab, randPosInView, Quaternion.identity);
            //add that cube to list
            // cubesList.Add(cubePrefab);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        //check for mouse click
        if (Input.GetMouseButtonDown(0))
        {
            //gets the position of the mouse
            Vector2 mousePos = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(mousePos);
            RaycastHit rch;

            //raycast at mouse click location
            //"out" will mark it as output rather than input
            if (Physics.Raycast(ray, out rch))
            {
                // the object we hit
                GameObject objToRemove = rch.collider.gameObject;
                //delete object clicked from list
                // cubesList.Remove(objToRemove);
                //delete object clicked from game
                Destroy(objToRemove);

                //set random position variable
                Vector3 randPosInView = new Vector3(Random.Range(-10, 10), 0, Random.Range(-7, 7));
                //create new cube in view
                Instantiate(cubePrefab, randPosInView, Quaternion.identity);
                //add new cube to list
                // cubesList.Add(cubePrefab);
            }
        }
    }
}