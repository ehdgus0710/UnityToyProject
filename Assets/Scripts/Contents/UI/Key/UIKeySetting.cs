using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIKeySetting : MonoBehaviour
{
    [SerializeField]
    public InputActionAsset inputActionAsset;

    [SerializeField]
    public List<KeyInterection> keyInterectionList;

    private void Awake()
    {
        keyInterectionList.AddRange(gameObject.GetComponentsInChildren<KeyInterection>());

        foreach (var keyInterection in keyInterectionList)
        {
            keyInterection.duplicateBindingEvent.AddListener(UpdateInputAction);
        }
    }

    private void UpdateInputAction()
    {
        //inputActionAsset.actionMaps

        foreach (var keyInterection in keyInterectionList)
        {
            keyInterection.UpdateKeyInterection();
        }

    }

    private void AddKeyInterection()
    {
       
    }

    private void OnAllResetSetting()
    {
        foreach(var actionMap in inputActionAsset.actionMaps)
        {
            actionMap.RemoveAllBindingOverrides();
        }

        foreach (var keyInterection in keyInterectionList)
        {
            keyInterection.UpdateKeyInterection();
        }
    }
}
