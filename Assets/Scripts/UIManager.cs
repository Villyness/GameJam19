using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject shipScript;

    public int[] shipSpawn = new int[3];

    public Image next1;
    public Image next2;
    public Image next3;

    public Image hold;

    public Sprite[] shipSprites = new Sprite[5];

    public GameObject pilot;

    public Slider healthbarRed;
    public Slider healthbarGreen;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        next1.sprite = shipSprites[shipScript.GetComponent<ShipSpawn>().nextShip[0]];
        next2.sprite = shipSprites[shipScript.GetComponent<ShipSpawn>().nextShip[1]];
        next3.sprite = shipSprites[shipScript.GetComponent<ShipSpawn>().nextShip[2]];

        if(pilot != null)
        {
            healthbarGreen.value = pilot.GetComponent<QueenController>().health;
        }
        
    }
}
