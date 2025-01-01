using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(FSMController<>), false)]
[CanEditMultipleObjects]
public class FSMCustomEditor<T> : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        var script = (FSMController<T>)target;

        EditorGUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();

        if (GUILayout.Button("Add All States", GUILayout.Height(40)))
        {
            script.AddAllStates();
        }

        if (GUILayout.Button("Find And Add All States", GUILayout.Height(40)))
        {
            script.FindAndAddAllStates();
        }

        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
    }

    //static public void RunForChild(WolfFSM c)
    //{
    //    WolfFSM p = c;
    //    p.AddAllStates();
    //}
}

[CustomEditor(typeof(PlayerFSM), true)]
[CanEditMultipleObjects]
public class PlayerFSMCustomEditor : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        base.OnInspectorGUI();
        var script = (PlayerFSM)target;

        EditorGUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();


        if (GUILayout.Button("Add All States", GUILayout.Height(40)))
        {
            script.AddAllStates();
        }

        if (GUILayout.Button("Find And Add All States", GUILayout.Height(40)))
        {
            script.FindAndAddAllStates();
        }

        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
    }
}

//[CustomEditor(typeof(WolfFSM), true)]
//[CanEditMultipleObjects]
//public class WolfFSMCustomEditor : Editor
//{
//    public override void OnInspectorGUI()
//    {
//        serializedObject.Update();
//        base.OnInspectorGUI();
//        var script = (WolfFSM)target;

//        EditorGUILayout.BeginHorizontal();
//        GUILayout.FlexibleSpace();

        

//        if (GUILayout.Button("Add All States", GUILayout.Height(40)))
//        {
//            script.AddAllStates();
//        }

//        if (GUILayout.Button("Find And Add All States", GUILayout.Height(40)))
//        {
//            script.FindAndAddAllStates();
//        }

//        if (GUILayout.Button("Play Animation", GUILayout.Width(120), GUILayout.Height(40))) 
//        {
//            script.EditorPlayAnimation();
//        }

//        GUILayout.FlexibleSpace();
//        EditorGUILayout.EndHorizontal();
//    }
//}