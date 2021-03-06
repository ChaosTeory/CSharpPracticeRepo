﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(Unit)), CanEditMultipleObjects]
public class HideShowEditor : Editor
{
    SerializedProperty selectsProperty;

    private void OnEnable()
    {
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();


        selectsProperty = serializedObject.FindProperty("selects");

        //LogProperties(serializedObject);

        if (selectsProperty.isArray)
        {
            int arrayLength = 0;


            selectsProperty.Next(true);
            //Create List Title
            EditorGUILayout.PropertyField(selectsProperty, false);
            if(selectsProperty.isExpanded)
            {
                selectsProperty.Next(true);

                EditorGUI.indentLevel++;
                EditorGUILayout.PropertyField(selectsProperty, false);
                //Get array size
                arrayLength = selectsProperty.intValue;

                selectsProperty.Next(false);


                int lastIndex = arrayLength - 1;

                for (int i = 0; i < arrayLength; i++)
                {

                    SerializedProperty spSelection = selectsProperty.FindPropertyRelative("selection");
                    EditorGUILayout.PropertyField(spSelection);
                    Unit.Selections _selection = (Unit.Selections)spSelection.enumValueIndex;

                    switch (_selection)
                    {
                        case Unit.Selections.Cube:
                            SerializedProperty spSelectionName = selectsProperty.FindPropertyRelative("selectionName");
                            EditorGUILayout.PropertyField(spSelectionName, false);
                            break;
                    }

                   // Unit.SelectGround selectGrounds =
                   //     serializedObject.FindProperty(string.Format("selectGrounds.Array.data[{0}]", i).objectReferenceValue as Unit.SelectGround;
                    //EditorGUILayout.PropertyField(selectGrounds, false);



                    selectsProperty.Next(false);
                }
            }
        }
        serializedObject.ApplyModifiedProperties();













        //if(spCopy.isArray)
        //{
        //    int arrayLength = 0;

        //    spCopy.Next(true); // skip generic field
        //    spCopy.Next(true); // advance to array size field

        //    // Get the array size
        //    arrayLength = spCopy.intValue;

        //    spCopy.Next(true); // advance to first array index

        //    // Write values to list
        //    List<Unit> values = new List<Unit>(arrayLength);
        //    int lastIndex = arrayLength - 1;


        //    for (int i = 0; i < arrayLength; i++)
        //    {
        //        //EditorGUILayout.PropertyField(selectsParent, false);
        //        values.Add(spCopy.objectReferenceValue as System.Object as Unit);
        //        if (i < lastIndex) spCopy.Next(true);
        //    }

        //    List<Unit.Select> _list = new List<Unit.Select>();

        //    for(int k=0; k < values.Count; k++)
        //    {
        //        values[k] = (Unit)EditorGUILayout.ObjectField(values[k], typeof(Unit));


        //    }

        //    //Debug.Log("Value " + k + ": " + values[k]);


        //    for (int i = 0; i < values.Count; i++)
        //    {
        //        //EditorGUILayout.IntField(values[i].selection);
        //        //EditorGUILayout.LabelField(values[i].textArea);


        //        //EditorGUILayout.

        //        ////SerializedProperty spSelection = spCopy.FindPropertyRelative("selection");

        //        //Unit.Selections _selection = (Unit.Selections)spCopy.FindPropertyRelative("selection").enumValueIndex;

        //        //switch (_selection)
        //        //{
        //        //    case Unit.Selections.Cube:
        //        //        SerializedProperty sp = spCopy.FindPropertyRelative("textArea");
        //        //        EditorGUILayout.PropertyField(sp, false);
        //        //        break;
        //        //}
        //    }

        //    //DrawDefaultInspector();

        //    serializedObject.ApplyModifiedProperties();


        //    //    while (selectsParent.Next(true))
        //    //{


        //    //}
        //    //foreach (SerializedProperty selectsMain in selectsParent)
        //    //{
        //    //EditorGUILayout.PropertyField(selectsMain, true);

        //    //}
        //}
    }






