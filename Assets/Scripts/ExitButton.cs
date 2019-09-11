using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class ExitButton : MonoBehaviour
{
    public Sprite exit;
    public Sprite exitGlow;
    private AudioSource source;
    [Range(0, 1)]
    public float pitchShift;


    // Start is called before the first frame update
    void Start()
    {
        source = FindObjectOfType<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ExitEnter()
    {
        GetComponent<Image>().sprite = exitGlow;
        source.pitch = 0.7f + pitchShift;
        source.Play();
    }

    public void ExitExit()
    {
        GetComponent<Image>().sprite = exit;
        source.pitch = 0.7f - pitchShift;
        source.Play();
    }

    public void ExitClick()
    {
        Application.Quit();
        //EditorApplication.isPlaying = false;
    }
}
