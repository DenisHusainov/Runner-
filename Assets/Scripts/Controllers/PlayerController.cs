using UnityEngine;

public class PlayerController : MonoBehaviour, ISpawner
{
    private const float Speed = 0.8f;
    private const float RightBorder = 3.5f;
    private const float LeftBorder = -3.5f;

    private Vector3 _moveVector = default;
    private Vector3 _defaultSpeed = default;

    private bool CanMove
    {
        get { return GameManager.Instance.IsStarted && !GameManager.Instance.IsFinished; }
    }

    private void OnEnable()
    {
        GameManager.Finished += GameManager_Finished;
    }

    private void OnDisable()
    {
        GameManager.Finished -= GameManager_Finished;
    }

    private void Awake()
    {
        //_defaultSpeed = GetComponent<Transform>();
    }

    private void Start()
    {
        _defaultSpeed = new Vector3(0, 0, 1f);
    }

    private void FixedUpdate()
    {
        if (!CanMove)
        {
            return;
        }

        _moveVector = GetMoveVector();
        transform.position += _defaultSpeed * Speed;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, LeftBorder, RightBorder), transform.position.y, transform.position.z);
        transform.position += _moveVector;
    }

    private Vector3 GetMoveVector()
    {
        Vector3 dir = Vector3.zero;

        dir.x = UIJoystick.Instance.InputVector.x;

        return dir;
    }

    void ISpawner.Spawn(int count)
    {
        for (int i = 0; i < count; i++)
        {
            var objFromPool = PoolManager.Instance.Get<Poolable>();
            objFromPool.transform.position = new Vector3(Random.Range(LeftBorder, RightBorder), transform.position.y, transform.position.z);
        }
    }

    private void GameManager_Finished()
    {
        gameObject.SetActive(false);
    }

}