<p align="center">
  <img width="250" height="250" src="http://uupload.ir/files/9e17_logo.png">
</p>



### گیم سرویس

##### توجه: این سرویس فعلا بر روی سیستم عامل اندروید کار می کند

#### راه اندازی

  قبل از راه اندازی گیم سرویس و همچنین برای استفاده از آن از اتصال کاربر به اینترنت اطمینان حاصل کنید. سپس پلاگین گیم سرویس را از [اینجا دریافت](https://github.com/firoozehcorporation/GameService-Android-Unity-SDK/tree/master/Assets/package) و آن را به صورت پکیج یونیتی به پروژه بازی خود اضافه کنید

![اضافه کردن پکیج](http://uupload.ir/files/uavu_screen_shot_1397-12-02_at_11.46.34_am.png)

![اضافه کردن پکیج](http://uupload.ir/files/mmlh_screen_shot_1397-12-02_at_11.50.16_am.png)

پس از اضافه کردن و نمایش محتویات پکیج گزینه import را انتخاب کنید

حال از مسیر زیر باید دسترسی به شبکه را برای بازی خود فراهم کنید

> File -> Build Settings -> Android -> Player Settings -> Other Settings -> Internet Access -> Required 

![اضافه کردن پکیج](http://uupload.ir/files/hf4a_screen_shot_1397-12-25_at_9.38.23_am.png)

 پس از اضافه کردن پکیج با دستور زیر می توانید به گیم سرویس دسترسی داشته باشید

```c#
            FiroozehGameServiceInitializer
            .With("Your clientId","Your clientSecret")
            .IsNotificationEnable(true)
            .CheckGameServiceInstallStatus(true)
            .CheckGameServiceOptionalUpdate(true)
            .Init(g =>
        {
            // Use (g = GameService Obj) 
        }, 
        e =>
        {
            Debug.Log("FiroozehGameServiceInitializerError: "+e);
        });
```



------



##### متد های دستور بالا

__1- With__

```c#
public static FiroozehGameServiceInitializer With(string clientId, string clientSecret){}
```

 باید در پنل توسعه دهندگان [گیم سرویس](https://gameservice.liara.run) بازی خود را ثبت کنید clientSecret  و clientId برای دریافت .
پس از ورود به پنل خود بازی خود را اضافه کنید   

 برای اضافه کردن بازی خود نام بازی دسته بندی و توضیحی از بازی خود وارد کنید

 همچنین باید یک شناسه خاص انگلیسی برای بازی خود وارد کنید

![اضافه کردن بازی](http://uupload.ir/files/en7m_screen_shot_1397-12-02_at_12.16.20_pm.png)





![اضافه کردن بازی](http://uupload.ir/files/f38a_screen_shot_1397-12-02_at_12.20.14_pm.png)

در این قسمت باید کلید های دسترسی که در مرحله قبل آن را از پنل توسعه دهندگان بدست اوردید را قرار دهید

------



__2- IsNotificationEnable__

```c#
public FiroozehGameServiceInitializer IsNotificationEnable(bool enable)}{}
```

با قرار دادن مقدار true در این قسمت گیم سرویس به صورت خودکار اعلاناتی را در میان بازی نمایش خواهد داد

------



__3- CheckGameServiceInstallStatus__

```c#
public FiroozehGameServiceInitializer CheckGameServiceInstallStatus(bool check){}
```

با قرار دادن مقدار true در این قسمت وضعیت نصب گیم سرویس در گوشی کاربر بررسی خواهد شد

------

__4- CheckGameServiceOptionalUpdate__

```c#
public FiroozehGameServiceInitializer CheckGameServiceOptionalUpdate(bool check){}
```

در صورت قرار دادن مقدار true در این قسمت بروز بودن برنامه گیم سرویس بررسی خواهد شد

------

__5- Init__

```c#
public void Init(DelegateCore.OnSuccessInitService onSuccess,DelegateCore.OnError onError){}
```

پس از صدا زدن این دستور گیم سرویس در onSuccess و در صورت وجود خطا در onError ان را دریافت خواهید کرد

 **onError خطاهای بخش**

- InvalidInputs =  باشد  NULL خالی یا clientSecret  و clientId  درصورتی که 
- GameServiceNotInstalled = درصورتی که برنامه گیم سرویس بر روی دستگاه کاربر نصب نباشد
- GameServiceException = خطایی در بخش گیم سرویس به دلایل گوناگون رخ داده است
- NetworkUnreachable = درصورتی که دستگاه کاربر به اینترنت دسترسی نداشته باشد
- LoginFailed = درصورتی که خطایی در لاگین رخ بدهد
- LoginDismissed = درصورتی که لاگین کردن در گیم سرویس توسط کاربر کنسل شود

------



#### متد های گیم سرویس

```
پس از انجام فرایند بالا شما گیم سرویس را در اختیار دارید با استفاده از دستورات زیر می توانید از گیم سرویس استفاده کنید
```

```c#
FiroozehGameServiceInitializer
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
```

 نکته : بهتر است  شی گیم سرویس در یک متغیر استاتیک ذخیره شود تا دسترسی به متد های آن در تمام بازی آسان باشد

------



__1- GetLeaderBoards__

```c#
public void GetLeaderBoards(DelegateCore.OnGetLeaderBoards callback, DelegateCore.OnError error)
```



 با این دستور  می توانید تمامی لیست مقایسه ای بازی خود را که در پنل ثبت کرده اید دریافت کنید

  های شماست LeaderBoard لیستی از  callback  در این جا 

  به شما به صورت متی بازمیگردد error درصورتی که خطایی در دریافت رخ دهد در 



**error خطاهای بخش**

- UnreachableService = (درصورتی که گیم سرویس در دسترس نباشد (برای حل این مشکل دوباره گیم سرویس را راه اندازی کنید
- NetworkUnreachable = درصورتی که دستگاه کاربر به اینترنت دسترسی نداشته باشد

------



__2- GetAchievements__

```c#
public void GetAchievements(DelegateCore.OnGetAchievement callback,DelegateCore.OnError error)
```



 با این دستور می توانید تمامی لیست دستاورد های  بازی خود را که در پنل ثبت کرده اید دریافت کنید

  های شماست Achievement لیستی از  callback  در این جا 

  به شما به صورت متی بازمیگردد error درصورتی که خطایی در دریافت رخ دهد در 



**error خطاهای بخش**

- UnreachableService = (درصورتی که گیم سرویس در دسترس نباشد (برای حل این مشکل دوباره گیم سرویس را راه اندازی کنید
- NetworkUnreachable = درصورتی که دستگاه کاربر به اینترنت دسترسی نداشته باشد



------

__3- SaveGame__

```c#
public void SaveGame(string saveGameName
            ,string saveGameDescription
            ,string saveGameCover
            ,object saveGameData
            , DelegateCore.OnCallback callback
            , DelegateCore.OnError error)
```

 با این دستور می توانید بازی خود را سیو کنید



**ورودی ها**

- saveGameName = نام سیو
- saveGameDescription = توضیح سیو
- saveGameCover = (باشد Base 64  کاور سیو (کاور باید حتما به فرم 
- saveGameData = سیو مورد نظر شما 
- callback = نتیجه سیو
- error = درصورت خطا به شما بازمیگردد



**error خطاهای بخش**

- UnreachableService = (درصورتی که گیم سرویس در دسترس نباشد (برای حل این مشکل دوباره گیم سرویس را راه اندازی کنید
- NetworkUnreachable = درصورتی که دستگاه کاربر به اینترنت دسترسی نداشته باشد
- InvalidSaveImgFileSize = درصورتی که کاور سیو بیشتر از ۱۲۸ کیلو بایت باشد
- InvalidSaveFileSize = درصورتی که  سیو مورد نظر شما  بیشتر از ۱۲۸ کیلو بایت باشد
- InvalidInputs = باشد  NULL  در صورتی که یکی از ورودی ها خالی یا 



------



##### 4- SubmitScore



```c#
 public void SubmitScore(string leaderBoardId,
            int scoreValue,
            DelegateCore.OnCallback callback,
            DelegateCore.OnError error)
```



 با این دستور می توانید با ایدی جدول های مقایسه ای که در پنل ثبت کرده اید امتیاز کاربر را در آن ثبت کنید

**ورودی ها**

- leaderBoardId = ایدی جدول های مقایسه ای
- scoreValue = (مقدار امتیاز (مقدار آن نباید از حداکثر مقدار ثبت شده در پنل بیشتر باشد
- callback = نتیجه ثبت
- error = درصورت خطا به شما بازمیگردد



**error خطاهای بخش**

- UnreachableService = (درصورتی که گیم سرویس در دسترس نباشد (برای حل این مشکل دوباره گیم سرویس را راه اندازی کنید
- NetworkUnreachable = درصورتی که دستگاه کاربر به اینترنت دسترسی نداشته باشد
- InvalidInputs =  باشد NULL خالی یا  leaderBoardId در صورتی که   
- InvalidScore =منفی باشد scoreValue درصورتی که 
- leaderboard_notfound =  جدول های مقایسه ای موجود نباشد leaderBoardId  در صورتی که برای 



------



__5- UnlockAchievement__



```c#
 public void UnlockAchievement(string achievementId, 
    DelegateCore.OnUnlockAchievement callback,
    DelegateCore.OnError error)
```

 با این دستور می توانید با ایدی دستاورد  که در پنل ثبت کرده اید آن دستاورد را  برای بازیکن باز کنید

**ورودی ها**

- achievementId = ایدی دستاورد
- callback = (نتیجه بازکردن (دستاورد باز شده بازمیگردد
- error = درصورت خطا به شما بازمیگردد

**error خطاهای بخش**

- UnreachableService = (درصورتی که گیم سرویس در دسترس نباشد (برای حل این مشکل دوباره گیم سرویس را راه اندازی کنید
- NetworkUnreachable = درصورتی که دستگاه کاربر به اینترنت دسترسی نداشته باشد
- InvalidInputs =  باشد NULL خالی یا  achievementId در صورتی که   
- achievement_notfound =  دستاوردی موجود نباشد achievementId  در صورتی که برای 



------



__6- GetSaveGame__



```c#
public void GetSaveGame<T>(DelegateCore.OnSaveGame<T>saveGameData, DelegateCore.OnError error)
```



 با این دستور می توانید تمامی لیست دستاورد های  بازی خود را که در پنل ثبت کرده اید دریافت کنید

 کلاس سیو شماست saveGameData  در این جا 

 به شما به صورت متی بازمیگردد error درصورتی که خطایی در دریافت رخ دهد در 



**error خطاهای بخش** 

- UnreachableService = (درصورتی که گیم سرویس در دسترس نباشد (برای حل این مشکل دوباره گیم سرویس را راه اندازی کنید

- NetworkUnreachable = درصورتی که دستگاه کاربر به اینترنت دسترسی نداشته باشد

- savegame_notfound = در صورتی که سیو بازی وجود نداشته  باشد

    

  ------

   

__7- GetLeaderBoardDetails__



```c#
public void GetLeaderBoardDetails(string leaderBoardId,
            DelegateCore.OnGetLeaderBoardDetails callback,
            DelegateCore.OnError error)
```

 با این دستور می توانید با ایدی لیست مقایسه ای  که در پنل ثبت کرده اید آن لیست مقایسه ای را دریافت کنید

**ورودی ها**

- leaderBoardId = ایدی لیست مقایسه ای
- callback = (نتیجه دریافت (لیست مقایسه ای بازمیگردد
- error = درصورت خطا به شما بازمیگردد



**error خطاهای بخش**

- UnreachableService = (درصورتی که گیم سرویس در دسترس نباشد (برای حل این مشکل دوباره گیم سرویس را راه اندازی کنید
- NetworkUnreachable = درصورتی که دستگاه کاربر به اینترنت دسترسی نداشته باشد
- InvalidInputs =  باشد NULL خالی یا  leaderBoardId در صورتی که
- leaderboard_notfound =  جدول های مقایسه ای موجود نباشد leaderBoardId  در صورتی که برای 



------

__8- ShowAchievementsUI__



```c#
public void ShowAchievementsUI(DelegateCore.OnError error)
```

   با این دستور می توانید  لیست دستاورد های بازی را به بازیکن نمایش دهید

**ورودی ها**

- error = درصورت خطا به شما بازمیگردد



**error خطاهای بخش** 

- UnreachableService = (درصورتی که گیم سرویس در دسترس نباشد (برای حل این مشکل دوباره گیم سرویس را راه اندازی کنید
- NetworkUnreachable = درصورتی که دستگاه کاربر به اینترنت دسترسی نداشته باشد



------

__9- ShowLeaderBoardsUI__



```c#
public void ShowLeaderBoardsUI(DelegateCore.OnError error)
```

 با این دستور می توانید  لیست های مقایسه ای بازی را به بازیکن نمایش دهید

**ورودی ها**

- error = درصورت خطا به شما بازمیگردد



**error **خطاهای بخش 

- UnreachableService = (درصورتی که گیم سرویس در دسترس نباشد (برای حل این مشکل دوباره گیم سرویس را راه اندازی کنید
- NetworkUnreachable = درصورتی که دستگاه کاربر به اینترنت دسترسی نداشته باشد



------



__10- GetSDKVersion__



```c#
public void GetSDKVersion(DelegateCore.OnCallback version, DelegateCore.OnError error)
```

   با این دستور می توانید نسخه فعلی گیم سرویس را دریافت کنید

**ورودی ها**

- callback = (نتیجه دریافت (نسخه گیم سرویس بازمیگردد
- error = درصورت خطا به شما بازمیگردد

**error خطاهای بخش** 

- UnreachableService = (درصورتی که گیم سرویس در دسترس نباشد (برای حل این مشکل دوباره گیم سرویس را راه اندازی کنید

------

__11- GetUserData__



```c#
 public void GetUserData(DelegateCore.OnGetUserData Data, DelegateCore.OnError error)
```

   با این دستور می توانید اطلاعات بازیکن فعلی که بازی می کند را دریافت کنید

**ورودی ها**

- Data = (نتیجه دریافت (کلاس یوزر برمیگردد
- error = درصورت خطا به شما بازمیگردد

**error خطاهای بخش** 

- UnreachableService = (درصورتی که گیم سرویس در دسترس نباشد (برای حل این مشکل دوباره گیم سرویس را راه اندازی کنید
- NetworkUnreachable = درصورتی که دستگاه کاربر به اینترنت دسترسی نداشته باشد

------

__12- RemoveLastSave__



```c#
public void RemoveLastSave(DelegateCore.OnCallback saveGameData, DelegateCore.OnError error)
```

  با این دستور می توانید آخرین سیو کاربر فعلی را حذف کنید

**ورودی ها**

- saveGameData = (بازمیگردد Done نتیجه (درصورت موفق بودن 
- error = درصورت خطا به شما بازمیگردد

**error خطاهای بخش** 

- UnreachableService = (درصورتی که گیم سرویس در دسترس نباشد (برای حل این مشکل دوباره گیم سرویس را راه اندازی کنید
- NetworkUnreachable = درصورتی که دستگاه کاربر به اینترنت دسترسی نداشته باشد
- savegame_notfound = در صورتی که سیو بازی وجود نداشته  باشد

------

__13- ShowSurveyUi__



```c#
public void ShowSurveyUi(DelegateCore.OnError error)
```

   با این دستور صفحه نظر سنجی نسبت به بازی شما باز می شود 

**ورودی ها**

- error = درصورت خطا به شما بازمیگردد

**error خطاهای بخش** 

- UnreachableService = (درصورتی که گیم سرویس در دسترس نباشد (برای حل این مشکل دوباره گیم سرویس را راه اندازی کنید
- NetworkUnreachable = درصورتی که دستگاه کاربر به اینترنت دسترسی نداشته باشد

------

__14- ShowGamePageUi__



```c#
public void ShowGamePageUi(DelegateCore.OnError error)
```

 با این دستور صفحه بازی شما در برنامه گیم سرویس باز می شود 

**ورودی ها**

- error = درصورت خطا به شما بازمیگردد

**error خطاهای بخش** 

- UnreachableService = (درصورتی که گیم سرویس در دسترس نباشد (برای حل این مشکل دوباره گیم سرویس را راه اندازی کنید
- NetworkUnreachable = درصورتی که دستگاه کاربر به اینترنت دسترسی نداشته باشد

------

__15- DownloadObbData__



```c# 
public void DownloadObbData(string obbDataTag,DelegateCore.OnCallback downloadCallback,DelegateCore.OnError error)
```

 با این دستور دیتای بازی که با تگ در پنل ثبت کرده اید دانلود می شود 

**ورودی ها**

- obbDataTag = تگ دیتای بازی که در پنل ثبت کرده اید

- downloadCallback =  باز میگردد Data_Download_Finished درصورت دانلود کامل دیتا مقدار  

  باز میگردد Data_Downloaded در صورتی که دیتا موجود باشد مقدار 

- error = درصورت خطا به شما بازمیگردد

**error خطاهای بخش** 

- UnreachableService = (درصورتی که گیم سرویس در دسترس نباشد (برای حل این مشکل دوباره گیم سرویس را راه اندازی کنید

- Data_Download_Dismissed = درصورتی که دانلود توسط کاربر لغو شود

- Download_Error = درصورتی که خطایی در دانلود رخ دهد

- datapack_notfound =قرار داده اید وجود نداشته باشد obbDataTag درصورتی که فایلی با نامی که در 

    

------

__کتابخانه های استفاده شده__

- [Newtonsoft.Json](https://github.com/JamesNK/Newtonsoft.Json)

------

__بازی های تستی__ 

- [ZigZag Game](https://github.com/firoozehcorporation/ZigZag-GameService-Template)
- [2048_Game](https://github.com/firoozehcorporation/2048-GameService-Template)
- [Flappy Bird Game](https://github.com/firoozehcorporation/FlappyBird-GameService-Template)

##### https://github.com/firoozehcorporation/FlappyBird-GameService-Template)
