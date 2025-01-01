using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "VfxContainer", menuName = "VFXContainer/VFXContainer", order = 5)]
public class VfxContainerData : ScriptableObject
{
    [SerializeField]
    private SerializableDictionary<string, List<GameObject>> vfxContainerTable = new SerializableDictionary<string, List<GameObject>>();
    public SerializableDictionary<string, List<GameObject>> VfxContainerTable { get { return vfxContainerTable; } }
}
