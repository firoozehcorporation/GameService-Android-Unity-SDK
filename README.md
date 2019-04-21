<p align="center">
  <img width="250" height="250" src="http://uupload.ir/files/9e17_logo.png">
</p>


#                                    گیم سرویس

#####                                             *توجه: این سرویس فعلا بر روی سیستم عامل اندروید کار می کند*






## : راه اندازی

### توجه : قبل از راه اندازی گیم سرویس و همچنین برای استفاده از آن از اتصال کاربر به اینترنت اطمینان حاصل کنید



#### **ابتدا پلاگین گیم سرویس را از [دریافت](https://github.com/firoozehcorporation/GameService-Android-Unity-SDK/tree/master/Assets/package)  کنید**

#### سپس آن را به صورت پکیج یونیتی به پروژه بازی خود اضافه کنید



![اضافه کردن پکیج](http://uupload.ir/files/uavu_screen_shot_1397-12-02_at_11.46.34_am.png)





![اضافه کردن پکیج](http://uupload.ir/files/mmlh_screen_shot_1397-12-02_at_11.50.16_am.png)



##### را بزنید Import  پس از اضافه کردن محتوایات پکیج  نمایش داده می شود دکمه 



#### از مسیر زیر دسترسی اینترنت را به بازی خود بدهید
##### File -> Build Settings -> Android -> Player Settings -> Other Settings -> Internet Access -> Required

![اضافه کردن پکیج](http://uupload.ir/files/hf4a_screen_shot_1397-12-25_at_9.38.23_am.png)


##### پس از اضافه کردن پکیج با دستور زیر می توانید به گیم سرویس دسترسی داشته باشید


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



------



###  :متد های دستور بالا

#### 1- With



```c#
public static FiroozehGameServiceInitializer With(string clientId, string clientSecret){}
```





##### باید در پنل توسعه دهندگان [گیم سرویس](https://gameservice.liara.run) بازی خود را ثبت کنید clientSecret  و clientId برای دریافت 

##### پس از ورود به پنل خود بازی خود را اضافه کنید   

##### برای اضافه کردن بازی خود نام بازی دسته بندی و توضیحی از بازی خود وارد کنید

 ##### همچنین باید یک شناسه خاص انگلیسی برای بازی خود وارد کنید

![اضافه کردن بازی](http://uupload.ir/files/en7m_screen_shot_1397-12-02_at_12.16.20_pm.png)





![اضافه کردن بازی](http://uupload.ir/files/f38a_screen_shot_1397-12-02_at_12.20.14_pm.png)





 #####  در یونیتی قرار دهید clientSecret و clientId پس از اضافه کردن بازی خود در پنل به صفحه بازی خود رفته و شناسه و رمزینه خود را به ترتیب در 



------



#### 2- IsNotificationEnable



```c#
public FiroozehGameServiceInitializer IsNotificationEnable(bool enable)}{}
```





#####    قرار دهید true را  enable درصورتی که بخواهید اعلانات برای بازی شما از سمت گیم سرویس فعال باشد مقدار 



------



#### 3- CheckGameServiceInstallStatus



```c#
public FiroozehGameServiceInitializer CheckGameServiceInstallStatus(bool check){}
```





#####    قرار دهید true را  check درصورتی که بخواهید وضعیت نصب بودن  گیم سرویس بر روی دستگاه کاربر را بررسی کند مقدار 

------


#### 4- CheckGameServiceOptionalUpdate

```c#
public FiroozehGameServiceInitializer CheckGameServiceOptionalUpdate(bool check){}
```

#####    قرار دهید true را  check درصورتی که بخواهید وضعیت بروز بودن گیم سرویس بر روی دستگاه کاربر را بررسی کند مقدار 

------



#### 5- Init



```c#
public void Init(DelegateCore.OnSuccessInitService onSuccess,DelegateCore.OnError onError){}
```





##### به صورت متنی بازمیگردد onError گیم سرویس بازمیگردد درصورتی که خطایی پیش آید خطای آن در  onSuccess پس از صدا زدن این دستور در  



####  : onError خطاهای بخش 

1. ##### InvalidInputs =  باشد  NULL خالی یا clientSecret  و clientId  درصورتی که 

2. ##### GameServiceNotInstalled = درصورتی که برنامه گیم سرویس بر روی دستگاه کاربر نصب نباشد

3. ##### GameServiceException = خطایی در بخش گیم سرویس به دلایل گوناگون رخ داده است

4. ##### NetworkUnreachable = درصورتی که دستگاه کاربر به اینترنت دسترسی نداشته باشد

5. ##### LoginFailed = درصورتی که خطایی در لاگین رخ بدهد

6. ##### LoginDismissed = درصورتی که لاگین کردن در گیم سرویس توسط کاربر کنسل شود



------



### : متد های گیم سرویس

#####    پس از انجام فرایند بالا شما گیم سرویس را در اختیار دارید با استفاده از دستورات زیر می توانید از گیم سرویس استفاده کنید



```c#
FiroozehGameServiceInitializer
    .With("Your clientId","Your clientSecret")
    .IsNotificationEnable(true)
    .CheckGameServiceInstallStatus(true)
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
            g.ShowLeaderBoardsUI(e=>{});
            g.GetSDKVersion(v=>{},e=>{});
            g.GetUserData(r=>{},e=>{});
            g.RemoveLastSave(r=>{},e=>{});
            g.ShowSurveyUi(e=>{});
            g.ShowGamePageUi(e=>{});
            g.DownloadObbData("main.VersionCode.<PackageName>.obb",r=>{},e=>{});            

        }, 
        e =>
        {
            Debug.Log("FiroozehGameServiceInitializer: "+e);
        });
```



##### نکته : بهتر است  شی گیم سرویس در یک متغیر استاتیک ذخیره شود تا دسترسی به متد های آن در تمام بازی آسان باشد



------



#### 1- GetLeaderBoards



```c#
public void GetLeaderBoards(DelegateCore.OnGetLeaderBoards callback, DelegateCore.OnError error){}

```



##### با این دستور  می توانید تمامی لیست مقایسه ای بازی خود را که در پنل ثبت کرده اید دریافت کنید

#####  های شماست LeaderBoard لیستی از  callback  در این جا 

#####  به شما به صورت متی بازمیگردد error درصورتی که خطایی در دریافت رخ دهد در 



####  : error خطاهای بخش 

1. ##### UnreachableService = (درصورتی که گیم سرویس در دسترس نباشد (برای حل این مشکل دوباره گیم سرویس را راه اندازی کنید

2. #####  NetworkUnreachable = درصورتی که دستگاه کاربر به اینترنت دسترسی نداشته باشد

    

------



#### 2- GetAchievements



```c#
public void GetAchievements(DelegateCore.OnGetAchievement callback,DelegateCore.OnError error){}

```



##### با این دستور می توانید تمامی لیست دستاورد های  بازی خود را که در پنل ثبت کرده اید دریافت کنید

#####  های شماست Achievement لیستی از  callback  در این جا 

#####  به شما به صورت متی بازمیگردد error درصورتی که خطایی در دریافت رخ دهد در 



#### : error خطاهای بخش 

1. ##### UnreachableService = (درصورتی که گیم سرویس در دسترس نباشد (برای حل این مشکل دوباره گیم سرویس را راه اندازی کنید

2. ##### NetworkUnreachable = درصورتی که دستگاه کاربر به اینترنت دسترسی نداشته باشد



------



#### 3- SaveGame



```c#
public void SaveGame(string saveGameName
            ,string saveGameDescription
            ,string saveGameCover
            ,object saveGameData
            , DelegateCore.OnCallback callback
            , DelegateCore.OnError error)
{}

```



##### با این دستور می توانید بازی خود را سیو کنید



#### :ورودی ها

1. ##### saveGameName = نام سیو

2. ##### saveGameDescription = توضیح سیو

3. ##### saveGameCover = (باشد Base 64  کاور سیو (کاور باید حتما به فرم 

4. ##### saveGameData = سیو مورد نظر شما 

5. ##### callback = نتیجه سیو

6. ##### error = درصورت خطا به شما بازمیگردد



#### : error خطاهای بخش 

1. ##### UnreachableService = (درصورتی که گیم سرویس در دسترس نباشد (برای حل این مشکل دوباره گیم سرویس را راه اندازی کنید

2. ##### NetworkUnreachable = درصورتی که دستگاه کاربر به اینترنت دسترسی نداشته باشد

3. ##### InvalidSaveImgFileSize = درصورتی که کاور سیو بیشتر از ۱۲۸ کیلو بایت باشد

4. ##### InvalidSaveFileSize = درصورتی که  سیو مورد نظر شما  بیشتر از ۱۲۸ کیلو بایت باشد

5. ##### InvalidInputs = باشد  NULL  در صورتی که یکی از ورودی ها خالی یا 



------



#### 4- SubmitScore



```c#
 public void SubmitScore(string leaderBoardId,
            int scoreValue,
            DelegateCore.OnCallback callback,
            DelegateCore.OnError error)
 {}
```



##### با این دستور می توانید با ایدی جدول های مقایسه ای که در پنل ثبت کرده اید امتیاز کاربر را در آن ثبت کنید

#### :ورودی ها

1. ##### leaderBoardId = ایدی جدول های مقایسه ای

2. ##### scoreValue = (مقدار امتیاز (مقدار آن نباید از حداکثر مقدار ثبت شده در پنل بیشتر باشد

3. ##### callback = نتیجه ثبت

4. ##### error = درصورت خطا به شما بازمیگردد



#### : error خطاهای بخش 

1. ##### UnreachableService = (درصورتی که گیم سرویس در دسترس نباشد (برای حل این مشکل دوباره گیم سرویس را راه اندازی کنید

2. ##### NetworkUnreachable = درصورتی که دستگاه کاربر به اینترنت دسترسی نداشته باشد

3. ##### InvalidInputs =  باشد NULL خالی یا  leaderBoardId در صورتی که   

4. ##### InvalidScore =منفی باشد scoreValue درصورتی که 

5. ##### leaderboard_notfound =  جدول های مقایسه ای موجود نباشد leaderBoardId  در صورتی که برای 



------



#### 5- UnlockAchievement



```c#
 public void UnlockAchievement(string achievementId, 
    DelegateCore.OnUnlockAchievement callback,
    DelegateCore.OnError error){}
```



##### با این دستور می توانید با ایدی دستاورد  که در پنل ثبت کرده اید آن دستاورد را  برای بازیکن باز کنید

#### :ورودی ها

1. ##### achievementId = ایدی دستاورد

2. ##### callback = (نتیجه بازکردن (دستاورد باز شده بازمیگردد

3. ##### error = درصورت خطا به شما بازمیگردد



#### : error خطاهای بخش 

1. ##### UnreachableService = (درصورتی که گیم سرویس در دسترس نباشد (برای حل این مشکل دوباره گیم سرویس را راه اندازی کنید

2. ##### NetworkUnreachable = درصورتی که دستگاه کاربر به اینترنت دسترسی نداشته باشد

3. ##### InvalidInputs =  باشد NULL خالی یا  achievementId در صورتی که   

4. ##### achievement_notfound =  دستاوردی موجود نباشد achievementId  در صورتی که برای 



------



#### 6- GetSaveGame



```c#
public void GetSaveGame<T>(DelegateCore.OnSaveGame<T>saveGameData, DelegateCore.OnError error)
```



##### با این دستور می توانید تمامی لیست دستاورد های  بازی خود را که در پنل ثبت کرده اید دریافت کنید

##### کلاس سیو شماست saveGameData  در این جا 

##### به شما به صورت متی بازمیگردد error درصورتی که خطایی در دریافت رخ دهد در 



#### : error خطاهای بخش 

1. ##### UnreachableService = (درصورتی که گیم سرویس در دسترس نباشد (برای حل این مشکل دوباره گیم سرویس را راه اندازی کنید

2. ##### NetworkUnreachable = درصورتی که دستگاه کاربر به اینترنت دسترسی نداشته باشد

3. ##### savegame_notfound = در صورتی که سیو بازی وجود نداشته  باشد

    

   ------

    

#### 7- GetLeaderBoardDetails



```c#
public void GetLeaderBoardDetails(string leaderBoardId,
            DelegateCore.OnGetLeaderBoardDetails callback,
            DelegateCore.OnError error){}
```



##### با این دستور می توانید با ایدی لیست مقایسه ای  که در پنل ثبت کرده اید آن لیست مقایسه ای را دریافت کنید

#### :ورودی ها

1. ##### leaderBoardId = ایدی لیست مقایسه ای

2. ##### callback = (نتیجه دریافت (لیست مقایسه ای بازمیگردد

3. ##### error = درصورت خطا به شما بازمیگردد



#### : error خطاهای بخش 

1. ##### UnreachableService = (درصورتی که گیم سرویس در دسترس نباشد (برای حل این مشکل دوباره گیم سرویس را راه اندازی کنید

2. ##### NetworkUnreachable = درصورتی که دستگاه کاربر به اینترنت دسترسی نداشته باشد

3. ##### InvalidInputs =  باشد NULL خالی یا  leaderBoardId در صورتی که

4. ##### leaderboard_notfound =  جدول های مقایسه ای موجود نباشد leaderBoardId  در صورتی که برای 



------


#### 8- ShowAchievementsUI



```c#
public void ShowAchievementsUI(DelegateCore.OnError error){}
```



#####   با این دستور می توانید  لیست دستاورد های بازی را به بازیکن نمایش دهید

#### :ورودی ها

1. ##### error = درصورت خطا به شما بازمیگردد



#### : error خطاهای بخش 

1. ##### UnreachableService = (درصورتی که گیم سرویس در دسترس نباشد (برای حل این مشکل دوباره گیم سرویس را راه اندازی کنید

2. ##### NetworkUnreachable = درصورتی که دستگاه کاربر به اینترنت دسترسی نداشته باشد



------


#### 9- ShowLeaderBoardsUI



```c#
public void ShowLeaderBoardsUI(DelegateCore.OnError error){}
```


#####   با این دستور می توانید  لیست های مقایسه ای بازی را به بازیکن نمایش دهید

#### :ورودی ها

1. ##### error = درصورت خطا به شما بازمیگردد



#### : error خطاهای بخش 

1. ##### UnreachableService = (درصورتی که گیم سرویس در دسترس نباشد (برای حل این مشکل دوباره گیم سرویس را راه اندازی کنید

2. ##### NetworkUnreachable = درصورتی که دستگاه کاربر به اینترنت دسترسی نداشته باشد



------



#### 10- GetSDKVersion



```c#
public void GetSDKVersion(DelegateCore.OnCallback version, DelegateCore.OnError error)
```


#####   با این دستور می توانید نسخه فعلی گیم سرویس را دریافت کنید

#### :ورودی ها

1. ##### callback = (نتیجه دریافت (نسخه گیم سرویس بازمیگردد
2. ##### error = درصورت خطا به شما بازمیگردد


#### : error خطاهای بخش 

1. ##### UnreachableService = (درصورتی که گیم سرویس در دسترس نباشد (برای حل این مشکل دوباره گیم سرویس را راه اندازی کنید

------

#### 11- GetUserData



```c#
 public void GetUserData(DelegateCore.OnGetUserData Data, DelegateCore.OnError error){}
```


#####   با این دستور می توانید اطلاعات بازیکن فعلی که بازی می کند را دریافت کنید

#### :ورودی ها

1. ##### Data = (نتیجه دریافت (کلاس یوزر برمیگردد
2. ##### error = درصورت خطا به شما بازمیگردد


#### : error خطاهای بخش 

1. ##### UnreachableService = (درصورتی که گیم سرویس در دسترس نباشد (برای حل این مشکل دوباره گیم سرویس را راه اندازی کنید

2. ##### NetworkUnreachable = درصورتی که دستگاه کاربر به اینترنت دسترسی نداشته باشد

------

#### 12- RemoveLastSave



```c#
public void RemoveLastSave(DelegateCore.OnCallback saveGameData, DelegateCore.OnError error)
```


#####   با این دستور می توانید آخرین سیو کاربر فعلی را حذف کنید

#### :ورودی ها

1. ##### saveGameData = (بازمیگردد Done نتیجه (درصورت موفق بودن 
2. ##### error = درصورت خطا به شما بازمیگردد


#### : error خطاهای بخش 

1. ##### UnreachableService = (درصورتی که گیم سرویس در دسترس نباشد (برای حل این مشکل دوباره گیم سرویس را راه اندازی کنید

2. ##### NetworkUnreachable = درصورتی که دستگاه کاربر به اینترنت دسترسی نداشته باشد

3. ##### savegame_notfound = در صورتی که سیو بازی وجود نداشته  باشد

------

#### 13- ShowSurveyUi



```c#
public void ShowSurveyUi(DelegateCore.OnError error){}
```


#####   با این دستور صفحه نظر سنجی نسبت به بازی شما باز می شود 

#### :ورودی ها

1. ##### error = درصورت خطا به شما بازمیگردد


#### : error خطاهای بخش 

1. ##### UnreachableService = (درصورتی که گیم سرویس در دسترس نباشد (برای حل این مشکل دوباره گیم سرویس را راه اندازی کنید

2. ##### NetworkUnreachable = درصورتی که دستگاه کاربر به اینترنت دسترسی نداشته باشد

------

#### 14- ShowGamePageUi



```c#
public void ShowGamePageUi(DelegateCore.OnError error)
```


##### با این دستور صفحه بازی شما در برنامه گیم سرویس باز می شود 

#### :ورودی ها

1. ##### error = درصورت خطا به شما بازمیگردد


#### : error خطاهای بخش 

1. ##### UnreachableService = (درصورتی که گیم سرویس در دسترس نباشد (برای حل این مشکل دوباره گیم سرویس را راه اندازی کنید

2. ##### NetworkUnreachable = درصورتی که دستگاه کاربر به اینترنت دسترسی نداشته باشد

------

#### 15- DownloadObbData



```c# 
public void DownloadObbData(string obbDataTag,DelegateCore.OnCallback downloadCallback,DelegateCore.OnError error)
        {}
```


##### با این دستور دیتای بازی که با تگ در پنل ثبت کرده اید دانلود می شود 

#### :ورودی ها

1. ##### obbDataTag = تگ دیتای بازی که در پنل ثبت کرده اید

2. ##### downloadCallback =  باز میگردد Data_Download_Finished درصورت دانلود کامل دیتا مقدار  

   ##### باز میگردد Data_Downloaded در صورتی که دیتا موجود باشد مقدار 

3. ##### error = درصورت خطا به شما بازمیگردد

#### : error خطاهای بخش 

1. ##### UnreachableService = (درصورتی که گیم سرویس در دسترس نباشد (برای حل این مشکل دوباره گیم سرویس را راه اندازی کنید

2. ##### Data_Download_Dismissed = درصورتی که دانلود توسط کاربر لغو شود

3. ##### Download_Error = درصورتی که خطایی در دانلود رخ دهد

4. ##### datapack_notfound =قرار داده اید وجود نداشته باشد obbDataTag درصورتی که فایلی با نامی که در 

    

------


###  :کتابخانه های استفاده شده

#####  1- [Newtonsoft.Json](https://github.com/JamesNK/Newtonsoft.Json)

------


### :بازی های تستی 

##### 1-[Flappy Bird](https://github.com/firoozehcorporation/FlappyBird-GameService-Template)