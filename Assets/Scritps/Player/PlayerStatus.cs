using UnityEngine;
using UnityEngine.Rendering;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField] private int _life;

    private void Awake()
    {

    }

    public void damageLife()
    {
        _life--;

        if (_life == 0)
        {
            Debug.Log("MOrreu bebe");
        }
        else
        {
            Debug.Log("Vai deixar?");
        }
    }
}
