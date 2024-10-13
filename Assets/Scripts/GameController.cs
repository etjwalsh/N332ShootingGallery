using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    //initialize number of cubes to spawn
    [SerializeField] private int numCubes = 10;

    //initialize numbers for scoring
    public int numHit = 0;
    public int numMissed = 0;
    [SerializeField] private int losingCondition;


    //initialize cube layer mask
    [SerializeField] private LayerMask cubeMask;

    //initialize list for cubes
    public List<GameObject> cubesList = new List<GameObject>();
    //initialize cube prefab reference
    [SerializeField] private GameObject cubePrefab;

    //initialize states
    public enum GameState { MenuEnter, PlayUpdate, PlayEnter, PauseEnter, GameOverEnter }
    //set state when you start the game state
    public GameState currentState = GameState.MenuEnter;

    //initialize UI references
    [SerializeField] private GameObject menuUI;
    [SerializeField] private GameObject gameUI;
    [SerializeField] private GameObject pauseUI;
    [SerializeField] private GameObject gameOverUI;

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        //state machine
        switch (currentState)
        {
            //initial menu enter state
            case GameState.MenuEnter:
                {
                    MenuStateEnter();
                    break;
                }
            //initial pause state
            case GameState.PauseEnter:
                {
                    PauseStateEnter();
                    break;
                }
            //initial play state
            case GameState.PlayEnter:
                {
                    PlayStateEnter();
                    break;   
                }
            //state while game is being played
            case GameState.PlayUpdate:
                {
                    PlayStateUpdate();
                    break;
                }
            //initial game over state
            case GameState.GameOverEnter:
                {
                    GameOverStateEnter();
                    break;   
                }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //check for cube tag on object that entered trigger
        if (other.tag == "Cube" && currentState == GameState.PlayUpdate)
        {
            numMissed++;
             //if too many cubes missed, end the game
            if (numMissed >= losingCondition)
            {
                //change to game over state
                currentState = GameState.GameOverEnter;
            }
            //reset cube function call
            ResetCube(other.gameObject);
        }
    }

    //reset cube function to delete cube from list and world,
    //and then add a new cube to the world and then add to the list
    public void ResetCube(GameObject cube)
    {
        //delete cube from list
        cubesList.Remove(cube);

        //delete cube from game
        Destroy(cube);

        //add new cube to game
        Vector3 randPosInView = new Vector3(Random.Range(-10, 10), 10, Random.Range(-7, 7));
        GameObject cubeToAdd = Instantiate(cubePrefab, randPosInView, Quaternion.identity);

        //add new cube to list
        cubesList.Add(cubeToAdd);
    }

    protected void PlayStateUpdate()
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
                numHit++;
                ResetCube(objToRemove);
            }
        }
    }

    protected void PlayStateEnter()
    {
        //set the correct UI to show
        gameUI.SetActive(true);
        menuUI.SetActive(false);

        //for loop to spawn cubes for the first time
        for (int i = 0; i < numCubes; i++)
        {
            //get random position on screen
            Vector3 randPosInView = new Vector3(Random.Range(-7, 6), Random.Range(10,25), Random.Range(-4, 7));
            //instantiate cube at random position
            GameObject cubeToAdd = Instantiate(cubePrefab, randPosInView, Quaternion.identity);

            //add that cube to list
            cubesList.Add(cubeToAdd);
        }
        //change to play state update
        currentState = GameState.PlayUpdate;
    }
    //method for initializing the menu
    protected void MenuStateEnter()
    {           
        menuUI.SetActive(true);
        gameUI.SetActive(false);
        pauseUI.SetActive(false);
        gameOverUI.SetActive(false);

        //reset all values if the game was restarted
        numHit = 0;
        numMissed = 0;

        //checking to make sure this isn't the first time we open the game
        while (cubesList.Count > 0)
        {
            //clear cubes list
            GameObject cube = cubesList[0];
            Destroy(cube);
            cubesList.RemoveAt(0);
        }
    }
    
    //method to initialize the game pause menu
    protected void PauseStateEnter()
    {
        //set correct UI
        gameUI.SetActive(false);
        pauseUI.SetActive(true);

        for (int i = 0; i < cubesList.Count; i++)
        {
            //turn off gravity
            cubesList[i].GetComponent<Rigidbody>().isKinematic = true;
        }        
    }
    //method to initialize the game over state
    protected void GameOverStateEnter()
    {
        gameUI.SetActive(false);
        gameOverUI.SetActive(true);
    }
}