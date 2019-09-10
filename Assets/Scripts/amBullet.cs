using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class amBullet : MonoBehaviour
{
    //Variables
    public AudioSource isMe;
    public AudioClip MyThing;

    // Start is called before the first frame update
    void Start()
    {
        isMe.pitch = Random.Range(0.8f,1.2f);
        isMe.PlayOneShot(MyThing);
        print ("didThing");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
