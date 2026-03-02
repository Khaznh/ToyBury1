using UnityEngine;
using UnityEngine.UI;

public class TestPaperCanva : MonoBehaviour
{
    [SerializeField] private ReportPaperItem reportPaperItem;
    [SerializeField] private Image[] testResultImgs;

    private TestResult[] testResults;

    private void OnEnable()
    {
        if (reportPaperItem == null)
        {
            reportPaperItem = FindAnyObjectByType<ReportPaperItem>();
        }

        testResults = reportPaperItem.GetTestResults();
        for (int i = 0; i < testResults.Length; i++)
        {
            UpdateUI(i);
        }
    }

    private void ToggleResult(int index)
    {
        if (testResults[index] == TestResult.None || testResults[index] == TestResult.UnSafe)
        {
            testResults[index] = TestResult.Safe;
        }
        else if (testResults[index] == TestResult.Safe)
        {
            testResults[index] = TestResult.UnSafe;
        }

        UpdateUI(index);
    }

    public void AudioTesting()
    {
        if (!GameController.Instance.isTestAudio)
        {
            return;
        }

        ToggleResult(0);
    }

    public void NameCall()
    {
        if (!GameController.Instance.isCallName)
        {
            return;
        }

        ToggleResult(1);
    }

    public void PhotographCapture()
    {
        if (!GameController.Instance.isPhotoTaken)
        {
            return;
        }

        ToggleResult(2);
    }

    public void TempuratureTest()
    {
        if (!GameController.Instance.isTempuration)
        {
            return;
        }

        ToggleResult(3);
    }

    public void PhysicalDiscomfortTesting()
    {
        if (!GameController.Instance.isScissor)
        {
            return;
        }

        ToggleResult(4);
    }

    private void UpdateUI(int index)
    {
        if (testResults[index] == TestResult.Safe)
        {
            testResultImgs[index].sprite = GameController.Instance.safeImgSource;
        }
        else if (testResults[index] == TestResult.UnSafe)
        {
            testResultImgs[index].sprite = GameController.Instance.unsafeImgSource;
        }
    }
}

public enum TestResult
{
    None,
    Safe,
    UnSafe
}

public enum HasTest
{
    Untested,
    Tested
}