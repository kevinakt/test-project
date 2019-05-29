using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine.UI;

public class FibonacciTest {

    [Test]
    public void CheckResult() {
        CalculateFibonacci calFibo = new CalculateFibonacci();

        Debug.Log("Start Check Result Test!!");
        
        int result = calFibo.fibonacci(10);
        Assert.AreEqual(55, result, "Fibonacci calculate is wrong!!!");
        
        Debug.Log("Start Check Zero Test!!");
        result = calFibo.fibonacci(0);
        Assert.AreEqual(0, result, "Fibonacci calculate is not zero!!!");

        Debug.Log("Start Check Minus Test!!");
        result = calFibo.fibonacci(-1);
        Assert.AreEqual(0, result, "Fibonacci calculate is not zero!!!");
    }

    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode
    // [UnityTest]
    // public IEnumerator FibonacciTestWithEnumeratorPasses() {
    //     // Use the Assert class to test conditions.
    //     // yield to skip a frame
    //     yield return null;
    // }
}
