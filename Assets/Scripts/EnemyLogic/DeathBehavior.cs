using UnityEngine;

public class DeathBehavior : MonoBehaviour
{
   public void OnDeathActions()
    {
        GetComponent<MoveEnemy>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
        var enemyAnimator = gameObject.GetComponent<Animator>();
        enemyAnimator.SetBool("IsDead", true);
        enemyAnimator.Play("Death", 0);        
                       
        GUIManager.Instance.CreatePopupText("+" + gameObject.GetComponent<EnemyData>().baseEnemyData.Reward.ToString(), gameObject.transform);
        GameManager.Instance.Gold += gameObject.GetComponent<EnemyData>().baseEnemyData.Reward;

        Destroy(gameObject, enemyAnimator.GetCurrentAnimatorClipInfo(0).Length);
    }
}
