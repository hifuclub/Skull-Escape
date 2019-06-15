using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBGM : MonoBehaviour {
    public AudioSource bgm;
    float bgmVolume = 0.14f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        bgm.volume = bgmVolume;

    }
    public void changeVolume(float f)
    {
        bgmVolume = f;
    }
}
