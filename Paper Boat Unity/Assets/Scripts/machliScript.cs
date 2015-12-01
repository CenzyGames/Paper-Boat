using UnityEngine;
using System.Collections;

public class machliScript : MonoBehaviour {
    float val;
    float count;
    public float speed;
    public float distance;
    public float position;
    public float angle;
    void Start ()
    {


	
	}

	void Update ()
    {
        angle = Mathf.Sin(count) * 15;
        val = Mathf.Sin(count)*distance;
        transform.eulerAngles = new Vector3(0, 270-angle, 0);
        transform.position = new Vector3(transform.position.x, transform.position.y, position + val);
        transform.position += new Vector3(-0.015f, 0, 0);
        count += speed;
	}
}
