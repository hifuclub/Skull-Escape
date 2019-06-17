using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick : MonoBehaviour
{

    Vector3 mousePositionOnScreen;//获取到点击屏幕的屏幕坐标
    public Vector3 joyPosForReturn;
    Vector3 targetPos;
    public Transform joy;
    public float speedForReturn = 0.5f;
    float maxH, minH, maxW, minW;
    bool isTr;
    public int maxRange;
    public float r, allRange;
    public float showV, showH;
    public float minMoveSpeed = 0.2f;

    float x1, x2, y1, y2, k;

    void Start()
    {
        maxH = this.transform.position.y * 2;
        maxW = this.transform.position.x * 2;
        mousePositionOnScreen = new Vector3(0, 0, 0);
    }
    void Update()
    {
        joyPosForReturn = this.transform.position;
        /////////////////////joy
        Vector3 re = Vector3.Lerp(joy.position, this.transform.position, speedForReturn);
        targetPos = re;

        ////////////////////


        if (Input.GetMouseButton(0))
        {
            mousePositionOnScreen = Input.mousePosition;
            float omaxH = maxH, ominH = minH, omaxW = maxW, ominW = minW;
            if (isTr)
            {
                omaxH += 100;
                omaxW += 200;
                isTr = false;

            }
            if (mousePositionOnScreen.x > ominW && mousePositionOnScreen.x < omaxW && mousePositionOnScreen.y > ominH && mousePositionOnScreen.y < omaxH)
            {
                //Debug.Log(mousePositionOnScreen);
                targetPos = mousePositionOnScreen;

                ////////////限位
                
                x1 = joyPosForReturn.x;
                y1 = joyPosForReturn.y;
                x2 = mousePositionOnScreen.x;
                y2 = mousePositionOnScreen.y;

                allRange = Mathf.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
                r = Mathf.Atan((y2 - y1) / (x2 - x1));
                k = maxRange / allRange;




                float dx = x2 - x1;
                if (dx > 230)
                {
                    dx = 230;
                }
                if (dx < -230)
                {
                    dx = -230;
                }
                float dy = y2 - y1;
                if (dy > 230)
                {
                    dy = 230;
                }
                if (dy < -200)
                {
                    dy = -200;
                }


                PlayerMove.h = dx / 230 * 0.5f;
                PlayerMove.v = dy / 220 * 0.5f;

                if (dy > 0)
                {
                    PlayerMove.rChange = dx / 400;
                }
                else
                {
                    PlayerMove.rChange = dx / 400;/////////////////////加负号,倒车旋转反向 
                }

                if (allRange > 50 && dy > 0)
                {
                    PlayerMove.v += minMoveSpeed;
                }
                if (allRange > 50 && dy < 0)
                {
                    PlayerMove.h *= -1;
                    PlayerMove.v *= 1.2f;


                }
                //if ((x2 - x1) < 0)
                //{
                //    //PlayerMove.v *= -1;
                //}
                //if ((y2 - y1) > 0)
                //{
                //    PlayerMove.h *= -1;
                //}


                showV = PlayerMove.v;
                showH = PlayerMove.h;

                if (allRange > maxRange)
                {
                    if ((x2 - x1) < 0)
                    {
                        k *= -1;
                    }
                    targetPos.x = Mathf.Cos(r) * k * allRange + x1;
                    targetPos.y = Mathf.Sin(r) * k * allRange + y1;

                }


                isTr = true;
            }
            else
            {
                isTr = false;
            }
        }

        ///////////////////joy
        joy.position = targetPos;




    }



}


//public Vector3 screenPosition;//将物体从世界坐标转换为屏幕坐标
//public Vector3 mousePositionInWorld;//将点击屏幕的屏幕坐标转换为世界坐标
//void MouseFollow()
//{
//    //获取鼠标在相机中（世界中）的位置，转换为屏幕坐标；
//    screenPosition = Camera.main.WorldToScreenPoint(transform.position);
//    //获取鼠标在场景中坐标
//    mousePositionOnScreen = Input.mousePosition;
//    //让场景中的Z=鼠标坐标的Z
//    mousePositionOnScreen.z = screenPosition.z;
//    //将相机中的坐标转化为世界坐标
//    mousePositionInWorld = Camera.main.ScreenToWorldPoint(mousePositionOnScreen);
//    //物体跟随鼠标移动
//    //transform.position = mousePositionInWorld;
//    //物体跟随鼠标X轴移动
//    transform.position = new Vector3(mousePositionInWorld.x, transform.position.y, transform.position.z);
//}
