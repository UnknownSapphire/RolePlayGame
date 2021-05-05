namespace Character {
    public class FrogLegsDecoct: Artifact {
        FrogLegsDecoct(int power) : base(power, false) {}
        
        public override void SpellCast(object person1, object person2, int power = 0) {
            if ((person2 is Character || person2 is Wizard)
            && (person1 is Character || person1 is Wizard)) {
                Character chr = (Character) person2;
                if (chr.State == State.Poisoned) {
                    chr.State = chr.Health <= 0.2 * chr.MaxHealth ? State.Weakened : State.Normal;
                }
            } 
        }

        public override void SpellCast(object person, int power = 0) {
            SpellCast(person, person);
        }
    }
}