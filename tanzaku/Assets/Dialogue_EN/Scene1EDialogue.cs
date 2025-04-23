using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Scene1EDialogue : MonoBehaviour
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
            StartCoroutine(TypeText(Char1speech, "What you wish for may be closer than you think."));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 3)
        {

            Char1name.text = "";
            StartCoroutine(TypeText(Char1speech, "You simply need to take the first step to success."));
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
            Char1name.text = "Kano Makoto";
            StartCoroutine(TypeText(Char1speech, "Hmm, interesting."));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 6)
        {
            StartCoroutine(FadeIn(ArtTakeshiR_a));
            ArtTakeshiR_a.SetActive(true);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "Akiyama Takeshi";
            StartCoroutine(TypeText(Char2speech, "Hey Makoto, what are you reading?"));
        }
        else if (primeInt == 7)
        {
            Char1name.text = "Kano Makoto";
            StartCoroutine(TypeText(Char1speech, "Today’s horoscope."));
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
            Char2name.text = "Akiyama Takeshi";
            StartCoroutine(TypeText(Char2speech, "And how exactly is that going to help us?"));
        }
        else if (primeInt == 9)
        {
            ArtMakoto_b.SetActive(false);
            ArtMakoto_c.SetActive(true);
            ArtTakeshiR_c.SetActive(false);
            ArtTakeshiR_a.SetActive(true);
            Char1name.text = "Kano Makoto";
            StartCoroutine(TypeText(Char1speech, "J-just in case, you know?"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 10)
        {
            Char1name.text = "Kano Makoto";
            StartCoroutine(TypeText(Char1speech, "How about this, then?"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 11)
        {
            ArtMakoto_c.SetActive(false);
            ArtMakoto_a.SetActive(true);
            Char1name.text = "Kano Makoto";
            StartCoroutine(TypeText(Char1speech, "When a prayer is made, the left eye is painted black. When the prayer is granted, the left eye is also painted black. Today, it is widely considered an auspicious charm."));
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
            Char2name.text = "Akiyama Takeshi";
            StartCoroutine(TypeText(Char2speech, "Do I look like a daruma to you?"));
        }
        else if (primeInt == 13)
        {
            Char1name.text = "Kano Makoto";
            StartCoroutine(TypeText(Char1speech, "I just thought we could find some clues!"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 14)
        {
            Char1name.text = "Kano Makoto";
            StartCoroutine(TypeText(Char1speech, "Don’t you wanna find a solution to your problem?"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 15)
        {
            Char1name.text = "Kano Makoto";
            StartCoroutine(TypeText(Char1speech, "It might just be somewhere, if we look hard enough."));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 16)
        {
            ArtTakeshiR_a.SetActive(true);
            ArtTakeshiR_c.SetActive(false);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "Akiyama Takeshi";
            StartCoroutine(TypeText(Char2speech, "I don't think we'll find it on a wikipedia page."));
        }
        else if (primeInt == 17)
        {
            Char1name.text = "Kano Makoto";
            StartCoroutine(TypeText(Char1speech, "You have to start somewhere!"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 18)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "Akiyama Takeshi";
            StartCoroutine(TypeText(Char2speech, "We should just leave it to our club leader. She said she’d find a solution for us, right?"));
        }
        else if (primeInt == 19)
        {
            Char1name.text = "Kano Makoto";
            StartCoroutine(TypeText(Char1speech, "We should help Minori-senpai. You want to get back to normal as soon as possible, right?"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 20)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "Akiyama Takeshi";
            StartCoroutine(TypeText(Char2speech, "What I mean is that we’ll just get in her way. We should leave this issue to the expert."));
        }
        else if (primeInt == 21)
        {
            Char1name.text = "Kano Makoto";
            StartCoroutine(TypeText(Char1speech, "Minori-senpai is not an expert you know; she just knows a lot about mythology."));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 22)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "Akiyama Takeshi";
            StartCoroutine(TypeText(Char2speech, "She's an expert compared to us."));
        }
        else if (primeInt == 23)
        {
            Char1name.text = "Kano Makoto";
            StartCoroutine(TypeText(Char1speech, "But as fellow club members, we should-"));
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
            Char2name.text = "Tachibana Ayase";
            StartCoroutine(TypeText(Char2speech, "Takkuuun, Maakuuun!"));
        }
        else if (primeInt == 25)
        {
            ArtTakeshiR_d.SetActive(true);
            ArtMakoto_d.SetActive(true);
            ArtAyase_a.SetActive(false);
            Char1name.text = "Makoto/Takeshi";
            StartCoroutine(TypeText(Char1speech, "!?"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 26)
        {
            Char1name.text = "Kano Makoto";
            StartCoroutine(TypeText(Char1speech, "Tachibana-san!?"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 27)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "Akiyama Takeshi";
            StartCoroutine(TypeText(Char2speech, "Geh, Ayase-nee! What are you doing here?"));
        }
        else if (primeInt == 28)
        {
            ArtTakeshiR_d.SetActive(false);
            ArtMakoto_d.SetActive(false);
            ArtAyase_a.SetActive(true);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "Tachibana Ayase";
            StartCoroutine(TypeText(Char2speech, "Hey hey, listen! Onee-chan got fired again! Comfort meeee."));
        }
        else if (primeInt == 29)
        {
            ArtMakoto_c.SetActive(true);
            Char1name.text = "Kano Makoto";
            StartCoroutine(TypeText(Char1speech, "Uhm… Tachibana-san, are you perhaps drunk again?"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 30)
        {
            ArtAyase_a.SetActive(false);
            ArtAyase_b.SetActive(true);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "Tachibana Ayase";
            StartCoroutine(TypeText(Char2speech, "Uhehehe★"));
        }
        else if (primeInt == 31)
        {
            ArtMakoto_c.SetActive(false);
            ArtTakeshiL_c.SetActive(true);
            Char1name.text = "Akiyama Takeshi";
            StartCoroutine(TypeText(Char1speech, "Go home already. You're bothering the neighbors."));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 32)
        {
            ArtAyase_b.SetActive(false);
            ArtAyase_c.SetActive(true);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "Tachibana Ayase";
            StartCoroutine(TypeText(Char2speech, "We’re in a park though."));
        }
        else if (primeInt == 33)
        {
            ArtTakeshiL_c.SetActive(false);
            ArtTakeshiL_d.SetActive(true);
            Char1name.text = "Akiyama Takeshi";
            StartCoroutine(TypeText(Char1speech, "Shut up! You know what I mean!"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 34)
        {
            ArtTakeshiL_d.SetActive(false);
            ArtMakoto_b.SetActive(true);
            Char1name.text = "Kano Makoto";
            StartCoroutine(TypeText(Char1speech, "Takeshi, you're being a bit too mean. Tachibana-san just got fired."));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 35)
        {
            ArtAyase_c.SetActive(false);
            ArtAyase_b.SetActive(true);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "Tachibana Ayase";
            StartCoroutine(TypeText(Char2speech, "As expected of Maa-kun, such a kind boy!"));
        }
        else if (primeInt == 36)
        {
            ArtMakoto_b.SetActive(false);
            ArtMakoto_a.SetActive(true);
            Char1name.text = "Kano Makoto";
            StartCoroutine(TypeText(Char1speech, "So, is there anything you need from us?"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 37)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "Tachibana Ayase";
            StartCoroutine(TypeText(Char2speech, "Mmm… gimme beer moneyyyy."));
        }
        else if (primeInt == 38)
        {
            ArtMakoto_a.SetActive(false);
            ArtMakoto_c.SetActive(true);
            Char1name.text = "Kano Makoto";
            StartCoroutine(TypeText(Char1speech, "Ahahaha…"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 39)
        {
            ArtMakoto_c.SetActive(false);
            ArtTakeshiL_c.SetActive(true);
            Char1name.text = "Akiyama Takeshi";
            StartCoroutine(TypeText(Char1speech, "Oi, Ayase-nee. Don't go around asking high school students for money."));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 40)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "Tachibana Ayase";
            StartCoroutine(TypeText(Char2speech, "But last month’s pay is already gone."));
        }
        else if (primeInt == 41)
        {
            ArtTakeshiL_c.SetActive(false);
            ArtTakeshiL_d.SetActive(true);
            Char1name.text = "Akiyama Takeshi";
            StartCoroutine(TypeText(Char1speech, "Already!? Even though you mooch food off us every night! You're a real headache for me and aneki!"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 42)
        {
            ArtAyase_b.SetActive(false);
            ArtAyase_a.SetActive(true);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "Tachibana Ayase";
            StartCoroutine(TypeText(Char2speech, "Oh, please give my regards to Kotone-chan~"));
        }
        else if (primeInt == 43)
        {
            ArtAyase_a.SetActive(false);
            ArtAyase_b.SetActive(true);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "Tachibana Ayase";
            StartCoroutine(TypeText(Char2speech, "Anyways, I’m begging you, Takkuuun!"));
        }
        else if (primeInt == 44)
        {
            Char1name.text = "Akiyama Takeshi";
            StartCoroutine(TypeText(Char1speech, "Oi, let go of me!"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 45)
        {
            ArtTakeshiL_d.SetActive(false);
            ArtAyase_b.SetActive(false);
            ArtMakoto_c.SetActive(true);
            Char1name.text = "Kano Makoto";
            StartCoroutine(TypeText(Char1speech, "Well this is a problem…"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 46)
        {
            ArtAyase_b.SetActive(true);
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "Tachibana Ayase";
            StartCoroutine(TypeText(Char2speech, "Ahhh...I wish I could find a proper job."));
        }
        else if (primeInt == 47)
        {
            ArtTakeshiR_d.SetActive(true);
            ArtMakoto_c.SetActive(false);
            ArtMakoto_d.SetActive(true);
            ArtAyase_b.SetActive(false);
            Char1name.text = "まこと/武";
            StartCoroutine(TypeText(Char1speech, "Geh!"));
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
            StartCoroutine(TypeText(Char1speech, "Boom!"));
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
            Char1name.text = "Makoto/Takeshi";
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
            Char2name.text = "Tachibana Ayase";
            StartCoroutine(TypeText(Char2speech, "…"));
        }
        else if (primeInt == 53)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "Tachibana Ayase";
            StartCoroutine(TypeText(Char2speech, "Huh? Where did Takkun go?"));
        }
        else if (primeInt == 54)
        {
            ArtAyase_c.SetActive(false);
            ArtTakeShiki.SetActive(true);
            ArtMakoto_d.SetActive(true);
            Char1name.text = "Kano Makoto";
            StartCoroutine(TypeText(Char1speech, "(She hasn’t caught on!?)"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 55)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "Akiyama Takeshi";
            StartCoroutine(TypeText(Char2speech, "(Thank god she’s drunk!)"));
        }
        else if (primeInt == 56)
        {
            ArtTakeShiki.SetActive(false);
            ArtMakoto_d.SetActive(false);
            ArtMakoto_c.SetActive(true);
            ArtAyase_c.SetActive(true);
            Char1name.text = "Kano Makoto";
            StartCoroutine(TypeText(Char1speech, "Looks like he got angry and went home, ahahaha…"));
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 57)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "Tachibana Ayase";
            StartCoroutine(TypeText(Char2speech, "Eeehhh, that’s so mean! Takkun’s such a meanie!"));
        }
        else if (primeInt == 58)
        {
            Char1name.text = "Kano Makoto";
            StartCoroutine(TypeText(Char1speech, "A-anyways, it's late so let’s go home too, shall we?"));
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
        SceneManager.LoadScene("Scene2E");
    }
}