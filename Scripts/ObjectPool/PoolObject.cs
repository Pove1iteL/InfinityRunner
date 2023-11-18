using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PoolObject : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capesity;

    private List<GameObject> _pool = new List<GameObject>();

    protected void Initialized(GameObject prefab)
    {
        for (int i = 0; i < _capesity; i++)
        {
            GameObject spawned = Instantiate(prefab, _container.transform);
            spawned.SetActive(false);

            _pool.Add(spawned);
        }
    }

    protected void Initialized(GameObject[] prefabs)
    {
        for (int i = 0; i < _capesity; i++)
        {
            int randomIndex = Random.Range(0, prefabs.Length);
            GameObject spawned = Instantiate(prefabs[randomIndex], _container.transform);
            spawned.SetActive(false);

            _pool.Add(spawned);
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = _pool.FirstOrDefault(obj => obj.activeSelf == false);

        return result != null;
    }
}
