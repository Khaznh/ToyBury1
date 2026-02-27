using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReportPaperItem : CanPickUpItem
{
    [SerializeField] private Vector3 offsetPos;
    [SerializeField] private Vector3 offsetRot;

    //public Image audioTestingImg;
    //public Image nameCallImg;
    //public Image photographCaptureImg;
    //public Image tempuratureTestImg;
    //public Image physicalDiscomfortTestingImg;

    [SerializeField] private Image[] testResultImgs;
    private TestResult[] testResults;

    private void Awake()
    {
        testResults = new TestResult[5];
    }

    public override void Interact()
    {
        if (playerController.hand.transform.childCount != 0)
        {
            ThrowAwayItem(playerController.hand.transform.GetChild(0).gameObject);
        }

        PickUpItem(this.gameObject);
        this.transform.localPosition = offsetPos;
        this.transform.localRotation = Quaternion.Euler(offsetRot);
    }

    public override void Use()
    {
        base.Use();
        if (GameController.Instance.IsPaperCanvaActive())
        {
            UpdateUI();
            GameController.Instance.SetPlayerCursor(false);
            GameController.Instance.SetPlayerControl(true);
            GameController.Instance.ShowTargetCanva();
            return;
        }

        GameController.Instance.SetPlayerCursor(true);
        GameController.Instance.SetPlayerControl(false);
        GameController.Instance.ShowReportPaper();
    }

    public override void OnExitItem()
    {
        ThrowAwayItem(this.gameObject);
    }

    private void UpdateUI()
    {
        for (int i = 0; i < testResults.Length; i++)
        {
            SetImgBaseResult(testResults[i], testResultImgs[i]);
        }
    }

    private void SetImgBaseResult(TestResult result, Image img)
    {
        if (result == TestResult.Safe)
        {
            img.sprite = GameController.Instance.safeImgSource;
        }
        else if (result == TestResult.UnSafe)
        {
            img.sprite = GameController.Instance.unsafeImgSource;
        }
    }

    public TestResult[] GetTestResults()
    {
        return testResults;
    }
}