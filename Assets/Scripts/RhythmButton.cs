using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmButton : MonoBehaviour
{
    [SerializeField]
    public KeyCode key;
    [SerializeField]
    bool active = false;
    [SerializeField]
    GameObject note;
    [SerializeField]
    Animator man, roommate;

    public bool createMode;
    public GameObject notePrefab;
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
            if (Input.GetKeyDown(key))
            {
                GameObject n = Instantiate(notePrefab, transform.position, Quaternion.identity);
                n.transform.parent = transform;
            }
        }
        else
        {
            if (Input.GetKeyDown(key))
            {
                Debug.Log("Press");

                Destroy(note);
                man.SetBool("Hide", true);
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
