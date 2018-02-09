# README
���M�׬O���Ц��M�׬[�c�����e�y�z    
���M�׬O���Ц��M�׬[�c�����e�y�z    
���M�׬O���Ц��M�׬[�c�����e�y�z    
���M�׬O���Ц��M�׬[�c�����e�y�z    
���M�׬O���Ц��M�׬[�c�����e�y�z    
���M�׬O���Ц��M�׬[�c�����e�y�z    
���M�׬O���Ц��M�׬[�c�����e�y�z    
���M�׬O���Ц��M�׬[�c�����e�y�z    
���M�׬O���Ц��M�׬[�c�����e�y�z    
���M�׬O���Ц��M�׬[�c�����e�y�z    
���M�׬O���Ц��M�׬[�c�����e�y�z    
*******
## �M�׬[�c

* [Root](#readme)
  * [Respostory](#respostory-%E5%9B%9E%E8%87%B3%E9%A0%82%E7%AB%AF)
  * [Model](#model-%E5%9B%9E%E8%87%B3%E9%A0%82%E7%AB%AF)
  * [Service](#Service)
  * [Web](#Web)
  * [Test](#Test)
  * [ConsoleTest](#ConsoleTest)
    
***********
### Model [�^�ܳ���](#readme)
���Ǯ״��Ѹ�Ƽҫ��A�]�tViewModel����Ƽҫ��A
�p�G�n�s�W��¦�ҫ�(___�DViewModel___)�A�бN�ҫ��~�� __BasicModel__ ���O�A�����O�]�~�ө� __IModel__�A
�����O�w�g�ƥ��w�q�n�̰򥻪����I        
```c#
//BasicModel class
public BasicModel()
{
    this.Id = Guid.NewGuid();
    this.CreateTime = DateTime.Now;
    this.UpdateTime = DateTime.Now;
    this.Visible = true;
}

public Guid Id { get; set; }                //�ߤ@Key

public DateTime CreateTime { get; set; }    //�إ߮ɶ�

public DateTime UpdateTime { get; set; }    //��s�ɶ�

public bool Visible { get; set; }           //�n�R���O��
```
__�`�N�I �ФŪ����ϥ�__ `DB`__����__�A
�Шϥ� __Respostory__ ���� [`DBInstance`](#2dbinstance-%E9%A1%9E%E5%88%A5) ���O��`Instance()`��k���o`DB`���O�A�ϥΤ�k[�аѦҳo](#2dbinstance-%E9%A1%9E%E5%88%A5)�I  

***********
### Respostory [�^�ܳ���](#readme)

#### 1.Repository ���O
���M�״��Ѿާ@��Ʈw����k�A�j�P�W�����ѤF __CRUD__ ���\��A���O�z�L�|�ө�H���O��@�A���O�O�H�U�|�Ӥ���`ICreate`�B`IRead`�B`IUpdate`�B`IDelete`�I     
�p�G�n�إ� __Repository__ ���O���ܡA���~�� __IRepository__ ���O�A�ñN������H��k�����I    
__Repository__ ���O�����ѤF�@��`DB`�ܼƥi�����ާ@��Ʈw�A�H��`Save()`��k�i�N�ާ@���᪺���e�x�s�I      
`Save()`��k�|�����Ʀs�i��Ʈw��O�_�����~�A�p�G�ާ@���ѷ|�����^��`false`�A���\�h�^��`true`�I        
�d�Ҧp�U�G
```c#
public class UserRespostory : Respostory<Models.User>
{

    //�Ыؤ@����ƪ���k
    public override bool Create(Models.User model)
    {
        return this.Save();
    }

    //�R���@����ƪ���k�AsoftHardSwitch�ѼƬ��O�n�εw���}���A�w�]���n�R��
    public override bool Delete(Guid id, bool softHardSwitch = false)
    {
        return this.Save();
    }

    //�d�ߤ@�Ӷ��X���Ҧ����e
    public override List<Models.User> Read()
    {
        return this.DB.User.ToList();
    }
    
    //�d�ߤ@�ӳ�@���e
    public override Models.User Read(Guid id)
    {
        return this.DB.User.Find(id);
    }
    
    //�ק�@����ƪ���k
    public override bool Update(Guid id, Models.User model)
    {
        return this.Save();
    }
    
}
```
#### 2.DBInstance ���O
`DBInstance`�O�@�ӵL�k���͹�Ҫ����O�A��®��Ӱ��s�u����ƶq���޲z�����O�A�z�L`DBInstance.Instance()`�i�H����`DB`��ҡA�@��`DB`��ҳQ���͡A�N�|����u�ΡA�Ȩ�s�u��������I   
�d�Ҧp�U�G      
```c#
DB DB = DBInstance.Instance();
```
#### 3.RespostoryFactory ���O
`RespostoryFactory`�O�@�ӵL�k���͹�Ҫ����O�A�ت��b�󲣥�`IRespostory`���u�t�A�ާ@��k�������إߦnRespostory���O�A�ñN���O��J`dictionary`�����U�Y�i�ϥΡI   
���U�d�Ҧp�U�G      
```c#
//���URespostory
public static IRespostory Respostory(string modelName)
{
    IRespostory respostory = null;

    Dictionary<string, Type> dictionary = new Dictionary<string, Type>
    {
        { "User", typeof(UserRespostory) }, //���UUserRespostory�A�ϥήɥu�ݭn��J"User"�r��Y�i���o�����O
        { "Rule", typeof(RuleRespostory) }  //���URuleRespostory�A�ϥήɥu�ݭn��J"Rule"�r��Y�i���o�����O
    };

    respostory = (IRespostory)dictionary[modelName].Assembly.CreateInstance(dictionary[modelName].FullName);

    return respostory;

}
```
���o�d�Ҧp�U�G      
```c#
//���oRespostory
IRespostory userRespostory = RespostoryFactory.Respostory("User");
((UserRespostory)userReRespostory).create(model);   //���X��A�૬�Y�i�ϥ�
```
***********
### Service [�^�ܳ���](#readme)
���M�׬O���Ц��M�׬[�c�����e�y�z    
���M�׬O���Ц��M�׬[�c�����e�y�z    
���M�׬O���Ц��M�׬[�c�����e�y�z    
���M�׬O���Ц��M�׬[�c�����e�y�z    
***********
### Web [�^�ܳ���](#readme)
���M�׬O���Ц��M�׬[�c�����e�y�z    
���M�׬O���Ц��M�׬[�c�����e�y�z    
���M�׬O���Ц��M�׬[�c�����e�y�z    
���M�׬O���Ц��M�׬[�c�����e�y�z    
���M�׬O���Ц��M�׬[�c�����e�y�z    
���M�׬O���Ц��M�׬[�c�����e�y�z    
***********
### Test [�^�ܳ���](#readme)
���M�׬O���Ц��M�׬[�c�����e�y�z    
���M�׬O���Ц��M�׬[�c�����e�y�z    
���M�׬O���Ц��M�׬[�c�����e�y�z    
���M�׬O���Ц��M�׬[�c�����e�y�z    
���M�׬O���Ц��M�׬[�c�����e�y�z    
���M�׬O���Ц��M�׬[�c�����e�y�z    
���M�׬O���Ц��M�׬[�c�����e�y�z    
***********
### ConsoleTest [�^�ܳ���](#readme)
���M�׬O���Ц��M�׬[�c�����e�y�z    
���M�׬O���Ц��M�׬[�c�����e�y�z    
���M�׬O���Ц��M�׬[�c�����e�y�z    
���M�׬O���Ц��M�׬[�c�����e�y�z    
���M�׬O���Ц��M�׬[�c�����e�y�z    
***********