    //------------------------------
    //------------------------------
    //------------------------------
    public static void LogProperties(SerializedObject so, bool includeChildren = true)
    {
        // Shows all the properties in the serialized object with name and type
        // You can use this to learn the structure
        so.Update();
        SerializedProperty propertyLogger = so.GetIterator();
        while (true)
        {
            Debug.Log("name = " + propertyLogger.name + " type = " + propertyLogger.type);
            if (!propertyLogger.Next(includeChildren)) break;
        }
    }
    public static void LogInnerProperties(SerializedProperty sp, bool includeChildren = true)
    {
        // Shows all the properties in the serialized object with name and type
        // You can use this to learn the structure
        //so.Update();
        
        while (true)
        {
            Debug.Log("NAME = " + sp.name + " ------- TYPE = " + sp.type);
            if (!sp.Next(includeChildren)) break;
        }
    }
    // variablePath may have a structure like this:
    // "meshData.Array.data[0].vertexColors"
    // So it uses FindProperty to get data from a specific field in an object array
    public static void SetSerializedProperty(UnityEngine.Object obj, string variablePath, object variableValue)
    {
        SerializedObject so = new SerializedObject(obj);
        SerializedProperty sp = so.FindProperty(variablePath);
        if (sp == null)
        {
            Debug.Log("Error setting serialized property! Variable path: \"" + variablePath + "\" not found in object!");
            return;
        }

        so.Update(); // refresh the data

        //SerializedPropertyType type = sp.propertyType; // get the property type
        System.Type valueType = variableValue.GetType(); // get the type of the incoming value

        if (sp.isArray && valueType != typeof(string))
        { // serialized property is an array, except string which is also an array
          // assume the incoming value is also an array
            if (!WriteSerializedArray(sp, variableValue)) return; // write the array
        }
        else
        { // not an array
            if (!WriteSerialzedProperty(sp, variableValue)) return; // write the value to the property
        }

        so.ApplyModifiedProperties(); // apply the changes
    }

    private static bool WriteSerialzedProperty(SerializedProperty sp, object variableValue)
    {
        // Type the property and fill with new value
        SerializedPropertyType type = sp.propertyType; // get the property type

        if (type == SerializedPropertyType.Integer)
        {
            int it = (int)variableValue;
            if (sp.intValue != it)
            {
                sp.intValue = it;
            }
        }
        else if (type == SerializedPropertyType.Boolean)
        {
            bool b = (bool)variableValue;
            if (sp.boolValue != b)
            {
                sp.boolValue = b;
            }
        }
        else if (type == SerializedPropertyType.Float)
        {
            float f = (float)variableValue;
            if (sp.floatValue != f)
            {
                sp.floatValue = f;
            }
        }
        else if (type == SerializedPropertyType.String)
        {
            string s = (string)variableValue;
            if (sp.stringValue != s)
            {
                sp.stringValue = s;
            }
        }
        else if (type == SerializedPropertyType.Color)
        {
            Color c = (Color)variableValue;
            if (sp.colorValue != c)
            {
                sp.colorValue = c;
            }
        }
        else if (type == SerializedPropertyType.ObjectReference)
        {
            Object o = (Object)variableValue;
            if (sp.objectReferenceValue != o)
            {
                sp.objectReferenceValue = o;
            }
        }
        else if (type == SerializedPropertyType.LayerMask)
        {
            int lm = (int)variableValue;
            if (sp.intValue != lm)
            {
                sp.intValue = lm;
            }
        }
        else if (type == SerializedPropertyType.Enum)
        {
            int en = (int)variableValue;
            if (sp.enumValueIndex != en)
            {
                sp.enumValueIndex = en;
            }
        }
        else if (type == SerializedPropertyType.Vector2)
        {
            Vector2 v2 = (Vector2)variableValue;
            if (sp.vector2Value != v2)
            {
                sp.vector2Value = v2;
            }
        }
        else if (type == SerializedPropertyType.Vector3)
        {
            Vector3 v3 = (Vector3)variableValue;
            if (sp.vector3Value != v3)
            {
                sp.vector3Value = v3;
            }
        }
        else if (type == SerializedPropertyType.Rect)
        {
            Rect r = (Rect)variableValue;
            if (sp.rectValue != r)
            {
                sp.rectValue = r;
            }
        }
        else if (type == SerializedPropertyType.ArraySize)
        {
            int aSize = (int)variableValue;
            if (sp.intValue != aSize)
            {
                sp.intValue = aSize;
            }
        }
        else if (type == SerializedPropertyType.Character)
        {
            int ch = (int)variableValue;
            if (sp.intValue != ch)
            {
                sp.intValue = ch;
            }
        }
        else if (type == SerializedPropertyType.AnimationCurve)
        {
            AnimationCurve ac = (AnimationCurve)variableValue;
            if (sp.animationCurveValue != ac)
            {
                sp.animationCurveValue = ac;
            }
        }
        else if (type == SerializedPropertyType.Bounds)
        {
            Bounds bounds = (Bounds)variableValue;
            if (sp.boundsValue != bounds)
            {
                sp.boundsValue = bounds;
            }
        }
        else
        {
            Debug.Log("Unsupported SerializedPropertyType \"" + type.ToString() + " encoutered!");
            return false;
        }
        return true;
    }

