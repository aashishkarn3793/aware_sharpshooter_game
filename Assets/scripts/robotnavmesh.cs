using UnityEngine;
using UnityEngine.AI;

public class script : MonoBehaviour
{
    [SerializeField] GameObject target;
    const string PLAYER_TAG = "player";
    enemyhealth em ;
    NavMeshAgent agent;
    PLAYERHEALTH ph;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        em = GetComponent<enemyhealth>();
    }
    void Start()
    {
        ph = FindFirstObjectByType<PLAYERHEALTH>();  
    }
    void Update()
    {
        
        agent.SetDestination(target.transform.position);
        //agent.transform.LookAt(target.transform);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(PLAYER_TAG))
        {  
            ph.takeplayerdamage(4);
            em.selfdistruct();
        }
    }

    // Update is called once per frame

}
