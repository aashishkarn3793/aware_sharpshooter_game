using UnityEngine;
using UnityEngine.AI;

public class zombienav : MonoBehaviour
{
   
    [SerializeField] GameObject targett;
    [SerializeField] float firstHitDelay = 1.3f;
    const string PLAYER_TAGE = "player";
    enemyhealth emH ;
    NavMeshAgent agentS;
    PLAYERHEALTH phe;
    [SerializeField] Animator animator;
    [SerializeField] float damageCooldown = 2.5f;
    bool playerInside = false;
    bool firstHitDone = false;

    float nextDamageTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        agentS = GetComponent<NavMeshAgent>();
        emH= GetComponent<enemyhealth>();
    }
    void Start()
    {
        phe = FindFirstObjectByType<PLAYERHEALTH>();  
    }
    void Update()
    {
        agentS.speed = 1.5f;
        agentS.SetDestination(targett.transform.position);
        
    }
    
void OnTriggerEnter(Collider other)
{
    if (other.gameObject.CompareTag(PLAYER_TAGE))
    {
        animator.SetBool("HIT", true);

        firstHitDone = false;

        // First damage after 1.3 sec
        nextDamageTime = Time.time + firstHitDelay;
    }
}

void OnTriggerStay(Collider other)
{
    if (other.gameObject.CompareTag(PLAYER_TAGE))
    {
        if (Time.time >= nextDamageTime)
        {
            phe.takeplayerdamage(10);

            if (!firstHitDone)
            {
                firstHitDone = true;
                nextDamageTime = Time.time + damageCooldown;
            }
            else
            {
                nextDamageTime = Time.time + damageCooldown;
            }
        }
    }
}

void OnTriggerExit(Collider other)
{
    if (other.gameObject.CompareTag(PLAYER_TAGE))
    {
        animator.SetBool("HIT", false);

        firstHitDone = false;
    }
}

    // Update is called once per frame

}


