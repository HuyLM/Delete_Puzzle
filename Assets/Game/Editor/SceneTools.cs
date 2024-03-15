using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace DP
{
    public class SceneTools : MonoBehaviour
    {
        const string ProjectPath = "Game/";
        #region Editor Scenes Menu
        public static string LogoScenePath = "Assets/" + ProjectPath + "Scenes/LogoScene.unity";
        public static string[] SceneName = new string[] { "Assets/" + ProjectPath + "Scenes/HomeScene.unity",
                                                            "Assets/" + ProjectPath + "Scenes/GameplayScene.unity"
        };

        [MenuItem(ProjectPath + "Play", false, 0)]
        private static void PlayGame()
        {
            OpenLogoScene();
            EditorApplication.isPlaying = true;
        }

        [MenuItem(ProjectPath + "Scenes/Open Logo Scene", false, 1)]
        private static void OpenLogoScene()
        {
            if(UnityEditor.SceneManagement.EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
            {
                UnityEditor.SceneManagement.EditorSceneManager.OpenScene(LogoScenePath);
            }
        }

        [MenuItem(ProjectPath + "Scenes/Open Home Scene", false, 1)]
        private static void OpenHomeScene()
        {
            if(UnityEditor.SceneManagement.EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
            {
                UnityEditor.SceneManagement.EditorSceneManager.OpenScene(SceneName[0]);
            }
        }

        [MenuItem(ProjectPath + "Scenes/Open GamePlay Scene", false, 1)]
        private static void OpenGamePlayScene()
        {
            if(UnityEditor.SceneManagement.EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
            {
                UnityEditor.SceneManagement.EditorSceneManager.OpenScene(SceneName[1]);
            }
        }


        #endregion
    }
}
    


