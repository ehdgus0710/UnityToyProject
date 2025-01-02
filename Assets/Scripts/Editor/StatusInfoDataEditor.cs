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
            script.StatusTable.Clear();

            for (int i = (int)StatType.None + 1; i < (int)StatType.End; ++i)
            {
                script.StatusTable.Add((StatType)i, new StatusValue((StatType)i));
            }
        }

    }
}
