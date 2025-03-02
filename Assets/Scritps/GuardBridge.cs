using UnityEngine;
using UnityEngine.UI;

public class GuardBridge : MonoBehaviour
{
    [SerializeField]private Canvas _canvas;


    private void Awake()
    {
        _canvas.gameObject.SetActive(false);

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

    public void CloseCanvas()
    {
        _canvas.gameObject.SetActive(false);
    }
}
