using System;

namespace Character {
    public enum State {
        Normal,
        Weakened,
        Sick,
        Poisoned,
        Paralyzed,
        Dead
    }

    public enum Race {
        Human,
        Gnome,
        Elf,
        Orc,
        Goblin
    }

    public enum Gender {
        Male,
        Female
    }
    
    public class Character: IComparable, ICloneable {
        public const int MaxHealth = 100;
        public const int MaxExp = int.MaxValue;
        protected static int _nextId;
        protected int _id;
        
        private string _name;
        private State _state = State.Normal;
        private bool _canTalk = true;
        private bool _canMove = true;
        private Race _race;
        private Gender _gender;
        private int _age;
        private int _health = MaxHealth;
        private int _exp;

        public int ID => _id;

        public string Name {
            get => _name;
            protected set {
                string name = value.Trim();
                if (string.IsNullOrEmpty(name)) {
                    throw new ArgumentException("The name of the character must not be empty");
                }
                _name = name;
            }
        }

        public State State {
            get => _state;
            protected set => _state = value;
        }

        public bool CanTalk {
            get => _canTalk;
            protected set => _canTalk = value;
        }

        public bool CanMove {
            get => _canMove;
            protected set => _canMove = value;
        }
        public Race Race => _race;

        public Gender Gender => _gender;

        public int Age {
            get => _age;
            protected set {
                if (value <= 0 || value > 200) {
                    throw new ArgumentException("Invalid value for age of the character");
                }
                _age = value;
            }
        }
        public  int Health {
            get => _health;
            protected internal set {
                _health = Math.Max(0, Math.Min(value, MaxHealth));

                if (Health == 0) {
                    State = State.Dead;
                    CanTalk = false;
                    CanMove = false;
                }
                else if (State == State.Normal && Health * 100 / MaxHealth < 10) {
                    State = State.Weakened;
                }
                else if (State == State.Weakened && Health * 100 / MaxHealth >= 10) {
                    State = State.Normal;
                }
            }
        }

        public int Exp {
            get => _exp;
            protected set => _exp = Math.Min(value, MaxExp);
        }
        
        public Character(string name, Gender gender, Race race, int age) {
            _id = _nextId++;
            Name = name;
            _gender = gender;
            _race = race;
            Age = age;
        }

        public int CompareTo(object obj) {
            Character chr = (Character) obj;
            if (chr == null) {
                throw new Exception("It's impossible to compare those objects");
            }
            return Exp.CompareTo(chr.Exp);
        }

        public virtual object Clone() {
            Character chr = this;
            chr._id = _nextId++;
            return chr;
        }

        public override string ToString() {
            return $"ID: {ID}, Name: {Name}, Health: {Health}, Exp: {Exp}, Gender: {Gender}, Race: {Race}," +
                   $" Age: {Age}, State: {State}, Can talk: {CanTalk}, Can move: {CanMove}";
        }
    }
}