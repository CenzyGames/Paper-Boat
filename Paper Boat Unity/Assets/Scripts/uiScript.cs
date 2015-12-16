using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class uiScript : MonoBehaviour {

    public Vector3 moveTo;
    public Vector3 moveBy;

    public GameObject boat;
    public GameObject manager;
    public GameObject bridge;
    public GameObject ui;
    public GameObject gameMenu;

    bool move;

    public int slips;
    public Text fpsText;

    void Start()
    {
        Application.targetFrameRate = 60;
        slips = PlayerPrefs.GetInt("slips", 0);
        move = true;
        moveTo = Camera.main.transform.position;
    }

    void Update()
    {
        if (move)
        {
            moveBy = Vector3.MoveTowards(Camera.main.transform.position, moveTo, 1);
            Camera.main.transform.position = moveBy;
        }
        float fps = 1/Time.deltaTime;
        fpsText.text = ((int)fps).ToString();

    }

    public void playGame()
    {
        boat.SetActive(true);
        manager.SetActive(true);
        bridge.SetActive(false);
        ui.SetActive(false);
        move = false;
    }

    public void achievements()
    {

    }

    public void showLeaderboard()
    {

    }

    public void gotoPanel(float xVal)
    {
        moveTo = new Vector3(xVal, moveTo.y, moveTo.z);
    }

    public void buyItem(int value)
    {
        if (slips - value < 0)
        {
            print("kangaal Manushya");
        }
        else
        {
            slips -= value;
            PlayerPrefs.SetInt("slips", slips);
            print("Bahut paise aa gaye hain !!!");
        }
    }

    public void addSlips()
    {
        slips++;
        PlayerPrefs.SetInt("slips", slips);
    }
}
