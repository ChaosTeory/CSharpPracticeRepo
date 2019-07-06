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

        int current, last;

        (int ccurrent, int llast) = GetNumber("text");

        Debug.Log("Current: " + ccurrent);
        Debug.Log("Last: " + llast);

    }

    public List<string> allStrings;

    public (int, int) GetNumber(string s)
    {
        int i = 0;
        int k = 1;

        return (i, k);
    }

    public float GetTime() => Time.time * 10;
	
	// Update is called once per frame
	void Update () {

        float _f;
        _f = GetTime();

        Debug.Log(GetNumber(""));


	}

    
}
