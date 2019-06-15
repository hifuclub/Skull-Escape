using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOption : MonoBehaviour {
    public GameObject menu;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void returnMenu()
    {
        CameraUI.cameraMode = 1;
        menu.SetActive(true);
        CameraUI.targetPos = new Vector3(0f, 11.41f, -604f);
        CameraUI.nowRot = -90;
        this.gameObject.SetActive(false);
    }
}
