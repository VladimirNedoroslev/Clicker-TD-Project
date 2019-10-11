using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class EditorUnitTestScripts
    {

       /* private void InitializeMainComponents()
        {
            GameObject.Instantiate(Resources.Load("Prefabs/GameManager"));
            GameManager.Instance.StartTheGame();

            GameObject.Instantiate(Resources.Load("Prefabs/GUI/GUIManager"));
        }

        [Test]
        public void HealthBar_Is_Initialized()
        {
            //arrange                        
            var enemyPrefab = GameObject.Instantiate(Resources.Load("Prefabs/Enemies/EvilHead/MonsterEvilHeadLevel_1")) as GameObject;
            int expectedHealth = enemyPrefab.GetComponent<EnemyData>().baseEnemyData.Health;
            var healthBar = enemyPrefab.GetComponentInChildren<HealthBar>();

            //act
            healthBar.Initialize();
            int actualHealth = healthBar.CurrentHealth;

            //assert
            Assert.AreEqual(expectedHealth, actualHealth);
        }

        [Test]
        public void Enemy_Is_Dead_If_Health_Is_Below_Or_Equals_Zero()
        {
            //arrange                        
            var enemyPrefab = GameObject.Instantiate(Resources.Load("Prefabs/Enemies/EvilHead/MonsterEvilHeadLevel_1")) as GameObject;
            int expectedHealth = enemyPrefab.GetComponent<EnemyData>().baseEnemyData.Health;
            var healthBar = enemyPrefab.GetComponentInChildren<HealthBar>();

            //act
            healthBar.Initialize();
            healthBar.DealDamage(expectedHealth);
            bool actualResult = healthBar.IsDead();

            //assert
            Assert.IsTrue(actualResult);
        }

        [Test]
        public void Unit_Upgrade_Reduces_Gold()
        {
            //arrange
            InitializeMainComponents();
            var unitPrefab = GameObject.Instantiate(Resources.Load("Prefabs/Units/Archer/ArcherBase")) as GameObject;
            var upgradeController = unitPrefab.GetComponentInChildren<UpgradeController>();
            int initialGold = GameManager.Instance.Gold;

            //act
            upgradeController.Initialize();
            upgradeController.UpgradeUnit();
            var goldAfterUpgrade = GameManager.Instance.Gold;

            //assert
            Assert.Less(goldAfterUpgrade, initialGold);
        }

        [Test]
        public void GamePause()
        {
            //arrange
            InitializeMainComponents();

            //act
            //GUIManager.Instance.PauseResumeTheGame();

            //assert
            Assert.AreEqual(Time.timeScale, 0f);
        }*/
    }
}
