using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class AbilityController : MonoBehaviour
{

    public abstract class Ability
    {
        public abstract string type { get; }
        public abstract void Process();
    }

    public class FireAbility : Ability
    {
        public override string type { get { return "fire"; } }
        public override void Process()
        {
            Debug.Log("Fire Ability Used..");

        }
    }
    public class IceAbility : Ability
    {
        public override string type { get { return "ice"; } }
        public override void Process()
        {
            Debug.Log("Ice Ability Used..");

        }
    }
    //-----------
    public class AbilityFactory
    {
        private Dictionary<string, Type> abilitiesByName;
        
        public AbilityFactory()
        {
            var abilityTypes =
                Assembly.GetAssembly(typeof(Ability)).GetTypes().Where(myType => myType.IsClass &&
                                                                        !myType.IsAbstract &&
                                                                        myType.IsSubclassOf(typeof(Ability)));
        }
    }

}
