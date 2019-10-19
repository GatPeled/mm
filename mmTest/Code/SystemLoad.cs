using mmTest.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace mmTest.Code
{
    public static class SystemLoad
    {
        public static List<UpcomingModel> Upcoming;
        public static List<PlayedModel> Played;
        static SystemLoad()
        {
            LoadUpComing();
            LoadPlayed();
        }

        public static void LoadUpComing()
        {
            Upcoming = new List<UpcomingModel>();
            string[] lines = System.IO.File.ReadAllLines(GetPath() + @"\Data\result_upcoming.csv");
            for (int i = 1; i < lines.Length; i++)
            {
                var ln = lines[i];
                var vals = ln.Split(',');
                var obj = new UpcomingModel
                {
                    home_team = vals[0],
                    away_team = vals[1],
                    tournament = vals[2],
                    start_time = vals[3],
                    kickoff = vals[4],
                    Status = MatchStatus.UpComing
                };
                Upcoming.Add(obj);
            }
        }

        public static void LoadPlayed()
        {
            Played = new List<PlayedModel>();
            string[] lines = System.IO.File.ReadAllLines(GetPath() + @"\Data\result_played.csv");
            for (int i = 1; i < lines.Length; i++)
            {
                var ln = lines[i];
                var vals = ln.Split(',');
                var obj = new PlayedModel
                {
                    home_team = vals[0],
                    home_score = vals[1],
                    away_team = vals[2],
                    away_score = vals[3],
                    tournament = vals[4],
                    start_time = vals[5],
                    Status = MatchStatus.Played
                };
                Played.Add(obj);
            }
        }

        //get the path of the Assembly - for loadin the csv files from bin folder
        public static string GetPath()
        {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            return Path.GetDirectoryName(path);
        }
    }   
}