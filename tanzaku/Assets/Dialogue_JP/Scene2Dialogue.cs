using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Scene2Dialogue : MonoBehaviour
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
            Char1name.text = "";
            StartCoroutine(TypeText(Char1speech, "次の昼、立花が部屋を出たあと。"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 3)
        {
            StartCoroutine(FadeIn(ArtBG1));
            ArtBG1.SetActive(true);
            StartCoroutine(FadeIn(ArtMakoto_d));
            ArtMakoto_d.SetActive(true);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 4)
        {
            Char1name.text = "叶 まこと";
            StartCoroutine(TypeText(Char1speech, "はあ…なんとか誤魔化せました。"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 5)
        {
            Char1name.text = "叶 まこと";
            StartCoroutine(TypeText(Char1speech, "でもこれからどうしよう。"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 6)
        {
            StartCoroutine(FadeIn(ArtTakeShiki));
            ArtTakeShiki.SetActive(true);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "秋山 武";
            StartCoroutine(TypeText(Char2speech, "不本意だけど仕方ねえ。あやせ姉の願いを叶うしかねえ。"));
        }
        else if (primeInt == 7)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "秋山 武";
            StartCoroutine(TypeText(Char2speech, "ったく。自分の将来だから自分で仕事探そうよ。"));
        }
        else if (primeInt == 8)
        {
            ArtMakoto_d.SetActive(false);
            ArtMakoto_b.SetActive(true);
            Char1name.text = "叶 まこと";
            StartCoroutine(TypeText(Char1speech, "今回は立花さんのせいじゃないけど…"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 9)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "秋山 武";
            StartCoroutine(TypeText(Char2speech, "わかってる。"));
        }
        else if (primeInt == 10)
        {
            Char1name.text = "叶 まこと";
            StartCoroutine(TypeText(Char1speech, "それで、作戦はなんですか?"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 11)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "秋山 武";
            StartCoroutine(TypeText(Char2speech, "俺はあやせ姉の部屋で手がかりを探す。まことは町で雇用している場所を探す。"));
        }
        else if (primeInt == 12)
        {
            ArtMakoto_b.SetActive(false);
            ArtMakoto_d.SetActive(true);
            Char1name.text = "叶 まこと";
            StartCoroutine(TypeText(Char1speech, "えええ!? たけし、乱入ですよ!"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 13)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "秋山 武";
            StartCoroutine(TypeText(Char2speech, "あいつもだよ！いつも深夜に俺の部屋に乱入してるぞ！眠らせてくれねえ。"));
        }
        else if (primeInt == 14)
        {
            Char1name.text = "叶 まこと";
            StartCoroutine(TypeText(Char1speech, "それ、言い方がちょっと…"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 15)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "秋山 武";
            StartCoroutine(TypeText(Char2speech, "とにかく、あやせ姉のことだから平気。"));
        }
        else if (primeInt == 16)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "秋山 武";
            StartCoroutine(TypeText(Char2speech, "それにこの姿で鍵がなくても出入りは簡単だ。"));
        }
        else if (primeInt == 17)
        {
            ArtMakoto_d.SetActive(false);
            ArtMakoto_b.SetActive(true);
            Char1name.text = "叶 まこと";
            StartCoroutine(TypeText(Char1speech, "ふんん…"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 18)
        {
            Char1name.text = "叶 まこと";
            StartCoroutine(TypeText(Char1speech, "わかりました。今回だけですよ。"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 19)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "秋山 武";
            StartCoroutine(TypeText(Char2speech, "よし、手分けだ。今夜6時に公園で待ち合わせするぞ。いつもの場所だ。"));
        }
        else if (primeInt == 20)
        {
            Char1name.text = "叶 まこと";
            StartCoroutine(TypeText(Char1speech, "うん!"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 21)
        {
            StartCoroutine(FadeOut(ArtTakeShiki));
            StartCoroutine(FadeOut(ArtMakoto_b));
            StartCoroutine(FadeOut(ArtBG1));
            DialogueDisplay.SetActive(false);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "";
            Char2speech.text = "";
            //nextButton.SetActive(false);
            //NextSceneButton.SetActive(true);
        }
        else if (primeInt == 22)
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
        SceneManager.LoadScene("Scene3");
    }
}