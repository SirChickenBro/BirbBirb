using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    private Monster[] _monsters;
    [SerializeField] string _nextLevelName;

    void OnEnable()
    {
        _monsters = FindObjectsOfType<Monster>();
    }


    // Update is called once per frame
    void Update()
    {
        if (MonstersAreAllDead())
            GoToNextLevel();
    }

    bool MonstersAreAllDead()
    {
        foreach (Monster monster in _monsters)
        {
            if (monster.gameObject.activeSelf)
                return false;
        }

        return true;
    }
    void GoToNextLevel()
    {
        Debug.Log("Go to level " + _nextLevelName);
        SceneManager.LoadScene(_nextLevelName);
    }
}
