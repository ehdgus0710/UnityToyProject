using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMessage : MonoBehaviour
{
    public string typeName;
    public BaseMessage() { name = this.GetType().Name; }
}
