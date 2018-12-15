using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Unit : MonoBehaviour {

    public string name;
    public float weight;
    public Vector3 size;

    public string pubSSS = "public string";
    private string priSSS = "private string";
    protected string proSSS = "protected string";
    internal string intSSS = "internal string";
    protected internal string proIntSSS = "protected internal string";



    public Unit() { }
    public Unit(string name, float weight, Vector3 size)
    {
        this.name = name;
        this.weight = weight;
        this.size = size;
    }



    /*
    public class Person
    {
        string name { get; set; }
        string middlename { get; set; }
        string surname { get; set; }

        public Person() { }
        public Person(string n, string m, string s) {
            name = n;
            middlename = m;
            surname = s;
        }
    }

    public string GetStrings(Person p)
    {
        Person pp = new Person();


        return "";
        //return $"{u.name} {u.weight.ToString()}";
    }
    */
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
