using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    SpriteRenderer myRenderer;
    public Color baseColor;
    public Color actionColor;

    [SerializeField]
    float speed;

    void Start()
    {
        myRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Move(horizontal * speed, vertical * speed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Action();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            ReleaseAction();
        }
    }

    public void Action()
    {
        myRenderer.color = actionColor;
    }

    public void ReleaseAction()
    {
        myRenderer.color = baseColor;
    }

    public void Move(float hDir, float vDir)
    {
        Vector3 newPos = transform.position;
        newPos = new Vector3(newPos.x + hDir * Time.deltaTime, newPos.y + vDir * Time.deltaTime, newPos.z);
        transform.position = newPos;
    }
}
