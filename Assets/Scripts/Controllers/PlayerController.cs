using UnityEngine;

public class PlayerController : MonoBehaviour, ISpawner
{
    private const float RightBorder = 3.5f;
    private const float LeftBorder = -3.5f;
    private const float DefaultSpeed = 1f;

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

    private void FixedUpdate()
    {
        if (!CanMove)
        {
            return;
        }

        Vector3 expectedPosition = transform.position;
        expectedPosition.z += DefaultSpeed;
        expectedPosition.x += UIJoystick.Instance.InputVector.x;
        expectedPosition.x = Mathf.Clamp(expectedPosition.x, LeftBorder, RightBorder);
        transform.position = expectedPosition;
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