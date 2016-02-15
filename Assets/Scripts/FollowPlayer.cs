using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

    public float followDistance;
    public float cameraUpAngle;
    public float cameraHeight;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        GameObject player = GameObject.Find("Cube");

        Vector3 Diff = GetComponent<Transform>().position - player.GetComponent<Transform>().position;
        if (Diff.magnitude > followDistance)
        {
            float mult = followDistance / Diff.magnitude;
            GetComponent<Transform>().position -= Diff;
            GetComponent<Transform>().position += Diff * mult;
        }

        GetComponent<Transform>().LookAt(player.GetComponent<Transform>());
    }
}
