using System.Linq;
using TMPro;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int stone;

    private TextMeshProUGUI _qtdPedras;

    private GameObject inventarioInstance;

    [SerializeField] private GameObject _inventario;


    private void Awake()
    {
        //createInventory();
    }

    public void addStone()
    {
        stone++;
        Debug.Log("Quantidade de pedra" + stone);
    }

    public void openListItens()
    {
        if (inventarioInstance != null)
        {
            inventarioInstance.SetActive(!inventarioInstance.activeSelf);
            Time.timeScale = inventarioInstance.activeSelf ? 0 : 1;

            if (inventarioInstance.activeSelf)
            {
                updateQtdPedra();
            }
        }
        else
        {
            createInventory();
         
        }

    }

    private void createInventory()
    {
        inventarioInstance = Instantiate(_inventario);

        if (inventarioInstance != null)
        {
            inventarioInstance.SetActive(true);
            Time.timeScale = 0;
        }

        TextMeshProUGUI[] textos = inventarioInstance.GetComponentsInChildren<TextMeshProUGUI>(); // Identifica quais filhos do canvas são texto

        _qtdPedras = textos.FirstOrDefault(t => t.name == "Qtd_Pedras"); // Expressao lambda, que identificada dentro do array o texto "qtd_pedras", se nao houve, ele retorna valor null.

        updateQtdPedra();
    }

    private void updateQtdPedra()
    {
        if (_qtdPedras == null) return;
        {
            _qtdPedras.text = "";
            _qtdPedras.text = stone.ToString();
        }
        
    }
}
