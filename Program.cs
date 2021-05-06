using System;
using System.Threading;
namespace Character {
    internal class Program {
        static void History1() {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("                   History 1" + '\n');
            Console.ResetColor();
            Thread.Sleep(1000);

            Character darkKnight = new Character("dark knight", Gender.Male, Race.Human, 25, 220);
            Wizard joker = new Wizard("joker", Gender.Male, Race.Elf, 21, 150);
            Wizard oldHermit = new Wizard("old hermit", Gender.Male, Race.Goblin, 53, 130);

            LightningWand lightningWand = new LightningWand();
            AddHealth heal = new AddHealth(false, true);
            VasiliskEye vasiliskEye = new VasiliskEye(20);

            joker.PickArtifact(lightningWand);
            oldHermit.PickArtifact(vasiliskEye);
            oldHermit.LearnSpell(heal);
            Console.WriteLine($"Давным-давно в далекой стране мирно жили герои... Но все изменилось, когда {joker.Name}" +
                              $" решил захватить королевство. Он шел по дороге и увидел {darkKnight.Name}..." + '\n');
            Console.WriteLine($"Злой {joker.Name} собирается поразить рыцаря изумрудным посохом (введите силу заряда)");
            
            int hp = Convert.ToInt32(Console.ReadLine());
            while (hp <= 0) {
                Console.WriteLine("Сила должна быть больше 0! Введите еще раз.");
                hp = Convert.ToInt32(Console.ReadLine());
            }
            joker.UseArtifact(lightningWand, darkKnight, hp);

            Console.WriteLine($"И у {darkKnight.Name} осталось {darkKnight.Health} hp");
            Console.WriteLine($"Итак, {joker.Name} собирается зарядить свой посох...");

            Thread.Sleep(4000);
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            for (int i = 0; i < 5; i++) {
                Thread.Sleep(1000);
                Console.WriteLine($"Заряд посоха: {lightningWand.Power}");
                if (lightningWand.Power == LightningWand.MaxPower)
                {
                    Console.WriteLine("Посох заряжен!");
                    break;
                }
            }
            Console.ResetColor();
            Console.WriteLine($"... Но это заметил {oldHermit.Name} и парализовал {joker.Name} глазом василиска, который завалялся у него в кармане.");
            oldHermit.UseArtifact(vasiliskEye, joker, 20);
            Console.WriteLine($"А потом {oldHermit.Name} и {darkKnight.Name} связали {joker.Name} и оставили в лесу .........");
        }
        
        static void History2() {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("                   History 2" + '\n');
            Console.ResetColor();
            Thread.Sleep(3000);
            Character workerJohn = new Character("worker John", Gender.Male, Race.Orc, 33, 300);
            Character workerJimi = new Character("worker Jimi", Gender.Male, Race.Orc, 46, 310);
            Character hunter = new Character("hunter", Gender.Male, Race.Elf, 54, 280);
            Wizard evilWizard = new Wizard("evil wizard", Gender.Male, Race.Goblin, 29, 210);

            /* Действующие лица */

            PoisonousSaliva pSalivaL = new PoisonousSaliva();
            PoisonousSaliva pSalivaB = new PoisonousSaliva();
            LightningWand lightningWand = new LightningWand();
            FrogLegsDecoct frogLegs = new FrogLegsDecoct(20);
            VasiliskEye vasiliskEye = new VasiliskEye(20);

            evilWizard.PickArtifact(pSalivaL);

            Console.WriteLine($"Охотник за головами темных магов {hunter.Name} наконец выследил свою добычу {evilWizard.Name}, он готовился к этому дню на протяжении года," +
            " постепенно подбираясь к магу, он шел по следам его бесчинств, но сегодня он точно отомстит этому негодяю," +
            " не зря же он собрал такую огромную коллекцию артефактов." + '\n');

            Thread.Sleep(8000);

            workerJohn.PickArtifact(lightningWand);
            workerJimi.PickArtifact(lightningWand);
            workerJohn.PickArtifact(vasiliskEye);
            workerJimi.PickArtifact(vasiliskEye);
            workerJimi.PickArtifact(vasiliskEye);

            hunter.PickArtifact(pSalivaB);
            hunter.PickArtifact(frogLegs);
            hunter.PickArtifact(frogLegs);
            hunter.PickArtifact(vasiliskEye);

            Console.WriteLine($"Охотник отвлекся и не заметил, как {evilWizard.Name} подобрался к двум бедным работягам {workerJimi.Name} и {workerJohn.Name}," +
            $" отравил их ядовитой слюной, делал он это из жажды нажив," +
            $" т к знал, что у них хранится клад артефактов.");

            Thread.Sleep(7000);
            
            evilWizard.UseArtifact(pSalivaL, workerJimi, 10);
            evilWizard.UseArtifact(pSalivaL, workerJohn, 10);
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < 5; ++i) {
                Thread.Sleep(1000);
                Console.WriteLine($"Здоровье {workerJimi.Name} : {workerJimi.Health}");
                Thread.Sleep(1000);
                Console.WriteLine($"Здоровье {workerJohn.Name} : {workerJohn.Health}");
            }
            Console.ResetColor();

