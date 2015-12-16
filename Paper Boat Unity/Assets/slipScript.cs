using UnityEngine;
using System.Collections;

public class slipScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.position = new Vector3(transform.position.x, 0.05f, Random.Range(0.6f, 1.6f) * -1);
    }
	
	// Update is called once per frame
	void Update () {
        transform.position += new Vector3(-0.01f, 0, 0);
        if (transform.position.x < -6)
        {
            Destroy(gameObject);
        }
    }
}
