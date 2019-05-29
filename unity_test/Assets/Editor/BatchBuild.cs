using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Build.Reporting;
using System.IO;

public class BatchBuild {

    private static BuildTarget m_TargetPlatform;
    private static bool m_IsRelease = false;
    private static string filename = "./build/batch_build.apk";
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
        SaveBuildID();
        //m_TargetPlatform = BuildTarget.Android;
        //m_IsRelease = false;
        //version = "9.0.9";

        Debug.Log(m_TargetPlatform + ", " + m_IsRelease + ", " + version + ", " + filename);
        Debug.Log("This is filename: " + filename);

        if (m_TargetPlatform == BuildTarget.Android)
        {
            bool status = BuildAndroid(m_IsRelease);
            EditorApplication.Exit(status ? 0 : 1);
        } else {
            bool status = BuildiOS();
            EditorApplication.Exit(status ? 0 : 1);
        }
    }

    private static void SwitchIOSPlatform()
    {
        EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.iOS, BuildTarget.iOS);
    }

    public static bool BuildiOS()
    {
        Debug.Log("[ScriptLog] Start Build iOS");

        //  リリースビルドではない場合Profiler等は繋げるようにする
        BuildOptions opt = BuildOptions.None;
        // if(isRelease == false)
        // {
        //     opt |= BuildOptions.Development | BuildOptions.ConnectWithProfiler | BuildOptions.AllowDebugging;
        // }

        string[] scenes = GetEnabledScene();
        BuildReport buildReport = BuildPipeline.BuildPlayer(scenes, filename, m_TargetPlatform, opt);


        if (buildReport.summary.result == BuildResult.Succeeded)
        {
            Debug.Log("[ScriptLog] Success Build iOS");
            return true;
        }

        Debug.Log("[ScriptLog] Failed Build iOS");
        //Debug.Log(System.Environment.NewLine + errorMsg + System.Environment.NewLine);
        return false;
    }

    public static bool BuildAndroid(bool isRelease = false)
    {
        Debug.Log("[ScriptLog] Start Build Android");

        //  リリースビルドではない場合Profiler等は繋げるようにする
        BuildOptions opt = BuildOptions.None;
        if(isRelease == false)
        {
            opt |= BuildOptions.Development | BuildOptions.AllowDebugging;
        }

        //  Keystoreの設定
        //SetAndroidKeyStoreSetting();

        string[] scenes = GetEnabledScene();
        BuildReport buildReport = BuildPipeline.BuildPlayer(scenes, filename, m_TargetPlatform, BuildOptions.None);


        if (buildReport.summary.result == BuildResult.Succeeded)
        {
            Debug.Log("[ScriptLog] Success Build Android");
            return true;
        }

        Debug.Log("[ScriptLog] Failed Build Android");
        //Debug.Log(System.Environment.NewLine + errorMsg + System.Environment.NewLine);
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
                    Debug.Log("platform");
                    m_TargetPlatform = (BuildTarget)System.Enum.Parse(typeof(BuildTarget), args[i + 1]);
                    break;
                case "-isRelease":
                    Debug.Log("isRelease");
                    m_IsRelease = bool.Parse(args[i + 1]);
                    break;
                case "-version":
                    Debug.Log("-version");
                    version = args[i + 1];
                    //PlayerSettings.bundleVersion = version;
                    break;
                case "-filename":
                    filename = args[i + 1];
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

        private static void SaveBuildID(){
        //CheckArgs();
        string path = "Assets/Resources/buildVersion.txt";
        StreamWriter writer = new StreamWriter(path, false);
        writer.WriteLine(version);
        writer.Close();

       
        StreamReader reader = new StreamReader(path);
         PlayerSettings.bundleVersion = "Build Version : " + reader.ReadLine();
        reader.Close();
    }
}
