public class InputController : Sington<InputController>
{
    private GameModeType currentGameMode = GameModeType.None;
    public GameModeType GameModeType { get { return currentGameMode; } }

    // private TopViewInputController   playerInputController;
    private CameraController        cameraController;
    // private UIInputController       uIInputController;

    private void Reset()
    {
        // playerInputController = FindObjectOfType<TopViewInputController>();
        cameraController = FindObjectOfType<CameraController>();
    }

    public void SetGameMode(GameModeType gameModeType)
    {
        currentGameMode = gameModeType;

        switch(currentGameMode)
        {
            case GameModeType.None:
                break;
            case GameModeType.GamePlay:
                break;
            case GameModeType.GamePause:
                break;
            case GameModeType.GameStop:
                break;
            case GameModeType.End:
            default:
                break;
        }
    }

    //public void OnGamePlay()
    //{
    //    if (playerInputController != null)
    //        playerInputController.SetInputable(true);
    //}

    //public void OnGamePause()
    //{
    //    if (playerInputController != null)
    //        playerInputController.SetInputable(false);

    //}
    //public void OnGameStop()
    //{
    //    if (playerInputController != null)
    //        playerInputController.SetInputable(false);
    //}
}
