using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour {
    public AudioClip mainSong;
    AudioSource src;
    bool delayCheck = true;

    // Use this for initialization
    void Start() {
        src = GetComponent<AudioSource>();
        Invoke("BeginChecking", 0.1f);
    }

    void BeginChecking()
    {
        // Unity is dumb and isPlaying is set to false for the first couple of frames
        // regardless of if it is playing or not
        delayCheck = false;
    }
	
	// Update is called once per frame
	void Update () {
	    if(!src.isPlaying && !delayCheck)
        {
            src.clip = mainSong;
            src.loop = true;
            src.Play();
        }
	}
}
