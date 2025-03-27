using System.Xml.Serialization;
using UnityEngine;

public class GoblinVazioDano : MonoBehaviour
{
    private PlayerStatus _status;
    private Vector2 _newPosition;

    private void Awake()
    {
        _status = GetComponent<PlayerStatus>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //_status.damageLife();
            Debug.Log("Ataque feito");
            Teleport();
            Debug.Log("Me Teleportei");
        }
        
    }

    private void Teleport()
    {
        _newPosition = new Vector2(transform.position.x + Random.Range(-4, 4), transform.position.y + Random.Range(-4, 4));

        gameObject.transform.root.position = _newPosition;
    }
}
