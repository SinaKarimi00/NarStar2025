using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    [SerializeField] Button menuButton;

    private void Awake()
    {
        menuButton.onClick.AddListener(() => SceneManager.LoadScene("Main"));
    }
}