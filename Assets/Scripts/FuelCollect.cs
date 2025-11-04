using UnityEngine;

public class FuelCollect : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            FuelController.instance.RefillFuel();
            Destroy(gameObject);
        }
    }
}
