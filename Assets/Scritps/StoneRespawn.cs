using System.Collections;
using UnityEngine;

public class StoneRespawn : MonoBehaviour
{
    public int TotalStone;

    [SerializeField]private GameObject _stoneprefab;

    private void Start()
    {
        StartCoroutine(CreateStoneRoutine());
    }


    private IEnumerator CreateStoneRoutine()
    {
        while (TotalStone < 10)
        {
            Vector2 _position = new Vector2(Random.Range(36, 55), Random.Range(-2, 11)); // Usamos um local fixo e não variavel, pois sempre quero que as pedras nasçam nesse lugar. (*Metodo variavel usa o confiner).
            Instantiate(_stoneprefab, _position, Quaternion.identity);
            TotalStone++;

        }
        

        yield return null;
    }
    
        
    

}
