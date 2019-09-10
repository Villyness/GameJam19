using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSpawn : MonoBehaviour
{
    // Use the directional buttons to move a slider.
    // Slider displays an image of the currently selected ship.
    // At specific time intervals, slider instantiates the selected ship
    // Randomise the next ship to be selected.

    //Place Ship prefabs here.
    public GameObject[] spawnableShips;

    public Transform spawnLocation;

    public int selectedShip;
    //public int nextShip;

    public List<int> nextShip; 

    public float spawnTime;
    public float currSpawnTime;

    // Speed the slider can move across the screen.
    public float speed = 2.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        selectedShip = 0;

        for(int i = 0; i < 3; i++)
        {
            nextShip.Add(Random.Range(0, spawnableShips.Length-1));
        }
        StartCoroutine(StartCountdown());

    }

    // Update is called once per frame
    void Update()
    {
        // Clamping the position to within the play boundaries.
        Vector3 currentPosition = transform.position;
        currentPosition.x = Mathf.Clamp( currentPosition.x, -5, 5);
        transform.position = currentPosition;
        
        // Move the slider left and right.
        transform.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0) * speed * Time.deltaTime;
    }

    public IEnumerator StartCountdown(float spawnTime = 3.0f)
    {
        currSpawnTime = spawnTime;
        while (currSpawnTime >= 0)
        {
            Debug.Log("Countdown: " + currSpawnTime);
            yield return new WaitForSeconds(1.0f);
            currSpawnTime--;
        }
        StartCoroutine(StartCountdown());
        
        // Spawns a copy of the currently selected ship.
        Instantiate (spawnableShips[selectedShip], spawnLocation.position, spawnLocation.rotation);
        Debug.Log("Spawning #" + selectedShip);
        selectedShip = nextShip[0];
        nextShip.RemoveAt(0);

        // Randomly picks the next ship.
        nextShip.Add(Random.Range(0, spawnableShips.Length-1));
        //selectedShip = nextShip[0];
        
        Debug.Log("Next ship is: #" + selectedShip);
        // TODO: Display an image of the selected ship on the SpawnPoint GameObject as well as the preview screen.
    }
}
