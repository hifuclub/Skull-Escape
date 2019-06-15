using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {
    public GameObject startGame;
    public GameObject boxRoom;
    public GameObject option;
    public GameObject aboutMe;

    public GameObject menuStart;
    public GameObject menuBoxRoom;
    public GameObject menuOption;
    public GameObject menuAboutMe;


    private int i;
    public static bool isAct;
    public static int showButtonNum = 0;

    // Use this for initialization
    void Start () {

        startGame.SetActive(false);
        boxRoom.SetActive(false);
        option.SetActive(false);
        aboutMe.SetActive(false);


        i = 0;
    }

    // Update is called once per frame
    void Update () {
        if (isAct)
        {
            i++;
            if (i > 30 && showButtonNum == 0)
            {
                startGame.SetActive(true);
            }
            if (i > 50 && showButtonNum == 0)
            {
                boxRoom.SetActive(true);
            }
            if (i > 70 && showButtonNum == 0)
            {
                option.SetActive(true);
            }
            if (i > 90 && showButtonNum == 0)
            {
                aboutMe.SetActive(true);
                isAct = false;
            }
        }
	}

    public void startGameDown()
    {
        CameraUI.targetPos =new Vector3(1200, 11, -604);
        this.gameObject.SetActive(false);
        CameraUI.nowRot = 90;
        menuStart.SetActive(true);
        CameraUI.cameraMode = 2;
    }
    public void boxRoomDown()
    {
        CameraUI.targetPos = new Vector3(1100, 11, -604);
        this.gameObject.SetActive(false);
        CameraUI.nowRot = 90;
        menuBoxRoom.SetActive(true);
        CameraUI.cameraMode = 3;
    }
    public void optionDown()
    {
        CameraUI.targetPos = new Vector3(1100, 11, -604);
        this.gameObject.SetActive(false);
        menuOption.SetActive(true);
        CameraUI.nowRot = 90;
    }
    public void aboutMeDown()
    {
        CameraUI.targetPos = new Vector3(1100, 11, -604);
        this.gameObject.SetActive(false);
        menuAboutMe.SetActive(true);
        CameraUI.nowRot = 90;
    }
}