            Thread.Sleep(4000);

            Console.WriteLine($"Чувствуя вкус приближающейся победы, маг потерял бдительность, эта секунда и нужна была {hunter.Name}. Он парализовал и отравил злого мага и " +
            $"стал ждать когда подействует отрава и маг не умрет.");

            Thread.Sleep(4000);

            hunter.UseArtifact(vasiliskEye, evilWizard, 10);
            hunter.UseArtifact(pSalivaB, evilWizard, 200);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.ResetColor();
            Console.WriteLine($"Параллельно с ожиданием он стал лечить лягушачьими лапками работяг {workerJimi.Name} и {workerJohn.Name}.");
            hunter.UseArtifact(frogLegs, workerJohn, 10);
            hunter.UseArtifact(frogLegs, workerJimi, 20);
            Console.WriteLine($"В благодарность за спасение эти бедные существа поделились своим сокровищем с их спасителем и он снова отправился на поиски приключений");
        }

          static void History3()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("                   History 4" + '\n');
            Thread.Sleep(2000);
            Console.ResetColor();
            Wizard lightWizard = new Wizard("Gendelf", Gender.Male, Race.Human, 45, 180);
            Character mamElf = new Character("mam elf", Gender.Female, Race.Elf, 43, 150);
            Character dadElf = new Character("dad elf", Gender.Male, Race.Elf, 50, 200);
            Character sunElf = new Character("sun elf", Gender.Male, Race.Elf, 15, 100);
            Character daughterElf = new Character("daughter elf", Gender.Female, Race.Elf, 11, 100);
            Character goblin = new Character("goblin", Gender.Male, Race.Goblin, 38, 200);

            WitherAway wAway = new WitherAway(true, true);
            Cure cure = new Cure(false, true);
            Armor armor = new Armor(true, false);
            LightningWand lightningWand = new LightningWand();

            lightWizard.LearnSpell(wAway);
            lightWizard.LearnSpell(cure);
            lightWizard.LearnSpell(armor);
            dadElf.PickArtifact(lightningWand);
            goblin.PickArtifact(lightningWand);

            Console.WriteLine("Всю историю существования Королевство эльфов процветало, т к эта раса была более эгоистичной, чем остальные и редко приходила на помощь во время воин" + '\n');
            Thread.Sleep(5000);
            Console.WriteLine("Народы, которые не получали поддержки эльфов проклинали их" + '\n');
            Thread.Sleep(3000);
            Console.WriteLine("И в один ужасный для эльфов день это сильнейшее проклятие вступило в силу, началась эпидемия, болезнь поражала лишь детей" + '\n');
            Thread.Sleep(3000);
            Console.WriteLine("И тогда отцы и матери взмолились о помощи, ведь это невыносимо смотреть на смерть собственных детей" + '\n');
            Thread.Sleep(3000);
            Console.WriteLine("На помощь эльфийскому народу пришли светлые маги. Они тратили свою ману до последней капли, дабы излечить детей" + '\n');
            Thread.Sleep(3000);
            Console.WriteLine($"Одного из них звали {lightWizard.Name}. В тот день в очередной раз светлый маг спешил на помощь к эльфийской семье, сын" +
                $" которых был парализован, а дочь - тяжело больна" + '\n');
            Thread.Sleep(3000);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.ResetColor();
            Thread.Sleep(5000);

            Console.WriteLine($"{lightWizard.Name} исполнил свой долг и собирался уже уходить, как вдруг на семью напал напал злой и голодный гоблин " + '\n');
            Thread.Sleep(3000);
            Console.WriteLine($"В схватку с ним вступил глава семейства - {dadElf.Name} " + '\n');
            Thread.Sleep(3000);
            Console.WriteLine($"{lightWizard.Name} понимал, что эльф не востоит против гоблина и воспользовался заклинанием защиты" + '\n');
            Thread.Sleep(3000);
            lightWizard.UseSpell(dadElf, armor, 10);

            while(goblin.Health != 0) {
                Console.ForegroundColor = ConsoleColor.Green;
                Thread.Sleep(1000);
                Console.WriteLine($"Здоровье {dadElf.Name} : {dadElf.Health}");
                Console.ForegroundColor = ConsoleColor.Red;
                Thread.Sleep(1000);
                lightningWand.SpellCast(dadElf, goblin, 50);
                lightningWand.SpellCast(goblin, dadElf, 20);
                if (goblin.State == State.Dead) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{goblin.Name} умер");
                    break;
                }
                Console.WriteLine($"Здоровье {goblin.Name} : {goblin.Health}");
            }
            Console.ResetColor();
            Console.WriteLine($"После этой схватки они зажарили гоблина и в благодарность семья эльфов поделилась частью добычи с {lightWizard.Name}" + '\n');
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("                    The END!!!              ");
            Console.ResetColor();
        }
        
        public static void Main() {
            History1();
            Thread.Sleep(3000);
            History2();
            Thread.Sleep(3000);
            History3();
            Thread.Sleep(1000);
        }
    }
}