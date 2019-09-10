using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPreview : MonoBehaviour
{
    public GameObject shipSpawnScript;

    public Mesh[] shipMesh = new Mesh[5];

    public GameObject spawnPreviewMesh;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnPreviewMesh.GetComponent<MeshFilter>().mesh = shipMesh[shipSpawnScript.GetComponent<ShipSpawn>().selectedShip];
    }
}
