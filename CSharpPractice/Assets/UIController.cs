using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController Instance { private set; get; }

    public void Awake()
    {
        Instance = this;
    }

    public void StepInformerPanelHandler()
    {

    }



}
