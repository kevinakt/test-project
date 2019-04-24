using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BatchBuildSimple {

    // ビルド実行でAndroidのapkを作成する例
    [UnityEditor.MenuItem("Tools/Build Simple")]
    public static void Build()
    {
        EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTarget.Android);
        List<string> allScene = new List<string>();
        foreach(EditorBuildSettingsScene scene in EditorBuildSettings.scenes)
        {
            if(scene.enabled)
            {
                allScene.Add(scene.path);
            }
        }

        PlayerSettings.applicationIdentifier = "com.amata.testunity";
        PlayerSettings.bundleVersion = "1.0.99";
        PlayerSettings.statusBarHidden = true;
        BuildPipeline.BuildPlayer(allScene.ToArray(), "./build/batch_build.apk", BuildTarget.Android, BuildOptions.None);
    }
}
