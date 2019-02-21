

# گیم سرویس

##### *توجه: این سرویس فعلا بر روی سیستم عامل اندروید کار می کند*



 

## : راه اندازی

##### **ابتدا پلاگین گیم سرویس را از [دریافت](https://github.com/AR-Ghodrati/GameService_UnitySide/tree/master/Assets/package)  کنید**

##### سپس آن را به صورت پکیج یونیتی به پروژه بازی خود اضافه کنید



![اضافه کردن پکیج](http://uupload.ir/files/uavu_screen_shot_1397-12-02_at_11.46.34_am.png)





![اضافه کردن پکیج](http://uupload.ir/files/mmlh_screen_shot_1397-12-02_at_11.50.16_am.png)



##### را بزنید Import  پس از اضافه کردن محتوایات پکیج  نمایش داده می شود دکمه 

##### پس از اضافه کردن پکیج با دستور زیر می توانید به گیم سرویس دسترسی داشته باشید


```c#
FiroozehGameServiceInitializer
    .With("Your clientId","Your clientSecret")
    .IsNotificationEnable(true)
    .CheckGameServiceInstallStatus(true)
    .Init(g =>
        {
            // Use (g = GameService Obj) 
        }, 
        e =>
        {
            Debug.Log("FiroozehGameServiceInitializer: "+e);
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



#### 4- Init



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
            g.GetSDKVersion(v=>{},e=>{});
            g.ShowLeaderBoardsUI(e=>{});
           
        
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
            ,string saveGameData
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
public void GetSaveGame(DelegateCore.OnCallback saveGameData, DelegateCore.OnError error){}
```



##### با این دستور می توانید تمامی لیست دستاورد های  بازی خود را که در پنل ثبت کرده اید دریافت کنید

##### سیو متنی ذخیره شده شماست saveGameData  در این جا 

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
