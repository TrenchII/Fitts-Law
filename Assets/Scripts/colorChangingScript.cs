using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorChangingScript : MonoBehaviour
{
    SpriteRenderer _spriteRenderer;
    public int score = 0;
    private int cur;
    private int [] order;
    public DataLoggerScript dataLoggerScript;
    // Start is called before the first frame update
    void Start()
    {
        cur = 0;
        order = new int[9] {1, 4, 7, 8, 6, 2, 5, 9, 3};
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeColor(GameObject g) {
        if(g.name == "BG" || g.name != order[cur].ToString()) {
            dataLoggerScript.wrong = 1;
        }
        else {
            _spriteRenderer = g.GetComponent<SpriteRenderer>();
            _spriteRenderer.color = new Color(0f, 0f, 0f, 0f);
            if(cur+1 != 9) {
                GameObject next = GameObject.Find(order[cur+1].ToString());
                _spriteRenderer = next.GetComponent<SpriteRenderer>();
                _spriteRenderer.color = new Color(1f, 0f, 0f, 1f);
                cur = cur + 1;
            }
        }
        dataLoggerScript.WriteCSV();
    }
}
