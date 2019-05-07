using FiroozehGameServiceAndroid.Builders;
using UnityEngine;

public class Test : MonoBehaviour
{
    private void Start()
    {
        FiroozehGameService
            .With("Your clientId","Your clientSecret")
            .IsNotificationEnable(true)
            .CheckGameServiceInstallStatus(true)
            .CheckGameServiceOptionalUpdate(true)
            .Init(g =>
                {
                    
                    g.GetLeaderBoards(r=>{},e=>{});
                    g.GetAchievements(r=>{},e=>{});
                    g.SaveGame("SaveName","Save Des",null,"20",r=>{},e=>{});
                    g.SubmitScore("LeaderBoardID",20,r=>{},e=>{});
                    g.UnlockAchievement("Achievement ID",r=>{},e=>{});
                    g.GetSaveGame<object>(r=>{},e=>{});
                    g.GetLeaderBoardDetails("LeaderBoardID",r=>{},e=>{});
                    g.ShowAchievementsUI(e=>{});
                    g.GetSDKVersion(v=>{},e=>{});
                    g.ShowLeaderBoardsUI(e=>{});
                    g.GetUserData(r=>{},e=>{});
                    g.RemoveLastSave(r=>{},e=>{});
                    g.ShowSurveyUi(e=>{});
                    g.ShowGamePageUi(e=>{});
                    
                    
                    g.DownloadObbData("main.VersionCode.<PackageName>.obb", r =>
                        {
                            if (r.Equals("Data_Download_Finished") || r.Equals("Data_Downloaded"))
                            {
                                // Now Obb Data Exist !!! Load Base Scene
                            } 
                        },
                        e =>
                        {
                            if(e.Equals("Data_Download_Dismissed"))
                                Application.Quit();
                           
                        });
     
                }, 
                e =>
                {
                    Debug.Log("FiroozehGameServiceInitializerError: "+e);
                });

    }
}