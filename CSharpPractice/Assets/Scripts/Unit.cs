using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {

    //public static Unit Instance;


    //public void Awake()
    //{
    //    Instance = this;

    //    Select _select = new Select(Selections.Cube, "CUBE");
    //    Select _selectSecond = new Select(Selections.Rectangle, "RECTANGLE");

    //    selects.Add(_select);
    //}

    [SerializeField]
    public List<Select> selects;


    [System.Serializable]
    public class Select
    {
        [SerializeField]
        public Selections selection;
        [SerializeField]
        public string selectionName;
        [SerializeField]
        public SelectGround selectGrounds;

    }

    [SerializeField]
    public class SelectGround
    {
        public int groundQuantity;
    }

    [System.Serializable]
    public enum Selections
    {
        Cube,
        Rectangle,
        Sphere,
        Cone
    };


 //   //public Unit() { }
 //   //public Unit(string name, float weight, Vector3 size)
 //   //{
 //   //    this.name = name;
 //   //    this.weight = weight;
 //   //    this.size = size;
 //   //}



 //   /*
 //   public class Person
 //   {
 //       string name { get; set; }
 //       string middlename { get; set; }
 //       string surname { get; set; }

 //       public Person() { }
 //       public Person(string n, string m, string s) {
 //           name = n;
 //           middlename = m;
 //           surname = s;
 //       }
 //   }

 //   public string GetStrings(Person p)
 //   {
 //       Person pp = new Person();


 //       return "";
 //       //return $"{u.name} {u.weight.ToString()}";
 //   }
 //   */
	//// Use this for initialization
	//void Start() {
		
	//}
	
	//// Update is called once per frame
	//void Update () {
		
	//}
}
