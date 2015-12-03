using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class testScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<RectTransform>().localPosition += new Vector3(-1.0f, -1.0f, 0);
	
	}
}
