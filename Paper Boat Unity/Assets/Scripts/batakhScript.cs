using UnityEngine;
using System.Collections;

public class batakhScript : MonoBehaviour {
    float length;
    [SerializeField] float value;
    [SerializeField]
    float value2;
    [SerializeField] float count;

    [SerializeField] Vector3 rotateDuck;
    public float rotateAngle;

	void Start ()
    {
        length = 0.35f;
        StartCoroutine("moveDuck");
	}

    IEnumerator moveDuck()
    {
        yield return new WaitForSeconds(Time.deltaTime);
        value = Mathf.Sin(count) * 0.35f;
        value2 = Mathf.Sin(count);
        transform.localPosition += new Vector3(0, 0, -0.005f);
       // transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, -0.75f - value);
        count += 0.01f;
        if (transform.position.z < -1.1f)
        {
            StopCoroutine("moveDuck");
        }
        else
        {
            StartCoroutine("moveDuck");
        }
        /*
         if (value > 0.345f && rotateAngle == 180)
         {
             changeAngle();
         }
         else if (value < -0.345f && rotateAngle == 0)
         {
             changeAngle();
         }
         else
         {
             StartCoroutine("moveDuck");
         }*/
    }

    IEnumerator rotate()
    {
        yield return new WaitForSeconds(Time.deltaTime);
        transform.localEulerAngles += new Vector3(0,-4,0);
        if (Mathf.Floor(transform.localEulerAngles.y) == rotateAngle)
        {
            StartCoroutine("moveDuck");
            StopCoroutine("rotate");
        }
        else
        {
            StartCoroutine("rotate");
        }
       
    }

    void changeAngle()
    {
        rotateAngle += value < 0 ? 180 : -180;
        StartCoroutine("rotate");
        StopCoroutine("moveDuck");
    }
}
