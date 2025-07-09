using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge3
{
    class CricketTeam
    {
        public void Pointscalculation(int no_of_matches)
        {
            List<int> scores = new List<int>();
            int sum = 0;

            Console.WriteLine("Enter the scores for each match:");

            for (int i = 0; i < no_of_matches; i++)
            {
                Console.Write($"Match {i + 1} score: ");
                int score = int.Parse(Console.ReadLine());
                scores.Add(score);
                sum += score;
            }

            double average = (double)sum / no_of_matches;

            
            Console.WriteLine($"Total Matches Played: {no_of_matches}");
            Console.WriteLine($"Sum of Scores: {sum}");
            Console.WriteLine($"Average Score: {average}");
        }
    }

    class Question1
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of matches played: ");
            int no_of_matches = int.Parse(Console.ReadLine());

            CricketTeam team = new CricketTeam();
            team.Pointscalculation(no_of_matches);

            Console.ReadLine();
        }
    }
}



