using UnityEngine;

public class CraftItem : MonoBehaviour
{
    InventoryManager _inventoryManager;
    [SerializeField] Canvas _canvas;

    private void Awake()
    {
        _canvas.gameObject.SetActive(false);
        _inventoryManager = FindAnyObjectByType<InventoryManager>();
    }
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

    public void Craft()
    {
        if (_inventoryManager != null)
        {
            if (_inventoryManager.hasMushstick == false)
            {
                if (_inventoryManager.stone >= 7 && _inventoryManager.mushStick >= 1)
                {
                    _inventoryManager.hasMushstick = true;
                    _inventoryManager.stone = _inventoryManager.stone - 7;
                    _inventoryManager.mushStick = _inventoryManager.mushStick - 1;
                    Debug.Log("Parabens, você adquiriu o bastao de cogumelo");
                }
                else
                {
                    Debug.Log("Não tem material suficiente");

                }
            }
            else
            {
                Debug.Log("Voce ja possui o item");
            }


        }
    }

    public void CloseCanvas()
    {
        _canvas.gameObject.SetActive(false);
    }
}
