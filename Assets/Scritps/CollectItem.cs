using UnityEngine;

public class CollectItem : MonoBehaviour
{
    private bool _canCollect;
    private DestroyItem _destroy;

    private InventoryManager _inventory; //Instancia o Script de inventário que está no gerenciador de inventário (tem que ter apenas 1 no jogo)
    private StoneRespawn _stoneMG; //Instancia o Script de Respawn da Pedras que está no gerenciador de Itens (tem que ter apenas 1 no jogo)

    private void Awake()
    {
        _destroy = GetComponent<DestroyItem>();
        _stoneMG = FindAnyObjectByType<StoneRespawn>(); //Localiza o script de StoneRespawn (tem que ter apenas 1 no jogo)
        _inventory = FindAnyObjectByType<InventoryManager>(); //Localiza o script de Inventorio (tem que ter apenas 1 no jogo)
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
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
                    _destroy.DestroyGO(1f); // Destroi depois de Xf de coleta
                    if (gameObject.tag == "Stone")
                    {
                        //_stoneMG.TotalStone--; // Diminui o total de Minas no jogo (Talvez tenha que trocar por uma nova rotina aqui);
                        //_stoneMG.respawnStone();
                        _inventory.addStone();
                    }
                    else if(gameObject.tag == "Mushroom")
                    {
                        _inventory.addMushStick();
                    }
                    
                    Debug.Log("Obrigado por me coletar");

                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _canCollect = false;
            Debug.Log("Até logo");

        }
    }
}
