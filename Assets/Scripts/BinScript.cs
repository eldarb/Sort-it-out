using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Script for the behavior of the bins.
/// </summary>
public class BinScript : MonoBehaviour
{
    /// <summary>
    /// Public AudioClip variable that holds the successSound.
    /// </summary>
    public AudioClip m_SuccessSound;
    /// <summary>
    /// Public AudioClip variable that holds the failSound.
    /// </summary>
    public AudioClip m_FailSound;
    /// <summary>
    /// Private BoxCollider variable that holds the bin's 3D Box Collider.
    /// </summary>
    private BoxCollider m_Collider;
    /// <summary>
    /// Private BoxCollider variable that holds the bin's Audio Source.
    /// </summary>
    private AudioSource m_AudioSource;
    /// <summary>
    /// script that handles change in score
    /// </summary>
    private ScoreManager scoreManager;

    private GameObject m_Recyclables;

    /// <summary>
    /// Start is called before the first frame update.
    /// Sets m_Collider and m_AudioSource.
    /// </summary>
    void Start()
    {
        m_Collider = GetComponent<BoxCollider>();
        m_AudioSource = GetComponent<AudioSource>();
        scoreManager = FindObjectOfType<ScoreManager>();
        m_Recyclables = GameObject.Find("Recyclables");
    }

    /// <summary>
    /// On Collision, it'll play a certain sound if the player put the trash in the correct bin.
    /// </summary>
    /// <param name="collision"> The Collision that hit the binHole</param>
    private void OnCollisionEnter(Collision collision)
    {
        //Logic for the 4 bins. Checks tags to make sure the gameobject is going into the right bin.
        if((gameObject.CompareTag("RecyclingHole") && collision.gameObject.CompareTag("Recycling"))
        || (gameObject.CompareTag("GlassHole") && collision.gameObject.CompareTag("Glass"))
        || (gameObject.CompareTag("MetalHole") && collision.gameObject.CompareTag("Metal"))
        || (gameObject.CompareTag("PlasticHole") && collision.gameObject.CompareTag("Plastic")))
        {
            //Destroy the trash
            Destroy(collision.gameObject);
            //Plays Success sound once. 
            m_AudioSource.PlayOneShot(m_SuccessSound);
            //Point increment
            if(scoreManager != null) { scoreManager.scoreIncrement(); }
            m_Recyclables.GetComponent<ItemCounter>().addItem(1);
            
        }
        // Prevents the fail sound to play due to binHole collision with Bins.
        else if ((gameObject.CompareTag("RecyclingHole") && collision.gameObject.CompareTag("RecyclingBin"))
        || (gameObject.CompareTag("GlassHole") && collision.gameObject.CompareTag("GlassBin"))
        || (gameObject.CompareTag("MetalHole") && collision.gameObject.CompareTag("MetalBin"))
        || (gameObject.CompareTag("PlasticHole") && collision.gameObject.CompareTag("PlasticBin")))
        {
            
        }
        else 
        {
            //Plays fail sound once.
            m_AudioSource.PlayOneShot(m_FailSound);
            //Spit the item back to the player or ground. TODO: Modify force speed (1000 for right now) and angle.
            collision.gameObject.GetComponent<Rigidbody>().AddForce((transform.forward * -1) * 1000);
            //Point decrement
            if (scoreManager != null){ scoreManager.scoreDecrement(); }
        }
    }
}
