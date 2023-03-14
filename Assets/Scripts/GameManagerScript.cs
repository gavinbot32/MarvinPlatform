using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManagerScript : MonoBehaviour
{

    public TextMeshProUGUI pointsTxt;
    public PlayerController player;
    public bool usePoints = true;
    // Start is called before the first frame update
    void Start()
    {
        if (usePoints)
        {
            player = FindObjectOfType<PlayerController>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (usePoints)
        {
            pointsTxt.SetText((player.points).ToString());
        }
    }
    public void load_scene(int level)
    {
        SceneManager.LoadScene(level);
    }
}
