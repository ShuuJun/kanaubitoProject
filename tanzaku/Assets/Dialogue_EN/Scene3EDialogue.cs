using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Scene3EDialogue : MonoBehaviour
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
            StartCoroutine(TypeText(Char1speech, "数時間後..."));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 3)
        {
            StartCoroutine(FadeIn(ArtBG1));
            ArtBG1.SetActive(true);
            StartCoroutine(FadeIn(ArtMakoto_b));
            ArtMakoto_b.SetActive(true);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 4)
        {
            Char1name.text = "叶 まこと";
            StartCoroutine(TypeText(Char1speech, "ハローワークで求人を調べたり、街中を探したりしたのですが、特に目立つものが見つかりませんでした…"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 5)
        {
            Char1name.text = "叶 まこと";
            StartCoroutine(TypeText(Char1speech, "まあ、バイトしか…"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 6)
        {
            ArtMakoto_b.SetActive(false);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "じいちゃん";
            StartCoroutine(TypeText(Char2speech, "おや、叶家の息子じゃないか。何だ、バイト探してるのかい？"));
        }
        else if (primeInt == 7)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "ばあちゃん";
            StartCoroutine(TypeText(Char2speech, "こんにちは、まことちゃん。"));
        }
        else if (primeInt == 8)
        {
            ArtMakoto_a.SetActive(true);
            Char1name.text = "叶 まこと";
            StartCoroutine(TypeText(Char1speech, "あ、文房具店のじいちゃんとばあちゃん。こんにちは。"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 9)
        {
            Char1name.text = "叶 まこと";
            StartCoroutine(TypeText(Char1speech, "じつは、ただ働くことが気になっただけです。僕はもうすぐ高校２年生なんですし。"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 10)
        {
            ArtMakoto_a.SetActive(false);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "ばあちゃん";
            StartCoroutine(TypeText(Char2speech, "それは立派なこと。若いのに将来のことをちゃんと考えてるね。"));
        }
        else if (primeInt == 11)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "じいちゃん";
            StartCoroutine(TypeText(Char2speech, "うちでバイトしたいならいつでも来いよ。"));
        }
        else if (primeInt == 12)
        {
            ArtMakoto_c.SetActive(true);
            Char1name.text = "叶 まこと";
            StartCoroutine(TypeText(Char1speech, "あはは、ありがとうございます。考えときますね。"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 13)
        {
            ArtMakoto_c.SetActive(false);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "じいちゃん";
            StartCoroutine(TypeText(Char2speech, "ところで、あのたけしのやつは今日一緒じゃないのかい。怠け者だな。"));
        }
        else if (primeInt == 14)
        {
            ArtMakoto_c.SetActive(true);
            Char1name.text = "叶 まこと";
            StartCoroutine(TypeText(Char1speech, "あ、たけしなら…そう! 今日は立花さんと一緒にいるそうです。立花あやせさん。"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 15)
        {
            ArtMakoto_c.SetActive(false);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "じいちゃん";
            StartCoroutine(TypeText(Char2speech, "立花家の三女か。そういえばあの子、うちでバイトしたことあったかなばあちゃん？。"));
        }
        else if (primeInt == 16)
        {
            ArtMakoto_b.SetActive(true);
            Char1name.text = "叶 まこと";
            StartCoroutine(TypeText(Char1speech, "え? そうなんですか?"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 17)
        {
            ArtMakoto_b.SetActive(false);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "ばあちゃん";
            StartCoroutine(TypeText(Char2speech, "そうですよ。あやせちゃんはまだ大学生の頃だったわね。はああ…あわれな子。"));
        }
        else if (primeInt == 18)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "ばあちゃん";
            StartCoroutine(TypeText(Char2speech, "あの子は昔からそんなに軽薄だったわけじゃないんだよ。"));
        }
        else if (primeInt == 19)
        {
            ArtMakoto_b.SetActive(true);
            Char1name.text = "叶 まこと";
            StartCoroutine(TypeText(Char1speech, "それはどういう…"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 20)
        {
            ArtMakoto_b.SetActive(false);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "じいちゃん";
            StartCoroutine(TypeText(Char2speech, "そうだ、あの子は真面目だったな。しっかりしていたぞ。"));
        }
        else if (primeInt == 21)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "じいちゃん";
            StartCoroutine(TypeText(Char2speech, "だが…急に辞めちゃったな。"));
        }
        else if (primeInt == 22)
        {
            ArtMakoto_b.SetActive(true);
            Char1name.text = "叶 まこと";
            StartCoroutine(TypeText(Char1speech, "もしよろしければ、その時のことを詳しく教えてくれますか？立花さんがなぜ変わったのかご存知ですか?"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 23)
        {
            ArtMakoto_b.SetActive(false);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "じいちゃん";
            StartCoroutine(TypeText(Char2speech, "ふんん...まあいいんじゃない？あの子がお前を信頼してるからな。でもあまり多くの人にバラすんなよ!"));
        }
        else if (primeInt == 24)
        {
            ArtMakoto_b.SetActive(true);
            Char1name.text = "叶 まこと";
            StartCoroutine(TypeText(Char1speech, "(そうなのか? 僕を信頼…) わかりました。"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 25)
        {
            ArtMakoto_b.SetActive(false);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "ばあちゃん";
            StartCoroutine(TypeText(Char2speech, "あやせちゃんはね、兄弟姉妹が多い。そしてみんなは優秀。優秀すぎるかもね。"));
        }
        else if (primeInt == 26)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "ばあちゃん";
            StartCoroutine(TypeText(Char2speech, "なのにあやせちゃんはこの中で一番真面目だったわ。彼女は才能に欠けていた部分を努力で補った。"));
        }
        else if (primeInt == 27)
        {
            ArtMakoto_b.SetActive(true);
            Char1name.text = "叶 まこと";
            StartCoroutine(TypeText(Char1speech, "…今の立花さんを見るとちょっと想像しづらいですね…"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 28)
        {
            ArtMakoto_b.SetActive(false);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "じいちゃん";
            StartCoroutine(TypeText(Char2speech, "はは、そうじゃっただろう!"));
        }
        else if (primeInt == 29)
        {
            ArtMakoto_b.SetActive(true);
            Char1name.text = "叶 まこと";
            StartCoroutine(TypeText(Char1speech, "あ、すみません。思わず口に出しました。"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 30)
        {
            ArtMakoto_b.SetActive(false);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "ばあちゃん";
            StartCoroutine(TypeText(Char2speech, "あやせちゃんのご両親はたぶん他の子どもを忙しすぎたのだろう。"));
        }
        else if (primeInt == 31)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "ばあちゃん";
            StartCoroutine(TypeText(Char2speech, "それに、あやせちゃんにあまりプレッシャーをかけたくなかった。だから何があっても、二人は何も言わなかった。"));
        }
        else if (primeInt == 32)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "ばあちゃん";
            StartCoroutine(TypeText(Char2speech, "失敗しても、叱られたことはなかった。成功しても、褒められたことはなかった。"));
        }
        else if (primeInt == 33)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "ばあちゃん";
            StartCoroutine(TypeText(Char2speech, "あやせちゃんの真面目な性格は、どうやら彼女にとって裏目に出たようだ。"));
        }
        else if (primeInt == 34)
        {
            ArtMakoto_b.SetActive(true);
            Char1name.text = "叶 まこと";
            StartCoroutine(TypeText(Char1speech, "それで、ご両親にかまって欲しかったので、立花さんが性格を変えました?"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 35)
        {
            ArtMakoto_b.SetActive(false);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "じいちゃん";
            StartCoroutine(TypeText(Char2speech, "はは、まさか! それがあったらまだましだ。"));
        }
        else if (primeInt == 36)
        {
            ArtMakoto_b.SetActive(true);
            Char1name.text = "叶 まこと";
            StartCoroutine(TypeText(Char1speech, "あれ？どういうことですか。"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 37)
        {
            ArtMakoto_b.SetActive(false);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "ばあちゃん";
            StartCoroutine(TypeText(Char2speech, "あれはあやせちゃんが教員免許を取得したあとでした。"));
        }
        else if (primeInt == 38)
        {
            ArtMakoto_d.SetActive(true);
            Char1name.text = "叶 まこと";
            StartCoroutine(TypeText(Char1speech, "え!? ちょっと待って、立花さんは教員免許を持っていますか!?"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 39)
        {
            ArtMakoto_d.SetActive(false);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "ばあちゃん";
            StartCoroutine(TypeText(Char2speech, "あら、言ってなかったかしら? あやせちゃんは大学で教育専攻だったわ。"));
        }
        else if (primeInt == 40)
        {
            ArtMakoto_d.SetActive(true);
            Char1name.text = "叶 まこと";
            StartCoroutine(TypeText(Char1speech, "それは初耳です!"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 41)
        {
            ArtMakoto_d.SetActive(false);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "じいちゃん";
            StartCoroutine(TypeText(Char2speech, "ふんん、だろうな。あの日のあとだったら、隠したいことがあり得る。"));
        }
        else if (primeInt == 42)
        {
            ArtMakoto_b.SetActive(true);
            Char1name.text = "叶 まこと";
            StartCoroutine(TypeText(Char1speech, "それは…？"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 43)
        {
            ArtMakoto_b.SetActive(false);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "ばあちゃん";
            StartCoroutine(TypeText(Char2speech, "卒業式の日-"));
        }
        else if (primeInt == 44)
        {
            ArtAyase_c.SetActive(true);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "立花 あやせ";
            StartCoroutine(TypeText(Char2speech, "まぁくん?"));
        }
        else if (primeInt == 45)
        {
            ArtMakoto_d.SetActive(true);
            ArtAyase_c.SetActive(false);
            Char1name.text = "叶 まこと";
            StartCoroutine(TypeText(Char1speech, "!!"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 46)
        {
            ArtMakoto_d.SetActive(false);
            ArtAyase_c.SetActive(true);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "立花 あやせ";
            StartCoroutine(TypeText(Char2speech, "それにじいちゃんとばあちゃん。みんな怖い顔している。何の話?"));
        }
        else if (primeInt == 47)
        {
            ArtAyase_c.SetActive(false);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "ばあちゃん";
            StartCoroutine(TypeText(Char2speech, "あやせちゃん! 大したことないわ!"));
        }
        else if (primeInt == 48)
        {
            ArtMakoto_c.SetActive(true);
            Char1name.text = "叶 まこと";
            StartCoroutine(TypeText(Char1speech, "た-立花さんこそ、ここで何をしているんですか?"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 49)
        {
            ArtMakoto_c.SetActive(false);
            ArtAyase_c.SetActive(true);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "立花 あやせ";
            StartCoroutine(TypeText(Char2speech, "今日は日曜だし、洗濯や買い物しようとしているけど…"));
        }
        else if (primeInt == 50)
        {
            ArtAyase_c.SetActive(false);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "ばあちゃん";
            StartCoroutine(TypeText(Char2speech, "あ-あらまあ! こんな時間になっちゃったわ! 店を閉めないとね!"));
        }
        else if (primeInt == 51)
        {
            ArtAyase_c.SetActive(true);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "立花 あやせ";
            StartCoroutine(TypeText(Char2speech, "でもまだ5時ですよ。確か6時まで空いているんじゃない?"));
        }
        else if (primeInt == 52)
        {
            ArtAyase_c.SetActive(false);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "ばあちゃん";
            StartCoroutine(TypeText(Char2speech, "それは...じいちゃんは疲れたわよ! 私達はもう年を取ったからね、じいちゃん?"));
        }
        else if (primeInt == 53)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "じいちゃん";
            StartCoroutine(TypeText(Char2speech, "は? あ! そうじゃった! もうくたくただ! 早く寝ないとな。じゃあな、二人共!"));
        }
        else if (primeInt == 54)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "ばあちゃん";
            StartCoroutine(TypeText(Char2speech, "元気にしててね、まことちゃん、あやせちゃん!"));
        }
        else if (primeInt == 55)
        {
            ArtAyase_c.SetActive(true);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "立花  あやせ";
            StartCoroutine(TypeText(Char2speech, "うん…じゃあね…"));
        }
        else if (primeInt == 56)
        {
            ArtMakoto_c.SetActive(true);
            Char1name.text = "叶 まこと";
            StartCoroutine(TypeText(Char1speech, "立花さん、荷物は重そうですね。家まで運ぶのを手伝います!"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 57)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "立花  あやせ";
            StartCoroutine(TypeText(Char2speech, "いいの? ありがとう…"));
        }
        else if (primeInt == 58)
        {
            StartCoroutine(FadeOut(ArtAyase_c));
            StartCoroutine(FadeOut(ArtMakoto_c));
            StartCoroutine(FadeOut(ArtBG1));
            DialogueDisplay.SetActive(false);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "";
            Char2speech.text = "";
            //nextButton.SetActive(false);
            //NextSceneButton.SetActive(true);
        }
        else if (primeInt == 59)
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
        SceneManager.LoadScene("Scene4");
    }
}