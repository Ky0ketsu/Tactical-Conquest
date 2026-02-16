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
            gridGenerator.GenerateGrid();

            /*if (Application.isPlaying)
            {
                
            }
            else
            {
                Debug.LogWarning("Passe en mode play pour Générer la grille");
            }*/

        }

        if (GUILayout.Button("CLEAR TILES", GUILayout.Height(40)))
        {
            gridGenerator.ClearSpawnedTiles();
        }
    }
}