    private static bool WriteSerializedArray(SerializedProperty sp, object arrayObject)
    {
        System.Array[] array = (System.Array[])arrayObject; // cast to array

        sp.Next(true); // skip generic field
        sp.Next(true); // advance to array size field

        // Set the array size
        if (!WriteSerialzedProperty(sp, array.Length)) return false;

        sp.Next(true); // advance to first array index

        // Write values to array
        int lastIndex = array.Length - 1;
        for (int i = 0; i < array.Length; i++)
        {
            if (!WriteSerialzedProperty(sp, array[i])) return false; // write the value to the property
            if (i < lastIndex) sp.Next(false); // advance without drilling into children            }

            return true;
        }
        return true;
    }
        // A way to see everything a SerializedProperty object contains in case you don't
        // know what type is stored.
        public static void LogAllValues(SerializedProperty serializedProperty)
        {
            Debug.Log("PROPERTY: name = " + serializedProperty.name + " type = " + serializedProperty.type);
            Debug.Log("animationCurveValue = " + serializedProperty.animationCurveValue);
            Debug.Log("arraySize = " + serializedProperty.arraySize);
            Debug.Log("boolValue = " + serializedProperty.boolValue);
            Debug.Log("boundsValue = " + serializedProperty.boundsValue);
            Debug.Log("colorValue = " + serializedProperty.colorValue);
            Debug.Log("depth = " + serializedProperty.depth);
            Debug.Log("editable = " + serializedProperty.editable);
            Debug.Log("enumNames = " + serializedProperty.enumNames);
            Debug.Log("enumValueIndex = " + serializedProperty.enumValueIndex);
            Debug.Log("floatValue = " + serializedProperty.floatValue);
            Debug.Log("hasChildren = " + serializedProperty.hasChildren);
            Debug.Log("hasMultipleDifferentValues = " + serializedProperty.hasMultipleDifferentValues);
            Debug.Log("hasVisibleChildren = " + serializedProperty.hasVisibleChildren);
            Debug.Log("intValue = " + serializedProperty.intValue);
            Debug.Log("isAnimated = " + serializedProperty.isAnimated);
            Debug.Log("isArray = " + serializedProperty.isArray);
            Debug.Log("isExpanded = " + serializedProperty.isExpanded);
            Debug.Log("isInstantiatedPrefab = " + serializedProperty.isInstantiatedPrefab);
            Debug.Log("name = " + serializedProperty.name);
            Debug.Log("objectReferenceInstanceIDValue = " + serializedProperty.objectReferenceInstanceIDValue);
            Debug.Log("objectReferenceValue = " + serializedProperty.objectReferenceValue);
            Debug.Log("prefabOverride = " + serializedProperty.prefabOverride);
            Debug.Log("propertyPath = " + serializedProperty.propertyPath);
            Debug.Log("propertyType = " + serializedProperty.propertyType);
            Debug.Log("quaternionValue = " + serializedProperty.quaternionValue);
            Debug.Log("rectValue = " + serializedProperty.rectValue);
            Debug.Log("serializedObject = " + serializedProperty.serializedObject);
            Debug.Log("stringValue = " + serializedProperty.stringValue);
            Debug.Log("tooltip = " + serializedProperty.tooltip);
            Debug.Log("type = " + serializedProperty.type);
            Debug.Log("vector2Value = " + serializedProperty.vector2Value);
            Debug.Log("vector3Value = " + serializedProperty.vector3Value);
        }
    }

