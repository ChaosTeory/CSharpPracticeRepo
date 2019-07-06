using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerController : MonoBehaviour {


    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Inside");

        switch(other)
        {
            case SphereCollider boxCol:
                boxCol.transform.position = new Vector3(10, 10, 10);

                Debug.Log("Box Collider Msg");
                break;
            case MeshCollider meshCol when other.transform.localScale == new Vector3(1, 1, 1):
                Debug.Log("Mesh Collider Msg");
                break;
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
