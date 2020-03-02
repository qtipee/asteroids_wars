using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    private float verticalSpeed = 100.0f;
    private float horizontalSpeed = 2.0f;
    private float upDownSpeed = 2.0f;

    public float lookSpeed = 10f;

    private float _camRotationY;
    private float _camRotationX;


    public Vector2 sensitivity = new Vector2(0.5f, 0.5f);
    public Vector2 smoothing = new Vector2(3f, 3f);
    public Vector2 clampInDegrees = new Vector2(360, 180);

    public GameManager GM;

    private void Update()
    {
        if (CrossSceneInformation.isPlaying)
		{
            float y = Input.GetAxisRaw("Mouse Y");
            float x = Input.GetAxisRaw("Mouse X");
            float verticalTranslation = Input.GetAxis("Vertical") * verticalSpeed;
            float horizontalTranslation = Input.GetAxis("Horizontal") * horizontalSpeed;

            bool up = Input.GetKey(KeyCode.Space);
            bool down = Input.GetKey(KeyCode.LeftControl);

            float upOrDown = 0.0f;
            if (up)
                upOrDown = 1.0f;
            else if (down)
                upOrDown = -1.0f;

            float upDownTranslation = upOrDown * upDownSpeed;


            Vector2 mouseDelta = new Vector2(x, y);
            mouseDelta = Vector2.Scale(mouseDelta, new Vector2(sensitivity.x * smoothing.x, sensitivity.y * smoothing.y));
            verticalTranslation *= Time.deltaTime;
            transform.Translate(horizontalTranslation, upDownTranslation, verticalTranslation);

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

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            GM.LoadEndScene();
        }
    }
}
