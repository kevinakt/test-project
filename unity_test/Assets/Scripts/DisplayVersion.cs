using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.IO;
using UnityEngine.Networking;

public class DisplayVersion : MonoBehaviour {

    [SerializeField]
    private Text displayText;

    void Start()
    {

        //CheckArgs();
        //string version = "dev-90909";
        
        //string path = Application.streamingAssetsPath + "buildVersion.txt";
        //StreamWriter writer = new StreamWriter(path, false);
       // writer.WriteLine(version);
       // writer.Close();
        //Debug.Log(UnityEngine.Application.streamingAssetsPath);  
        //AssetDatabase.ImportAsset(path); 
        //TextAsset asset = Resources.Load("tbuildVersionst");
        //string path = "jar:file://" + Application.dataPath + "!/assets/" + "buildVersion.txt";
       
        //File.WriteAllBytes (toPath,www.bytes);
        //#endif
        //StreamReader reader2 = new StreamReader(dbPath);
        //displayText.text = "Version : " + Application.version;
        //displayText.text = "Version : " + www.text;
       // reader2.Close();
        //StartCoroutine(ReadText());
        ReadText();
    


    }

    private void ReadText() {
        string filePath;
        #if UNITY_IOS

        filePath = Path.Combine(Application.dataPath, "/Raw/buildVersion.txt");
        StreamReader reader = new StreamReader(filePath);
        displayText.text = "Version :" + reader.read();
        reader.Close();

        #else
        //string fullPath = "jar:file://" + Application.dataPath + "/!/assets/" + "buildVersion.txt";
        filePath = Path.Combine(Application.streamingAssetsPath, "buildVersion.txt");
        WWW www = new WWW (filePath);
        //yield return www;

        while (!www.isDone) {
        }
        displayText.text = "Version : " + www.text;

        #endif
    }
}
