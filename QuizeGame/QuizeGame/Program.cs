namespace QuizeGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StartGame Game = new();
            Game.stGame();
        }
    }


    public class Question
    {
        public string Q { get; set; }
        public string Answer { get; set; }

        public Question(string q,string ans)
        {
            Q = q;
            Answer = ans;
        }

    }

    public class Game {

        public List<Question> Questions = new();
        
        public void MakeQustion()
        {
            var q1 = new Question("1-What Is The Red Plant", "mars");
            Questions.Add(q1);

            var q2 = new Question("2-What Is The Bigest Animal", "whale");
            Questions.Add(q2);

            var q3 = new Question("1-What Is The Capital Of Italy", "roma");
            Questions.Add(q3);

        }

        public void ShowQustion()
        {
            foreach (var q in Questions)
            {
                Console.WriteLine(q.Q); 
            }
        }

        public int TakeAnswer()
        {
            int TrueAns = 0;
            for(int i = 0; i < Questions.Count; i++)
            {
                Console.WriteLine($"Q({i+1})Answer:");
                string ans = Console.ReadLine();
                if (Questions[i].Answer.ToLower() == ans.ToLower())
                {
                    Console.WriteLine("Correct Answer");
                    TrueAns++;
                }
                else
                {
                    Console.WriteLine("Wrong Answer");
                }
            }
            return TrueAns;
        }

        public void FinalResult()
        {
            int correct = TakeAnswer();
            if (correct > (Questions.Count / 2))
            {
                Console.WriteLine("Congratulaton..");
            }
            else
            {
                Console.WriteLine("Not Passed");
            }
            Console.WriteLine($"You Answerd {correct}/{Questions.Count}");
            Console.WriteLine("Press To Back...");
            Console.ReadKey();
        }

        public void ShowCorrectAnswer()
        {
            foreach (var ans in Questions)
            {
                Console.WriteLine($"Q :{ans.Q} Answer :{ans.Answer}");

            }
            Console.WriteLine("press..");
            Console.ReadKey();
        }
    
    
    }

    public class StartGame
    {
        public Game game = new();
        public void stGame()
        {
            Console.WriteLine("Welcome Quiz Game");

            game.MakeQustion();
            game.ShowQustion();
            game.FinalResult();
            game.ShowCorrectAnswer();
        }
    }

}
