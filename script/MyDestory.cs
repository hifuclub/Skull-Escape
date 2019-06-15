using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyDestory : MonoBehaviour {
    public int deTime = 2;
    int i;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (i++ > deTime * 60)
        {
            Destroy(this.gameObject);
        }
	}
}
