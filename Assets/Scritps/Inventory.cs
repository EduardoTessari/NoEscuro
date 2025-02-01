using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int stone;

    public void addStone()
    {
        stone++;

        Debug.Log("Quantidade de pedra" + stone);
    }
}
