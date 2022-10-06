using UnityEngine;
public class EnemyController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float attackRange,enemySpeed=50;
    private float distance;

    void Update()
    {
        Vector3 temp = player.transform.position;
        temp.y = transform.position.y;
        distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance<=attackRange)
        {
            transform.LookAt(temp);
            transform.Translate(transform.forward*enemySpeed*Time.deltaTime);
        }
    }
}
