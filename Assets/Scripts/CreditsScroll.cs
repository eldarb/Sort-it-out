using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script to scroll credits on the credits page.
/// </summary>
public class CreditsScroll : MonoBehaviour
{

    /// <summary>
    /// Private float variable that holds the speed of the credits.
    /// </summary>
    private float speed = 100.0f;

    // Might need later.
    // // Start is called before the first frame update
    // void Start() { }

    /// <summary>
    /// Scrolls the credits based on time change and speed.
    /// Credits will stop at the thanks in the middle of the screen.
    /// Update is called once per frame.
    /// </summary>
    void Update()
    {
        if(transform.position.y < 9435)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
    }
}
