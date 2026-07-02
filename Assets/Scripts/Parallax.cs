using TreeEditor;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float parallax;
    private Transform cameraTrans;
    private Vector3 previouscameraposition;
    private float spriteWidth, starposition;

    private void Start()
    {
        cameraTrans = Camera.main.transform;
        previouscameraposition = cameraTrans.position;
        spriteWidth = GetComponent<SpriteRenderer>().bounds.size.x;
        starposition = transform.position.x;
    }
    private void LateUpdate()
    {
        float deltaX = (cameraTrans.position.x - previouscameraposition.x) * parallax;
        float moveAmount = cameraTrans.position.x * (1 - parallax);
        transform.Translate(new Vector3(deltaX, 0, 0));
        previouscameraposition = cameraTrans.position;

        if (moveAmount > starposition + spriteWidth)
        {
            transform.Translate(new Vector3(spriteWidth, 0, 0));
            starposition += spriteWidth;
        }
        else if (moveAmount < starposition -spriteWidth)
        {
            transform.Translate(new Vector3(-spriteWidth, 0, 0));
            starposition -= spriteWidth;
        }
    }
}
