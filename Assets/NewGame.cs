using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour
{
    RectTransform r;
    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        r.localPosition = new Vector3(96, r.localPosition.y, r.localPosition.z);
    }

    private void OnMouseExit()
    {
        r.localPosition = new Vector3(110, r.localPosition.y, r.localPosition.z);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}
