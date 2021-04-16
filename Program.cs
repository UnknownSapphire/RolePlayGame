using System;

namespace Character {
    internal class Program {
        public static void Main() {
            Character chr = new Character("Tom", Gender.Male, Race.Human, 24);
            Wizard w = new Wizard("Gaus", Gender.Male, Race.Elf, 30);
            Console.WriteLine(chr);
            Console.WriteLine(w);
        }
    }
}