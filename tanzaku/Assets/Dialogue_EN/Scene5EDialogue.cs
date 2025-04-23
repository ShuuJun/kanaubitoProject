using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Scene5EDialogue : MonoBehaviour
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
            StartCoroutine(TypeText(Char1speech, "1時間後"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 3)
        {
            StartCoroutine(FadeIn(ArtBG1));
            ArtBG1.SetActive(true);
            StartCoroutine(FadeIn(ArtTakeShiki));
            ArtTakeShiki.SetActive(true);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 4)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "秋山 武";
            StartCoroutine(TypeText(Char2speech, "…"));
        }
        else if (primeInt == 5)
        {
            StartCoroutine(FadeIn(ArtMakoto_d));
            ArtMakoto_d.SetActive(true);
            Char1name.text = "叶 まこと";
            StartCoroutine(TypeText(Char1speech, "たけし!やっと出られました!"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 6)
        {
            ArtMakoto_d.SetActive(false);
            ArtMakoto_b.SetActive(true);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "秋山 武";
            StartCoroutine(TypeText(Char2speech, "ああ…まあ、ちょっとね。とりあえず情報を交換しよう。"));
        }
        else if (primeInt == 7)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "";
            StartCoroutine(TypeText(Char2speech, "…"));
        }
        else if (primeInt == 8)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "秋山 武";
            StartCoroutine(TypeText(Char2speech, "そっか、そんなことあったか。たしかに、教員免許を見たな。"));
        }
        else if (primeInt == 9)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "秋山 武";
            StartCoroutine(TypeText(Char2speech, "ったく…あんなガキの頃の俺が言ったことをまだ覚えてて…"));
        }
        else if (primeInt == 10)
        {
            ArtMakoto_b.SetActive(false);
            ArtMakoto_a.SetActive(true);
            Char1name.text = "叶 まこと";
            StartCoroutine(TypeText(Char1speech, "それってたけしのことを大事にしているんですよ。"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 11)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "秋山 武";
            StartCoroutine(TypeText(Char2speech, "…知ってる。俺もだ。"));
        }
        else if (primeInt == 12)
        {
            Char1name.text = "叶 まこと";
            StartCoroutine(TypeText(Char1speech, "たけし!"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 13)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "秋山 武";
            StartCoroutine(TypeText(Char2speech, "でもあいつに絶対に言うなよ。調子に乗るから。"));
        }
        else if (primeInt == 14)
        {
            Char1name.text = "叶 まこと";
            StartCoroutine(TypeText(Char1speech, "はいはい、わかりました。"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 15)
        {
            ArtMakoto_a.SetActive(false);
            ArtMakoto_b.SetActive(true);
            Char1name.text = "叶 まこと";
            StartCoroutine(TypeText(Char1speech, "ところで、立花さんはすぐに教師の仕事を見つけられると思いますか?"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 16)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "秋山 武";
            StartCoroutine(TypeText(Char2speech, "一人で? 無理だろう。"));
        }
        else if (primeInt == 17)
        {
            ArtMakoto_b.SetActive(false);
            ArtMakoto_d.SetActive(true);
            Char1name.text = "叶 まこと";
            StartCoroutine(TypeText(Char1speech, "でもそれってたけしが元に戻れないんじゃない?"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 18)
        {
            ArtMakoto_d.SetActive(false);
            ArtMakoto_b.SetActive(true);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "秋山 武";
            StartCoroutine(TypeText(Char2speech, "安心しろ。今夜姉貴に聞くぞ。"));
        }
        else if (primeInt == 19)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "秋山 武";
            StartCoroutine(TypeText(Char2speech, "…ちょっと怖ぇけどしょうがねえ。姉貴は知り合いが多いからな…"));
        }
        else if (primeInt == 20)
        {
            Char1name.text = "叶 まこと";
            StartCoroutine(TypeText(Char1speech, "そっか、琴音さんはたけしの変身姿をもう知っていますよね。"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 21)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "秋山 武";
            StartCoroutine(TypeText(Char2speech, "ああ、姉貴には何も隠せねえ。すぐバレた。"));
        }
        else if (primeInt == 22)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "秋山 武";
            StartCoroutine(TypeText(Char2speech, "まあそういうことだから、明日はまた公園で会おうぜ。"));
        }
        else if (primeInt == 23)
        {
            ArtMakoto_b.SetActive(false);
            ArtMakoto_a.SetActive(true);
            Char1name.text = "叶 まこと";
            StartCoroutine(TypeText(Char1speech, "了解です。また明日ね。"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 24)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "秋山 武";
            StartCoroutine(TypeText(Char2speech, "ああ、じゃあな。"));
        }
        else if (primeInt == 25)
        {
            StartCoroutine(FadeOut(ArtTakeShiki));
            StartCoroutine(FadeOut(ArtMakoto_a));
            StartCoroutine(FadeOut(ArtBG1));
            DialogueDisplay.SetActive(false);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "";
            Char2speech.text = "";
            //nextButton.SetActive(false);
            //NextSceneButton.SetActive(true);
        }
        else if (primeInt == 26)
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
        SceneManager.LoadScene("Scene6");
    }
}