using UnityEngine;
using UnityEngine.UI;
using TMPro;
using PlayFab;
using PlayFab.ClientModels;

using UnityEngine.SceneManagement;
using System; // If you're using any classes from the System namespace, you can keep this import

public class LoginPagePlayfab : MonoBehaviour
{
    [SerializeField] Text MessageText;

    [Header("Login")]
    [SerializeField] InputField EmailLoginInput;
    [SerializeField] InputField PasswordLoginInput;
    [SerializeField] GameObject LoginPage;

    [Header("Register")]
    [SerializeField] InputField UsernameRegisterInput;
    [SerializeField] InputField EmailRegisterInput;
    [SerializeField] InputField PasswordRegisterInput;
    [SerializeField] GameObject RegisterPage;

    [Header("Recovery")]
    [SerializeField] InputField EmailRecoveryInput;
    [SerializeField] GameObject RecoveryPage;





    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    #region ButtonFunctions
    public void RegisterUser()
    {
        var request = new RegisterPlayFabUserRequest
        {
            DisplayName = UsernameRegisterInput.text,
            Email = EmailRegisterInput.text,
            Password = PasswordRegisterInput.text,
            RequireBothUsernameAndEmail = false
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnError);
    }

    public void Login()
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = EmailLoginInput.text,
            Password = PasswordLoginInput.text,
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnError);
    }

    private void OnLoginSuccess(LoginResult result)
    {
        MessageText.text = "Logging in ";
        SceneManager.LoadScene(3);
    }
    public void ForgotPassword()
    {
        var request = new SendAccountRecoveryEmailRequest
        {
            Email = EmailRecoveryInput.text,
            TitleId = "24668" // Replace this with your actual title ID
        };
        PlayFabClientAPI.SendAccountRecoveryEmail(request, OnForgotPasswordSuccess, OnForgotPasswordError);
    }

    private void OnForgotPasswordSuccess(SendAccountRecoveryEmailResult result)
    {
        MessageText.text = "Recovery email sent. Please check your inbox.";
    }

    private void OnForgotPasswordError(PlayFabError error)
    {
        MessageText.text = "Failed to send recovery email: " + error.ErrorMessage;
        Debug.LogError("Forgot password error: " + error.GenerateErrorReport());
    }
    private void OnError(PlayFabError Error)
    {
        MessageText.text = Error.ErrorMessage;
        Debug.Log(Error.GenerateErrorReport());
    }

    private void OnRegisterSuccess(RegisterPlayFabUserResult Result)
    {
        MessageText.text = "New Account Is created ";
        OpenLoginPage();
    }

    public void OpenLoginPage()
    {
        LoginPage.SetActive(true);
        RegisterPage.SetActive(false);
        RecoveryPage.SetActive(false);
    }

    public void OpenRegisterPage()
    {
        LoginPage.SetActive(false);
        RegisterPage.SetActive(true);
        RecoveryPage.SetActive(false);
    }public void OpenRecoveryPage()
    {
        RecoveryPage.SetActive(true);
        LoginPage.SetActive(false);
        RegisterPage.SetActive(false);
    }

    #endregion
    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
