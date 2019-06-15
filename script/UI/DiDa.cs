using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiDa : MonoBehaviour {

    public AudioSource dida;
    public int i;
    public bool isPlay;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0) && !isPlay)
        {
            dida.Play();
            isPlay = true;
        }
        if (isPlay)
        {
            i++;
            if (i > 30)
            {
                i = 0;
                isPlay = false;
            }
        }
    }
}
