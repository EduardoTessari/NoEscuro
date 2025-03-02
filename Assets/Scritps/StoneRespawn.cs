using System.Collections;
using UnityEngine;

public class StoneRespawn : MonoBehaviour
{
    public int TotalStone;
    [SerializeField] private float _respawnTime = 300f;


    [SerializeField]private GameObject _stoneprefab;

    private void Start()
    {
        StartCoroutine(CreateStoneRoutine());
    }

    public void respawnStone()
    {
        float _startTime = Time.time; // variable created to set a time rule

        float _elapsedTime = Time.time - _startTime;

        if (TotalStone < 10 && _elapsedTime >= _respawnTime)
        {
            Debug.Log(_elapsedTime);
            StartCoroutine(CreateStoneRoutine());
        }
        
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
