using UnityEngine;

public class ContatoPergaminho : MonoBehaviour
{
    [SerializeField] private GameObject _actionButton;
    [SerializeField] private GameObject _pergaminho;


    private void Awake()
    {
        _pergaminho.SetActive(false);
        _actionButton.SetActive(false);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_actionButton != null)
        {
            if (collision.CompareTag("Player"))
            {
                _actionButton.SetActive(true);
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (_actionButton != null)
        {
            if (collision.CompareTag("Player"))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    // Verifica se o pergaminho est� ativo ou n�o e alterna
                    _pergaminho.SetActive(!_pergaminho.activeSelf); // _pergaminho.SetActive(!_pergaminho.activeSelf): Isso alterna o estado de ativa��o do pergaminho. Se ele estiver ativado, ser� desativado, e se estiver desativado, ser� ativado
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_actionButton != null)
        {
            if (collision.CompareTag("Player"))
            {
                _actionButton.SetActive(false);
            }
        }
    }

    public void FecharPergaminho()
    {
        _pergaminho.SetActive(false);
    }
}

