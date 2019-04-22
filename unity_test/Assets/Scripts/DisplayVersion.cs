using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayVersion : MonoBehaviour {

    [SerializeField]
    private Text displayText;

    void Start()
    {
        displayText.text = "Version : " + Application.version;
    }

}
