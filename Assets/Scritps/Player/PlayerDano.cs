using UnityEngine;

public class PlayerDano : MonoBehaviour
{

    PlayerStatus status;

    private void Awake()
    {
        status = GetComponent<PlayerStatus>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {

            status.damageLife();
        }
    }
}
