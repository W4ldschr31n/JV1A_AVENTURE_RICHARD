using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public class StartSceneWindow : EditorWindow
{
    private SceneAsset selectedScene;
    private int selectedButton = 0;
    void OnGUI()
    {
        // Use the Object Picker to select the start SceneAsset
        selectedScene = (SceneAsset)EditorGUILayout.ObjectField(new GUIContent("Start Scene"), selectedScene, typeof(SceneAsset), false);
        string[] opts = { "Starting scene", "Current scene" };
        selectedButton = GUILayout.SelectionGrid(selectedButton, opts, 2, EditorStyles.radioButton);
        if (selectedButton == 0)
        {
            EditorSceneManager.playModeStartScene = selectedScene;
        }
        else
        {
            EditorSceneManager.playModeStartScene = null;
        }


    }



    [MenuItem("Window/StartScene")]
    static void Open()
    {
        GetWindow<StartSceneWindow>();
    }
}