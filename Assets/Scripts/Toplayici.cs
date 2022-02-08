using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toplayici : MonoBehaviour
{
    GameObject anaKup;
    int yukseklik;

    [SerializeField] List<GameObject> toplananKupler;

    void Start()
    {
        anaKup = GameObject.Find("AnaKup");
    }
    void Update()
    {
        anaKup.transform.position = new Vector3(transform.position.x, yukseklik + 1, transform.position.z);
        this.transform.localPosition = new Vector3(0, -yukseklik, 0);
    }

    public void YukseklikAzalt()
    {
        yukseklik--;
    }

    private void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Topla" && c.gameObject.GetComponent<ToplanacakKup>().GetToplandiMi()==false)
        {
            yukseklik += 1;
            toplananKupler.Add(c.gameObject);
            c.gameObject.GetComponent<ToplanacakKup>().ToplandiYap();
            c.gameObject.GetComponent<ToplanacakKup>().IndexAyarla(yukseklik);
            c.gameObject.transform.parent = anaKup.transform;
        }
        if (c.gameObject.tag == "Engel" )
        {
            
            c.GetComponent<BoxCollider>().enabled = false;

            if (toplananKupler.Count>1)
            {
                YukseklikAzalt();
                toplananKupler[toplananKupler.Count - 1].transform.parent = null;
                toplananKupler.RemoveAt(toplananKupler.Count - 1);
            }
            else
            {
                
                Debug.Log("lose game");
                
            }

        }
    }
}
