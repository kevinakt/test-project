using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayVersion : MonoBehaviour {

    public Text displayText;

	void Start () {
        displayText.text = "Version : " + Application.version;
	}

}
