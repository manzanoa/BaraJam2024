using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmButton : MonoBehaviour
{
    [SerializeField]
    public KeyCode key1, key2;
    [SerializeField]
    bool active = false;
    [SerializeField]
    GameObject note;
    [SerializeField]
    Animator man, roommate;

    public bool createMode;
    public GameObject notePrefab1, notePrefab2;
    public bool inView;

    public Destroyer d;

    // Start is called before the first frame update
    void Start()
    {
        inView = true;
    }

    // Update is called once per frame
    void Update()
    {


        if (createMode)
        {
            if (Input.GetKeyDown(key1))
            {
                GameObject n = Instantiate(notePrefab1, transform.position, Quaternion.identity);
                n.transform.parent = transform;
            }
            else if (Input.GetKeyDown(key2))
            {
                GameObject n = Instantiate(notePrefab2, transform.position, Quaternion.identity);
                n.transform.parent = transform;
            }
        }
        else
        {
            if (Input.GetKeyDown(key2))
            {
                Debug.Log("Press");

                Destroy(note);
                man.SetTrigger("Hide");
                inView = false;

                int rand = Random.Range(0, 3);
                switch (rand)
                {
                    case 0:
                        roommate.SetTrigger("ROOMATE3");
                        break;
                    case 1:
                        roommate.SetTrigger("ROOMATE2");
                        break;
                    case 2:
                        roommate.SetTrigger("ROOMATE3");
                        break;
                }

                d.StartBackgroundReturn();
            }
            else if(Input.GetKeyDown((key1)))
            {
                Destroy(note);
                man.SetTrigger("Jerk");
                //check for the type of note
                //if jerk start jerk anim and gain points
                //if hide then start hide anim
                //if missed then start caught anim and lose points
                //if jerk but is hide start caught anim and lose points
                //if hide but is jerk start hide anim and lose points
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        active = true;
        if (collision.tag == "Note")
        {
            note = collision.gameObject;
            Debug.Log(note);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        active = false;
        Debug.Log("Note is not in range");
    }
}
