# README
此專案是介紹此專案架構的內容描述    
此專案是介紹此專案架構的內容描述    
此專案是介紹此專案架構的內容描述    
此專案是介紹此專案架構的內容描述    
此專案是介紹此專案架構的內容描述    
此專案是介紹此專案架構的內容描述    
此專案是介紹此專案架構的內容描述    
此專案是介紹此專案架構的內容描述    
此專案是介紹此專案架構的內容描述    
此專案是介紹此專案架構的內容描述    
此專案是介紹此專案架構的內容描述    
*******
## 專案架構

* [Root](#readme)
  * [Respostory](#respostory-%E5%9B%9E%E8%87%B3%E9%A0%82%E7%AB%AF)
  * [Model](#model-%E5%9B%9E%E8%87%B3%E9%A0%82%E7%AB%AF)
  * [Service](#Service)
  * [Web](#Web)
  * [Test](#Test)
  * [ConsoleTest](#ConsoleTest)
    
***********
### Model [回至頂端](#readme)
此傳案提供資料模型，包含ViewModel的資料模型，
如果要新增基礎模型(___非ViewModel___)，請將模型繼承 __BasicModel__ 類別，此類別也繼承於 __IModel__，
此類別已經事先定義好最基本的欄位！        
```c#
//BasicModel class
public BasicModel()
{
    this.Id = Guid.NewGuid();
    this.CreateTime = DateTime.Now;
    this.UpdateTime = DateTime.Now;
    this.Visible = true;
}

public Guid Id { get; set; }                //唯一Key

public DateTime CreateTime { get; set; }    //建立時間

public DateTime UpdateTime { get; set; }    //更新時間

public bool Visible { get; set; }           //軟刪除記號
```
__注意！ 請勿直接使用__ `DB`__物件__，
請使用 __Respostory__ 內的 [`DBInstance`](#2dbinstance-%E9%A1%9E%E5%88%A5) 類別的`Instance()`方法取得`DB`類別，使用方法[請參考這](#2dbinstance-%E9%A1%9E%E5%88%A5)！  

***********
### Respostory [回至頂端](#readme)

#### 1.Repository 類別
此專案提供操作資料庫的方法，大致上都提供了 __CRUD__ 的功能，分別透過四個抽象類別實作，分別是以下四個介面`ICreate`、`IRead`、`IUpdate`、`IDelete`！     
如果要建立 __Repository__ 類別的話，請繼承 __IRepository__ 類別，並將內部抽象方法實踐完畢！    
__Repository__ 類別內提供了一個`DB`變數可直接操作資料庫，以及`Save()`方法可將操作完後的內容儲存！      
`Save()`方法會抓取資料存進資料庫後是否有錯誤，如果操作失敗會直接回傳`false`，成功則回傳`true`！        
範例如下：
```c#
public class UserRespostory : Respostory<Models.User>
{

    //創建一筆資料的方法
    public override bool Create(Models.User model)
    {
        return this.Save();
    }

    //刪除一筆資料的方法，softHardSwitch參數為是軟或硬的開關，預設為軟刪除
    public override bool Delete(Guid id, bool softHardSwitch = false)
    {
        return this.Save();
    }

    //查詢一個集合內所有內容
    public override List<Models.User> Read()
    {
        return this.DB.User.ToList();
    }
    
    //查詢一個單一內容
    public override Models.User Read(Guid id)
    {
        return this.DB.User.Find(id);
    }
    
    //修改一筆資料的方法
    public override bool Update(Guid id, Models.User model)
    {
        return this.Save();
    }
    
}
```
#### 2.DBInstance 類別
`DBInstance`是一個無法產生實例的類別，單純拿來做連線物件數量的管理的類別，透過`DBInstance.Instance()`可以產生`DB`實例，一但`DB`實例被產生，就會持續沿用，值到連線關閉為止！   
範例如下：      
```c#
DB DB = DBInstance.Instance();
```
#### 3.RespostoryFactory 類別
`RespostoryFactory`是一個無法產生實例的類別，目的在於產生`IRespostory`的工廠，操作方法必須先建立好Respostory類別，並將類別丟入`dictionary`內註冊即可使用！   
註冊範例如下：      
```c#
//註冊Respostory
public static IRespostory Respostory(string modelName)
{
    IRespostory respostory = null;

    Dictionary<string, Type> dictionary = new Dictionary<string, Type>
    {
        { "User", typeof(UserRespostory) }, //註冊UserRespostory，使用時只需要輸入"User"字串即可取得該類別
        { "Rule", typeof(RuleRespostory) }  //註冊RuleRespostory，使用時只需要輸入"Rule"字串即可取得該類別
    };

    respostory = (IRespostory)dictionary[modelName].Assembly.CreateInstance(dictionary[modelName].FullName);

    return respostory;

}
```
取得範例如下：      
```c#
//取得Respostory
IRespostory userRespostory = RespostoryFactory.Respostory("User");
((UserRespostory)userReRespostory).create(model);   //取出後再轉型即可使用
```
***********
### Service [回至頂端](#readme)
此專案是介紹此專案架構的內容描述    
此專案是介紹此專案架構的內容描述    
此專案是介紹此專案架構的內容描述    
此專案是介紹此專案架構的內容描述    
***********
### Web [回至頂端](#readme)
此專案是介紹此專案架構的內容描述    
此專案是介紹此專案架構的內容描述    
此專案是介紹此專案架構的內容描述    
此專案是介紹此專案架構的內容描述    
此專案是介紹此專案架構的內容描述    
此專案是介紹此專案架構的內容描述    
***********
### Test [回至頂端](#readme)
此專案是介紹此專案架構的內容描述    
此專案是介紹此專案架構的內容描述    
此專案是介紹此專案架構的內容描述    
此專案是介紹此專案架構的內容描述    
此專案是介紹此專案架構的內容描述    
此專案是介紹此專案架構的內容描述    
此專案是介紹此專案架構的內容描述    
***********
### ConsoleTest [回至頂端](#readme)
此專案是介紹此專案架構的內容描述    
此專案是介紹此專案架構的內容描述    
此專案是介紹此專案架構的內容描述    
此專案是介紹此專案架構的內容描述    
此專案是介紹此專案架構的內容描述    
***********