using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class PlayModeUnitTests
    {

        private void InitializeMainComponents()
        {
            GameObject.Instantiate(Resources.Load("Prefabs/GameManager"));
            GameManager.Instance.StartTheGame();

            GameObject.Instantiate(Resources.Load("Prefabs/GUI/GUIManager"));
        }

        [UnityTest]
        public IEnumerator Unit_Falls_Asleep()
        {
            //arrange
            var unitPrefab = GameObject.Instantiate(Resources.Load("Prefabs/Units/Archer/ArcherBase")) as GameObject;            
            int awakeTime = unitPrefab.GetComponent<UnitData>().CurrentLevel.AwakeTime;

            //act
            yield return new WaitForSeconds(awakeTime + 1);

            //assert
            Assert.AreEqual(false, unitPrefab.GetComponentInChildren<AwakeBehavior>().isAwake);
        }

        [UnityTest]
        public IEnumerator Unit_Turns_When_Enemy_Passes_It()
        {
            //arrange            
            InitializeMainComponents();
            var archerPrefab = Object.Instantiate(Resources.Load("Prefabs/Units/Archer/ArcherBase") as GameObject);
            archerPrefab.transform.position = new Vector3(-13, 2, 0);
            var expectedFlip = !archerPrefab.GetComponent<SpriteRenderer>().flipX;

            //act
            yield return new WaitForSeconds(5);

            //assert
            var actualFlip = archerPrefab.GetComponent<SpriteRenderer>().flipX;
            Assert.AreEqual(expectedFlip, actualFlip);
        }

        [UnityTest]
        public IEnumerator EnemySpawner_Creates_Enemies()
        {
            //arrange
            GameObject.Instantiate(Resources.Load("Prefabs/GameManager"));
            GameManager.Instance.StartTheGame();

            //act            
            yield return new WaitForSeconds(5);
            var spawnedEnemies = GameObject.FindGameObjectsWithTag("Enemy");

            //assert
            Assert.Greater(spawnedEnemies.Length, 0);
        }

        [UnityTest]
        public IEnumerator OnDeathActionsMethod_Is_Called_When_Monster_Is_Killed()
        {
            //arrange
            InitializeMainComponents();
            int actualGold = GameManager.Instance.Gold;            
            var archerPrefab = Object.Instantiate(Resources.Load("Prefabs/Units/Archer/ArcherBase") as GameObject);
            archerPrefab.transform.position = new Vector3(-13, 2,0);
            
            //act
            yield return new WaitForSeconds(5);

            //assert
            Assert.Greater(GameManager.Instance.Gold, actualGold);            
        }                            
    }
}
