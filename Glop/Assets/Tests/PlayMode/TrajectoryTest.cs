using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class TrajectoryTest
    {
        [UnityTest]
        public IEnumerator trajectoryTest()
        {
            var gameObject = new GameObject();
            var trajectoryTest = gameObject.AddComponent<GameManager>();

           // TrajectoryTest.Update();


            yield return new WaitForSeconds(5);

            //Assert.AreEqual();

            
     
        }
    }
}
