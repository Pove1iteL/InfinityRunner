using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private PlayerLife _player;
    [SerializeField] private Heart _hertPrefab;

    private List<Heart> _hearts = new List<Heart>();

    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(int value)
    {
        if (_hearts.Count < value)
        {
            int createHealths = value - _hearts.Count;

            for (int i = 0; i < createHealths; i++)
            {
                CreateHeart();
            }
        }
        else if (_hearts.Count > value && _hearts.Count != 0)
        {
            int removeHealths = _hearts.Count - value;

            for (int i = 0; i < removeHealths; i++)
            {
                DestroyHert(_hearts[_hearts.Count - 1]);
            }
        }
    }

    private void DestroyHert(Heart heart)
    {
        _hearts.Remove(heart);
        heart.ToEmpty();
    }

    private void CreateHeart()
    {
        Heart heart = Instantiate(_hertPrefab, transform);
        _hearts.Add(heart.GetComponent<Heart>());
        heart.ToFill();
    }
}
