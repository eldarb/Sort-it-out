using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BinScript : MonoBehaviour
{

    public AudioClip m_SuccessSound;
    public AudioClip m_FailSound;
    private BoxCollider m_Collider;
    private AudioSource m_AudioSource;

    // Start is called before the first frame update
    void Start()
    {
        m_Collider = GetComponent<BoxCollider>();
        m_AudioSource = GetComponent<AudioSource>();
    }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    private void OnCollisionEnter(Collision collision)
    {
        if((gameObject.tag == "RecyclingHole" && collision.gameObject.tag == "Recycling"))
        {
            //Destroy the trash
            Destroy(collision.gameObject);
            m_AudioSource.PlayOneShot(m_SuccessSound);
            //TODO: point increment
        }
        else 
        {

            m_AudioSource.PlayOneShot(m_FailSound);
            //Spit the item back to the player or ground. TODO: Modify force speed (1000 for right now) and angle.
            collision.gameObject.GetComponent<Rigidbody>().AddForce((transform.forward * -1) * 1000);
            //TODO: point decrement
        }
    }
}
