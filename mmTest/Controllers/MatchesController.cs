using mmTest.Code;
using mmTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace mmTest.Controllers
{
    public class MatchesController : ApiController
    {
        public ICollection<Match> Get()
        {
            var m1 = from a in SystemLoad.Played
                     select new Match
                     {
                         away_team = a.away_team,
                         home_team = a.home_team,
                         tournament = a.tournament,
                         start_time = a.start_time,
                         Status = a.Status
                     };

            var m2 = from a in SystemLoad.Upcoming
                     select new Match
                     {
                         away_team = a.away_team,
                         home_team = a.home_team,
                         tournament = a.tournament,
                         start_time = a.start_time,
                         Status = a.Status
                     };

            var lst = new List<Match>();
            lst.AddRange(m1);
            lst.AddRange(m2);

            return lst.OrderBy(x => x.home_team).OrderBy(y => y.away_team).ToList();
        }

        public ICollection<Match> Get(string id)
        {
            if (id == "played")
            {
                var m1 = from a in SystemLoad.Played
                         select new Match
                         {
                             away_team = a.away_team,
                             home_team = a.home_team,
                             tournament = a.tournament,
                             start_time = a.start_time,
                             Status = a.Status
                         };
                return m1.OrderBy(x => x.home_team).OrderBy(y => y.away_team).ToList();
            }

            if (id == "upcoming")
            {
                var m1 = from a in SystemLoad.Upcoming
                         select new Match
                         {
                             away_team = a.away_team,
                             home_team = a.home_team,
                             tournament = a.tournament,
                             start_time = a.start_time,
                             Status = a.Status
                         };
                return m1.OrderBy(x => x.home_team).OrderBy(y => y.away_team).ToList();
            }
            return null; 
        }
    }
}
