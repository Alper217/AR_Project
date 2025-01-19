using UnityEngine;

public class ZombieController : MonoBehaviour
{
    public Transform player;
    public float detectionRange = 10f;
    public float attackRange = 1f;
    public Animator animator;
    public float moveSpeed = 2f;
    public float attackDamage = 10f; 
    public float attackCooldown = 2f; 

    private bool isAttacking = false;
    private float lastAttackTime = -Mathf.Infinity; 
    private HealtArrangement playerHealth;

    void Start()
    {
        playerHealth = player.GetComponent<HealtArrangement>();
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= attackRange)
        {
            if (Time.time >= lastAttackTime + attackCooldown)
            {
                animator.SetBool("IsRunning", false);
                animator.SetBool("IsAttacking", true);
                isAttacking = true;
                AttackPlayer();
                lastAttackTime = Time.time; 
            }
        }
        else if (distanceToPlayer <= detectionRange)
        {
            animator.SetBool("IsRunning", true);
            animator.SetBool("IsAttacking", false);
            isAttacking = false;
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;
            transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z)); 
        }
        else
        {
            animator.SetBool("IsRunning", false);
            animator.SetBool("IsAttacking", false);
            isAttacking = false;
        }
    }

    void AttackPlayer()
    {
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(attackDamage);
        }
    }
}
