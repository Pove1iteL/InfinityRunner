using UnityEngine;

public class MedKit : MonoBehaviour
{
    [SerializeField] private int _healPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerLife>(out PlayerLife playerLife))
        {
            playerLife.TakeHeal(_healPoint);
        }

        Die();
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
