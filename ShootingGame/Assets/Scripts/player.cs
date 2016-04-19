using UnityEngine;
using System.Collections;

public class player : MonoBehaviour
{

    Ranking.Players p;

    // Use this for initialization
    void Start()
    {
        p = new Ranking.Players();
        p.XmlParser(@"D:\player.xml");

        for (int i = 0; i < p.plrs.Count; i++)
        {
            Debug.Log(p.plrs[i].Name);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
