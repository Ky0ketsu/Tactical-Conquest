using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ToolLevel))]
public class ToolLevelEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        ToolLevel toolEditor = (ToolLevel)target;

        GUILayout.Space(10);

        if (toolEditor.isEditing == false)
        {
            if (GUILayout.Button("ACTIVE LEVEL EDIT", GUILayout.Height(40)))
            {
                toolEditor.ChangeEditState();
            }
        }
        else
        {
            if (GUILayout.Button("DISABLE LEVEL EDIT", GUILayout.Height(40)))
            {
                toolEditor.ChangeEditState();
            }
        }
    }
}
