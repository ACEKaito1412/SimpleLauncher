using UnityEngine;

public class PlayerMovement_2 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private Animator animate;
    void Start()
    {
        animate = GetComponent<Animator>();
        animate.SetBool("walk", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
