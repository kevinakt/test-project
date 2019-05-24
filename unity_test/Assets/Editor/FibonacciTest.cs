using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine.UI;

public class FibonacciTest {

    CalculateFibonacci calFibo = new CalculateFibonacci();

    [Test]
    public void CheckResult() {
        Debug.Log("Start Check Result Test!!");
        int result = calFibo.fibonacci(10);
    
        Assert.AreEqual(55, result, "Fibonacci calculate failed!!!");
    }

    // [Test]
    // public void InputMinus(){
    //     bool result = calFibo.Calculate(-10);
        
    //     Assert.IsFalse(result);
    // }

    // [Test]
    // public void InputZero(){
    //     bool result = calFibo.Calculate(0);
        
    //     Assert.IsFalse(result);
    // }


    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode
    // [UnityTest]
    // public IEnumerator FibonacciTestWithEnumeratorPasses() {
    //     // Use the Assert class to test conditions.
    //     // yield to skip a frame
    //     yield return null;
    // }
}
