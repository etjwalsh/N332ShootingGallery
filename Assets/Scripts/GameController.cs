using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //making 
    [SerializeField]
    private LayerMask cubeMask;

    //initialize list for cubes
    protected List<GameObject> cubesList = new List<GameObject>();
    //initialize cube prefab reference
    [SerializeField]
    private GameObject cubePrefab;

    // Start is called before the first frame update
    private void Start()
    {
        //for loop to spawn cubes
        for (int i = 0; i < 10; i++)
        {
            //get random position on screen
            Vector3 randPosInView = new Vector3(Random.Range(-7, 6), 10, Random.Range(-4, 7));
            //instantiate cube at random position
            Instantiate(cubePrefab, randPosInView, Quaternion.identity);

            //add that cube to list
            cubesList.Add(cubePrefab);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        //check for mouse click
        if (Input.GetButtonDown("Fire1"))
        {
            //gets the position of the mouse
            Vector2 mousePos = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(mousePos);
            RaycastHit rch;

            //raycast at mouse click location
            //"out" will mark it as output rather than input
            if (Physics.Raycast(ray, out rch, 1000f, cubeMask))
            {
                // the object we hit
                GameObject objToRemove = rch.collider.gameObject;

                ResetCube(objToRemove);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //check for cube tag on object that entered trigger
        if (other.tag == "Cube")
        {
            //reset cube function call
            ResetCube(other.gameObject);
        }
    }

    //reset cube function to delete cube from list and world,
    //and then add a new cube to the world and then add to the list
    private void ResetCube(GameObject cube)
    {
        //delete cube from list
        cubesList.Remove(cube);

        //delete cube from game
        Destroy(cube);

        //add new cube to game
        Vector3 randPosInView = new Vector3(Random.Range(-10, 10), 10, Random.Range(-7, 7));
        Instantiate(cubePrefab, randPosInView, Quaternion.identity);

        //add new cube to list
        cubesList.Add(cubePrefab);
    }
}