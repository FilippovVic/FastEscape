using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
/*    public Button PlayButton;*/

    private AudioSource SoundEffect;

    private void Start()
    {
        SoundEffect= GetComponent<AudioSource>();
    }

    public void OnButtonClick()
    {
        if (PlayerPrefs.GetInt("sound", 0) == 1) {
            SoundEffect.Play();
        }
        StartCoroutine(SoundWaiter());
    }

    IEnumerator SoundWaiter()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("SampleScene");
    }
}