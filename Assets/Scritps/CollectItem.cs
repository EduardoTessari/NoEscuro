using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public class CollectItem : MonoBehaviour
{
    private bool _canCollect;
    private DestroyItem _destroy;

    private Inventory _inventory;

    private void Awake()
    {
        _destroy = GetComponent<DestroyItem>();
        
        _inventory = FindAnyObjectByType<Inventory>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Debug.Log("Pode Me coletar");
            _canCollect = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (_canCollect)
            {
                if (Input.GetKey(KeyCode.E))
                {
                    _canCollect = false;
                    _destroy.DestroyGO(1f);
                    _inventory.addStone();
                    Debug.Log("Obrigado por me coletar");

                }
            } 
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            _canCollect = false;
            Debug.Log("Até logo");

        }
    }
}
