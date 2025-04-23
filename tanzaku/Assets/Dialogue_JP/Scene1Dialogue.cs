using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Scene1Dialogue : MonoBehaviour
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
            StartCoroutine(TypeText(Char1speech, "あなたが望むものは、あなたが思っているよりも近いかもしれません。"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 3)
        {

            Char1name.text = "";
            StartCoroutine(TypeText(Char1speech, "成功への第一歩を踏み出すだけでいいのです。"));
            Char2name.text = "";
            Char2speech.text = "";
            //gameHandler.AddPlayerStat(1);
        }
        else if (primeInt == 4)
        {
            StartCoroutine(FadeIn(ArtBG1));
            ArtBG1.SetActive(true);
            StartCoroutine(FadeIn(ArtMakoto_a));
            ArtMakoto_a.SetActive(true);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 5)
        {
            Char1name.text = "叶 まこと";
            StartCoroutine(TypeText(Char1speech, "ふん、なるほど。"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 6)
        {
            StartCoroutine(FadeIn(ArtTakeshiR_a));
            ArtTakeshiR_a.SetActive(true);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "秋山 武";
            StartCoroutine(TypeText(Char2speech, "なあまこと、何読んでる？"));
        }
        else if (primeInt == 7)
        {
            Char1name.text = "叶 まこと";
            StartCoroutine(TypeText(Char1speech, "今日の星座占いです。"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 8)
        {
            ArtTakeshiR_a.SetActive(false);
            ArtTakeshiR_c.SetActive(true);
            ArtMakoto_a.SetActive(false);
            ArtMakoto_b.SetActive(true);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "秋山 武";
            StartCoroutine(TypeText(Char2speech, "で、俺らにどう役立つか。"));
        }
        else if (primeInt == 9)
        {
            ArtMakoto_b.SetActive(false);
            ArtMakoto_c.SetActive(true);
            ArtTakeshiR_c.SetActive(false);
            ArtTakeshiR_a.SetActive(true);
            Char1name.text = "叶 まこと";
            StartCoroutine(TypeText(Char1speech, "ね-念のためだけですよ。"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 10)
        {
            Char1name.text = "叶 まこと";
            StartCoroutine(TypeText(Char1speech, "じゃあ、これはどうですか。"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 11)
        {
            ArtMakoto_c.SetActive(false);
            ArtMakoto_a.SetActive(true);
            Char1name.text = "叶 まこと";
            StartCoroutine(TypeText(Char1speech, "祈願のため左目に黒目を書き入れ、成就すると右にも黒目を入れる。現在では縁起物として広く親しまれている。"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 12)
        {
            ArtTakeshiR_a.SetActive(false);
            ArtTakeshiR_c.SetActive(true);
            ArtMakoto_a.SetActive(false);
            ArtMakoto_b.SetActive(true);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "秋山 武";
            StartCoroutine(TypeText(Char2speech, "俺はだるまに見える？"));
        }
        else if (primeInt == 13)
        {
            Char1name.text = "叶 まこと";
            StartCoroutine(TypeText(Char1speech, "何か手がかりが見つかるかもしれないと思っただけ！"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 14)
        {
            Char1name.text = "叶 まこと";
            StartCoroutine(TypeText(Char1speech, "たけしの変身問題を解決したいんでしょ？"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 15)
        {
            Char1name.text = "叶 まこと";
            StartCoroutine(TypeText(Char1speech, "よく探せば、どこかにあるかもしれません。"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 16)
        {
            ArtTakeshiR_a.SetActive(true);
            ArtTakeshiR_c.SetActive(false);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "秋山 武";
            StartCoroutine(TypeText(Char2speech, "ウィキペディアのページで見つからねえと思う。"));
        }
        else if (primeInt == 17)
        {
            Char1name.text = "叶 まこと";
            StartCoroutine(TypeText(Char1speech, "どこかから始めなければならないです！"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 18)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "秋山 武";
            StartCoroutine(TypeText(Char2speech, "部長にまかせようよ。解決方法をなんとか探すって言ったんだろう。"));
        }
        else if (primeInt == 19)
        {
            Char1name.text = "叶 まこと";
            StartCoroutine(TypeText(Char1speech, "みのり先輩を手伝いましょう。早くもとに戻りたいでしょ？"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 20)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "秋山 武";
            StartCoroutine(TypeText(Char2speech, "だから俺らが邪魔になるだけだ。この問題は専門家に任せるべきだ。"));
        }
        else if (primeInt == 21)
        {
            Char1name.text = "叶 まこと";
            StartCoroutine(TypeText(Char1speech, "みのり先輩は専門家じゃなくて、ただ神話に詳しいですよ。"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 22)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "秋山 武";
            StartCoroutine(TypeText(Char2speech, "俺らに比べて専門家だ。"));
        }
        else if (primeInt == 23)
        {
            Char1name.text = "叶 まこと";
            StartCoroutine(TypeText(Char1speech, "でも僕たち部員として‐"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 24)
        {
            ArtTakeshiR_a.SetActive(false);
            ArtMakoto_b.SetActive(false);
            ArtAyase_a.SetActive(true);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "立花 あやせ";
            StartCoroutine(TypeText(Char2speech, "たっくうううん、まぁくううん!"));
        }
        else if (primeInt == 25)
        {
            ArtTakeshiR_d.SetActive(true);
            ArtMakoto_d.SetActive(true);
            ArtAyase_a.SetActive(false);
            Char1name.text = "まこと/武";
            StartCoroutine(TypeText(Char1speech, "!?"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 26)
        {
            Char1name.text = "叶 まこと";
            StartCoroutine(TypeText(Char1speech, "立花さん!?"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 27)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "秋山 武";
            StartCoroutine(TypeText(Char2speech, "げっ、あやせ姉! なんでここに?"));
        }
        else if (primeInt == 28)
        {
            ArtTakeshiR_d.SetActive(false);
            ArtMakoto_d.SetActive(false);
            ArtAyase_a.SetActive(true);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "立花 あやせ";
            StartCoroutine(TypeText(Char2speech, "ねえ、ねえ、聞いてよ！ お姉ちゃんまた首になっちゃったよ！ 慰めてええ。"));
        }
        else if (primeInt == 29)
        {
            ArtMakoto_c.SetActive(true);
            Char1name.text = "叶 まこと";
            StartCoroutine(TypeText(Char1speech, "あの…立花さん、もしかしてまた酔っていますか？"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 30)
        {
            ArtAyase_a.SetActive(false);
            ArtAyase_b.SetActive(true);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "立花 あやせ";
            StartCoroutine(TypeText(Char2speech, "うへへへ★"));
        }
        else if (primeInt == 31)
        {
            ArtMakoto_c.SetActive(false);
            ArtTakeshiL_c.SetActive(true);
            Char1name.text = "秋山 武";
            StartCoroutine(TypeText(Char1speech, "さっさと帰れ。近所迷惑だ。"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 32)
        {
            ArtAyase_b.SetActive(false);
            ArtAyase_c.SetActive(true);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "立花 あやせ";
            StartCoroutine(TypeText(Char2speech, "ここは公園だけど。"));
        }
        else if (primeInt == 33)
        {
            ArtTakeshiL_c.SetActive(false);
            ArtTakeshiL_d.SetActive(true);
            Char1name.text = "秋山 武";
            StartCoroutine(TypeText(Char1speech, "うるせえ！言ってる意味がわかるだろう！"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 34)
        {
            ArtTakeshiL_d.SetActive(false);
            ArtMakoto_b.SetActive(true);
            Char1name.text = "叶 まこと";
            StartCoroutine(TypeText(Char1speech, "たけし、ちょっと意地悪すぎるよ。立花さん、首になったばかりですよ。"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 35)
        {
            ArtAyase_c.SetActive(false);
            ArtAyase_b.SetActive(true);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "立花 あやせ";
            StartCoroutine(TypeText(Char2speech, "さすがまぁくん、優しい子ね！"));
        }
        else if (primeInt == 36)
        {
            ArtMakoto_b.SetActive(false);
            ArtMakoto_a.SetActive(true);
            Char1name.text = "叶 まこと";
            StartCoroutine(TypeText(Char1speech, "それで、僕たちに何か用ですか?"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 37)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "立花 あやせ";
            StartCoroutine(TypeText(Char2speech, "ふんん。ビールのお小遣い、ちょうだ〜い。"));
        }
        else if (primeInt == 38)
        {
            ArtMakoto_a.SetActive(false);
            ArtMakoto_c.SetActive(true);
            Char1name.text = "叶 まこと";
            StartCoroutine(TypeText(Char1speech, "あははは…"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 39)
        {
            ArtMakoto_c.SetActive(false);
            ArtTakeshiL_c.SetActive(true);
            Char1name.text = "秋山 武";
            StartCoroutine(TypeText(Char1speech, "おい、あやせ姉。高校生に金を求めるな。"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 40)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "立花 あやせ";
            StartCoroutine(TypeText(Char2speech, "だって先月の給料はもうなくなっちゃったよ。"));
        }
        else if (primeInt == 41)
        {
            ArtTakeshiL_c.SetActive(false);
            ArtTakeshiL_d.SetActive(true);
            Char1name.text = "秋山 武";
            StartCoroutine(TypeText(Char1speech, "もうないの!? 毎晩俺んちに晩飯を食べに来るくせに！俺と姉貴に迷惑だ！"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 42)
        {
            ArtAyase_b.SetActive(false);
            ArtAyase_a.SetActive(true);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "立花 あやせ";
            StartCoroutine(TypeText(Char2speech, "あ、琴音ちゃんによろしく伝えてね〜"));
        }
        else if (primeInt == 43)
        {
            ArtAyase_a.SetActive(false);
            ArtAyase_b.SetActive(true);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "立花 あやせ";
            StartCoroutine(TypeText(Char2speech, "とにかく おねがい、たっくうううん!"));
        }
        else if (primeInt == 44)
        {
            Char1name.text = "秋山 武";
            StartCoroutine(TypeText(Char1speech, "おい、離せ!"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 45)
        {
            ArtTakeshiL_d.SetActive(false);
            ArtAyase_b.SetActive(false);
            ArtMakoto_c.SetActive(true);
            Char1name.text = "叶 まこと";
            StartCoroutine(TypeText(Char1speech, "困りましてね…"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 46)
        {
            ArtAyase_b.SetActive(true);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "立花 あやせ";
            StartCoroutine(TypeText(Char2speech, "あ〜あ…ちゃんとした仕事が見つかって欲しいなあ。"));
        }
        else if (primeInt == 47)
        {
            ArtTakeshiR_d.SetActive(true);
            ArtMakoto_c.SetActive(false);
            ArtMakoto_d.SetActive(true);
            ArtAyase_b.SetActive(false);
            Char1name.text = "まこと/武";
            StartCoroutine(TypeText(Char1speech, "げっ!"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 48)
        {
            StartCoroutine(FadeOut(ArtTakeshiR_d));
            //ArtTakeshiR_d.SetActive(false);
            StartCoroutine(FadeOut(ArtMakoto_d));
           // ArtMakoto_d.SetActive(false);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 49)
        {
            Char1name.text = "";
            StartCoroutine(TypeText(Char1speech, "ドカン!"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 50)
        {
            StartCoroutine(FadeIn(ArtTakeShiki));
            ArtTakeShiki.SetActive(true);
            StartCoroutine(FadeIn(ArtMakoto_d));
            ArtMakoto_d.SetActive(true);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 51)
        {
            Char1name.text = "まこと/武";
            StartCoroutine(TypeText(Char1speech, "!!!"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 52)
        {
            ArtTakeShiki.SetActive(false);
            ArtMakoto_d.SetActive(false);
            ArtAyase_c.SetActive(true);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "立花 あやせ";
            StartCoroutine(TypeText(Char2speech, "…"));
        }
        else if (primeInt == 53)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "立花 あやせ";
            StartCoroutine(TypeText(Char2speech, "あれ? たっくんどこ行ったの?"));
        }
        else if (primeInt == 54)
        {
            ArtAyase_c.SetActive(false);
            ArtTakeShiki.SetActive(true);
            ArtMakoto_d.SetActive(true);
            Char1name.text = "叶 まこと";
            StartCoroutine(TypeText(Char1speech, "(バレてない!?)"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 55)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "秋山 武";
            StartCoroutine(TypeText(Char2speech, "(あいつが酔っ払っててよかった!)"));
        }
        else if (primeInt == 56)
        {
            ArtTakeShiki.SetActive(false);
            ArtMakoto_d.SetActive(false);
            ArtMakoto_c.SetActive(true);
            ArtAyase_c.SetActive(true);
            Char1name.text = "叶 まこと";
            StartCoroutine(TypeText(Char1speech, "もう怒って帰ったみたい、あははは…"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 57)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "立花 あやせ";
            StartCoroutine(TypeText(Char2speech, "えええひど〜い〜! ひどいよたっくん!"));
        }
        else if (primeInt == 58)
        {
            Char1name.text = "叶 まこと";
            StartCoroutine(TypeText(Char1speech, "と- とにかくもう遅いし、僕達も帰りましょうよ!"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 59)
        {
            StartCoroutine(FadeOut(ArtAyase_c));
            //ArtAyase_c.SetActive(false);
            StartCoroutine(FadeOut(ArtMakoto_c));
            //ArtMakoto_c.SetActive(false);
            StartCoroutine(FadeOut(ArtBG1));
            //ArtBG1.SetActive(false);
            DialogueDisplay.SetActive(false);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "";
            Char2speech.text = "";
            //nextButton.SetActive(false);
            //NextSceneButton.SetActive(true);
        }
        else if (primeInt == 60)
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
        SceneManager.LoadScene("Scene2");
    }
}