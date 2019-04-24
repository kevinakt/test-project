using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BatchBuild {

    private static BuildTarget m_TargetPlatform;
    private static bool m_IsRelease = false;
    private static string version;

    // Android KeyStore Settings
    //private static string keystorePath = "keyStoreの保存場所";
    //private static string keystorePass = "keyStoreのpass";
    //private static string keyaliasName = "keyAliasの名前";
    //private static string keyaliasPass = "keySAliasのPass";
    //----------

    [UnityEditor.MenuItem("Tools/Build Project AllScene Android")]
    public static void Build()
    {
        Debug.Log("test debug");
        GetCommandLineArgs();
        Debug.Log(m_TargetPlatform + ", " + m_IsRelease + ", " + version);

        if (m_TargetPlatform == BuildTarget.Android)
        {
            bool status = BuildAndroid(m_IsRelease);
            EditorApplication.Exit(status ? 0 : 1);
        }
    }

    public static bool BuildAndroid(bool isRelease = false)
    {
        Debug.Log("[ScriptLog] Start Build Android");

        //  リリースビルドではない場合Profiler等は繋げるようにする
        BuildOptions opt = BuildOptions.None;
        if(isRelease == false)
        {
            opt |= BuildOptions.Development | BuildOptions.ConnectWithProfiler | BuildOptions.AllowDebugging;
        }

        //  Keystoreの設定
        //SetAndroidKeyStoreSetting();

        string[] scenes = GetEnabledScene();
        string errorMsg = BuildPipeline.BuildPlayer(scenes, "./Assets/Build", m_TargetPlatform, opt).ToString();

        if(string.IsNullOrEmpty(errorMsg))
        {
            Debug.Log("[ScriptLog] Success Build Android");
            return true;
        }

        Debug.Log("[ScriptLog] Failed Build Android");
        Debug.Log(System.Environment.NewLine + errorMsg + System.Environment.NewLine);
        return false;
    }

    /// <summary>
    /// コマンドライン引数を解釈して変数に格納する
    /// </summary>
    //private static void SetAndroidKeyStoreSetting()
    //{
    //    string keystoreName = System.IO.Directory.GetCurrentDirectory() + keystorePath;
    //    //  KeyStoreの場所とパスワードを設定
    //    PlayerSettings.Android.keystoreName = keystoreName;
    //    PlayerSettings.Android.keystorePass = keystorePass;
    //    // KeyAliasの名前とパスワードを設定
    //    PlayerSettings.Android.keyaliasName = keyaliasName;
    //    PlayerSettings.Android.keyaliasPass = keyaliasPass;
    //}


    /// <summary>
    /// コマンドライン引数を解釈して変数に格納する
    /// </summary>
    private static void GetCommandLineArgs()
    {
        string[] args = System.Environment.GetCommandLineArgs();
        //  引数を判定
        for (int i = 0, max = args.Length; i < max; ++i)
        {
            switch (args[i])
            {
                case "-platform":
                    m_TargetPlatform = (BuildTarget)System.Enum.Parse(typeof(BuildTarget), args[i + 1]);
                    break;
                case "-isRelease":
                    m_IsRelease = bool.Parse(args[i + 1]);
                    break;
                case "-version":
                    version = args[i + 1];
                    PlayerSettings.bundleVersion = version;
                    break;
                default:
                    break;
            }
        }
    }


    /// <summary>
    /// BuildSettingで有効になっているSceneを取得
    /// </summary>
    /// <returns>The enabled scenes.</returns>
    private static string[] GetEnabledScene()
    {
        EditorBuildSettingsScene[] scenes = EditorBuildSettings.scenes;

        List<string> sceneList = new List<string>();

        for (int i = 0, max = scenes.Length; i < max; ++i)
        {
            if(scenes[i].enabled)
            {
                sceneList.Add(scenes[i].path);
            }
        }

        return sceneList.ToArray();
    }
}
