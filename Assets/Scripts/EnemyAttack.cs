using UnityEngine;
using UnityEngine.SceneManagement;

public class Damage : MonoBehaviour
{
    public PlayerHealth pHealth;
    public GameObject hitbox;
    public float damage;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pHealth.health -= damage;

        }




    }
}



















