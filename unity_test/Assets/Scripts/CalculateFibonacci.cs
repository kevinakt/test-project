using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalculateFibonacci : MonoBehaviour {

	[SerializeField] Text inputBox{get; set;}
	[SerializeField] Text resultText;
	string result = "";

	public bool Calculate() {
		result = "";
		int input = int.Parse(inputBox.text);

		if(input >= 1) {

			fibonacci(input);

			for(int i = 1; i <= input; i++) {
				result += fibonacci(i) + " ";
			}
			
			resultText.text ="Result : " + result;

			return true;
		}
		else {
			return false;
		}
	}

	public int fibonacci(int n) {
		if(n == 0) {
			return 0;
		} else if(n == 1) {
			return 1;
		} else {
			return fibonacci(n-1) + fibonacci(n-2);
		}
	}
}
