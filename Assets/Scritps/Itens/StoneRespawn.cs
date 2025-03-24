using System.Collections;
using UnityEngine;

public class StoneRespawn : MonoBehaviour
{
    public int TotalStone;
    private bool _isRespawning;


    [SerializeField] private float _respawnTime; // definido no inspector


    [SerializeField]private GameObject _stoneprefab;

    private void Start()
    {
        SpawnInitialStones();
    }


    private void SpawnInitialStones() // cria as pedras no inicio do jogo.
    {
        for (int i = 0; i < 10; i++) // Cria todas de uma vez no início
        {
            Vector2 position = new Vector2(Random.Range(36, 55), Random.Range(-2, 11));
            Instantiate(_stoneprefab, position, Quaternion.identity);
            TotalStone++;
        }
    }

    private IEnumerator CreateStoneRoutine()
    {
        _isRespawning = true;

        while (TotalStone < 10)
        {
            Vector2 _position = new Vector2(Random.Range(36, 55), Random.Range(-2, 11)); // Usamos um local fixo e não variavel, pois sempre quero que as pedras nasçam nesse lugar. (*Metodo variavel usa o confiner).
            Instantiate(_stoneprefab, _position, Quaternion.identity);
            TotalStone++;

            yield return new WaitForSeconds(_respawnTime); // Adiciona um intervalo entre os spawns
        }


        _isRespawning = false; // Para indicar que não precisa mais spawnar
    }
    
     public void removeStone()
    {
        TotalStone--;
        checkCanRespawn();
    }   
    
    public void checkCanRespawn()
    {
        if (TotalStone < 10 && !_isRespawning)
        {
            _isRespawning = true;
            StartCoroutine(CreateStoneRoutine());
        }
    }
}
