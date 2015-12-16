﻿using UnityEngine;
using System.Collections;

public class inputManagerScript : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;

    GameObject ball;
    GameObject boat;
    public GameObject ripple;
    GameObject rippleClone;

    public float ballSpeed;

	void Start ()
    {
        boat = GameObject.Find("boat");
	}

	void Update ()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction*50, Color.red);
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, 50))
            {
                if (hit.collider.name == "collider")
                {
                    rippleClone = Instantiate(ripple, hit.point, Quaternion.identity) as GameObject;
                    ball = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    ball.name = "ball";
                    ball.tag = "ball";
                    ball.transform.localPosition = hit.point + (Vector3.up * 0.05f);
                    ball.transform.localScale *= 0.05f;

                    ball.AddComponent<Rigidbody>();
                    ball.GetComponent<Rigidbody>().useGravity = false;
                    ball.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
                    ball.GetComponent<Rigidbody>().mass = 2;
                    ball.AddComponent<ConstantForce>();

                    float x = getAngle(hit.point, boat.transform.localPosition);
                    Vector3 angle = new Vector3(-Mathf.Sin(x * (Mathf.PI / 180)), 0, Mathf.Cos(x * (Mathf.PI / 180)));
                    angle = angle.normalized * 2;
                    ball.GetComponent<Rigidbody>().velocity = angle * ballSpeed;
                    ball.AddComponent<ballScript>();
                    ball.GetComponent<MeshRenderer>().enabled = false;

                    ball.transform.parent = rippleClone.transform;
                }
            }
        }
	}

    float getAngle(Vector3 from, Vector3 to)
    {
        float angle =  Mathf.Atan2(to.z - from.z, to.x - from.x) * 180 / Mathf.PI;
        angle -= 90;
        if (angle < 0)
        {
            angle += 360;
        }
        
        angle %= 360;
        return angle;
    }
}
