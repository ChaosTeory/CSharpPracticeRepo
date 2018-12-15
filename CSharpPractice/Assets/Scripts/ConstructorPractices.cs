using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructorPractices : MonoBehaviour {

    static int x;
    int y;

    
    public ConstructorPractices() {
        Debug.Log("NON-Static Constructor Called.");

    }
    static ConstructorPractices()
    {
        Debug.Log("Static Constructor Called.");

    }

	// Use this for initialization
	void Start () {
        //ConstructorPractices cp = new ConstructorPractices();
        x = 5;
        y = 3;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
