using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class MovingObject : MonoBehaviour
{
    [SerializeField] float objectSpeed = 15.5f;
    [SerializeField] float resetPosition = 0.0f;
    [SerializeField] float startPosition = 0.0f;

    protected void Update()
    {
        MoveLeft();
    }

    private void MoveLeft()
    {
        if (GameManager.instance.playerActive)
            transform.Translate(Vector3.left * objectSpeed * Time.deltaTime);
        if (transform.localPosition.x <= resetPosition)
        {
            var newPos = new Vector3(startPosition, transform.position.y, transform.position.z);
            transform.position = newPos;
        }
    }
}
