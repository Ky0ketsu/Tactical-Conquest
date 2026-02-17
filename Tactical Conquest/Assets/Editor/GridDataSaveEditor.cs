using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GridDataSave))]
public class GridDataSaveEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        GridDataSave gridDataSave = (GridDataSave)target;

        GUILayout.Space(10);

        if (GUILayout.Button("SAVE MAP", GUILayout.Height(40)))
        {
            gridDataSave.SaveIntoJson();
        }

        if(GUILayout.Button("LOAD MAP", GUILayout.Height(40)))
        {
            gridDataSave.LoadIntoJson();
        }
    }
}
