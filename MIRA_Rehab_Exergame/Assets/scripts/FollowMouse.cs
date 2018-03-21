using UnityEngine;
using System.Collections;

public class FollowMouse : MonoBehaviour {

    private Vector2 mousePosition;
    public float moveSpeed = 0.1f;
    private bool collision = false;
    private bool pause = false;
    GameObject shared;
    ShareVariables sv;

    // Use this for initialization
    void Start () {
        
        shared = GameObject.FindGameObjectWithTag("SharedVariables");
        sv = shared.GetComponent<ShareVariables>();
    }

    // Update is called once per frame
    void Update () {
        pause = sv.getPause();

        if (collision == false && pause == false)
        {
            
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

            mousePosition.x = Mathf.Clamp(mousePosition.x, -6.5f, 6.25f);
            mousePosition.y = Mathf.Clamp(mousePosition.y, - (Screen.height/200) + 1.2f, (Screen.height/200) - 1.2f);

            //Debug.Log(Screen.height);
           // mousePosition.y = Mathf.Clamp(mousePosition.x, -6.5f, 6.7f);
            //if (mousePosition.x < -6.5f || mousePosition.x > 6.7f)
            //{
            //    transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
            //}
            //else
            //{
            transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
            //}
        }
    }

    public void setCollision(bool b)
    {
        collision = b;
    }

    public void stopCar(bool b)
    {
        pause = b;
    }
        
}