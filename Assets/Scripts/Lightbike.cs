using UnityEngine;
using System.Collections;

public class Lightbike : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame 
    void Update () { 
        GetComponent<Rigidbody>().velocity = new Vector3(Input.GetAxis("Horizontal")*20, 0, Input.GetAxis("Vertical")*20);
	}
}
