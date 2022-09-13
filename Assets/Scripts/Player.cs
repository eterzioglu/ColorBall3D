using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    #region Variables
    public Bounds bound;
    private Rigidbody rb;
    
    [Range(20,40)]
    public float speedModifier = 0;
    public float forwardSpeed;
    #endregion

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        MovePlayer();
        MoveBounds();
        ControlPlayer();
    }

    private void MovePlayer()
    {
        transform.position += new Vector3(0, 0, forwardSpeed * Time.fixedDeltaTime);
    }

    private void MoveBounds()
    {
        bound.forward.position += new Vector3(0, 0, forwardSpeed * Time.fixedDeltaTime);
        bound.back.position += new Vector3(0, 0, forwardSpeed * Time.fixedDeltaTime);
    }

    private void ControlPlayer()
    {
        float speed = 0;

        if (InputManager.instance.eventData != null) speed = speedModifier;
        else speed = 0;

        rb.velocity = new Vector3(InputManager.instance.deltaPos.x * speed * Time.fixedDeltaTime,
            transform.position.y,
            InputManager.instance.deltaPos.y * speed * Time.fixedDeltaTime);
    }

    private void BallExplosion()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        forwardSpeed = 0;

        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            GameObject childObject = gameObject.transform.GetChild(i).gameObject;
            
            childObject.GetComponent<Collider>().enabled = true;
            childObject.GetComponent<Rigidbody>().isKinematic = false;
            childObject.GetComponent<Rigidbody>().AddForce(5, 5, 5);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("obstacle") && collision.gameObject.GetComponent<MeshRenderer>().material.color !=
            gameObject.gameObject.GetComponent<MeshRenderer>().material.color)
        {
            BallExplosion();
            CameraManager.instance.Fail();
            UIManager.instance.Fail();
        }
    }
}
