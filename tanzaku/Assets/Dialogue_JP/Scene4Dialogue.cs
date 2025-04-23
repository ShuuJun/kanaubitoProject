using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Scene4Dialogue : MonoBehaviour
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
            StartCoroutine(FadeIn(ArtBG1));
            ArtBG1.SetActive(true);
            StartCoroutine(FadeIn(ArtTakeShiki));
            ArtTakeShiki.SetActive(true);
            DialogueDisplay.SetActive(true);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 3)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "秋山 武";
            StartCoroutine(TypeText(Char2speech, "(これを見るのは久しぶりだな…)"));
        }
        else if (primeInt == 4)
        {
            Char1name.text = "";
            StartCoroutine(TypeText(Char1speech, "カチャッ!"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 5)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "秋山 武";
            StartCoroutine(TypeText(Char2speech, "(え?あやせ姉もう帰ったか!? まだ５時半だぞ!)"));
        }
        else if (primeInt == 6)
        {
            ArtTakeShiki.SetActive(false);
            StartCoroutine(FadeIn(ArtMakoto_b));
            ArtMakoto_b.SetActive(true);
            StartCoroutine(FadeIn(ArtAyase_c));
            ArtAyase_c.SetActive(true);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 7)
        {
            ArtMakoto_b.SetActive(false);
            ArtAyase_c.SetActive(false);
            ArtTakeShiki.SetActive(true);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "秋山 武";
            StartCoroutine(TypeText(Char2speech, "(まこと!? 仕方ねえ、様子を見るか…)"));
        }
        else if (primeInt == 8)
        {
            ArtMakoto_b.SetActive(true);
            ArtTakeShiki.SetActive(false);
            Char1name.text = "叶 まこと";
            StartCoroutine(TypeText(Char1speech, "…"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 9)
        {
            ArtAyase_c.SetActive(true);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "立花 あやせ";
            StartCoroutine(TypeText(Char2speech, "…"));
        }
        else if (primeInt == 10)
        {
            Char1name.text = "叶 まこと";
            StartCoroutine(TypeText(Char1speech, "…気まずい…"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 11)
        {
            ArtMakoto_b.SetActive(false);
            ArtAyase_c.SetActive(false);
            ArtTakeShiki.SetActive(true);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "秋山 武";
            StartCoroutine(TypeText(Char2speech, "(…何だ、この空気は? 何があったのか?)"));
        }
        else if (primeInt == 12)
        {
            ArtTakeShiki.SetActive(false);
            ArtAyase_c.SetActive(true);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "立花 あやせ";
            StartCoroutine(TypeText(Char2speech, "…で、卒業式のこと、聞きたい?"));
        }
        else if (primeInt == 13)
        {
            ArtMakoto_b.SetActive(true);
            Char1name.text = "叶 まこと";
            StartCoroutine(TypeText(Char1speech, "!!"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 14)
        {
            ArtAyase_c.SetActive(false);
            ArtAyase_d.SetActive(true);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "立花  あやせ";
            StartCoroutine(TypeText(Char2speech, "ふふ〜ん、お姉ちゃんを誤魔化せないよ〜 ぜ〜んぶ、聞こえちゃった★"));
        }
        else if (primeInt == 15)
        {
            ArtMakoto_b.SetActive(false);
            ArtMakoto_d.SetActive(true);
            Char1name.text = "叶 まこと";
            StartCoroutine(TypeText(Char1speech, "立花さん、僕は悪気がないんです!"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 16)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "立花  あやせ";
            StartCoroutine(TypeText(Char2speech, "わかってるよ。まぁくんはお姉ちゃんを助けたいだけでしょ？だから話したい。"));
        }
        else if (primeInt == 17)
        {
            ArtMakoto_d.SetActive(false);
            ArtMakoto_b.SetActive(true);
            Char1name.text = "叶 まこと";
            StartCoroutine(TypeText(Char1speech, "…"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 18)
        {
            ArtTakeshiR_d.SetActive(true);
            ArtAyase_d.SetActive(false);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "立花  あやせ";
            StartCoroutine(TypeText(Char2speech, "あの日、誰も来なかった。両親も、兄弟も、姉妹も。"));
        }
        else if (primeInt == 19)
        {
            Char1name.text = "叶 まこと";
            StartCoroutine(TypeText(Char1speech, "!!"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 20)
        {
            ArtTakeshiR_d.SetActive(false);
            ArtAyase_c.SetActive(true);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "立花  あやせ";
            StartCoroutine(TypeText(Char2speech, "ああ でも、みんなが忙しいのはわかっていた。両親も海外だったし。"));
        }
        else if (primeInt == 21)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "立花  あやせ";
            StartCoroutine(TypeText(Char2speech, "でもね、両親は私の兄弟姉妹に、「メッセージを受け取ったら必ず返信して」と言ったから…"));
        }
        else if (primeInt == 22)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "立花  あやせ";
            StartCoroutine(TypeText(Char2speech, "だからメッセージしたよ。何回も! でも全く返事が来なかった…"));
        }
        else if (primeInt == 23)
        {
            ArtAyase_c.SetActive(false);
            ArtMakoto_b.SetActive(false);
            ArtTakeShiki.SetActive(true);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "秋山 武";
            StartCoroutine(TypeText(Char2speech, "…"));
        }
        else if (primeInt == 24)
        {
            ArtAyase_b.SetActive(true);
            ArtMakoto_b.SetActive(true);
            ArtTakeShiki.SetActive(false);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "立花  あやせ";
            StartCoroutine(TypeText(Char2speech, "それで駄駄を捏ねて家出した! そしてそれ以来、家族との連絡を一切断ち切った！"));
        }
        else if (primeInt == 25)
        {
            ArtMakoto_b.SetActive(false);
            ArtMakoto_d.SetActive(true);
            Char1name.text = "叶 まこと";
            StartCoroutine(TypeText(Char1speech, "ああ…"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 26)
        {
            ArtAyase_b.SetActive(false);
            ArtAyase_d.SetActive(true);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "立花  あやせ";
            StartCoroutine(TypeText(Char2speech, "それだけだよ。今までの私は、大人気ないよね。"));
        }
        else if (primeInt == 27)
        {
            ArtMakoto_d.SetActive(false);
            ArtMakoto_b.SetActive(true);
            Char1name.text = "叶 まこと";
            StartCoroutine(TypeText(Char1speech, "それは…"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 28)
        {
            ArtAyase_d.SetActive(false);
            ArtTakeshiR_d.SetActive(true);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "立花  あやせ";
            StartCoroutine(TypeText(Char2speech, "バイトを辞めた日、私はじいちゃんとばあちゃんにこう言った："));
        }
        else if (primeInt == 29)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "立花  あやせ";
            StartCoroutine(TypeText(Char2speech, "「もう意味ないから…」っと"));
        }
        else if (primeInt == 30)
        {
            Char1name.text = "叶 まこと";
            StartCoroutine(TypeText(Char1speech, "立花さん…"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 31)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "立花  あやせ";
            StartCoroutine(TypeText(Char2speech, "それ以来フリーターとしてギリギリ生活しているけど…このままじゃだめだよね…"));
        }
        else if (primeInt == 32)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "立花  あやせ";
            StartCoroutine(TypeText(Char2speech, "でもこんなダメな大人が先生になるなんて…今更なんだよね?"));
        }
        else if (primeInt == 33)
        {
            ArtMakoto_b.SetActive(false);
            ArtMakoto_d.SetActive(true);
            Char1name.text = "叶 まこと";
            StartCoroutine(TypeText(Char1speech, "そんなことないんですよ!"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 34)
        {
            ArtAyase_c.SetActive(true);
            ArtTakeshiR_d.SetActive(false);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "立花  あやせ";
            StartCoroutine(TypeText(Char2speech, "!"));
        }
        else if (primeInt == 35)
        {
            Char1name.text = "叶 まこと";
            StartCoroutine(TypeText(Char1speech, "だって、ほら…"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 36)
        {
            Char1name.text = "叶 まこと";
            StartCoroutine(TypeText(Char1speech, "あなたが望むものは、あなたが思っているよりも近いかもしれません!"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 37)
        {
            Char1name.text = "叶 まこと";
            StartCoroutine(TypeText(Char1speech, "成功への第一歩を踏み出すだけでいいのです!"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 38)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "立花  あやせ";
            StartCoroutine(TypeText(Char2speech, "…"));
        }
        else if (primeInt == 39)
        {
            ArtMakoto_d.SetActive(false);
            ArtAyase_c.SetActive(false);
            ArtTakeShiki.SetActive(true);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "秋山 武";
            StartCoroutine(TypeText(Char2speech, "(があ…まことのやつ…)"));
        }
        else if (primeInt == 40)
        {
            ArtMakoto_d.SetActive(true);
            ArtAyase_b.SetActive(true);
            ArtTakeShiki.SetActive(false);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "立花  あやせ";
            StartCoroutine(TypeText(Char2speech, "…あははは! 昨日の星座占いだよね、それ?"));
        }
        else if (primeInt == 41)
        {
            ArtMakoto_d.SetActive(false);
            ArtMakoto_c.SetActive(true);
            Char1name.text = "叶 まこと";
            StartCoroutine(TypeText(Char1speech, "あ…あははは…"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 42)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "立花  あやせ";
            StartCoroutine(TypeText(Char2speech, "まぁくんったら面白い子よね。"));
        }
        else if (primeInt == 43)
        {
            ArtMakoto_c.SetActive(false);
            ArtMakoto_b.SetActive(true);
            Char1name.text = "叶 まこと";
            StartCoroutine(TypeText(Char1speech, "はあ…"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 44)
        {
            ArtAyase_b.SetActive(false);
            ArtAyase_d.SetActive(true);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "立花あやせ";
            StartCoroutine(TypeText(Char2speech, "でも…そうかもしれない。"));
        }
        else if (primeInt == 45)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "立花あやせ";
            StartCoroutine(TypeText(Char2speech, "…"));
        }
        else if (primeInt == 46)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "立花あやせ";
            StartCoroutine(TypeText(Char2speech, "あのね、私が教師になりたかった理由は、たっくんだったよ。"));
        }
        else if (primeInt == 47)
        {
            ArtMakoto_b.SetActive(false);
            ArtMakoto_d.SetActive(true);
            Char1name.text = "叶 まこと";
            StartCoroutine(TypeText(Char1speech, "え!?"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 48)
        {
            ArtMakoto_d.SetActive(false);
            ArtAyase_d.SetActive(false);
            ArtTakeShiki.SetActive(true);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "秋山 武";
            StartCoroutine(TypeText(Char2speech, "!"));
        }
        else if (primeInt == 49)
        {
            ArtMakoto_d.SetActive(true);
            ArtAyase_a.SetActive(true);
            ArtTakeShiki.SetActive(false);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "立花あやせ";
            StartCoroutine(TypeText(Char2speech, "びっくりした? たっくんが小さい子供のとき、私は家庭教師をしていたんだよ!"));
        }
        else if (primeInt == 50)
        {
            Char1name.text = "叶 まこと";
            StartCoroutine(TypeText(Char1speech, "そうなんですか!?"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 51)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "立花あやせ";
            StartCoroutine(TypeText(Char2speech, "そうなんだよ! そしてある日、たっくんがこういった:"));
        }
        else if (primeInt == 52)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "立花あやせ";
            StartCoroutine(TypeText(Char2speech, "「あやお姉ちゃん、いつか先生になる？先生になっても、俺を毎日勉強教えてね。」"));
        }
        else if (primeInt == 53)
        {
            Char1name.text = "叶 まこと";
            StartCoroutine(TypeText(Char1speech, "…お-おう…"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 54)
        {
            ArtMakoto_d.SetActive(false);
            ArtAyase_a.SetActive(false);
            ArtTakeShiki.SetActive(true);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "秋山 武";
            StartCoroutine(TypeText(Char2speech, "(くそお! 昔の俺、恥ずかしい!)"));
        }
        else if (primeInt == 55)
        {
            ArtMakoto_d.SetActive(true);
            ArtAyase_b.SetActive(true);
            ArtTakeShiki.SetActive(false);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "立花あやせ";
            StartCoroutine(TypeText(Char2speech, "きゃああ! 可愛すぎるんだもん!"));
        }
        else if (primeInt == 56)
        {
            ArtMakoto_d.SetActive(false);
            ArtMakoto_c.SetActive(true);
            Char1name.text = "叶 まこと";
            StartCoroutine(TypeText(Char1speech, "そ-そうなんですか? あははは…"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 57)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "立花あやせ";
            StartCoroutine(TypeText(Char2speech, "ああ、懐かしい…"));
        }
        else if (primeInt == 58)
        {
            ArtMakoto_c.SetActive(false);
            ArtAyase_b.SetActive(false);
            ArtAyase_a.SetActive(true);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "立花あやせ";
            StartCoroutine(TypeText(Char2speech, "…"));
        }
        else if (primeInt == 59)
        {
            ArtAyase_a.SetActive(false);
            ArtAyase_d.SetActive(true);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "立花あやせ";
            StartCoroutine(TypeText(Char2speech, "……"));
        }
        else if (primeInt == 60)
        {
            ArtAyase_d.SetActive(false);
            ArtTakeshiR_d.SetActive(true);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "立花あやせ";
            StartCoroutine(TypeText(Char2speech, "………"));
        }
        else if (primeInt == 61)
        {
            ArtAyase_d.SetActive(true);
            ArtTakeshiR_d.SetActive(false);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "立花あやせ";
            StartCoroutine(TypeText(Char2speech, "…私の長話を聞いてくれてありがとう、まぁくん。もう遅いし、今日はもう帰っててね?"));
        }
        else if (primeInt == 62)
        {
            ArtAyase_d.SetActive(true);
            ArtTakeshiR_d.SetActive(false);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "立花あやせ";
            StartCoroutine(TypeText(Char2speech, "お姉ちゃんがなんとかするから。"));
        }
        else if (primeInt == 63)
        {
            ArtMakoto_b.SetActive(true);
            Char1name.text = "叶 まこと";
            StartCoroutine(TypeText(Char1speech, "立花さん…わかりました。ではおやすみなさい。"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 64)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "立花あやせ";
            StartCoroutine(TypeText(Char2speech, "んん!おやすみ〜"));
        }
        else if (primeInt == 65)
        {
            StartCoroutine(FadeOut(ArtAyase_d));
            StartCoroutine(FadeOut(ArtMakoto_b));
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 66)
        {
            ArtTakeShiki.SetActive(true);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "秋山 武";
            StartCoroutine(TypeText(Char2speech, "(…あやせ姉…)"));
        }
        else if (primeInt == 67)
        {
            StartCoroutine(FadeOut(ArtTakeShiki));
            StartCoroutine(FadeOut(ArtBG1));
            DialogueDisplay.SetActive(false);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "";
            Char2speech.text = "";
            //nextButton.SetActive(false);
            //NextSceneButton.SetActive(true);
        }
        else if (primeInt == 68)
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
        SceneManager.LoadScene("Scene5");
    }
}