using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        switch(other.gameObject.tag)
        {
            case "Fuel":
                Debug.Log("You picked up fuel.");
                break;
            case "Friendly":
            Debug.Log("This is friendly.");
                break;
            case "Finish":
                Debug.Log("You finished.");
                break;
            default:
                Debug.Log("You blew up");
                break;
        }    
    }   
}
