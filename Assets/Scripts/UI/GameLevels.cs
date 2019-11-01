using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using UnityEditor;

public class GameLevels : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    GameObject levelButton;

    void Start()
    {
        string folderName = Application.dataPath + "/Scenes/FinalLevels";
        var dirInfo = new DirectoryInfo(folderName);
        var allFileInfos = dirInfo.GetFiles("*.unity", SearchOption.AllDirectories);
        //List<EditorBuildSettingsScene> editorBuildSettingsScenes = new List<EditorBuildSettingsScene>();
        //EditorBuildSettings.scenes = editorBuildSettingsScenes.ToArray();
        EditorBuildSettingsScene[] scenes = EditorBuildSettings.scenes;
        for (int i = 2; i < scenes.Length; i++)
        {
            //string levelName = Path.GetFileNameWithoutExtension(allFileInfos[i].FullName);
            string levelName = Path.GetFileNameWithoutExtension(scenes[i].path);
            GameObject levelBtn = Instantiate(levelButton, Vector3.zero, Quaternion.identity);
            levelBtn.GetComponent<LevelButton>().levelNumber = i;
            levelBtn.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = levelName;
            levelBtn.transform.SetParent(this.gameObject.transform);
            Debug.Log("Found a scene file: " + levelName);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
