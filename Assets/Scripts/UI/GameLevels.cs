using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.IO;
using TMPro;
using UnityEditor;
using System.Linq;
using UnityEngine.UI;

public class GameLevels : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    GameObject levelButton;
    private int latestLevel;

    void Start()
    {
        int[] points = LevelManager.instance.levelPoints;
        // string folderName = Application.dataPath + "/Scenes/FinalLevels";
        // var dirInfo = new DirectoryInfo(folderName);
        // var allFileInfos = dirInfo.GetFiles("*.unity", SearchOption.AllDirectories);
        //List<EditorBuildSettingsScene> editorBuildSettingsScenes = new List<EditorBuildSettingsScene>();
        //EditorBuildSettings.scenes = editorBuildSettingsScenes.ToArray();
        EditorBuildSettingsScene[] scenes = EditorBuildSettings.scenes;
        scenes = scenes.Skip(2).ToArray();
        // Debug.Log("moi "+ scenes.Length);
        for (int i = 0; i < scenes.Length; i++)
        {
            //string levelName = Path.GetFileNameWithoutExtension(allFileInfos[i].FullName);
            string levelName = Path.GetFileNameWithoutExtension(scenes[i].path);
            GameObject levelBtn = Instantiate(levelButton, Vector3.zero, Quaternion.identity);
            levelBtn.GetComponent<LevelButton>().levelNumber = i + 2;
            levelBtn.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = levelName;
            levelBtn.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = $"{points[i]}";
            levelBtn.transform.SetParent(this.gameObject.transform);
            Debug.Log("Found a scene file: " + levelName);
            if (points[i] == -1)
            {
                levelBtn.GetComponent<Button>().interactable = false;
                levelBtn.transform.GetChild(1).gameObject.SetActive(false);
            }
            else
            {
                latestLevel = i;
            }
        }
        Debug.Log($"latest level: {latestLevel}");
    }
}
