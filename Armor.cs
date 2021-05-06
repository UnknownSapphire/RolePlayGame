using System.Threading;

namespace Character {
    public class Armor: Spell {
        private Thread _thread;
        private object locker = new object();
        
        public Armor(bool haveVerbalComponent, bool haveMotorComponent) :
                    base(50, haveVerbalComponent, haveMotorComponent) {}

        public override void SpellCast(object person1, object person2, int seconds = 0) {
            if (person1 is Wizard w && person2 is Character chr && chr.State != State.Dead
                && CanSpell(w, _minMana, _haveVerbalComponent, _haveMotorComponent)) {
                _thread = new Thread(() => {
                    int healthBefore = chr.Health;
                    while (seconds > 0) {
                        lock (locker) {
                            chr.Health = int.MaxValue;
                            w.Mana -= _minMana;
                            --seconds;
                        }
                        Thread.Sleep(1000);
                    }
                    chr.Health = healthBefore;
                    _thread.Abort();
                });
                _thread.Start();
            }
        }

        public override void SpellCast(object person, int seconds) {
            SpellCast(person, person, seconds);
        }
    }
}