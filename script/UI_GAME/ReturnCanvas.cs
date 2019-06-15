using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnCanvas : MonoBehaviour
{
    public GameObject norCan;
    public GameObject deathCan;
    public GameObject optionCan;
    public static bool isOption;
    //public static float Audio;
    public bool gameQuality;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isOption)
        {
            optionCan.SetActive(true);
            norCan.SetActive(false);
        }
    }

    public void openOption()
    {
        isOption = true;
    }

    public void gotoGame(int i)
    {
        PlayerMove.heathPoint = 100;
        PlayerMove.isDeath = false;
        isOption = false;
        SceneManager.LoadScene(i);
    }


    public void deathReturnGame(int i)
    {
        PlayerMove.heathPoint = 100;
        PlayerMove.isDeath = false;
        deathCan.SetActive(false);
        norCan.SetActive(true);

        SceneManager.LoadScene(i);
    }
}
