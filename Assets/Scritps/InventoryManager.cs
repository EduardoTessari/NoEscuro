using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int stone, mushStick;

    public bool hasMushstick;

    private TextMeshProUGUI _qtdPedras, _qtdMushStick;

    private GameObject inventarioInstance, weaponSheetSelecion, itemSheetSelecion, _weapon;

    private Button _weaponButton, _itemButton, _equipMushSword;

    [SerializeField] private GameObject _inventario, _weaponLocation;

    public GameObject[] weapons;

    private Transform _cabecalho, _inventarioArma;


    private void Awake()
    {
        //createInventory();
    }


    #region Adiçao de recursos
    public void addStone()
    {
        stone++;

        Debug.Log("Quantidade de pedra" + stone);
    }

    public void addMushStick()
    {
        mushStick++;
        Debug.Log("Quantidade de Galhos de Cogumelo" + mushStick);
    }

    #endregion

    #region Criaçao e abertura do inventario
    public void openListItens()
    {
        if (inventarioInstance != null)
        {
            inventarioInstance.SetActive(!inventarioInstance.activeSelf);
            Time.timeScale = inventarioInstance.activeSelf ? 0 : 1;

            if (inventarioInstance.activeSelf)
            {
                updateQtdPedra();
                updateQtdMushStick();
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

        // configura os botoes do inventário
        _cabecalho = inventarioInstance.transform.Find("Cabeçalho"); // Pegamos o cabeçalho primeiro, que os botoes sao filho dele
        if (_cabecalho != null)
        {
            weaponButtonOnclick();
            itemButtonOnclick();
        }
        else
        {
            Debug.LogWarning("Cabeçalho do inventário não encontrado!");
        }


        // busca as abas dentro do inverntário
        weaponSheetSelecion = inventarioInstance.transform.Find("Image_Inventario(Armas)")?.gameObject;
        if (weaponSheetSelecion == null) Debug.LogWarning("Aba de armas não encontrada!");

        itemSheetSelecion = inventarioInstance.transform.Find("Image_Inventario(Itens)")?.gameObject;
        if (itemSheetSelecion == null) Debug.LogWarning("Aba de itens não encontrada!");

        // Solução para evitar o erro de chave duplicada
        Dictionary<string, TextMeshProUGUI> textos = new Dictionary<string, TextMeshProUGUI>();
        foreach (var text in inventarioInstance.GetComponentsInChildren<TextMeshProUGUI>(true)) // identifica os filhos do inventário
        {
            if (!textos.ContainsKey(text.name)) // Evita duplicatas
                textos.Add(text.name, text);
            else
                Debug.LogWarning($"O texto '{text.name}' já existe no inventário e foi ignorado.");
        }
        // Converte para dicionário para acesso rápido

        textos.TryGetValue("Qtd_Pedras", out _qtdPedras);
        textos.TryGetValue("Qtd_MushStick", out _qtdMushStick);

        updateQtdMushStick();
        updateQtdPedra();

    }

    private void weaponButtonOnclick() // faz com que o botao de arma do inventário funcione(pois o inventário ainda nao existe pra referenciar no inspetor)
    {

        _weaponButton = _cabecalho.transform.Find("BTN_Weapon")?.GetComponent<Button>();

        if (_weaponButton != null)
        {
            _weaponButton.onClick.AddListener(WeaponSheet);
        }
        else
        {
            Debug.LogWarning("Botão de arma não encontrado dentro do inventário!");
        }

        _inventarioArma = inventarioInstance.transform.Find("Image_Inventario(Armas)");

        if (_inventarioArma != null)
        {
            _equipMushSword = _inventarioArma.transform.Find("Btt_EquiparMushSword")?.GetComponent<Button>();

            if (_equipMushSword != null)
            {
                _equipMushSword.onClick.AddListener(SelectMushSword);
            }
            else
            {
                Debug.LogWarning("Botão de seleção não encontrado dentro do inventário!");
            }
        }

        else
        {
            Debug.LogWarning("Botão de inventário não encontrado dentro do inventário!");
        }

    }

    private void itemButtonOnclick() // faz com que o botao de arma do inventário funcione (pois o inventário ainda nao existe pra referenciar no inspetor)
    {
        _itemButton = _cabecalho.transform.Find("BTN_Item")?.GetComponent<Button>();

        if (_itemButton != null)
        {
            _itemButton.onClick.AddListener(ItemSheet);
        }
        else
        {
            Debug.LogWarning("Botão de item não encontrado dentro do inventário!");
        }
    }

    private void WeaponSheet() // Ao selecionar o botao de arma, desativa a tela de item
    {
        if (weaponSheetSelecion != null && itemSheetSelecion != null)
        {
            itemSheetSelecion.SetActive(false);
            weaponSheetSelecion.SetActive(true);

        }
        else
        {
            Debug.LogWarning("Não foi possível encontrar o objeto 'Image_Inventario(Armas)' dentro do inventário!");
        }
    }
    private void ItemSheet() //Ao selecionar o botao de item, desativa a tela de arma
    {
        if (weaponSheetSelecion != null && itemSheetSelecion != null)
        {
            itemSheetSelecion.SetActive(true);
            weaponSheetSelecion.SetActive(false);

        }
        else
        {
            Debug.LogWarning("Não foi possível encontrar o objeto 'Image_Inventario(Armas)' dentro do inventário!");
        }
    }
    #endregion

    #region Atualizaçao de Recursos
    private void updateQtdPedra()
    {
        if (_qtdPedras == null) return;
        {
            _qtdPedras.text = "";
            _qtdPedras.text = stone.ToString();
        }

    }
    private void updateQtdMushStick()
    {
        if (_qtdMushStick == null) return;
        {
            _qtdMushStick.text = "";
            _qtdMushStick.text = mushStick.ToString();
        }
    }
    #endregion

    #region Armas

    private void SelectMushSword()
    {
        _weapon = weapons[0];
        Instantiate(_weapon, _weaponLocation.transform);
    }


    #endregion
}

