using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Destroyer : MonoBehaviour
{
    public Image background;
    [SerializeField]
    Animator man, roommate;
    [SerializeField]
    RhythmButton rb;

    [SerializeField]
    public Sprite[] images;

    [SerializeField]
    GameObject pauseMenu;

    [SerializeField]
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartSong());
    }


    IEnumerator StartSong()
    {
        yield return new WaitForSeconds(3f);
        audioSource.Play();
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(!pauseMenu.activeSelf);

            if(pauseMenu.activeSelf )
            {
                audioSource.Pause();
                Time.timeScale = 0f;
            }
            else
            {
                Time.timeScale = 1.0f;
                audioSource.Play();
            }
                
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Note" && !rb.createMode)
        {
            Destroy(collision.gameObject);

            int rand = Random.Range(0, 3);

            

            switch (rand)
            {
                case 0:
                    roommate.SetTrigger("ROOMATE1");
                    break;
                case 1:
                    roommate.SetTrigger("ROOMATE2");        
                    break;
                case 2:
                    roommate.SetTrigger("ROOMATE3");
                    break;
            }
            if (rb.inView)
            {
                roommate.SetTrigger("Caught");
                man.SetTrigger("Caught");
            }


            StartBackgroundReturn();
        }
    }

    public void StartBackgroundReturn()
    {
        StartCoroutine(BackgroundReturn());
    }

    IEnumerator BackgroundReturn()
    {
        yield return null;
        roommate.SetBool("Roomate1", false);
        roommate.SetBool("Roomate2", false);
        roommate.SetBool("Roomate3", false);

        rb.inView = true;
        
    }
}
