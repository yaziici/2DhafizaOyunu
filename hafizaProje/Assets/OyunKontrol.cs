using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OyunKontrol : MonoBehaviour
{
    // GENEL AYARLAR
    public int hedefbasari;
    int ilkSecimDegeri;
    int anlikbasari;
    //------------
    GameObject secilenButon;
    GameObject butonunKendisi;
    //------------
    public TextMeshProUGUI Sayac;
    public Sprite defaultSprite;
    public AudioSource[] sesler;
    public GameObject[] Butonlar;
    public GameObject[] OyunSonuPaneller;
    public Slider ZamanSlider;
    // SAYAÇ
    public float ToplamZaman;
    float dakika;
    float saniye;
    bool zamanlayici;
    float gecenzaman;
    //-------------------

    public GameObject Grid;
    public GameObject Havuz;
    bool olusturmadurumu;
    int OlusturmaSayisi;
    int ToplamElemanSayisi;

    void Start()
    {
        ilkSecimDegeri = 0;
        zamanlayici = true;
        gecenzaman = 0;
        olusturmadurumu = true;
        OlusturmaSayisi = 0;
        ToplamElemanSayisi = Havuz.transform.childCount;
        ZamanSlider.value = gecenzaman;
        ZamanSlider.maxValue = ToplamZaman;



        Debug.Log(Havuz.transform.childCount);
        // Debug.Log(Havuz.transform.GetChild(rastgelesayi).name);

        StartCoroutine(Olustur());
    }


    private void Update()
    {
        if (zamanlayici && gecenzaman!=ToplamZaman)
        {
            gecenzaman += Time.deltaTime;

            ZamanSlider.value = gecenzaman;
            if (ZamanSlider.maxValue == ZamanSlider.value)
            {
                zamanlayici = false;
                GameOver();
            }

        /*dakika = Mathf.FloorToInt(ToplamZaman / 60);     
        saniye = Mathf.FloorToInt(ToplamZaman % 60);

        // Sayac.text = Mathf.FloorToInt(ToplamZaman).ToString();
        Sayac.text = string.Format("{0:00}:{1:00}", dakika, saniye);*/
        }

        
    }

    IEnumerator Olustur()
    {
        yield return new WaitForSeconds(.1f);

        while (olusturmadurumu)
        {
            int rastgelesayi = Random.Range(0, Havuz.transform.childCount - 1);

            if (Havuz.transform.GetChild(rastgelesayi).gameObject != null)
            {
                Havuz.transform.GetChild(rastgelesayi).transform.SetParent(Grid.transform);
                OlusturmaSayisi++;

                if(OlusturmaSayisi == ToplamElemanSayisi)
                {
                    olusturmadurumu = false;
                    Destroy(Havuz.gameObject);
                }
            }
            
        }
    }

    public void Oyunudurdur()
    {
        OyunSonuPaneller[2].SetActive(true);
        Time.timeScale = 0;

    }

    public void OyunaDevamEt()
    {
        OyunSonuPaneller[2].SetActive(false);
        Time.timeScale = 1;

    }
    void GameOver()
    {
        OyunSonuPaneller[0].SetActive(true);
    }
    void Win()
    {
        OyunSonuPaneller[1].SetActive(true);
    }
    public void AnaMenu()
    {
        SceneManager.LoadScene("AnaMenu");
    }
    public void TekrarOyna()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ObjeVer(GameObject objem)
    {
        butonunKendisi = objem;

        butonunKendisi.GetComponent<Image>().sprite = butonunKendisi.GetComponentInChildren<SpriteRenderer>().sprite;
        butonunKendisi.GetComponent<Image>().raycastTarget = false;
        sesler[0].Play();

    }

    void Butonlaridurumu(bool durum)
    {   
        foreach (var item in Butonlar)
        {
            if (item!=null)
            {
                item.GetComponent<Image>().raycastTarget = durum;
            }
            
        }

    }

    public void ButonTikladi(int deger)
    {

        Kontrol(deger);
        
    }

    void Kontrol(int gelendeger)
    {
        if (ilkSecimDegeri == 0)
        {
            ilkSecimDegeri = gelendeger;
            secilenButon = butonunKendisi;

        }
        else
        {
            StartCoroutine(kontroletbakalim(gelendeger));
        }
    }


    IEnumerator kontroletbakalim(int gelendeger)
    {
        Butonlaridurumu(false);
        yield return new WaitForSeconds(1);

        if (ilkSecimDegeri == gelendeger)
        {
            anlikbasari++;
            secilenButon.GetComponent<Image>().enabled = false;
            butonunKendisi.GetComponent<Image>().enabled = false;
            ilkSecimDegeri = 0;
            secilenButon = null;
            Butonlaridurumu(true);
            if (hedefbasari == anlikbasari)
            {
                Win();
            }
        }
        else
        {
            sesler[1].Play();
            secilenButon.GetComponent<Image>().sprite = defaultSprite;
            butonunKendisi.GetComponent<Image>().sprite = defaultSprite;
            ilkSecimDegeri = 0;
            secilenButon = null;
            Butonlaridurumu(true);
        }

    }

    public void Level2()
    {
        SceneManager.LoadScene(2);
    }
    public void Level3()
    {
        SceneManager.LoadScene(3);
    }
    public void Level4()
    {
        SceneManager.LoadScene(4);
    }
    public void Level5()
    {
        SceneManager.LoadScene(5);
    }
    public void Level6()
    {
        SceneManager.LoadScene(6);
    }
}