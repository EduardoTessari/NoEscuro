using UnityEngine;

public class DestroyItem : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void DestroyGO(float delay)
    {
        Destroy(this.gameObject, delay);
    }
}
