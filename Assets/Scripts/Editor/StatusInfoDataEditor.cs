using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(StatusInfoData))]
public class StatusInfoDataEditor : Editor 
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        var script = (StatusInfoData)target;

        if (GUILayout.Button("Add Status", GUILayout.Height(40)))
        {
            for (int i = (int)StatusInfoType.None + 1; i < (int)StatusInfoType.End; ++i)
            {
                script.StatusTable.Add((StatusInfoType)i, new StatusValue((StatusInfoType)i));   
            }
        }

    }
}
