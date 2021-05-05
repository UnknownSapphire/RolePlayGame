using System;

namespace Character {
    internal class Program {
        public static void Main() {
            Wizard w = new Wizard("f", Gender.Female, Race.Elf, 20, 100);
            Character chr = new Character("f", Gender.Female, Race.Elf, 20, 20);
            WitherAway wa = new WitherAway(false, false);
            Console.WriteLine(w is Character);
        }
    }
}