using System.Threading;

namespace Character {
    public class Armor: Spell {
        private Thread _thread;

        class Data {
            public Wizard _w;
            public Character _chr;
            public int _seconds;

            public Data(Wizard w, Character chr, int seconds) {
                _w = w;
                _chr = chr;
                _seconds = seconds;
            }
        }
        
        public Armor(bool haveVerbalComponent, bool haveMotorComponent) :
                    base(50, haveVerbalComponent, haveMotorComponent) {}

        public override void SpellCast(ref Wizard w, ref Character chr, int seconds = 0) {
            if (CanSpell(ref w, _minMana, _haveVerbalComponent, _haveMotorComponent) && chr.State != State.Dead) {
                _thread = new Thread(GiveArmor);
                _thread.Start(new Data(w, chr, seconds));
            }
        } 
        
        private void GiveArmor(object obj) {
            Data data = obj as Data;
            int healthBefore = data._chr.Health;
            while (data._seconds > 0) {
                data._chr.Health = int.MaxValue;
                data._w.Mana -= _minMana;
                --data._seconds;
                Thread.Sleep(1000);
            }
            data._chr.Health = healthBefore;
            _thread.Abort();            
        } 
    }
}