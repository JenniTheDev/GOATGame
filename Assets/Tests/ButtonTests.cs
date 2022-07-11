using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class ButtonTests
{
    // A Test behaves as an ordinary method
    [Test]
    public void CheckForButtons()
    {
        var playButton = GameObject.Find("GoatButton Play");
        Assert.IsNotNull(playButton, "Missing play button");
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator ButtonTestsWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}