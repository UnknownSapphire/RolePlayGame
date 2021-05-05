﻿namespace Character {
    public enum BottleSize {
        Small = 10,
        Medium = 25,
        Big = 50
    }
    
    public class LivingWaterBottle: Artifact {
        private BottleSize _bottleSize;

        public LivingWaterBottle(int power, BottleSize bottleSize) : base(power, false) {
            _bottleSize = bottleSize;
        }

        public override void SpellCast(object person1, object person2, int power) {
            if (!ReferenceEquals(person1, person2) || !(person1 is Wizard w) 
                || !(person2 is Wizard) && !(person2 is Character)) {
                return;
            }
            w.Health += (int) _bottleSize;
            // delete from inventory
        }

        public override void SpellCast(object person, int power) {}
    }
}