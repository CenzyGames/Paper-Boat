using UnityEngine;
using System.Collections;

public class levelMovementScript : MonoBehaviour {
    levelManagerScript ls;
    public int arrayNum;
	void Start ()
    {
        ls = transform.parent.gameObject.GetComponent<levelManagerScript>();
        arrayNum = gameObject.transform.GetSiblingIndex();
	}

	void Update ()
    {
        transform.position += new Vector3(-0.01f, 0, 0) * Time.timeScale;
        if (transform.position.x < -3.98f)
        {     
            ls.spawnNewLevel(name, gameObject, arrayNum);
            Destroy(gameObject);
            //gameObject.SetActive(false);
            //    transform.position = new Vector3(3.98f * 4, 0, 0);
        }
	}
}
