using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScrolling : MonoBehaviour
{
    public float speed;
    Vector2 offset;
    Material material;

    // Start is called before the first frame update
    void Start()
    {
        speed = 0.2f;
        offset = new Vector2(0, speed);
        material = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        material.mainTextureOffset += offset * Time.deltaTime;
    }
}
