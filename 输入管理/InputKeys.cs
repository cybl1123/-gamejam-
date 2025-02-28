using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputKeyss:MonoBehaviour
{

}
public  class InputKeyBag
{
    [HideInInspector]public bool condition;
    [HideInInspector]public int index;
    string name;
    [HideInInspector]public KeyCode keyCode;
    public InputKeyBag(bool condition,int index,string name,KeyCode keyCode )
    { 
        this.condition=condition;
        this.index=index;
        this.name=name;
        this.keyCode = keyCode;
    }
}
