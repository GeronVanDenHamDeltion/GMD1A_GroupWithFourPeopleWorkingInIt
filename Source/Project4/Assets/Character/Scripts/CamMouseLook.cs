using UnityEngine;
using System.Collections;

public class CamMouseLook : MonoBehaviour
{
    Vector2 mouseLook;
    Vector2 smoothV;
    public float sensitivity;
    public float smoothing;
    public GameObject character;

	void Start ()
    {
        character = this.transform.parent.gameObject;
	}

    void Update()
    {
        var vector = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        vector = Vector2.Scale(vector, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothV.x = Mathf.Lerp(smoothV.x, vector.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, vector.y, 1f / smoothing);
        mouseLook += smoothV;
        mouseLook.y = Mathf.Clamp(mouseLook.y, -90f, 90f);
        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);
    }
}
