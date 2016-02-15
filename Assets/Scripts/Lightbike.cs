using UnityEngine;
using System.Collections;

public class Lightbike : MonoBehaviour {
    public float speed;
    public Material trailMaterial;

    private SortedList path;
    private Vector3 lastPath;
    private GameObject lastTrail;

    // Use this for initialization
    void Start ()
    {
        lastTrail = GameObject.CreatePrimitive(PrimitiveType.Cube);
        path = new SortedList();
        lastPath = GetComponent<Transform>().position;
        lastTrail.GetComponent<BoxCollider>().enabled = false;
        lastTrail.GetComponent<Renderer>().material = trailMaterial;
    }
	
	// Update is called once per frame 
    void Update () {
        if (Input.GetKeyDown(KeyCode.A))
        {
            GetComponent<Transform>().localEulerAngles += new Vector3(0, -90, 0);
            path.Add(path.Count, Object.Instantiate(lastTrail));
            lastPath = GetComponent<Transform>().position;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            GetComponent<Transform>().localEulerAngles += new Vector3(0, 90, 0);
            path.Add(path.Count, Object.Instantiate(lastTrail));
            lastPath = GetComponent<Transform>().position;
        }

        GetComponent<Rigidbody>().velocity = GetComponent<Transform>().forward * speed;

        Vector3 position = GetComponent<Transform>().position;
        lastTrail.transform.position = (lastPath + position) / 2;
        lastTrail.transform.localScale = new Vector3(position.x - lastPath.x, 5, position.z - lastPath.z);
    }
}
