using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GridGenerator))]
public class GridGeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        GridGenerator gridGenerator = (GridGenerator)target;

        GUILayout.Space(10);


        if (GUILayout.Button("GENERATE GRID", GUILayout.Height(40)))
        {
            gridGenerator.GenerateNewGrid();

        }

        if (GUILayout.Button("CLEAR TILES", GUILayout.Height(40)))
        {
            gridGenerator.ClearSpawnedTiles();
        }
    }
}
