using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerMovement _mover;

    private void Awake()
    {
        _mover = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _mover.TryMoveUp();
        }

        if(Input.GetKeyDown(KeyCode.S))
        {
            _mover.TryMoveDown();
        }
    }
}
