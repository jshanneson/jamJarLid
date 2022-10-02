using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageMovement : MonoBehaviour
{

    public Vector2 _newPosition;
    public Quaternion _newRotation;
    public Vector2 min;
    public Vector2 max;
    public Vector2 yRotationRange;
    [SerializeField]
    [Range(0.01f, 0.1f)]
    private float lerpSpeed = 0.05f;

    private void Awake()
    {
        _newPosition = transform.position;
        _newRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, _newPosition, Time.deltaTime * lerpSpeed);
        transform.rotation = Quaternion.Lerp(transform.rotation, _newRotation, Time.deltaTime * lerpSpeed);

        if (Vector3.Distance(transform.position, _newPosition) < 1f)
        {
            GetNewPosition();
        }
    }

    void GetNewPosition()
    {
        var xPos = Random.Range(min.x, max.x);
        var zPos = Random.Range(min.y, max.y);
        _newRotation = Quaternion.Euler(0, Random.Range(yRotationRange.x, yRotationRange.y), 0);
        _newPosition = new Vector3(xPos, 0, zPos);
    }
}

