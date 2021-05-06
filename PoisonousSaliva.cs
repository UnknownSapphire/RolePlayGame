using System;
using System.Threading;

namespace Character {
    public class PoisonousSaliva : Artifact {
        public const int MaxPower = 450;
        public const int PowerRegen = 10;
        public const int MaxPoisoningTime = 15;
        private object locker = new object();
        private Thread _poisonThread;

        public PoisonousSaliva() : base(MaxPower, true) {
            Thread restorePowerThread = new Thread(() => {
                while(true) {
                    if (_power + PowerRegen <= MaxPower) {
                        _power += PowerRegen;
                    }
                    Thread.Sleep(1000);
                }
            }) {IsBackground = true};
            restorePowerThread.Start();
        }

        public override void SpellCast(object person1, object person2, int power = 0) {
            if (!ReferenceEquals(person1, person2) && person1 is Character && person2 is Character chr
                 && (chr.State == State.Normal || chr.State == State.Weakened)) {
                chr.State = State.Poisoned;
                _poisonThread = new Thread(() => {
                    int seconds = Math.Min(power, MaxPoisoningTime);
                    int dps = Math.Max(power / MaxPoisoningTime, 1);
                    int remainingDmg = Math.Max(power % MaxPoisoningTime, 1);
                    while (seconds > 0) {
                        lock (locker) {
                            chr.Health -= seconds == 1 ? remainingDmg : dps;
                            _power -= seconds == 1 ? remainingDmg : dps;
                            --seconds;
                        }
                        Thread.Sleep(1000);
                    }
                    _poisonThread.Abort();
                });
                _poisonThread.Start();
            }
        }

        public override void SpellCast(object person, int power) {}
    }
}