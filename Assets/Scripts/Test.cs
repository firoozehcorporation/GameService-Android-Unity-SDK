using FiroozehGameServiceAndroid.Builders;
using UnityEngine;

public class Test : MonoBehaviour
{
    private void Start()
    {
        FiroozehGameServiceInitializer
            .With("Your clientId","Your clientSecret")
            .IsNotificationEnable(true)
            .CheckGameServiceInstallStatus(false)
            .Init(g =>
                {
                    
                    g.GetLeaderBoards(r=>{},e=>{});
                    g.GetAchievements(r=>{},e=>{});
                    g.SaveGame("SaveName","Save Des",null,"20",r=>{},e=>{});
                    g.SubmitScore("LeaderBoardID",20,r=>{},e=>{});
                    g.UnlockAchievement("Achievement ID",r=>{},e=>{});
                    g.GetSaveGame(r=>{},e=>{});
                    g.GetLeaderBoardDetails("LeaderBoardID",r=>{},e=>{});
                    g.ShowAchievementsUI(e=>{});
                    g.GetSDKVersion(v=>{},e=>{});
                    g.ShowLeaderBoardsUI(e=>{});
                    g.GetUserData(r=>{},e=>{});
                    g.RemoveLastSave(r=>{},e=>{});
                    g.ShowSurveyUi(e=>{});
                    g.ShowGamePageUi(e=>{});
                    
                   
                
                }, 
                e =>
                {
                    Debug.Log("FiroozehGameServiceInitializer: "+e);
                });

    }
}