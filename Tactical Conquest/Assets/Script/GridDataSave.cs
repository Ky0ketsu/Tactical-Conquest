using UnityEngine;

using System.IO;
using UnityEditor.ShaderGraph.Serialization;

public class GridDataSave : MonoBehaviour
{
    [SerializeField]
    private GridData gridData;

    [SerializeField]
    private string saveFileName;
    [SerializeField]
    private string loadFileName;

    public void SaveIntoJson()
    {
        gridData = transform.GetComponent<GridGenerator>().gridData;
        string grid = JsonUtility.ToJson(gridData);
        //System.IO.File.WriteAllText(Application.persistentDataPath + "/GridData.json", grid);

        

        string folder = Path.Combine(Application.persistentDataPath, "Tactical Conquest");

        if(!Directory.Exists(folder))
        {
            Directory.CreateDirectory(folder);
        }

        var path = Path.Combine(folder, $"{saveFileName}.json");


        Debug.Log(path);
        File.WriteAllText(path, grid);
        
    }

    public void LoadIntoJson()
    {
        string folder = Path.Combine(Application.persistentDataPath, "Tactical Conquest");
        string path = Path.Combine(folder, $"{loadFileName}.json");

        if (!File.Exists(path))
        {
            Debug.LogError("Fichier introuvable : " + path);
            return;
        }

        string json = File.ReadAllText(path);
        GridData grid = JsonUtility.FromJson<GridData>(json);

        /*foreach( TileData tileData in grid.tiles)
        {
            Debug.Log($"{tileData.x}, {tileData.z}");
        }*/
        Debug.Log("aaaaa");
        transform.GetComponent<GridGenerator>().LoadMap(grid);
    }


}
