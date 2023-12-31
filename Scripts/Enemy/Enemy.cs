using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerLife>(out PlayerLife playerLife))
        {
            playerLife.ApplyDamge(_damage);
        }

        Die();
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
