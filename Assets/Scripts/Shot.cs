using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public int force = 5;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Rigidbody2D>().AddForce(Vector3.up * force, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y > 5)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Enemy"))
        {
            other.collider.enabled = false;
            GameObject.FindObjectOfType<PlayerControler>().incrementScore();
            GameObject.FindObjectOfType<PlayerControler>().upScore();
            Destroy(other.gameObject, 2);
        }
    }

}
