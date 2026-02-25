using UnityEngine;

public class Damage : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Ennemy"))
        {
            Destroy(collision.gameObject);
        }
    }
}
