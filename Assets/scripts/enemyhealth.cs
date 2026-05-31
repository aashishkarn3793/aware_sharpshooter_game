



using UnityEngine;

public class enemyhealth : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] int health = 3;
    [SerializeField] GameObject explosionvfx;
    [SerializeField] Vector3 explosionoffset;

    void Update()
    {
        if(health <= 0)
        {
           selfdistruct();
        }
    }
    public void takedamage(int damage)
    {
        health-= damage;
    }
    public void selfdistruct()
    {
         Destroy(gameObject);
         Instantiate(explosionvfx, transform.position+ explosionoffset, Quaternion.identity);
    }
}
