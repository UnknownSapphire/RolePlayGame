namespace Character {
    public class FrogLegsDecoct: Artifact {
        FrogLegsDecoct(int power) : base(power, false) {}
        
        public override void SpellCast(object person1, object person2, int power = 0) {
            if (person1 is Character && person2 is Character chr && chr.State == State.Poisoned) {
                chr.State = chr.Health <= 0.2 * chr.MaxHealth ? State.Weakened : State.Normal;
            } 
        }

        public override void SpellCast(object person, int power) {
            SpellCast(person, person);
        }
    }
}