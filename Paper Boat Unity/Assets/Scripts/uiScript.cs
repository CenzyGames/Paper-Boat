using UnityEngine;
using System.Collections;

public class uiScript : MonoBehaviour {

    public Vector3 moveTo;
    Vector3 moveBy;

    void Start()
    {
        moveTo = Camera.main.transform.position;
    }

    void Update()
    {
        moveBy = Vector3.MoveTowards(Camera.main.transform.position, moveTo,1);
        Camera.main.transform.position = moveBy;
    }

    public void playGame()
    {

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

    public void buyItem(float value)
    {

    }
}
