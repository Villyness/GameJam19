using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixMaster : MonoBehaviour
{
    // Variables
    public AudioSource MyJams;
    public AudioClip ShipOnShipJam;
    public AudioClip BulletHitShipJam;
    public AudioClip HomingHitShipJam;
    public AudioClip ShipGotRektJam;

    public void ShipOnShip()
    {
        MyJams.PlayOneShot(ShipOnShipJam);
    }

    public void BulletHitShip()
    {
        MyJams.PlayOneShot(BulletHitShipJam);
    }

    public void HomingHitShip()
    {
        MyJams.PlayOneShot(HomingHitShipJam);
    }

    public void ShipGotRekt()
    {
        MyJams.PlayOneShot(ShipGotRektJam);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
