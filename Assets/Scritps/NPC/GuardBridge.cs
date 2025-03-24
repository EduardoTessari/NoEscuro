using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GuardBridge : MonoBehaviour
{
    [SerializeField]private Canvas _canvas;
    [SerializeField]private int _stonesToRepair;
    private bool _isOpen;

    [SerializeField] private GameObject _closeBridge;
    private InventoryManager _inventoryManager;
    



    private void Awake()
    {
        _isOpen = false;
        _canvas.gameObject.SetActive(false);
        _inventoryManager = FindAnyObjectByType<InventoryManager>();

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Input.GetMouseButtonDown(0))
            {
                _canvas.gameObject.SetActive(true);
            }


        }
    }

    public void OpenBridge()
    {
        if (!_isOpen)
        {
            if (_inventoryManager.stone >= _stonesToRepair)
            {
                _closeBridge.SetActive(false);
                _isOpen = true;
                _canvas.gameObject.SetActive(false);
                Debug.Log("Siga seu caminho");
                _inventoryManager.stone = _inventoryManager.stone - _stonesToRepair;
                Debug.Log(_inventoryManager.stone);
            }
            else
            {
                Debug.Log("Colete mais itens");
            }
        }
        else
        {
            Debug.Log("O caminho ja está aberto");
        }
        
    }

    public void CloseCanvas()
    {
        _canvas.gameObject.SetActive(false);
    }
}
