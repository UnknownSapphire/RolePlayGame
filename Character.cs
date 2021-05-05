using System;
using System.Collections.Generic;
using System.Linq;

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
        private int _health;
        private int _exp;
        private Dictionary<Artifact, int> _inventory;

        public int ID => _id;
        
        public int MaxHealth { get; }

        public string Name {
            get => _name;
            protected set {
                if (string.IsNullOrWhiteSpace(value)) {
                    throw new ArgumentException("The name of the character must not be empty");
                }
                _name = value.Trim();
            }
        }

        public State State {
            get => _state;
            protected internal set => _state = value;
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
        
        public Character(string name, Gender gender, Race race, int age, int maxHealth) {
            _id = _nextId++;
            Name = name;
            MaxHealth = maxHealth;
            _health = MaxHealth;
            _gender = gender;
            _race = race;
            Age = age;
            _inventory = new Dictionary<Artifact, int>();
        }

        public void PickArtifact(Artifact artifact, int amount = 1) {
            if (HaveArtifact(artifact, amount)) {
                _inventory.Add(artifact, amount);
            } else {
                _inventory[artifact] += amount;
            }
        }

        public void DropArtifact(Artifact artifact, int amount = 1) {
             if (HaveArtifact(artifact, amount)) {
                 _inventory[artifact] -= amount;
             }
        }

        public void GiveArtifact(Character chr, Artifact artifact, int amount = 1) {
            if (HaveArtifact(artifact, amount)) {
                _inventory[artifact] -= amount;
                chr.PickArtifact(artifact, amount);
            }
        }

        public void UseArtifact(Artifact artifact, Character target, int power) {
            if (HaveArtifact(artifact)) {
                --_inventory[artifact];
                artifact.SpellCast(this, target, power);
            }
        }

        public bool HaveArtifact(Artifact artifact, int amount = 1) {
            return _inventory.ContainsKey(artifact) && _inventory[artifact] - amount >= 0;
        }

        public int CompareTo(object obj) {
            if (!(obj is Character chr)) {
                throw new Exception("It's impossible to compare these objects");
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