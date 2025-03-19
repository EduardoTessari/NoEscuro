using UnityEngine;
using static UnityEditor.FilePathAttribute;

public class Equip_MushSword : MonoBehaviour
{
    private GameObject _weaponLocation;
    private GameObject _weapon;
    private InventoryManager _inventoryManager;
     
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        _inventoryManager = GetComponent<InventoryManager>();
        _weaponLocation = GameObject.Find("Weapon(Location)");
    }

    public void EquipSword()
    {
        _weapon = _inventoryManager.weapons[0];
        Instantiate(_weapon, _weaponLocation.transform);
    }
}
