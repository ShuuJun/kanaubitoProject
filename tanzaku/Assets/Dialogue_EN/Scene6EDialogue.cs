using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Scene6EDialogue : MonoBehaviour
{
    public int primeInt = 1;        // game progress int
    public TMP_Text Char1name;
    public TMP_Text Char1speech;
    public TMP_Text Char2name;
    public TMP_Text Char2speech;
    public GameObject DialogueDisplay;

    //art assets
    public GameObject ArtMakoto_a;
    public GameObject ArtMakoto_b;
    public GameObject ArtMakoto_c;
    public GameObject ArtMakoto_d;
    public GameObject ArtTakeshiL_a;
    public GameObject ArtTakeshiL_b;
    public GameObject ArtTakeshiL_c;
    public GameObject ArtTakeshiL_d;
    public GameObject ArtTakeshiR_a;
    public GameObject ArtTakeshiR_b;
    public GameObject ArtTakeshiR_c;
    public GameObject ArtTakeshiR_d;
    public GameObject ArtAyase_a;
    public GameObject ArtAyase_b;
    public GameObject ArtAyase_c;
    public GameObject ArtAyase_d;
    public GameObject ArtTakeShiki;
    public GameObject ArtBG1;
    //Scene control
    public GameObject NextSceneButton;
    public GameObject nextButton;
    //public AudioSource audioSource1;
    private bool allowSpace = true;

    // Set initial visibility. Added images or buttons need to also be SetActive(false);
    void Start()
    {
        DialogueDisplay.SetActive(false);
        ArtMakoto_a.SetActive(false);
        ArtMakoto_b.SetActive(false);
        ArtMakoto_c.SetActive(false);
        ArtMakoto_d.SetActive(false);
        ArtTakeshiL_a.SetActive(false);
        ArtTakeshiL_b.SetActive(false);
        ArtTakeshiL_c.SetActive(false);
        ArtTakeshiL_d.SetActive(false);
        ArtTakeshiR_a.SetActive(false);
        ArtTakeshiR_b.SetActive(false);
        ArtTakeshiR_c.SetActive(false);
        ArtTakeshiR_d.SetActive(false);
        ArtAyase_a.SetActive(false);
        ArtAyase_b.SetActive(false);
        ArtAyase_c.SetActive(false);
        ArtAyase_d.SetActive(false);
        ArtTakeShiki.SetActive(false);
        ArtBG1.SetActive(false);
        NextSceneButton.SetActive(false);
        nextButton.SetActive(true);
    }

    // Use the spacebar as a faster "Next" button:
    void Update()
    {
        if (allowSpace == true)
        {
            if (Input.GetKeyDown("space"))
            {
                Next();
            }

            // secret debug code: go back 1 Story Unit, if NEXT is visible
            if (Input.GetKeyDown("p"))
            {
                primeInt -= 2;
                Next();
            }
        }
    }

    //Story
    public void Next()
    {
        primeInt += 1;
        if (primeInt == 1)
        {
            // audioSource1.Play();
            
        }
        else if (primeInt == 2)
        {
            DialogueDisplay.SetActive(true);
            StartCoroutine(FadeIn(ArtBG1));
            ArtBG1.SetActive(true);
            StartCoroutine(FadeIn(ArtAyase_c));
            ArtAyase_c.SetActive(true);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 3)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "立花 あやせ";
            StartCoroutine(TypeText(Char2speech, "ふん? どうして私の教員免許がここに? あとこのノート…"));
        }
        else if (primeInt == 4)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "ノート";
            StartCoroutine(TypeText(Char2speech, "あやせ姉、いつ先生になるか?"));
        }
        else if (primeInt == 5)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "ノート";
            StartCoroutine(TypeText(Char2speech, "先生になっても、たまに俺にまた勉強教えてくれるよな?"));
        }
        else if (primeInt == 6)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "ノート";
            StartCoroutine(TypeText(Char2speech, "-武"));
        }
        else if (primeInt == 7)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "立花 あやせ";
            StartCoroutine(TypeText(Char2speech, "…"));
        }
        else if (primeInt == 8)
        {
            ArtAyase_c.SetActive(false);
            ArtAyase_d.SetActive(true);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "立花 あやせ";
            StartCoroutine(TypeText(Char2speech, "もうたっくんったら…"));
        }
        else if (primeInt == 9)
        {
            ArtAyase_d.SetActive(false);
            ArtAyase_b.SetActive(true);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "立花 あやせ";
            StartCoroutine(TypeText(Char2speech, "お姉ちゃんが本気になっちゃうかもよ。えへへへ〜"));
        }
        else if (primeInt == 10)
        {
            ArtAyase_b.SetActive(false);
            ArtAyase_c.SetActive(true);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "立花 あやせ";
            StartCoroutine(TypeText(Char2speech, "…"));
        }
        else if (primeInt == 11)
        {
            ArtAyase_c.SetActive(false);
            ArtTakeshiR_d.SetActive(true);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "立花 あやせ";
            StartCoroutine(TypeText(Char2speech, "…「第一歩」ね…"));
        }
        else if (primeInt == 12)
        {
            StartCoroutine(FadeOut(ArtTakeshiR_d));
            StartCoroutine(FadeOut(ArtBG1));
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 13)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "";
            StartCoroutine(TypeText(Char2speech, "次の朝"));
        }
        else if (primeInt == 14)
        {
            StartCoroutine(FadeIn(ArtBG1));
            ArtBG1.SetActive(true);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 15)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "";
            StartCoroutine(TypeText(Char2speech, "トゥルルルル! トゥルルルル!"));
        }
        else if (primeInt == 16)
        {
            StartCoroutine(FadeIn(ArtAyase_d));
            ArtAyase_d.SetActive(true);
            StartCoroutine(FadeIn(ArtTakeshiR_d));
            ArtTakeshiR_d.SetActive(false);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "立花 あやせ";
            StartCoroutine(TypeText(Char2speech, "もしもし? どなたですか?"));
        }
        else if (primeInt == 17)
        {
            ArtAyase_d.SetActive(false);
            ArtAyase_c.SetActive(true);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "立花 あやせ";
            StartCoroutine(TypeText(Char2speech, "…! お母さん!?"));
        }
        else if (primeInt == 18)
        {
            ArtAyase_c.SetActive(false);
            ArtTakeshiR_d.SetActive(true);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "立花 あやせ";
            StartCoroutine(TypeText(Char2speech, "どうやって私の番号を…"));
        }
        else if (primeInt == 19)
        {
            ArtAyase_c.SetActive(true);
            ArtTakeshiR_d.SetActive(false);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "立花 あやせ";
            StartCoroutine(TypeText(Char2speech, "…え!? 琴音ちゃんが!? …え!!?? 学校との面接!?"));
        }
        else if (primeInt == 20)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "立花 あやせ";
            StartCoroutine(TypeText(Char2speech, "そして卒業式の次の日、父さんと母さんの故障してた携帯たちがやっと修理できて、私のメッセージを見た!? ずっと謝りたかった!?"));
        }
        else if (primeInt == 21)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "立花 あやせ";
            StartCoroutine(TypeText(Char2speech, "ちょっと待ってて、ついていけないから一つずつだよ！"));
        }
        else if (primeInt == 22)
        {
            ArtAyase_c.SetActive(false);
            ArtTakeshiR_c.SetActive(true);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "立花 あやせ";
            StartCoroutine(TypeText(Char2speech, "…えええ!!!??? 親失格だと!? そんな大げさ!"));
        }
        else if (primeInt == 23)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "立花 あやせ";
            StartCoroutine(TypeText(Char2speech, "もうお父さん、泣かないでよ! 私のせいだから!"));
        }
        else if (primeInt == 24)
        {
            StartCoroutine(FadeOut(ArtTakeshiR_c));
            StartCoroutine(FadeOut(ArtBG1));
            DialogueDisplay.SetActive(false);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 25)
        {
            SceneChange();
        }

        IEnumerator TypeText(TMP_Text target, string fullText)
        {
            float delay = 0.01f;
            nextButton.SetActive(false);
            allowSpace = false;
            for (int i = 0; i < fullText.Length + 1; i++)
            {
                string currentText = fullText.Substring(0, i);
                target.text = currentText;
                yield return new WaitForSeconds(delay);
            }
            nextButton.SetActive(true);
            allowSpace = true;
        }

        IEnumerator FadeIn(GameObject fadeImage)
        {
            float alphaLevel = 0;
            fadeImage.GetComponent<Image>().color = new Color(1, 1, 1, alphaLevel);
            for (int i = 0; i < 100; i++)
            {
                alphaLevel += 0.01f;
                yield return null;
                fadeImage.GetComponent<Image>().color = new Color(1, 1, 1, alphaLevel);
                Debug.Log("Alpha is: " + alphaLevel);
            }
        }

        IEnumerator FadeOut(GameObject fadeImage)
        {
            float alphaLevel = 1;
            float x = 1;
            float y = 1;
            float z = 1;
            fadeImage.GetComponent<Image>().color = new Color(x, y, z, alphaLevel);
            for (int i = 0; i < 100; i++)
            {
                x -= 0.01f;
                y -= 0.01f;
                z -= 0.01f;
                alphaLevel -= 0.01f;
                yield return null;
                fadeImage.GetComponent<Image>().color = new Color(x, y, z, alphaLevel);
                Debug.Log("Alpha is: " + alphaLevel);
            }
        }
        //Please do NOT delete this final bracket that ends the Next() function:
    }

    public void SceneChange()
    {
        SceneManager.LoadScene("Scene7");
    }
}