using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalculateFibonacci : MonoBehaviour {

	[SerializeField] Text inputBox;
	[SerializeField] Text resultText;
	string result = "";

	public void Calculate() {
		result = "";
		int input = int.Parse(inputBox.text);

		Fibonacci(input);

		for(int i = 0; i <= input; i++) {
			result += Fibonacci(i) + " ";
		}
		
		resultText.text ="Result : " + result;
	}

	public int Fibonacci(int n) {
		if(n <= 0) {
			return 0;
		} else if(n == 1) {
			return 1;
		} else {
			return Fibonacci(n-1) + Fibonacci(n-2);
		}
	}
}
