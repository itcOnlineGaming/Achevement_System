using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;


public class AchievementSystemTests
{
    // A Test behaves as an ordinary method
    [Test]
    public void AchievementSystemTestsSimplePasses()
    {
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator AchievementSystemTestsWithEnumeratorPasses()
    {

        AchievementCondition achievementCondition = new AchievementCondition(); ;
     
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return new WaitForSeconds(1.0f);

        Assert.IsTrue(achievementCondition.getTrue());
    }
}
