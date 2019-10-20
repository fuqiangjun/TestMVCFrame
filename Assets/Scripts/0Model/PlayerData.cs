using UnityEngine;


namespace MainScene.Model
{
    public class PlayerData
    {
        #region  
        private static PlayerData instance;
        public static PlayerData Instance
        {
            get
            {
                if (instance != null)
                {
                    return instance;
                }
                else
                {
                    Debug.LogError("请先调用构造函数创建实例");
                    return null;
                }
            }
        }
        private PlayerType playerType;
        private string name;
        private int hP;
        private int mP;
        private int attack;
        private int defence;

        public PlayerType Player_Type
        {
            get
            {
                return playerType;
            }
            set
            {
                playerType = value;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                MessageCenter.Broadcast(GameEventType.NameChange, Name);
            }
        }
        public int HP
        {
            get
            {
                return hP;
            }
            set
            {
                hP = value;
                MessageCenter.Broadcast(GameEventType.HPChange, HP);
            }
        }
        public int MP
        {
            get
            {
                return mP;
            }
            set
            {
                mP = value;
                MessageCenter.Broadcast(GameEventType.MPChange, MP);
            }
        }
        public int Attack
        {
            get
            {
                return attack;
            }
            set
            {
                attack = value;
                MessageCenter.Broadcast(GameEventType.AttackChange, Attack);
            }
        }
        public int Defence
        {
            get
            {
                return defence;
            }
            set
            {
                defence = value;
                MessageCenter.Broadcast(GameEventType.DefenceChange, Defence);
            }
        }

        public PlayerData(PlayerType p, string n, int h, int m, int a, int d)
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Debug.LogError("PlayerInfo 已经创建了构造函数实例");
            }

            Player_Type = p;
            Name = n;
            HP = h;
            MP = m;
            Attack = a;
            Defence = d;
        }
        #endregion

        public void AddHP (int v)
        {
            HP += v; 
        }
        public void ReduceHP (int v)
        {
            HP -= v; 
            if (HP <0 ) { HP = 0;  }
        }
        public void AddMP(int v)
        {
            MP += v; 
        }
        public void ReduceMP(int v)
        {
            MP -= v;
            if (MP < 0) { MP = 0; }
        }
        public void AddAttack(int v)
        {

        }
        public void ReduceAttack(int v)
        {

        }
        public void AddDefence(int v)
        {

        }
        public void ReduceDefence(int v)
        {

        }

    }



    public class TempPlayer
    {
        public PlayerType playerType;
        public string name;
        public int hP;
        public int mP;
        public int attack;
        public int defence;

    }


    public enum PlayerType
    {
        None,
        Sword,
        Magic
    }
}