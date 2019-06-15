using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionCanvas : MonoBehaviour {
    public GameObject norCan;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void closeOption()
    {
        ReturnCanvas.isOption = false;
        norCan.SetActive(true);
        this.gameObject.SetActive(false);

    }

}
