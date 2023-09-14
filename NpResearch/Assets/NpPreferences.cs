using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System.IO;
using System;


public class NpPreferences : MonoBehaviour
{
    [InlineEditor(InlineEditorModes.FullEditor)]
    public NpPrefs ActivePrefs;


    [Button]
    void MakeNewPrefs()
    {
        ActivePrefs = new NpPrefs();
    }

    [Button]
    void SavePrefsToDisk()
    {
        string content = JsonUtility.ToJson(ActivePrefs);
        string path = Path.Combine(Application.streamingAssetsPath, "NpPreferences.txt");

        File.WriteAllText(path, content);


    }

    
}


[System.Serializable]
public class NpPrefs : ScriptableObject
{
    public bool LoadDefaultHeads;
    public bool LoadDefaultBodies;
    public bool LoadDefaultProps;
    public bool LoadDefaultLevelEditorProps;
    public bool LoadDefaultScenes;

}
