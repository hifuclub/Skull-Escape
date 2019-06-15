using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StartButton : MonoBehaviour {
    public Image img;
    public Color color01;
    Color objColor;
    public Vector4 iniV4;
    public Vector4 v4;

    public float i;
    private bool isTr = false;
    private bool isTr01 = false;
    private bool isTr02 = false;
    private bool isIni = true;
    public GameObject textPress;
    public GameObject objCameraUI;
    public GameObject menu;
    public GameObject menuStart;
    public GameObject menuBoxRoom;
    public GameObject menuOption;
    public GameObject menuAboutMe;



    // Use this for initialization
    void Start () {
        iniV4 = new Vector4(255,255,255,45);
        i = 350;
        textPress.SetActive(false);

        menu.SetActive(false);
        menuStart.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        /////////////////
        v4 = iniV4;
        /////////////////


        if (isIni)
        {
            i--;
            if (i < 0)
            {
                isIni = false;
                i = 0;
                textPress.SetActive(true);
            }
            v4.x = 255 - i * 255 / 350;
            v4.y = 255 - i * 255 / 350;
            v4.z = 255 - i * 255 / 350;
            v4.w += i * 215 / 350;
        }
        /////////////////
        if (isTr01)
        {
            i++;
            float alpha = -(Mathf.Cos(i * 0.1f)) * 255 * 0.1f + 0.15f;
            alpha = alpha;
            if(CameraUI.cameraMode == 0 && i > 60)
            {
                CameraUI.cameraMode = 1;
                CameraUI.targetPos = new Vector3(0f, 11.41f, -604f);
                CameraUI.nowRot = 90;
            }
            if (i > 40 * Mathf.PI)
            {
                isTr01 = false;
                i = 0;
                isTr02 = true;
                Destroy(textPress);
                menu.SetActive(true);
                Menu.isAct = true;
            }
            v4.w += alpha;
        }

        /////////////////
        //if (isTr02)
        //{
        //    i++;
        //    float alpha = -(Mathf.Cos(i * 0.1f)) * 255 * 0.1f + 0.15f;
        //    alpha = alpha;
        //    if (i > 40 * Mathf.PI)
        //    {
        //        isTr01 = false;
        //        i = 0;
        //    }
        //    v4.w += alpha;
        //}
        /////////////////
        objColor.r = v4.x / 255;
        objColor.b = v4.y / 255;
        objColor.g = v4.z / 255;
        objColor.a = v4.w / 255;
        /////////////////
        img.color = objColor;
    }


    public void d()
    {
        if (!isIni && !isTr) 
        {
            isTr = true;
            isTr01 = true;

        }

    }
}
