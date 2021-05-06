using System;
using System.Threading;

namespace Character {
    public class LightningWand: Artifact {
        public const int MaxPower = 450;
        public const int PowerRegen = 10;
        private Thread _restorePowerThread;
        public LightningWand() : base(MaxPower, true) {
             _restorePowerThread = new Thread(() => {
                while(true) {
                    if (_power + PowerRegen <= MaxPower) {
                        _power += Math.Min(PowerRegen, MaxPower - Power);
                    }
                    Thread.Sleep(1000);
                }
             }) {IsBackground = true};
            _restorePowerThread.Start();
        }

        public override void SpellCast(object person1, object person2, int power = 0) {
            if (!ReferenceEquals(person1, person2) && person1 is Character 
                && person2 is Character chr && _power >= power) {
                chr.Health -= power;
                _power -= power;
            }
        }

        public override void SpellCast(object person, int power) {}
    }
}