using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public Sprite play;
    public Sprite playGlow;
    private AudioSource source;
    [Range(0,1)]
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

    public void PlayEnter()
    {
        GetComponent<Image>().sprite = playGlow;
        source.pitch = 1.1f + pitchShift;
        source.Play();
    }

    public void PlayExit()
    {
        GetComponent<Image>().sprite = play;
        source.pitch = 1.1f - pitchShift;
        source.Play();
    }

    public void PlayClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
