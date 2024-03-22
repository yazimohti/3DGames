using UnityEngine.SceneManagement;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay=1f;
    [SerializeField] AudioClip crushSound;
    [SerializeField] AudioClip finishSound;
    [SerializeField] ParticleSystem crushParticle;
    [SerializeField] ParticleSystem finishParticle;
    

    AudioSource audioSource;
    bool isTransitioning=false;
    bool isCollisionDisable=false;
    void Start()
    {
        audioSource=GetComponent<AudioSource>();
    }
    void Update()
    {
        RespondTheDebugKeys();
    }
    void RespondTheDebugKeys()
    {
        if(Input.GetKeyUp(KeyCode.L))
        {
            NextLevel();
        }
        if(Input.GetKeyUp(KeyCode.C))
        {
            isCollisionDisable= !isCollisionDisable;
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if(isTransitioning || isCollisionDisable){ return; }
        switch(other.gameObject.tag)
        {
            case "Friendly":
            Debug.Log("This is friendly.");
                break;
            case "Finish":
                Debug.Log("You finished.");
                StartSuccessSequence();
                break;
            default:
                Debug.Log("You blew up");
                StartCrushSequence();
                break;
        }    
    }   
    void StartCrushSequence()
    {
        isTransitioning=true;
        audioSource.Stop();
        audioSource.PlayOneShot(crushSound,.02f);
        crushParticle.Play();
        GetComponent<Movement>().enabled=false;
        Invoke("ReloadLevel",levelLoadDelay);
    }
    void StartSuccessSequence()
    {
        isTransitioning=true;
        audioSource.Stop();
        audioSource.PlayOneShot(finishSound);
        finishParticle.Play();
        GetComponent<Movement>().enabled=false;
        Invoke("NextLevel",levelLoadDelay);
    }
    void ReloadLevel()
    {
        int currentSceneIndex=SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    void NextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex=currentSceneIndex+1;
        if(nextSceneIndex==SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex=0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
}
