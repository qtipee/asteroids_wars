using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    private float speed = 100.0f;

    public float lookSpeed = 10f;

    private float _camRotationY;
    private float _camRotationX;

    public Vector2 sensitivity = new Vector2(0.5f, 0.5f);
    public Vector2 smoothing = new Vector2(3f, 3f);
    public Vector2 clampInDegrees = new Vector2(360, 180);

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        float y = Input.GetAxisRaw("Mouse Y");
        float x = Input.GetAxisRaw("Mouse X");
        float translation = Input.GetAxis("Vertical") * speed;

        Vector2 mouseDelta = new Vector2(x, y);
        mouseDelta = Vector2.Scale(mouseDelta, new Vector2(sensitivity.x * smoothing.x, sensitivity.y * smoothing.y));
        translation *= Time.deltaTime;
        transform.Translate(0, 0, translation);

        _camRotationY -= mouseDelta.y * lookSpeed * Time.deltaTime * 10f;
        _camRotationY = Mathf.Clamp(_camRotationY, -90f, 90f);
        _camRotationX -= mouseDelta.x * lookSpeed * Time.deltaTime * 10f;

        transform.localRotation = Quaternion.Euler(_camRotationY, -_camRotationX, 0f);

        if (Input.GetMouseButton(0))
            Cursor.lockState = CursorLockMode.Locked;

        if (Input.GetKeyDown(KeyCode.Escape))
            Cursor.lockState = CursorLockMode.Confined;
    }
}
