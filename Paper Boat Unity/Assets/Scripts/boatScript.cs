using UnityEngine;
using System.Collections;

public class boatScript : MonoBehaviour
{
	public Vector3 vel;
    float newVelX;
    float newVelZ;

    float xPos;
    float moveX;

    Vector3 cameraPos;
    float difference;
    float camXPos;
    float xDiff;

    public GameObject canvas;
    void Start()
    {
        xPos = transform.position.x;
        cameraPos = Camera.main.transform.position;
        difference = cameraPos.z - transform.position.z;
        camXPos = transform.position.z + difference;
    }

    void Update ()
    {
        if (xPos - transform.position.x >= 0)
        {
            moveX = Mathf.Lerp(transform.position.x, xPos, Time.deltaTime * (xPos - transform.position.x));
        }
        else
        {
            moveX = Mathf.Lerp(transform.position.x, xPos, Time.deltaTime);
        }
        transform.position = new Vector3(moveX, transform.position.y, transform.position.z);
        camXPos = Mathf.Lerp(Camera.main.transform.position.z, transform.position.z + difference, Time.deltaTime*2);
        Camera.main.transform.position = new Vector3(cameraPos.x,cameraPos.y,camXPos);
		vel = GetComponent<Rigidbody> ().velocity;
        newVelX = Mathf.Lerp(vel.x, 0, Time.deltaTime);
        newVelZ = Mathf.Lerp (vel.z, 0, Time.deltaTime);
		GetComponent<Rigidbody> ().velocity = new Vector3(newVelX,0,newVelZ);
        if (!GetComponent<Renderer>().isVisible && transform.position.x < 1)
        {
            print("game over");
        }
	}

    void OnTriggerEnter(Collider pCol)
    {
        if (pCol.gameObject.tag == "slip")
        {
            Destroy(pCol.gameObject);
            canvas.GetComponent<uiScript>().addSlips();
        }
    }
}
