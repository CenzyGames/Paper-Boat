using UnityEngine;
using System.Collections;

public class lilyScript : MonoBehaviour{
    public GameObject ripple;
    GameObject ripple_clone;
    public float rippleDelay;

	void Start ()
    {
       transform.position = new Vector3(transform.position.x, 0.05f, Random.Range(0.6f, 1.6f) * -1);
        StartCoroutine("createRipple");
    }

    IEnumerator createRipple()
    {
        ripple_clone = Instantiate(ripple, transform.position, Quaternion.identity) as GameObject;
        ripple_clone.GetComponent<rippleScript>().delay = 0.75f;
        ripple_clone.GetComponent<rippleScript>().rippleScale = 0.001f;
        ripple_clone.transform.parent = transform;
        yield return new WaitForSeconds(rippleDelay);
        StartCoroutine("createRipple");
    }

void Update ()
    {
        transform.position += new Vector3(-0.01f,0,0);
        if (transform.position.x < -6.0f)
        {
            Destroy(gameObject);
        }
    }
}
